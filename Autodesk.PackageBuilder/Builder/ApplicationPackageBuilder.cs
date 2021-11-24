namespace Autodesk.PackageBuilder
{
    using Model.Application;
    public class ApplicationPackageBuilder : SingleBuilderBase<ApplicationPackageBuilder, ApplicationPackage>, IApplicationPackageBuilder
    {
        public ApplicationPackageBuilder(ApplicationPackage applicationPackage)
        {
            SetDataInternal(applicationPackage);
        }
        public ApplicationPackageBuilder Create(
            string schemaVersion)
        {
            return SchemaVersion(schemaVersion);
        }
        private ApplicationPackageBuilder SchemaVersion(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder Name(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder AutodeskProduct(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder Description(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder AppVersion(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder FriendlyVersion(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder ProductType(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder ProductCode(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder Author(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder HelpFile(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder SupportedLocales(string value) => SetPropertyValue(value);
        public ApplicationPackageBuilder OnlineDocumentation(string value) => SetPropertyValue(value);
    }

}