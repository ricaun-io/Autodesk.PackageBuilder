using Autodesk.PackageBuilder.Model.Application;
using Autodesk.PackageBuilder.Tests.Utils;
using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Data
{
    public class DataBuild_Tests
    {
        PackageContentsBuilder builder;
        [SetUp]
        public void Setup()
        {
            builder = BuilderUtils.Build<PackageContentsBuilder>();
        }

        [TestCase("Test", "Test")]
        [TestCase("Name", "Value")]
        public void DataBuilder_CreateAttribute(string name, object value)
        {
            var applicationPackageBuilder = builder.ApplicationPackage.Create();
            applicationPackageBuilder.DataBuilder.CreateAttribute(name, value);

            System.Console.WriteLine(builder.ToString());

            builder.AssertAttribute(name, value);
        }

        [TestCase("Test", "Test")]
        [TestCase("Name", "Value")]
        public void DataBuilder_CreateElement(string name, object value)
        {
            var applicationPackageBuilder = builder.ApplicationPackage.Create();
            applicationPackageBuilder.DataBuilder.CreateElement(name, value);

            System.Console.WriteLine(builder.ToString());

            builder.AssertElement(name, value);
        }

        [TestCase(3)]
        [TestCase(5)]
        public void Build_CreateComponentEntry(int length)
        {
            for (int i = 0; i < length; i++)
            {
                var componentsBuilder = builder.Components.CreateEntry($"Description {i}");

                componentsBuilder.DataBuilder.CreateElement<ComponentEntry>("Element", i);
                componentsBuilder.DataBuilder.CreateAttribute<ComponentEntry>("Attribute", i);

            }
            System.Console.WriteLine(builder.ToString());

            for (int i = 0; i < length; i++)
            {
                builder.AssertElement("Element", i);
                builder.AssertElementAttribute("ComponentEntry", "Attribute", i);
            }
        }
    }
}