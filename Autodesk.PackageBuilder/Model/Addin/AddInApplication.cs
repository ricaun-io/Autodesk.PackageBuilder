namespace Autodesk.PackageBuilder.Model.Addin
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents an add-in application definition for Autodesk products.
    /// </summary>
    public class AddInApplication : ExtensibleData
    {
        /// <summary>
        /// Gets or sets the type of the add-in application.
        /// </summary>
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the display name of the add-in application.
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assembly file name or path for the add-in application.
        /// </summary>
        [XmlElement]
        public string Assembly { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the add-in application.
        /// </summary>
        [XmlElement]
        public string AddInId { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified class name that implements the add-in application.
        /// </summary>
        [XmlElement]
        public string FullClassName { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier for the add-in application.
        /// </summary>
        [XmlElement]
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the vendor description for the add-in application.
        /// </summary>
        [XmlElement]
        public string VendorDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the add-in can be loaded into an existing session.
        /// </summary>
        [XmlElement]
        public bool AllowLoadingIntoExistingSession { get; set; } = true;
    }
}
