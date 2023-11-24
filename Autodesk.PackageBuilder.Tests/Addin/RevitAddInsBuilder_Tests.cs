using NUnit.Framework;
using System;
using System.IO;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    public class RevitAddInsBuilder_Tests
    {
        [Test]
        public void Build_RevitAddIns()
        {
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            var content = builder.ToString();
            Assert.IsTrue(content.Contains("RevitAddIns"));
        }

        [TestCase("Command")]
        [TestCase("Application")]
        [TestCase("DBApplication")]
        public void Build_CreateEntry(string entryName)
        {
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            builder.AddIn.CreateEntry(entryName);
            var content = builder.ToString();

            var AddinContains = $"AddIn Type=\"{entryName}\"";
            Assert.IsTrue(content.Contains(AddinContains));
        }

        [Test]
        public void Build_CreateEntry_Empty()
        {
            string entryName = "Application";
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            builder.AddIn.CreateEntry();
            var content = builder.ToString();

            Console.WriteLine(content);
            var AddinContains = $"AddIn Type=\"{entryName}\"";
            Assert.IsTrue(content.Contains(AddinContains));
        }

        [TestCase("Value")]
        [TestCase("PropertyValue")]
        public void Build_CreateEntry_AddInId(string value)
        {
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            builder.AddIn.CreateEntry()
                .Name(value)
                .Assembly(value)
                .AddInId(value)
                .FullClassName(value)
                .VendorId(value)
                .VendorDescription(value);

            var content = builder.ToString();

            Assert.IsTrue(content.Contains(PropertyValue("Name", value)));
            Assert.IsTrue(content.Contains(PropertyValue("Assembly", value)));
            Assert.IsTrue(content.Contains(PropertyValue("AddInId", value)));
            Assert.IsTrue(content.Contains(PropertyValue("FullClassName", value)));
            Assert.IsTrue(content.Contains(PropertyValue("VendorId", value)));
            Assert.IsTrue(content.Contains(PropertyValue("VendorDescription", value)));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void Build_CreateEntry_AddInId_Multiple(int length)
        {
            var builder = BuilderUtils.Build<RevitAddInsBuilder>();
            for (int i = 0; i < length; i++)
            {
                builder.AddIn.CreateEntry()
                    .Name(i.ToString());
            }

            var content = builder.ToString();
            for (int i = 0; i < length; i++)
            {
                Assert.IsTrue(content.Contains(PropertyValue("Name", i)));
            }

        }

        private string PropertyValue(string property, object value)
        {
            return $"<{property}>{value}</{property}>";
        }
    }
}