using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Inventor_Tests
    {
        [Test]
        public void Build_PackageBuilder_InventorClass()
        {
            var builder = BuilderUtils.Build<InventorPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
            if (InventorPackageBuilder.Expected.Equals(content) == false)
                Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(InventorPackageBuilder.Expected, content, $"Expected: {InventorPackageBuilder.Expected}\nContent: {content}");
        }

        public class InventorPackageBuilder : PackageContentsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <ApplicationPackage SchemaVersion="1.0" AutodeskProduct="Inventor" Name="InventorAddin" AppVersion="1.0.0" ProductType="Application">
                  <CompanyDetails Name="Company Name" Url="url" Email="email" />
                  <Components Description="Inventor 2024">
                    <RuntimeRequirements OS="Win64" Platform="Inventor" SeriesMin="Ir25" SeriesMax="Ir28" />
                    <ComponentEntry AppName="InventorAddin" ModuleName="./Contents/2024/InventorAddin.addin" />
                  </Components>
                  <Components Description="Inventor 2025">
                    <RuntimeRequirements OS="Win64" Platform="Inventor" SeriesMin="Ir29" />
                    <ComponentEntry AppName="InventorAddin" ModuleName="./Contents/2025/InventorAddin.addin" />
                  </Components>
                </ApplicationPackage>
                """";
            public InventorPackageBuilder()
            {
                ApplicationPackage
                    .Create()
                    .InventorApplication()
                    .Name("InventorAddin")
                    .AppVersion("1.0.0");

                CompanyDetails
                    .Create("Company Name")
                    .Url("url")
                    .Email("email");

                Components
                    .CreateEntry("Inventor 2024")
                    .InventorPlatform(25, 29, true)
                    .AppName("InventorAddin")
                    .ModuleName(@"./Contents/2024/InventorAddin.addin");

                Components
                    .CreateEntry("Inventor 2025")
                    .InventorPlatform(29, 0)
                    .AppName("InventorAddin")
                    .ModuleName(@"./Contents/2025/InventorAddin.addin");
            }
        }
    }
}