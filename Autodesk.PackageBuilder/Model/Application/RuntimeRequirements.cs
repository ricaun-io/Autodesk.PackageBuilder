namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents the runtime requirements for an application, including operating system, platform, and supported series range.
    /// </summary>
    public class RuntimeRequirements : ExtensibleData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeRequirements"/> class.
        /// </summary>
        public RuntimeRequirements()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeRequirements"/> class with the specified parameters.
        /// </summary>
        /// <param name="os">The operating system required.</param>
        /// <param name="platform">The platform required.</param>
        /// <param name="seriesMin">The minimum supported series version.</param>
        /// <param name="seriesMax">The maximum supported series version.</param>
        public RuntimeRequirements(string os, string platform, string seriesMin, string seriesMax)
        {
            OS = os;
            Platform = platform;
            SeriesMin = seriesMin;
            SeriesMax = seriesMax;
        }

        /// <summary>
        /// Gets or sets the required operating system.
        /// </summary>
        [XmlAttribute]
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets the required platform.
        /// </summary>
        [XmlAttribute]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the minimum supported series version.
        /// </summary>
        [XmlAttribute]
        public string SeriesMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum supported series version.
        /// </summary>
        [XmlAttribute]
        public string SeriesMax { get; set; }
    }
}