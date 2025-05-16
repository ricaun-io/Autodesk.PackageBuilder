namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    public class RuntimeRequirements : DataBase
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

        [XmlAttribute]
        public string OS { get; set; }

        [XmlAttribute]
        public string Platform { get; set; }

        [XmlAttribute]
        public string SeriesMin { get; set; }

        [XmlAttribute]
        public string SeriesMax { get; set; }
    }
}