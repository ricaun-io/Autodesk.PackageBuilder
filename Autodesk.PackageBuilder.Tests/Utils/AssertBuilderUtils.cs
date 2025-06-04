using NUnit.Framework;
using System;

namespace Autodesk.PackageBuilder.Tests.Utils
{
    public static class AssertBuilderUtils
    {
        /// <summary>
        /// Assert <paramref name="builder"/> with '&lt;<paramref name="element"/>'.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="element"></param>
        public static void AssertElement(this IBuilder builder, string element)
        {
            var content = builder.ToString();
            var elementValue = ElementStart(element);
            Assert.IsTrue(content.Contains(elementValue), $"The string '{elementValue}' is not found in '{content}'");
        }

        /// <summary>
        /// Assert <paramref name="builder"/> with '&lt;<paramref name="element"/>&gt;<paramref name="value"/>&lt;/<paramref name="element"/>&gt;'.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void AssertElement(this IBuilder builder, string element, object value)
        {
            var content = builder.ToString();
            var elementValue = ElementValue(element, value);
            Assert.IsTrue(content.Contains(elementValue), $"The string '{elementValue}' is not found in '{content}'");
        }

        /// <summary>
        /// Asserts that the specified <paramref name="element"/> is not present in the builder's content.
        /// </summary>
        /// <param name="builder">The builder instance to check.</param>
        /// <param name="element">The name of the element to verify absence of.</param>
        public static void AssertNotElement(this IBuilder builder, string element)
        {
            var content = builder.ToString();
            var elementValue = ElementStart(element);
            Assert.IsFalse(content.Contains(elementValue), $"The string '{elementValue}' is found in '{content}'");
        }

        /// <summary>
        /// Assert <paramref name="builder"/> with '<paramref name="attribute"/>="<paramref name="value"/>"'.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public static void AssertAttribute(this IBuilder builder, string attribute, object value)
        {
            var content = builder.ToString();
            var attributeValue = AttributeValue(attribute, value);
            Assert.IsTrue(content.Contains(attributeValue), $"The string '{attributeValue}' is not found in '{content}'");
        }

        /// <summary>
        /// Assert <paramref name="builder"/> with '&lt;<paramref name="element"/> <paramref name="attribute"/>="<paramref name="value"/>"'.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public static void AssertElementAttribute(this IBuilder builder, string element, string attribute, object value)
        {
            var content = builder.ToString();
            var attributeValue = AttributeValue(attribute, value);
            var elementAttibute = $"{ElementStart(element)} {attributeValue}";
            Assert.IsTrue(content.Contains(elementAttibute), $"The string '{elementAttibute}' is not found in '{content}'");
        }

        internal static string ElementStart(string element)
        {
            return $"<{element}";
        }

        internal static string ElementValue(string element, object value)
        {
            return $"<{element}>{value}</{element}>";
        }

        internal static string AttributeValue(string attribute, object value)
        {
            return $"{attribute}=\"{value}\"";
        }
    }
}
