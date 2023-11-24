using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model.Addin;

public class AddInApplication
{
    [XmlAttribute]
    public string Type { get; set; }

    [XmlElement]
    public string Name { get; set; }

    [XmlElement]
    public string Assembly { get; set; }

    [XmlElement]
    public string AddInId { get; set; }

    [XmlElement]
    public string FullClassName { get; set; }

    [XmlElement]
    public string VendorId { get; set; }

    [XmlElement]
    public string VendorDescription { get; set; }

    [XmlElement]
    public bool AllowLoadingIntoExistingSession { get; set; } = true;
}