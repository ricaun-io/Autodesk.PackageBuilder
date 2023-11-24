using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests
{
    public class BuilderUtils_Tests
    {
        public class Builder : IBuilder
        {
            public string Path { get; set; }
            public bool Config { get; set; }
            public string Build(string path)
            {
                Path = path;
                return Path;
            }
        }

        [Test]
        public void Build_ShouldBe_NotNull()
        {
            var builder = BuilderUtils.Build<Builder>();
            Assert.IsNotNull(builder);
        }

        [Test]
        public void Build_ShouldBe_NotNull_Config()
        {
            var builder = BuilderUtils.Build<Builder>((build) => { build.Config = true; });
            Assert.IsTrue(builder.Config);
        }

        [TestCase("path")]
        [TestCase("path2")]
        [TestCase("path3")]
        public void Build_ShouldBe_Path(string path)
        {
            var builder = BuilderUtils.Build<Builder>(path);
            Assert.AreEqual(builder.Path, path);
        }

        [TestCase("path")]
        [TestCase("path2")]
        [TestCase("path3")]
        public void Build_ShouldBe_Path_Config(string path)
        {
            var builder = BuilderUtils.Build<Builder>((build) => { build.Config = true; }, path);
            Assert.IsTrue(builder.Config);
            Assert.AreEqual(builder.Path, path);
        }
    }
}