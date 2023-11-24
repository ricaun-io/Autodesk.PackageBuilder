using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Model.Application;

public class RuntimeRequirements
{
    public RuntimeRequirements()
    {
    }

    public RuntimeRequirements(string os, string platform, string seriesMin, string seriesMax)
    {
        OS = os;
        Platform = platform;
        SeriesMin = seriesMin;
        SeriesMax = seriesMax;
    }

    [XmlAttribute] public string OS { get; set; }
    [XmlAttribute] public string Platform { get; set; }
    [XmlAttribute] public string SeriesMin { get; set; }
    [XmlAttribute] public string SeriesMax { get; set; }
}