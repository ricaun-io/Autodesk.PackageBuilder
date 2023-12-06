using NUnit.Framework;

namespace Autodesk.PackageBuilder.Tests.Constants
{
    public class ProductTypes_Tests
    {
        [Test]
        public void Application_Test()
        {
            Assert.AreEqual("Application", ProductTypes.Application);
        }

        [Test]
        public void Content_Test()
        {
            Assert.AreEqual("Content", ProductTypes.Content);
        }
    }
}