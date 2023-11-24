using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model.Application;

public sealed class Components
{
    [XmlAttribute] public string Description { get; set; }
    [XmlElement] public RuntimeRequirements RuntimeRequirements { get; set; }
    [XmlElement] public ComponentEntry ComponentEntry { get; set; }
}