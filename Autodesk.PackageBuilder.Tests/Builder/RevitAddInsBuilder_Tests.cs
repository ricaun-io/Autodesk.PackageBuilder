using NUnit.Framework;
using System.IO;

namespace Autodesk.PackageBuilder.Tests.Builder
{
    public class RevitAddInsBuilder_Tests : BuilderBaseTests<RevitAddInsBuilder>
    {
        public override string FileName => "RevitAddin.addin";

        [Test]
        public void Build_Should_CreateFile_WithoutExtension()
        {
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            builder.Build(Path.GetFileNameWithoutExtension(FileName));
            Assert.IsTrue(File.Exists(FileName));
        }
    }
}