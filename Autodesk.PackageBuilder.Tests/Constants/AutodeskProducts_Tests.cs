using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Constants
{
    public class AutodeskProducts_Tests
    {
        [Test]
        public void AutoCAD_Test()
        {
            Assert.AreEqual("AutoCAD", AutodeskProducts.AutoCAD);
        }

        [Test]
        public void Revit_Test()
        {
            Assert.AreEqual("Revit", AutodeskProducts.Revit);
        }

        [Test]
        public void Maya_Test()
        {
            Assert.AreEqual("Maya", AutodeskProducts.Maya);
        }

        [Test]
        public void Navisworks_Test()
        {
            Assert.AreEqual("Navisworks", AutodeskProducts.Navisworks);
        }
    }
}