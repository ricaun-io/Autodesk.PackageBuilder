using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;
using ricaun.Nuke;
using ricaun.Nuke.Components;

[CheckBuildProjectConfigurations]
partial class Build : NukeBuild, IPublishPack
{
    string IHazContent.Folder => "Release";
    string IHazRelease.Folder => "ReleasePack";
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}

partial class Build2 : NukeBuild
{
    /*
   public static int Main() => Execute<Build>(x => x.Compile);
    */
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
