using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;
using System;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    public class InventorAddInsBuilder_Tests
    {
        InventorAddInsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<InventorAddInsBuilder>();
        }

        [Test]
        public void Build_InventorAddIn()
        {
            builder.AssertElement("AddIn");
        }

        [TestCase("Standard")]
        [TestCase("NotStandard")]
        public void Build_CreateEntry(string type)
        {
            builder.AddIn.Create(type);
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [Test]
        public void Build_CreateEntry_Empty()
        {
            string type = "Standard";
            builder.AddIn.Create();
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [TestCase("Value")]
        [TestCase("PropertyValue")]
        public void Build_CreateEntry_AddInId(string value)
        {
            builder.AddIn.Create()
                .ClassId(value)
                .ClientId(value)
                .DisplayName(value)
                .Description(value)
                .Assembly(value);

            builder.AssertElement("ClassId", value);
            builder.AssertElement("ClientId", value);
            builder.AssertElement("DisplayName", value);
            builder.AssertElement("Description", value);
            builder.AssertElement("Assembly", value);

            builder.AssertNotElement("LoadAutomatically");
            builder.AssertNotElement("LoadBehavior");
            builder.AssertNotElement("UserUnloadable");
            builder.AssertNotElement("Hidden");
        }

        [TestCase("Value", 0)]
        [TestCase("PropertyValue", 1)]
        public void Build_CreateEntry_AddInId_Load(string value, int i)
        {
            builder.AddIn.Create()
                .ClassId(value)
                .ClientId(value)
                .DisplayName(value)
                .Description(value)
                .Assembly(value)
                .LoadAutomatically(i)
                .LoadBehavior(i)
                .UserUnloadable(i)
                .Hidden(i);

            builder.AssertElement("ClassId", value);
            builder.AssertElement("ClientId", value);
            builder.AssertElement("DisplayName", value);
            builder.AssertElement("Description", value);
            builder.AssertElement("Assembly", value);

            builder.AssertElement("LoadAutomatically", i);
            builder.AssertElement("LoadBehavior", i);
            builder.AssertElement("UserUnloadable", i);
            builder.AssertElement("Hidden", i);
        }

        [Test]
        public void Build_InventorAddIns_DemoClass()
        {
            var builder = BuilderUtils.Build<DemoAddinBuilder>();
            var content = builder.ToString();
            Console.WriteLine(builder.ToString());
            Assert.AreEqual(DemoAddinBuilder.Expected, content, $"Expected: {DemoAddinBuilder.Expected}\nContent: {content}");
        }

        public class DemoAddinBuilder : InventorAddInsBuilder
        {
            public static string Expected => """"
                <?xml version="1.0" encoding="utf-8"?>
                <AddIn Type="Standard">
                  <ClassId>{11111111-2222-3333-4444-555555555555}</ClassId>
                  <ClientId>{11111111-2222-3333-4444-555555555555}</ClientId>
                  <DisplayName>InventorAddIn</DisplayName>
                  <Description>InventorAddIn</Description>
                  <Assembly>InventorAddIn.dll</Assembly>
                  <LoadBehavior>0</LoadBehavior>
                  <UserUnloadable>0</UserUnloadable>
                  <SupportedSoftwareVersionGreaterThan>24..</SupportedSoftwareVersionGreaterThan>
                  <SupportedSoftwareVersionLessThan>29..</SupportedSoftwareVersionLessThan>
                </AddIn>
                """";
            public DemoAddinBuilder()
            {
                var classId = new Guid("11111111-2222-3333-4444-555555555555");
                AddIn.Create()
                    .ClassId(classId)
                    .ClientId(classId)
                    .DisplayName("InventorAddIn")
                    .Description("InventorAddIn")
                    .Assembly("InventorAddIn.dll")
                    .LoadBehavior(0)
                    .UserUnloadable(0)
                    .SupportedSoftwareVersionGreaterThan("24..")
                    .SupportedSoftwareVersionLessThan("29..");
            }
        }
    }
}