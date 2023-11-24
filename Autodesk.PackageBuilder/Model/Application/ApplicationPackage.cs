using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model.Application;

[Serializable]
public class ApplicationPackage : IPackageSerializable
{
    [XmlAttribute] public string SchemaVersion { get; set; }
    [XmlAttribute] public string AutodeskProduct { get; set; }
    [XmlAttribute] public string Name { get; set; }
    [XmlAttribute] public string Description { get; set; }
    [XmlAttribute] public string AppVersion { get; set; }
    [XmlAttribute] public string FriendlyVersion { get; set; }
    [XmlAttribute] public string ProductType { get; set; }
    [XmlAttribute] public string ProductCode { get; set; }
    [XmlAttribute] public string Author { get; set; }
    [XmlAttribute] public string HelpFile { get; set; }
    [XmlAttribute] public string SupportedLocales { get; set; }
    [XmlAttribute] public string OnlineDocumentation { get; set; }
    [XmlElement] public CompanyDetails CompanyDetails { get; set; } = new();
    [XmlElement] public List<Components> Components { get; set; } = new();
}