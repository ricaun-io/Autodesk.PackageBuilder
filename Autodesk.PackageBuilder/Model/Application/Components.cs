namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    public class Components
    {
        [XmlAttribute]
        public string Description { get; set; }

        [XmlElement]
        public RuntimeRequirements RuntimeRequirements { get; set; }

        [XmlElement]
        public ComponentEntry ComponentEntry { get; set; }
    }
}