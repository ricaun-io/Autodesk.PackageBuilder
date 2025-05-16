using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model
{
    public class ModelBase : IXmlSerializable
    {
        internal Dictionary<string, (object Value, bool IsElement)> Aux { get; } = new();

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader) => throw new System.NotImplementedException();

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

            foreach (var kvp in Aux)
            {
                if (!kvp.Value.IsElement)
                {
                    writer.WriteAttributeString(kvp.Key, kvp.Value.Value.ToString());
                }
            }

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

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
}