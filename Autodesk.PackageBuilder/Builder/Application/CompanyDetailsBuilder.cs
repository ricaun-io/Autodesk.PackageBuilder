namespace Autodesk.PackageBuilder
{
    using Model.Application;
    public class CompanyDetailsBuilder : SingleBuilderBase<CompanyDetailsBuilder, CompanyDetails>, ICompanyDetailsBuilder
    {
        public CompanyDetailsBuilder(CompanyDetails companyDetails)
        {
            SetDataInternal(companyDetails);
        }

        public CompanyDetailsBuilder Create(string name)
        {
            return Name(name);
        }

        private CompanyDetailsBuilder Name(string value) => SetPropertyValue(value);
        public CompanyDetailsBuilder Url(string value) => SetPropertyValue(value);
        public CompanyDetailsBuilder Email(string value) => SetPropertyValue(value);
    }

}