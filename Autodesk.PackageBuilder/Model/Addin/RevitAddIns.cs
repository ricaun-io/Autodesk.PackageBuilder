namespace Autodesk.PackageBuilder.Model.Addin
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    [Serializable]
    public class RevitAddIns : ModelBase, IPackageSerializable
    {
        [XmlElement]
        public List<AddInModel> AddIn { get; set; } = new List<AddInModel>();
    }
}