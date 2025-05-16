namespace Autodesk.PackageBuilder
{
    using Model.Application;
    /// <summary>
    /// Provides a builder for constructing <see cref="CompanyDetails"/> instances.
    /// </summary>
    public class CompanyDetailsBuilder : SingleBuilderBase<CompanyDetailsBuilder, CompanyDetails>, ICompanyDetailsBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetailsBuilder"/> class with the specified <see cref="CompanyDetails"/> data.
        /// </summary>
        /// <param name="companyDetails">The <see cref="CompanyDetails"/> instance to initialize the builder with.</param>
        public CompanyDetailsBuilder(CompanyDetails companyDetails)
        {
            SetDataInternal(companyDetails);
        }

        /// <summary>
        /// Creates a new <see cref="CompanyDetailsBuilder"/> and sets the company name.
        /// </summary>
        /// <param name="name">The name of the company.</param>
        /// <returns>The current <see cref="CompanyDetailsBuilder"/> instance with the specified name set.</returns>
        public CompanyDetailsBuilder Create(string name)
        {
            return Name(name);
        }

        /// <summary>
        /// Sets the name of the company.
        /// </summary>
        /// <param name="value">The company name.</param>
        /// <returns>The current <see cref="CompanyDetailsBuilder"/> instance.</returns>
        private CompanyDetailsBuilder Name(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the URL of the company.
        /// </summary>
        /// <param name="value">The company URL.</param>
        /// <returns>The current <see cref="CompanyDetailsBuilder"/> instance.</returns>
        public CompanyDetailsBuilder Url(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the email address of the company.
        /// </summary>
        /// <param name="value">The company email address.</param>
        /// <returns>The current <see cref="CompanyDetailsBuilder"/> instance.</returns>
        public CompanyDetailsBuilder Email(string value) => SetPropertyValue(value);
    }

}