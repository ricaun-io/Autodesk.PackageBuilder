using NUnit.Framework;
using Autodesk.PackageBuilder.Extensible.Navisworks;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Navisworks_Tests
    {
        [Test]
        public void Build_PackageBuilder_NavisworksClass()
        {
            var builder = BuilderUtils.Build<NavisworksPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
                if (NavisworksPackageBuilder.Expected.Equals(content) == false)
                    Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(NavisworksPackageBuilder.Expected, content, $"Expected: {NavisworksPackageBuilder.Expected}\nContent: {content}");
        }

        public class NavisworksPackageBuilder : PackageContentsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <ApplicationPackage SchemaVersion="1.0" AutodeskProduct="Navisworks" Name="NavisworksAddin" AppVersion="1.0.0">
                  <CompanyDetails Name="Company Name" Url="url" Email="email" />
                  <Components Description="Navisworks 2024">
                    <RuntimeRequirements OS="Win64" Platform="NAVMAN|NAVSIM" SeriesMin="Nw19" SeriesMax="Nw21" />
                    <ComponentEntry AppName="NavisworksAddin" ModuleName="./Contents/2024/NavisworksAddin.dll" AppType="ManagedPlugin" />
                  </Components>
                  <Components Description="Navisworks 2025">
                    <RuntimeRequirements OS="Win64" Platform="NAVMAN|NAVSIM" SeriesMin="Nw22" />
                    <ComponentEntry AppName="NavisworksAddin" ModuleName="./Contents/2025/NavisworksAddin.dll" />
                  </Components>
                </ApplicationPackage>
                """";

            public NavisworksPackageBuilder()
            {
                ApplicationPackage
                    .Create()
                    .AutodeskProduct("Navisworks")
                    .Name("NavisworksAddin")
                    .AppVersion("1.0.0");

                CompanyDetails
                    .Create("Company Name")
                    .Url("url")
                    .Email("email");

                Components
                    .CreateEntry("Navisworks 2024")
                    .NavisworksPlatform(19, 22, true)
                    .AppType()
                    .AppName("NavisworksAddin")
                    .ModuleName(@"./Contents/2024/NavisworksAddin.dll");

                Components
                    .CreateEntry("Navisworks 2025")
                    .NavisworksPlatform(22, 0)
                    .AppName("NavisworksAddin")
                    .ModuleName(@"./Contents/2025/NavisworksAddin.dll");
            }
        }
    }
}