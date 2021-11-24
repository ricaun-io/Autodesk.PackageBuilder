using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.SignTool;
using Nuke.Common.Utilities.Collections;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

partial class Build
{
    /*
        env:
          SignFile: ${{ secrets.SIGN_FILE }}
          SignPassword: ${{ secrets.SIGN_PASSWORD }}
    */

    // https://ricaun.com/downloads/sign/RICAUN.pfx

    const string timestampServer = "http://timestamp.digicert.com/";
    private string SignFile => EnvironmentInfo.GetVariable<string>("SIGN_FILE");
    private string SignPassword => EnvironmentInfo.GetVariable<string>("SIGN_PASSWORD");

    Target Sign => _ => _
            .TriggeredBy(Compile)
            .OnlyWhenStatic(() => SignFile.SkipEmpty())
            .OnlyWhenStatic(() => SignPassword.SkipEmpty())
            .Executes(() =>
            {
                var project = Solution.GetMainProject();
                var projectFolder = project.Directory / "bin";

                var certPath = VerifySignFile(SignFile);
                var certPassword = SignPassword;

                var files = GlobFiles(projectFolder, "**/*.dll");
                files.ForEach(file => SignBinary(certPath, certPassword, file));

                var nupkgs = GlobFiles(projectFolder, "**/*.nupkg");
                nupkgs.ForEach(file => SignNuGet(certPath, certPassword, file));
            });

    #region Sign Util

    /// <summary>
    /// VerifySignFile
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    string VerifySignFile(string path)
    {
        if (File.Exists(path))
            return path;

        var file = BuildAssemblyDirectory / "signfile.pfx";
        using (var client = new System.Net.WebClient())
        {
            client.DownloadFile(path, file);
        }
        return file;
    }

    /// <summary>
    /// https://github.com/DataDog/dd-trace-dotnet/blob/master/tracer/build/_build/Build.Gitlab.cs
    /// </summary>
    /// <param name="certPath"></param>
    /// <param name="certPassword"></param>
    /// <param name="binaryPath"></param>
    void SignBinary(string certPath, string certPassword, string binaryPath)
    {
        if (HasSignature(binaryPath)) return;

        Logger.Normal($"Signing: {binaryPath}");

        try
        {
            SignToolTasks.SignTool(x => x
                .SetFiles(binaryPath)
                .SetFile(certPath)
                .SetPassword(certPassword)
                .SetTimestampServerUrl(timestampServer)
            );
        }
        catch (Exception)
        {
            Logger.Error($"Failed to sign file '{binaryPath}");
        }

    }

    /// <summary>
    /// Sign Nuget
    /// </summary>
    /// <param name="certPath"></param>
    /// <param name="certPassword"></param>
    /// <param name="binaryPath"></param>
    void SignNuGet(string certPath, string certPassword, string binaryPath)
    {
        if (HasSignature(binaryPath)) return;

        Logger.Normal($"Signing: {binaryPath}");

        try
        {
            NuGetTasks.NuGet(
                $"sign \"{binaryPath}\"" +
                $" -CertificatePath {certPath}" +
                $" -CertificatePassword {certPassword}" +
                $" -Timestamper {timestampServer} -NonInteractive",
                logOutput: false,
                logInvocation: false,
                logTimestamp: false
                ); // don't print to std out/err
        }
        catch (Exception)
        {
            // Exception doesn't say anything useful generally and don't want to expose it if it does
            // so don't log it
            Logger.Error($"Failed to sign nuget package '{binaryPath}");
        }
    }

    /// <summary>
    /// Has Signature
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    bool HasSignature(string fileInfo)
    {
        if (fileInfo.EndsWith(".nupkg"))
        {
            try
            {
                NuGetTasks.NuGet(
                    $"verify -Signatures \"{fileInfo}\"",
                    logOutput: false,
                    logInvocation: false,
                    logTimestamp: false
                    ); // don't print to std out/err
                return true;
            }
            catch
            {
                return false;
            }
        }

        try
        {
            System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(fileInfo);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}
