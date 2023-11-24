using NUnit.Framework;
using System.IO;

namespace Autodesk.PackageBuilder.Tests.Builder
{
    public class PackageContentsBuilder_Tests : BuilderBaseTests<PackageContentsBuilder>
    {
        public override string FileName => "PackageContents.xml";

        [Test]
        public void Build_Should_CreateFile_WithoutName()
        {
            var builder = BuilderUtils.Build<PackageContentsBuilder>();
            builder.Build(string.Empty);
            Assert.IsTrue(File.Exists(FileName));
        }
    }
}