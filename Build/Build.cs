using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

partial class Build : NukeBuild, IPublishPack, IPrePack, ICompileExample, ITest
{
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}