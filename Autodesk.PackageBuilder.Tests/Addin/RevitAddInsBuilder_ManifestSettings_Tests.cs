using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    public class RevitAddInsBuilder_ManifestSettings_Tests
    {
        RevitAddInsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<RevitAddInsBuilder>();
        }

        [TestCase("ContextName")]
        [TestCase("MyContext")]
        public void Build_DataBuilder_ManifestSettings(string contextName)
        {
            var addIn = builder.AddIn.CreateEntry();
            var manifestSettings = new ManifestSettings
            {
                UseRevitContext = true,
                ContextName = contextName
            };

            builder.DataBuilder.CreateElement(nameof(ManifestSettings), manifestSettings);

            builder.AssertElement(nameof(ManifestSettings.UseRevitContext), "true");
            builder.AssertElement(nameof(ManifestSettings.ContextName), contextName);

            var content = builder.ToString();
            Console.WriteLine(content);
        }

        /// <summary>
        /// ManifestSettings Revit 2026
        /// </summary>
        /// <remarks>
        /// https://help.autodesk.com/view/RVT/2026/ENU/?guid=Revit_API_Revit_API_Developers_Guide_Introduction_Add_In_Integration_Add_in_Dependency_Isolation_html
        /// </remarks>
        public class ManifestSettings : ExtensibleData
        {
            [XmlElement]
            public bool UseRevitContext { get; set; }
            [XmlElement]
            public string ContextName { get; set; }
        }

        [Test]
        public void Build_RevitAddIns_DemoClass()
        {
            var builder = BuilderUtils.Build<DemoAddinBuilder>();
            var content = builder.ToString();
            Assert.AreEqual(DemoAddinBuilder.Expected, content, $"Expected: {DemoAddinBuilder.Expected}\nContent: {content}");
        }

        public class DemoAddinBuilder : RevitAddInsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <RevitAddIns>
                  <AddIn Type="Application">
                    <Name>RevitAddin</Name>
                    <Assembly>RevitAddin.dll</Assembly>
                    <AddInId>11111111-2222-3333-4444-555555555555</AddInId>
                    <FullClassName>RevitAddin.App</FullClassName>
                    <VendorId>RevitAddin</VendorId>
                    <VendorDescription>RevitAddin</VendorDescription>
                  </AddIn>
                  <ManifestSettings>
                    <UseRevitContext>true</UseRevitContext>
                    <ContextName>ContextName</ContextName>
                  </ManifestSettings>
                </RevitAddIns>
                """";
            public DemoAddinBuilder()
            {
                AddIn.CreateEntry("Application")
                    .Name("RevitAddin")
                    .Assembly("RevitAddin.dll")
                    .AddInId("11111111-2222-3333-4444-555555555555")
                    .FullClassName("RevitAddin.App")
                    .VendorId("RevitAddin")
                    .VendorDescription("RevitAddin");

                var manifestSettings = new ManifestSettings
                {
                    UseRevitContext = true,
                    ContextName = "ContextName"
                };

                DataBuilder.CreateElement(nameof(ManifestSettings), manifestSettings);
            }
        }
    }
}