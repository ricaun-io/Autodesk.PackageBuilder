namespace Autodesk.PackageBuilder
{
    using Model.Application;
    using System;

    /// <summary>
    /// Provides a builder for constructing <see cref="ApplicationPackage"/> instances with a fluent API.
    /// </summary>
    public class ApplicationPackageBuilder : SingleBuilderBase<ApplicationPackageBuilder, ApplicationPackage>, IApplicationPackageBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationPackageBuilder"/> class with the specified <see cref="ApplicationPackage"/> data.
        /// </summary>
        /// <param name="applicationPackage">The application package data to initialize the builder with.</param>
        public ApplicationPackageBuilder(ApplicationPackage applicationPackage)
        {
            SetDataInternal(applicationPackage);
        }

        /// <summary>
        /// Creates a new <see cref="ApplicationPackageBuilder"/> instance with the specified schema version.
        /// </summary>
        /// <param name="schemaVersion">The schema version to set for the application package.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder Create(string schemaVersion)
        {
            return SchemaVersion(schemaVersion);
        }

        /// <summary>
        /// Sets the schema version for the application package.
        /// </summary>
        /// <param name="value">The schema version value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        private ApplicationPackageBuilder SchemaVersion(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the name of the application package.
        /// </summary>
        /// <param name="value">The name value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder Name(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the Autodesk product associated with the application package.
        /// </summary>
        /// <param name="value">The Autodesk product value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder AutodeskProduct(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the description of the application package.
        /// </summary>
        /// <param name="value">The description value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder Description(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the application version as a string.
        /// </summary>
        /// <param name="value">The application version value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder AppVersion(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the application version using a <see cref="Version"/> object.
        /// </summary>
        /// <param name="value">The application version as a <see cref="Version"/>.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder AppVersion(Version value) => SetPropertyValue(value.ToString());

        /// <summary>
        /// Sets the user-friendly version string for the application package.
        /// </summary>
        /// <param name="value">The friendly version value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder FriendlyVersion(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the product type of the application package.
        /// </summary>
        /// <param name="value">The product type value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder ProductType(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the product code of the application package as a string.
        /// </summary>
        /// <param name="value">The product code value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder ProductCode(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the product code of the application package using a <see cref="Guid"/>.
        /// The GUID will be formatted with uppercase letters and braces, e.g. "{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}".
        /// </summary>
        /// <param name="value">The product code as a <see cref="Guid"/>.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder ProductCode(Guid value) => SetPropertyValue(value.ToStringBraces());

        /// <summary>
        /// Sets the application namespace associated with the application package.
        /// </summary>
        /// <param name="value">The application namespace value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder AppNameSpace(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the upgrade code of the application package as a string.
        /// </summary>
        /// <param name="value">The upgrade code value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder UpgradeCode(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the upgrade code of the application package using a <see cref="Guid"/>.
        /// The GUID will be formatted with uppercase letters and braces, e.g. "{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}".
        /// </summary>
        /// <param name="value">The upgrade code as a <see cref="Guid"/>.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder UpgradeCode(Guid value) => UpgradeCode(value.ToStringBraces());

        /// <summary>
        /// Sets the author of the application package.
        /// </summary>
        /// <param name="value">The author value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder Author(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the help file associated with the application package.
        /// </summary>
        /// <param name="value">The help file value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder HelpFile(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the supported locales for the application package.
        /// </summary>
        /// <param name="value">The supported locales value.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder SupportedLocales(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the URL to the online documentation for the application package.
        /// </summary>
        /// <param name="value">The online documentation URL.</param>
        /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
        public ApplicationPackageBuilder OnlineDocumentation(string value) => SetPropertyValue(value);
    }

}