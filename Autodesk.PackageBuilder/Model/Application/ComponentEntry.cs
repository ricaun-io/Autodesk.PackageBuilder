namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents an application component entry with metadata for XML serialization.
    /// </summary>
    public class ComponentEntry : DataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentEntry"/> class.
        /// </summary>
        public ComponentEntry() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="appName">The name of the application.</param>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="version">The version of the component (optional).</param>
        /// <param name="appDescription">The description of the application (optional).</param>
        public ComponentEntry(string appName, string moduleName, string version = null, string appDescription = null)
        {
            AppName = appName;
            ModuleName = moduleName;
            Version = version;
            AppDescription = appDescription;
        }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        [XmlAttribute]
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets the name of the module.
        /// </summary>
        [XmlAttribute]
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets the version of the component.
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the description of the application.
        /// </summary>
        [XmlAttribute]
        public string AppDescription { get; set; }
    }
}
