namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Defines a builder interface for creating <see cref="ApplicationPackageBuilder"/> instances.
    /// </summary>
    public interface IApplicationPackageBuilder
    {
        /// <summary>
        /// Creates a new <see cref="ApplicationPackageBuilder"/> instance with the specified schema version.
        /// </summary>
        /// <param name="schemaVersion">The schema version to use for the application package. Defaults to "1.0".</param>
        /// <returns>An <see cref="ApplicationPackageBuilder"/> instance initialized with the given schema version.</returns>
        ApplicationPackageBuilder Create(string schemaVersion = "1.0");
    }
}