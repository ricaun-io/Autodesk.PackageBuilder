using System.Xml.Serialization;
using Autodesk.PackageBuilder;

namespace Autodesk.PackageBuilder.Tests.Addin
{
    /// <summary>
    /// Provides extension methods for the <see cref="RevitAddInsBuilder"/> class.
    /// </summary>
    public static class RevitAddInsBuilderManifestSettingsExtensions
    {
        /// <summary>
        /// Creates a new instance of <see cref="ManifestSettings"/> and adds it to the builder.
        /// </summary>
        /// <param name="builder">The <see cref="RevitAddInsBuilder"/> instance to extend.</param>
        /// <returns>A new instance of <see cref="ManifestSettings"/>.</returns>
        public static ManifestSettings CreateManifestSettings(this RevitAddInsBuilder builder)
        {
            var manifestSettings = new ManifestSettings();
            builder.DataBuilder.CreateElement(nameof(ManifestSettings), manifestSettings);
            return manifestSettings;
        }

        /// <summary>
        /// Represents the manifest settings for Revit 2026.
        /// </summary>
        /// <remarks>
        /// For more information, see:
        /// https://help.autodesk.com/view/RVT/2026/ENU/?guid=Revit_API_Revit_API_Developers_Guide_Introduction_Add_In_Integration_Add_in_Dependency_Isolation_html
        /// </remarks>
        public class ManifestSettings
        {
            /// <summary>
            /// Gets or sets a value indicating whether to use the Revit context.
            /// </summary>
            [XmlElement]
            public bool UseRevitContext { get; set; }

            /// <summary>
            /// Gets or sets the name of the context.
            /// </summary>
            [XmlElement]
            public string ContextName { get; set; }
        }
    }
}