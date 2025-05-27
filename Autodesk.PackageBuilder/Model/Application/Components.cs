namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents a collection of application components, including runtime requirements and a component entry.
    /// </summary>
    public class Components : ExtensibleData
    {
        /// <summary>
        /// Gets or sets the description of the components.
        /// </summary>
        [XmlAttribute]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the runtime requirements for the components.
        /// </summary>
        [XmlElement]
        public RuntimeRequirements RuntimeRequirements { get; set; }

        /// <summary>
        /// Gets or sets the component entry associated with the components.
        /// </summary>
        [XmlElement]
        public ComponentEntry ComponentEntry { get; set; }
    }
}