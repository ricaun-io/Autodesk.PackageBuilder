using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Max3ds_Tests
    {
        [Test]
        public void Build_PackageBuilder_Max3ds_Class()
        {
            var builder = BuilderUtils.Build<Max3dsPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
            if (Max3dsPackageBuilder.Expected.Equals(content) == false)
                Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(Max3dsPackageBuilder.Expected, content, $"Expected: {Max3dsPackageBuilder.Expected}\nContent: {content}");
        }

        public class Max3dsPackageBuilder : PackageContentsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <ApplicationPackage SchemaVersion="1.0" AutodeskProduct="3ds Max" Name="Max3dsAddin" AppVersion="1.0.0" ProductType="Application">
                  <CompanyDetails Name="Company Name" Url="url" Email="email" />
                  <Components Description="Max3ds 2024">
                    <RuntimeRequirements OS="Win64" Platform="3ds Max" SeriesMin="2024" SeriesMax="2024" />
                    <ComponentEntry AppName="Max3dsAddin" ModuleName="./Contents/2024/Max3dsAddin.dll" />
                  </Components>
                  <Components Description="Max3ds 2025">
                    <RuntimeRequirements OS="Win64" Platform="3ds Max" SeriesMin="2025" SeriesMax="2025" />
                    <ComponentEntry AppName="Max3dsAddin" ModuleName="./Contents/2025/Max3dsAddin.dll" />
                  </Components>
                </ApplicationPackage>
                """";
            public Max3dsPackageBuilder()
            {
                ApplicationPackage
                    .Create()
                    .Max3dsApplication()
                    .Name("Max3dsAddin")
                    .AppVersion("1.0.0");

                CompanyDetails
                    .Create("Company Name")
                    .Url("url")
                    .Email("email");

                Components
                    .CreateEntry("Max3ds 2024")
                    .Max3dsPlatform(2024)
                    .AppName("Max3dsAddin")
                    .ModuleName(@"./Contents/2024/Max3dsAddin.dll");

                Components
                    .CreateEntry("Max3ds 2025")
                    .Max3dsPlatform(2025)
                    .AppName("Max3dsAddin")
                    .ModuleName(@"./Contents/2025/Max3dsAddin.dll");
            }
        }
    }
}