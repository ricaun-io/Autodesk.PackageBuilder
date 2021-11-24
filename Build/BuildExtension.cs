using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

public static class BuildExtension
{
    #region Solution

    /// <summary>
    /// Get all Configuration With no Debug
    /// </summary>
    /// <param name="Solution"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetReleases(this Solution Solution)
    {
        return Solution.GetConfigurations("Debug", true);
    }

    /// <summary>
    /// Get Configurations
    /// </summary>
    /// <param name="Solution"></param>
    /// <param name="contain"></param>
    /// <param name="notContain"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetConfigurations(this Solution Solution, string contain, bool notContain = false)
    {
        var configurations = Solution.GetConfigurations()
            .Where(s => s.Contains(contain, StringComparison.OrdinalIgnoreCase) != notContain);
        return configurations;
    }

    /// <summary>
    /// Get Configurations
    /// </summary>
    /// <param name="Solution"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetConfigurations(this Solution Solution)
    {
        var configurations = Solution.Configurations
                .Select(pair => pair.Value.Split("|").First())
                .Distinct();
        return configurations;
    }
    #endregion

    #region BuildMainProject

    /// <summary>
    /// Build the Main project
    /// </summary>
    /// <param name="Solution"></param>
    public static void BuildMainProject(this Solution Solution)
    {
        if (Solution.GetMainProject() is Project project)
        {
            foreach (var configuration in project.GetReleases())
            {
                project.Build(configuration);
            }
        }
    }

    /// <summary>
    /// Delete All bin / obj folder
    /// </summary>
    /// <param name="Solution"></param>
    /// <param name="BuildProjectDirectory"></param>
    public static void ClearSolution(this Solution Solution, AbsolutePath BuildProjectDirectory)
    {
        GlobDirectories(Solution.Directory, "**/bin", "**/obj")
            .Where(x => !IsDescendantPath(BuildProjectDirectory, x))
            .ForEach(FileSystemTasks.DeleteDirectory);
    }

    /// <summary>
    /// Get Main Project
    /// </summary>
    /// <param name="Solution"></param>
    /// <returns></returns>
    public static Project GetMainProject(this Solution Solution)
    {
        return Solution.GetProjects("*")
            .FirstOrDefault(p => p.Name.Equals(Solution.Name, StringComparison.OrdinalIgnoreCase));
    }

    #endregion

    #region Project
    /// <summary>
    /// Get Project Configurations with no Debug
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetReleases(this Project project)
    {
        return project.GetConfigurations("Debug", true);
    }

    /// <summary>
    /// Get Project Configurations
    /// </summary>
    /// <param name="project"></param>
    /// <param name="contain"></param>
    /// <param name="notContain"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetConfigurations(this Project project, string contain, bool notContain = false)
    {
        var configurations = project.GetConfigurations()
            .Where(s => s.Contains(contain, StringComparison.OrdinalIgnoreCase) != notContain);
        return configurations;
    }

    /// <summary>
    /// Get Project Configurations
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetConfigurations(this Project project)
    {
        var configurations = project.Configurations
                .Select(pair => pair.Value.Split("|").First())
                .Distinct();
        return configurations;
    }

    /// <summary>
    /// Build Project
    /// </summary>
    /// <param name="project"></param>
    /// <param name="configuration"></param>
    public static void Build(this Project project, string configuration)
    {
        MSBuild(s => s
            .SetTargets("Rebuild")
            .SetTargetPath(project)
            .SetConfiguration(configuration)
            .SetVerbosity(MSBuildVerbosity.Minimal)
            .SetMaxCpuCount(Environment.ProcessorCount)
            .DisableNodeReuse()
            .EnableRestore()
            );
    }
    #endregion

    #region String
    /// <summary>
    /// Return false if <paramref name="str"/> empty or null
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool SkipEmpty(this string str)
    {
        if (str == null) return false;
        if (str.Trim() == string.Empty) return false;
        return true;
    }

    #endregion

    #region Version Dll

    public static IEnumerable<CustomAttributeData> GetAttributes(this Project project)
    {
        var file = project.GetFileGreaterVersion();
        var assembly = Assembly.Load(File.ReadAllBytes(file));
        return assembly.CustomAttributes;
        //DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints
    }




    /// <summary>
    /// Get Project Version by dll
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    public static Version GetVersion(this Project project)
    {
        return project.GetAssemblyGreaterVersion().GetName().Version;
    }

    public static Assembly GetAssemblyGreaterVersion(this Project project)
    {
        return GetAssemblyGreaterVersion(project.Directory, $"*{project.Name}.dll");
    }
    private static Assembly GetAssemblyGreaterVersion(string sourceDir, string searchPattern = "*.dll")
    {
        Assembly assembly = null;
        Version version = new Version();
        var dllFiles = Directory.GetFiles(sourceDir, searchPattern, SearchOption.AllDirectories);
        foreach (var dll in dllFiles)
        {
            var assemblyTest = Assembly.Load(File.ReadAllBytes(dll));
            var fileVersion = assemblyTest.GetName().Version;
            if (version < fileVersion)
            {
                version = fileVersion;
                assembly = assemblyTest;
            }
        }
        return assembly;
    }

    /// <summary>
    /// Get File dll Greater Version
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    private static string GetFileGreaterVersion(this Project project)
    {
        return GetFileVersion(project.Directory, $"*{project.Name}.dll");
    }

    /// <summary>
    /// Get greater Version of the <paramref name="searchPattern"/> files
    /// </summary>
    /// <param name="sourceDir"></param>
    /// <param name="searchPattern"></param>
    /// <returns></returns>
    private static string GetFileVersion(string sourceDir, string searchPattern = "*.dll")
    {
        string path = null;
        Version version = new Version();
        var dllFiles = Directory.GetFiles(sourceDir, searchPattern, SearchOption.AllDirectories);
        foreach (var dll in dllFiles)
        {
            if (FileVersionInfo.GetVersionInfo(dll).ProductVersion is string productVersion)
            {
                var fileVersion = Version.Parse(productVersion);
                if (version < fileVersion)
                {
                    version = fileVersion;
                    path = dll;
                }
            }
        }
        return path;
    }
    #endregion

    #region Assembly

    /// <summary>
    /// Get Title
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetTitle(this Assembly assembly) => assembly.GetValue<AssemblyTitleAttribute>();

    /// <summary>
    /// Get Description
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetDescription(this Assembly assembly) => assembly.GetValue<AssemblyDescriptionAttribute>();

    /// <summary>
    /// Get Company
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetCompany(this Assembly assembly) => assembly.GetValue<AssemblyCompanyAttribute>();

    /// <summary>
    /// Get Product
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetProduct(this Assembly assembly) => assembly.GetValue<AssemblyProductAttribute>();

    /// <summary>
    /// Get Copyright
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetCopyright(this Assembly assembly) => assembly.GetValue<AssemblyCopyrightAttribute>();

    /// <summary>
    /// Get Trademark
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetTrademark(this Assembly assembly) => assembly.GetValue<AssemblyTrademarkAttribute>();

    /// <summary>
    /// Get Configuration
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetConfiguration(this Assembly assembly) => assembly.GetValue<AssemblyConfigurationAttribute>();

    /// <summary>
    /// GetValue of CustomAttributeType 
    /// </summary>
    /// <typeparam name="TCustomAttributeType"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetValue<TCustomAttributeType>(this Assembly assembly)
    {
        var attribute = assembly.CustomAttributes.Where(y => y.AttributeType == typeof(TCustomAttributeType)).FirstOrDefault();
        if (attribute == null) return "";
        return attribute.ConstructorArguments[0].Value.ToString();
    }
    #endregion
}