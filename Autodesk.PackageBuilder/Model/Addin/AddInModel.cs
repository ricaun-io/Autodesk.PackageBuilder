namespace Autodesk.PackageBuilder.Model.Addin
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents an add-in model for Autodesk Package Builder, containing metadata for an add-in.
    /// </summary>
    public class AddInModel : ExtensibleData
    {
        /// <summary>
        /// Gets or sets the type of the add-in.
        /// </summary>
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the add-in.
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assembly file name or path for the add-in.
        /// </summary>
        [XmlElement]
        public string Assembly { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the add-in.
        /// </summary>
        [XmlElement]
        public string AddInId { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified class name that implements the add-in.
        /// </summary>
        [XmlElement]
        public string FullClassName { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier for the add-in.
        /// </summary>
        [XmlElement]
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the vendor description for the add-in.
        /// </summary>
        [XmlElement]
        public string VendorDescription { get; set; }
    }
}
