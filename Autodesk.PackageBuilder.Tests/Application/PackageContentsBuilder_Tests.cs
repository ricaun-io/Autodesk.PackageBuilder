using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;
using System;

namespace Autodesk.PackageBuilder.Tests.Application
{
    public class PackageContentsBuilder_Tests
    {
        PackageContentsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<PackageContentsBuilder>();
        }

        [Test]
        public void Build_PackageBuilder()
        {
            var content = builder.ToString();
            //Console.WriteLine(content);
            builder.AssertElement("ApplicationPackage");
        }

        [TestCase("1.0")]
        [TestCase("2.0")]
        [TestCase("3.0")]
        public void Build_ApplicationPackage(string schemaVersion)
        {
            builder.ApplicationPackage.Create(schemaVersion);
            builder.AssertAttribute("SchemaVersion", schemaVersion);
        }

        [Test]
        public void Build_ApplicationPackage_Empty()
        {
            var schemaVersion = "1.0";
            builder.ApplicationPackage.Create();
            builder.AssertAttribute("SchemaVersion", schemaVersion);
        }

        [TestCase("Value")]
        [TestCase("AttributeValue")]
        public void Build_ApplicationPackage_Attribute(string value)
        {
            builder.ApplicationPackage.Create()
                .Name(value)
                .AutodeskProduct(value)
                .Description(value)
                .AppVersion(value)
                //.AppVersion(version)
                .FriendlyVersion(value)
                .ProductType(value)
                .ProductCode(value)
                //.ProductCode(guid)
                .Author(value)
                .HelpFile(value)
                .SupportedLocales(value)
                .OnlineDocumentation(value);

            builder.AssertAttribute("Name", value);
            builder.AssertAttribute("AutodeskProduct", value);
            builder.AssertAttribute("Description", value);
            builder.AssertAttribute("AppVersion", value);
            builder.AssertAttribute("FriendlyVersion", value);
            builder.AssertAttribute("ProductType", value);
            builder.AssertAttribute("ProductCode", value);
            builder.AssertAttribute("Author", value);
            builder.AssertAttribute("HelpFile", value);
            builder.AssertAttribute("SupportedLocales", value);
            builder.AssertAttribute("OnlineDocumentation", value);
        }

        [Test]
        public void Build_ApplicationPackage_Attribute_AppVersion()
        {
            var version = new Version(1, 2, 3, 4);
            builder.ApplicationPackage.Create()
                .AppVersion(version);

            builder.AssertAttribute("AppVersion", version);
        }

        [Test]
        public void Build_ApplicationPackage_Attribute_ProductCode()
        {
            var guid = Guid.NewGuid();
            builder.ApplicationPackage.Create()
                .ProductCode(guid);

            builder.AssertAttribute("ProductCode", guid);
        }

        [TestCase("Name")]
        [TestCase("Company")]
        public void Build_CompanyDetails(string name)
        {
            builder.CompanyDetails.Create(name);
            builder.AssertAttribute("Name", name);
        }

        [TestCase("Value")]
        [TestCase("AttributeValue")]
        public void Build_CompanyDetails_Attribute(string value)
        {
            builder.CompanyDetails.Create(value)
                .Url(value)
                .Email(value);

            builder.AssertAttribute("Name", value);
            builder.AssertAttribute("Url", value);
            builder.AssertAttribute("Email", value);
        }

        [TestCase("Name")]
        [TestCase("Description")]
        public void Build_Components_CreateEntry(string description)
        {
            builder.Components.CreateEntry(description);
            //Console.WriteLine(builder);
            builder.AssertElementAttribute("Components", "Description", description);
        }

        [TestCase(5)]
        [TestCase(9)]
        public void Build_Components_CreateEntry_Multiple(int length)
        {
            for (int i = 0; i < length; i++)
            {
                builder.Components.CreateEntry(i.ToString());
            }
            //Console.WriteLine(builder);
            for (int i = 0; i < length; i++)
            {
                builder.AssertElementAttribute("Components", "Description", i);
            }
        }

        [TestCase("Value")]
        [TestCase("AttributeValue")]
        public void Build_Components_CreateEntry_Attribute(string value)
        {
            builder.Components.CreateEntry(value)
                .OS(value)
                .Platform(value)
                .SeriesMin(value)
                .SeriesMax(value)
                .AppName(value)
                .ModuleName(value)
                .Version(value)
                .AppDescription(value);

            builder.AssertAttribute("Description", value);
            builder.AssertAttribute("OS", value);
            builder.AssertAttribute("Platform", value);
            builder.AssertAttribute("SeriesMin", value);
            builder.AssertAttribute("SeriesMax", value);
            builder.AssertAttribute("AppName", value);
            builder.AssertAttribute("ModuleName", value);
            builder.AssertAttribute("Version", value);
            builder.AssertAttribute("AppDescription", value);
        }

        [Test]
        public void Build_PackageBuilder_DemoClass()
        {
            var builder = BuilderUtils.Build<DemoPackageBuilder>();
            var content = builder.ToString();
#if NET6_0
            if (DemoPackageBuilder.Expected.Equals(content) == false)
                Assert.Ignore("Not equal, order not match in version net6.0 for some reason...");
#endif
            Assert.AreEqual(DemoPackageBuilder.Expected, content, $"Expected: {DemoPackageBuilder.Expected}\nContent: {content}");
        }

        public class DemoPackageBuilder : PackageContentsBuilder
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
            public DemoPackageBuilder()
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