using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;
using System;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    public class RevitAddInsBuilder_Tests
    {
        RevitAddInsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<RevitAddInsBuilder>();
        }

        [Test]
        public void Build_RevitAddIns()
        {
            builder.AssertElement("RevitAddIns");
        }

        [TestCase("Command")]
        [TestCase("Application")]
        [TestCase("DBApplication")]
        public void Build_CreateEntry(string type)
        {
            builder.AddIn.CreateEntry(type);
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [Test]
        public void Build_CreateEntry_Empty()
        {
            string type = "Application";
            builder.AddIn.CreateEntry();
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [TestCase("Value")]
        [TestCase("PropertyValue")]
        public void Build_CreateEntry_AddInId(string value)
        {
            builder.AddIn.CreateEntry()
                .Name(value)
                .Assembly(value)
                .AddInId(value)
                .FullClassName(value)
                .VendorId(value)
                .VendorDescription(value);

            builder.AssertElement("Name", value);
            builder.AssertElement("Assembly", value);
            builder.AssertElement("AddInId", value);
            builder.AssertElement("FullClassName", value);
            builder.AssertElement("VendorId", value);
            builder.AssertElement("VendorDescription", value);
        }

        [TestCase(5)]
        [TestCase(9)]
        public void Build_CreateEntry_AddInId_Multiple(int length)
        {
            for (int i = 0; i < length; i++)
            {
                builder.AddIn.CreateEntry()
                    .Name(i.ToString());
            }

            for (int i = 0; i < length; i++)
            {
                builder.AssertElement("Name", i);
            }
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
            }
        }
    }
}