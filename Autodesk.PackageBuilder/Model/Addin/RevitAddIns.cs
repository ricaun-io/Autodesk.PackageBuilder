using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model.Addin;

[Serializable]
public class RevitAddIns : IPackageSerializable
{
    [XmlElement]
    public List<AddInModel> AddIn { get; set; } = new List<AddInModel>();
}