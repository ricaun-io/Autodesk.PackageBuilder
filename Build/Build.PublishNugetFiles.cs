using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
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
          NugetApiUrl: "https://api.nuget.org/v3/index.json"
          NugetApiKey: ${{ secrets.NUGET_API_KEY }} 
    */
    /*
        env:
          NugetApiUrl: "https://nuget.pkg.github.com/${{github.repository_owner}}/index.json"
          NugetApiKey: ${{ secrets.GITHUB_TOKEN }}
    */

    /// <summary>
    /// NugetApiUrl
    /// </summary>
    private string NugetApiUrl => EnvironmentInfo.GetVariable<string>("NugetApiUrl");
    /// <summary>
    /// NugetApiKey
    /// </summary>
    private string NugetApiKey => EnvironmentInfo.GetVariable<string>("NugetApiKey");

    /// <summary>
    /// GitRepository
    /// </summary>
    [GitRepository] readonly GitRepository GitRepositoryNuget;

    Target PublishNugetFiles => _ => _
        .TriggeredBy(Compile)
        .OnlyWhenStatic(() => NugetApiUrl.SkipEmpty())
        .OnlyWhenStatic(() => NugetApiKey.SkipEmpty())
        .OnlyWhenStatic(() => GitRepositoryNuget.IsOnMasterBranch())
        .OnlyWhenStatic(() => IsServerBuild)
        .Executes(() =>
        {
            var project = Solution.GetMainProject();
            var projectFolder = project.Directory / "bin";

            GlobFiles(projectFolder, "**/*.nupkg")
               .NotEmpty()
               .ForEach(x =>
               {
                   DotNetNuGetPush(s => s
                        .SetTargetPath(x)
                        .SetSource(NugetApiUrl)
                        .SetApiKey(NugetApiKey)
                        .EnableSkipDuplicate()
                   );
               });
        });
}