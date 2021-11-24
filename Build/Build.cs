using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;

[CheckBuildProjectConfigurations]
partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    [Solution] readonly Solution Solution;

    Target Clean => _ => _
        .Executes(() =>
        {
            Solution.ClearSolution(BuildProjectDirectory);
        });

    Target Compile => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            Solution.BuildMainProject();
        });
}