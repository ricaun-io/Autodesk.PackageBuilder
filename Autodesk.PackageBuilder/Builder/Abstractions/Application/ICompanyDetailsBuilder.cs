namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Defines a builder interface for creating <see cref="CompanyDetailsBuilder"/> instances.
    /// </summary>
    public interface ICompanyDetailsBuilder
    {
        /// <summary>
        /// Creates a new <see cref="CompanyDetailsBuilder"/> for the specified company name.
        /// </summary>
        /// <param name="name">The name of the company.</param>
        /// <returns>
        /// A <see cref="CompanyDetailsBuilder"/> instance initialized with the specified company name.
        /// </returns>
        CompanyDetailsBuilder Create(string name);
    }
}