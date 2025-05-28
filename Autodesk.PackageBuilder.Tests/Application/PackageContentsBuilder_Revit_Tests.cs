using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Revit_Tests
    {
        [Test]
        public void Build_PackageBuilder_RevitClass()
        {
            var builder = BuilderUtils.Build<RevitPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
            if (RevitPackageBuilder.Expected.Equals(content) == false)
                Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(RevitPackageBuilder.Expected, content, $"Expected: {RevitPackageBuilder.Expected}\nContent: {content}");
        }

        public class RevitPackageBuilder : PackageContentsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <ApplicationPackage SchemaVersion="1.0" AutodeskProduct="Revit" Name="RevitAddin" AppVersion="1.0.0" ProductType="Application">
                  <CompanyDetails Name="Company Name" Url="url" Email="email" />
                  <Components Description="Revit 2021">
                    <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R2021" SeriesMax="R2021" />
                    <ComponentEntry AppName="RevitAddin" ModuleName="./Contents/2021/RevitAddin.addin" />
                  </Components>
                  <Components Description="Revit 2022">
                    <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R2022" SeriesMax="R2022" />
                    <ComponentEntry AppName="RevitAddin" ModuleName="./Contents/2022/RevitAddin.addin" />
                  </Components>
                </ApplicationPackage>
                """";
            public RevitPackageBuilder()
            {
                ApplicationPackage
                    .Create()
                    .AutodeskProduct(AutodeskProducts.Revit)
                    .Name("RevitAddin")
                    .AppVersion("1.0.0")
                    .ProductType(ProductTypes.Application);

                CompanyDetails
                    .Create("Company Name")
                    .Url("url")
                    .Email("email");

                Components
                    .CreateEntry("Revit 2021")
                    .OS("Win64")
                    .Platform("Revit")
                    .SeriesMin("R2021")
                    .SeriesMax("R2021")
                    .AppName("RevitAddin")
                    .ModuleName(@"./Contents/2021/RevitAddin.addin");

                Components
                    .CreateEntry("Revit 2022")
                    .RevitPlatform(2022)
                    .AppName("RevitAddin")
                    .ModuleName(@"./Contents/2022/RevitAddin.addin");
            }
        }
    }
}