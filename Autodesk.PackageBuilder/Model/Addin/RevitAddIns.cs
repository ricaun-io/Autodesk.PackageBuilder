namespace Autodesk.PackageBuilder.Model.Addin
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents a collection of Revit add-in definitions for XML serialization.
    /// </summary>
    [Serializable]
    public class RevitAddIns : DataBase, IPackageSerializable
    {
        /// <summary>
        /// Gets or sets the list of Revit add-in models.
        /// </summary>
        [XmlElement]
        public List<AddInModel> AddIn { get; set; } = new List<AddInModel>();
    }
}