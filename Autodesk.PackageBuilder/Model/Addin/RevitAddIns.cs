namespace Autodesk.PackageBuilder.Model.Addin
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    [Serializable]
    public class RevitAddIns : DataBase, IPackageSerializable
    {
        [XmlElement]
        public List<AddInModel> AddIn { get; set; } = new List<AddInModel>();
    }
}