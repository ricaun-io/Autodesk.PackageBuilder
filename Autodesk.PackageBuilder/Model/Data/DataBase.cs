using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Autodesk.PackageBuilder;
/// <summary>
/// Represents a base class for XML-serializable data models, supporting dynamic attributes and elements.
/// </summary>
public class DataBase : IXmlSerializable
{
    /// <summary>
    /// Gets the auxiliary dictionary for storing additional attributes and elements.
    /// The key is the name, and the value is a tuple containing the value and a flag indicating if it is an element.
    /// </summary>
    internal Dictionary<string, (object Value, bool IsElement)> Aux { get; } = new();

    /// <summary>
    /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null from this method.
    /// </summary>
    /// <returns>Always returns null.</returns>
    public XmlSchema GetSchema() => null;

    /// <summary>
    /// Reads the XML representation of the object. Not implemented.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader"/> stream from which the object is deserialized.</param>
    /// <exception cref="System.NotImplementedException">Always thrown.</exception>
    public void ReadXml(XmlReader reader) => throw new System.NotImplementedException();

    /// <summary>
    /// Writes the XML representation of the object, including properties and auxiliary attributes/elements.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter"/> stream to which the object is serialized.</param>
    public void WriteXml(XmlWriter writer)
    {
        var properties = this.GetType().GetProperties()
            .OrderBy(x => x.MetadataToken)
            .Where(p => p.GetCustomAttributes(typeof(XmlIgnoreAttribute), true).Length == 0)
            .ToList();

        var propertiesElements = properties
            .Where(p => p.GetCustomAttributes(typeof(XmlElementAttribute), true).Length > 0)
            .ToList();

        var propertiesAttributes = properties
            .Where(p => p.GetCustomAttributes(typeof(XmlElementAttribute), true).Length == 0)
            .ToList();

        // Write property attributes as XML attributes
        foreach (var p in propertiesAttributes)
        {
            var attributeName = p.GetCustomAttribute<XmlAttributeAttribute>()?.AttributeName;
            var name = string.IsNullOrWhiteSpace(attributeName) ? p.Name : attributeName;

            var value = p.GetValue(this);
            if (value != null)
            {
                writer.WriteAttributeString(name, value.ToString());
            }
        }

        // Write auxiliary attributes
        foreach (var kvp in Aux)
        {
            if (!kvp.Value.IsElement)
            {
                writer.WriteAttributeString(kvp.Key, kvp.Value.Value.ToString());
            }
        }

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        // Write property elements as XML elements
        foreach (var p in propertiesElements)
        {
            var value = p.GetValue(this);
            if (value != null)
            {
                var elementName = p.GetCustomAttribute<XmlElementAttribute>()?.ElementName;
                var name = string.IsNullOrWhiteSpace(elementName) ? p.Name : elementName;
                if (value is IEnumerable collection && value is not string)
                {
                    foreach (var item in collection)
                    {
                        var itemSerializer = new XmlSerializer(item.GetType(), new XmlRootAttribute(name));
                        itemSerializer.Serialize(writer, item, namespaces);
                    }
                    continue;
                }

                var elementSerializer = new XmlSerializer(value.GetType(), new XmlRootAttribute(name));
                elementSerializer.Serialize(writer, value, namespaces);
            }
        }

        // Write auxiliary elements
        foreach (var kvp in Aux)
        {
            if (kvp.Value.IsElement)
            {
                var value = kvp.Value.Value;
                if (value != null)
                {
                    var elementName = value.GetType().GetCustomAttribute<XmlRootAttribute>()?.ElementName;
                    var name = string.IsNullOrWhiteSpace(elementName) ? kvp.Key : elementName;
                    if (value is IEnumerable collection && value is not string)
                    {
                        foreach (var item in collection)
                        {
                            var itemSerializer = new XmlSerializer(item.GetType(), new XmlRootAttribute(name));
                            itemSerializer.Serialize(writer, item, namespaces);
                        }
                        continue;
                    }
                    var elementSerializer = new XmlSerializer(value.GetType(), new XmlRootAttribute(name));
                    elementSerializer.Serialize(writer, value, namespaces);
                }
            }
        }
    }
}