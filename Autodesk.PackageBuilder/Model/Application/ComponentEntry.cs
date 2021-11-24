namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    public class ComponentEntry
    {
        public ComponentEntry() { }
        public ComponentEntry(string appName, string moduleName, string version = null, string appDescription = null)
        {
            AppName = appName;
            ModuleName = moduleName;
            Version = version;
            AppDescription = appDescription;
        }
        [XmlAttribute]
        public string AppName { get; set; }

        [XmlAttribute]
        public string ModuleName { get; set; }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAttribute]
        public string AppDescription { get; set; }
    }
}
