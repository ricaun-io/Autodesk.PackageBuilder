namespace Autodesk.PackageBuilder
{
    using Model.Application;

    /// <summary>
    /// Provides a builder for constructing and serializing an Autodesk application package,
    /// including application metadata, company details, and components.
    /// </summary>
    public class PackageContentsBuilder : IBuilder
    {
        private readonly ApplicationPackage applicationPackage;

        private readonly ApplicationPackageBuilder _applicationPackage;
        private readonly CompanyDetailsBuilder _companyDetailsBuilder;
        private readonly ComponentsBuilder _components;

        /// <summary>
        /// Gets the builder for configuring the application package metadata.
        /// </summary>
        public IApplicationPackageBuilder ApplicationPackage => _applicationPackage;

        /// <summary>
        /// Gets the builder for configuring the company details.
        /// </summary>
        public ICompanyDetailsBuilder CompanyDetails => _companyDetailsBuilder;

        /// <summary>
        /// Gets the builder for configuring the components entries.
        /// </summary>
        public IComponentsEntryBuilder Components => _components;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageContentsBuilder"/> class.
        /// </summary>
        public PackageContentsBuilder()
        {
            applicationPackage = new ApplicationPackage();
            _applicationPackage = new ApplicationPackageBuilder(applicationPackage);
            _companyDetailsBuilder = new CompanyDetailsBuilder(applicationPackage.CompanyDetails);
            _components = new ComponentsBuilder(applicationPackage.Components);
        }

        /// <summary>
        /// Builds and serializes the <c>PackageContents.xml</c> file to the specified path.
        /// </summary>
        /// <param name="path">The directory path where the XML file will be saved.</param>
        /// <returns>The full file path of the generated <c>PackageContents.xml</c> file.</returns>
        public string Build(string path)
        {
            return applicationPackage.SerializeFile(path, "PackageContents.xml");
        }

        /// <summary>
        /// Returns the XML string representation of the application package.
        /// </summary>
        /// <returns>A string containing the serialized XML of the application package.</returns>
        public override string ToString()
        {
            return applicationPackage.SerializeObject();
        }
    }

}