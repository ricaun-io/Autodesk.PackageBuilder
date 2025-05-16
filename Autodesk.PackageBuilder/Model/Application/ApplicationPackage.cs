namespace Autodesk.PackageBuilder.Model.Application
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents an application package with metadata and components for XML serialization.
    /// </summary>
    [Serializable]
    public class ApplicationPackage : DataBase, IPackageSerializable
    {
        /// <summary>
        /// Gets or sets the schema version of the application package.
        /// </summary>
        [XmlAttribute]
        public string SchemaVersion { get; set; }

        /// <summary>
        /// Gets or sets the Autodesk product associated with this package.
        /// </summary>
        [XmlAttribute]
        public string AutodeskProduct { get; set; }

        /// <summary>
        /// Gets or sets the name of the application package.
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the application package.
        /// </summary>
        [XmlAttribute]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        [XmlAttribute]
        public string AppVersion { get; set; }

        /// <summary>
        /// Gets or sets the user-friendly version string.
        /// </summary>
        [XmlAttribute]
        public string FriendlyVersion { get; set; }

        /// <summary>
        /// Gets or sets the product type of the application package.
        /// </summary>
        [XmlAttribute]
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the product code of the application package.
        /// </summary>
        [XmlAttribute]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the author of the application package.
        /// </summary>
        [XmlAttribute]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the help file associated with the application package.
        /// </summary>
        [XmlAttribute]
        public string HelpFile { get; set; }

        /// <summary>
        /// Gets or sets the supported locales for the application package.
        /// </summary>
        [XmlAttribute]
        public string SupportedLocales { get; set; }

        /// <summary>
        /// Gets or sets the URL to the online documentation.
        /// </summary>
        [XmlAttribute]
        public string OnlineDocumentation { get; set; }

        /// <summary>
        /// Gets or sets the company details associated with the application package.
        /// </summary>
        [XmlElement]
        public CompanyDetails CompanyDetails { get; set; } = new CompanyDetails();

        /// <summary>
        /// Gets or sets the list of components included in the application package.
        /// </summary>
        [XmlElement]
        public List<Components> Components { get; set; } = new List<Components>();
    }
}