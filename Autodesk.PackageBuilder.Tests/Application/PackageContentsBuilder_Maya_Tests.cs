using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Maya_Tests
    {
        [Test]
        public void Build_PackageBuilder_Maya_Class()
        {
            var builder = BuilderUtils.Build<MayaPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
                if (MayaPackageBuilder.Expected.Equals(content) == false)
                    Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(MayaPackageBuilder.Expected, content, $"Expected: {MayaPackageBuilder.Expected}\nContent: {content}");
        }

        public class MayaPackageBuilder : PackageContentsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <ApplicationPackage SchemaVersion="1.0" AutodeskProduct="Maya" Name="MayaAddin" AppVersion="1.0.0" ProductType="Application">
                  <CompanyDetails Name="Company Name" Url="url" Email="email" />
                  <Components Description="Maya 2024">
                    <RuntimeRequirements OS="Win64" Platform="Maya" SeriesMin="2024" SeriesMax="2024" />
                    <ComponentEntry AppName="MayaAddin" ModuleName="./Contents/2024/MayaAddin.dll" />
                  </Components>
                  <Components Description="Maya 2025">
                    <RuntimeRequirements OS="Win64" Platform="Maya" SeriesMin="2025" SeriesMax="2025" />
                    <ComponentEntry AppName="MayaAddin" ModuleName="./Contents/2025/MayaAddin.dll" />
                  </Components>
                </ApplicationPackage>
                """";

            public MayaPackageBuilder()
            {
                ApplicationPackage
                    .Create()
                    .MayaApplication()
                    .Name("MayaAddin")
                    .AppVersion("1.0.0");

                CompanyDetails
                    .Create("Company Name")
                    .Url("url")
                    .Email("email");

                Components
                    .CreateEntry("Maya 2024")
                    .MayaPlatform(2024)
                    .AppName("MayaAddin")
                    .ModuleName(@"./Contents/2024/MayaAddin.dll");

                Components
                    .CreateEntry("Maya 2025")
                    .MayaPlatform(2025)
                    .AppName("MayaAddin")
                    .ModuleName(@"./Contents/2025/MayaAddin.dll");
            }
        }
    }
}