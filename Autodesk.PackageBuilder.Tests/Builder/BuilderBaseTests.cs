using NUnit.Framework;
using System.IO;

namespace Autodesk.PackageBuilder.Tests.Builder
{
    public abstract class BuilderBaseTests<T> where T : IBuilder, new()
    {
        public abstract string FileName { get; }
        [SetUp]
        [TearDown]
        public void DeleteFileName()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        [Test]
        public void Build_Should_NotNull()
        {
            var builder = BuilderUtils.Build<T>();
            Assert.IsNotNull(builder);
        }

        [Test]
        public void Build_Should_CreateFile()
        {
            var builder = BuilderUtils.Build<T>();
            builder.Build(FileName);
            Assert.IsTrue(File.Exists(FileName));
        }

        [Test]
        public void Build_Should_CreateFile_WithPath()
        {
            BuilderUtils.Build<T>(FileName);
            Assert.IsTrue(File.Exists(FileName));
        }

        [Test]
        public void Build_Should_CreateFile_WithConfig()
        {
            var builder = BuilderUtils.Build<T>((build) => { });
            builder.Build(FileName);
            Assert.IsTrue(File.Exists(FileName));
        }

        [Test]
        public void Build_Should_CreateFile_WithConfigAndPath()
        {
            BuilderUtils.Build<T>((build) => { }, FileName);
            Assert.IsTrue(File.Exists(FileName));
        }
    }
}