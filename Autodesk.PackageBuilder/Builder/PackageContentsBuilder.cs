namespace Autodesk.PackageBuilder
{
    using Model.Application;

    public class PackageContentsBuilder : IBuilder
    {
        private readonly ApplicationPackage applicationPackage;

        private readonly ApplicationPackageBuilder _applicationPackage;
        private readonly CompanyDetailsBuilder _companyDetailsBuilder;
        private readonly ComponentsBuilder _components;

        public IApplicationPackageBuilder ApplicationPackage => _applicationPackage;

        public ICompanyDetailsBuilder CompanyDetails => _companyDetailsBuilder;

        public IComponentsEntryBuilder Components => _components;

        public PackageContentsBuilder()
        {
            applicationPackage = new ApplicationPackage();
            _applicationPackage = new ApplicationPackageBuilder(applicationPackage);
            _companyDetailsBuilder = new CompanyDetailsBuilder(applicationPackage.CompanyDetails);
            _components = new ComponentsBuilder(applicationPackage.Components);
        }

        /// <summary>
        /// Build and serialize the PackageContents.xml file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Build(string path)
        {
            return applicationPackage.SerializeFile(path, "PackageContents.xml");
        }

        public override string ToString()
        {
            return applicationPackage.SerializeObject();
        }
    }

}