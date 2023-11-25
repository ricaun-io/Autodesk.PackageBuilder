using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    public class RevitUtils_Tests
    {
        PackageContentsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<PackageContentsBuilder>();
        }

        [Test]
        public void Build_RevitApplication()
        {
            builder.ApplicationPackage.Create()
                .RevitApplication();

            builder.AssertAttribute("AutodeskProduct", AutodeskProducts.Revit);
            builder.AssertAttribute("ProductType", ProductTypes.Application);
        }

        [TestCase(2021)]
        [TestCase(2022)]
        [TestCase(2023)]
        [TestCase(2024)]
        public void Build_RevitPlatform(int revitVersion)
        {
            var description = "RevitPlatform";
            builder.Components
                .CreateEntry(description)
                .RevitPlatform(revitVersion);

            builder.AssertAttribute("Description", description);
            builder.AssertAttribute("OS", "Win64");
            builder.AssertAttribute("Platform", "Revit");
            builder.AssertAttribute("SeriesMin", "R" + revitVersion);
            builder.AssertAttribute("SeriesMax", "R" + revitVersion);
        }
    }
}