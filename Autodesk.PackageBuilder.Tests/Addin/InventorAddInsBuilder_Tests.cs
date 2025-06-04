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
        public void Build_Create(string type)
        {
            builder.AddIn.Create(type);
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [Test]
        public void Build_Create_Empty()
        {
            string type = "Standard";
            builder.AddIn.Create();
            builder.AssertElementAttribute("AddIn", "Type", type);
        }

        [TestCase("Value")]
        [TestCase("PropertyValue")]
        public void Build_Create_AddInId(string value)
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
        public void Build_Create_AddInId_Load(string value, int i)
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

        [TestCase(28, "28..")]
        [TestCase(29, "29..")]
        public void Build_Create_AddInId_SupportedSoftwareVersionEqualTo(int version, string expected)
        {
            builder.AddIn.Create()
                .SupportedSoftwareVersion(version);

            builder.AssertElement("SupportedSoftwareVersionEqualTo", expected);
            builder.AssertNotElement("SupportedSoftwareVersionGreaterThan");
            builder.AssertNotElement("SupportedSoftwareVersionLessThan");
        }

        [TestCase(25, "24..")] // Inventor 2021+
        [TestCase(28, "27..")] // Inventor 2024+
        [TestCase(29, "28..")] // Inventor 2025+
        public void Build_Create_AddInId_SupportedSoftwareVersionGreaterThan(int version, string expected)
        {
            builder.AddIn.Create()
                .SupportedSoftwareVersion(version, 0);

            builder.AssertElement("SupportedSoftwareVersionGreaterThan", expected);
            builder.AssertNotElement("SupportedSoftwareVersionLessThan");
            builder.AssertNotElement("SupportedSoftwareVersionEqualTo");
        }

        [TestCase(25, "24..", 28, "29..")] // Inventor 2021+ to 2024-
        [TestCase(25, "24..", 28, "28..", true)] // Inventor 2021+ to 2024- (not include 2024)
        [TestCase(29, "28..", 30, "31..")] // Inventor 2025+ to 2026-
        [TestCase(29, "28..", 30, "30..", true)] // Inventor 2025+ to 2026- (not include 2026)
        public void Build_Create_AddInId_SupportedSoftwareVersionGreaterAndLessThan(int minVersion, string minExpected, int maxVersion, string maxExpected, bool maxVersionMinusOne = false)
        {
            builder.AddIn.Create()
                .SupportedSoftwareVersion(minVersion, maxVersion, maxVersionMinusOne);

            builder.AssertElement("SupportedSoftwareVersionGreaterThan", minExpected);
            builder.AssertElement("SupportedSoftwareVersionLessThan", maxExpected);
            builder.AssertNotElement("SupportedSoftwareVersionEqualTo");
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