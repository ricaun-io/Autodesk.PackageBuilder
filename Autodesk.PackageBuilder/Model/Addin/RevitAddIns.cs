namespace Autodesk.PackageBuilder.Model.Addin
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    [Serializable]
    public class RevitAddIns : IPackageSerializable
    {
        [XmlElement]
        public List<AddInApplication> AddIn { get; set; } = new List<AddInApplication>();
    }
}