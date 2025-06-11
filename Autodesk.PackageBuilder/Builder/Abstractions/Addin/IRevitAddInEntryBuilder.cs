namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Defines a builder interface for creating add-in entry configurations.
    /// </summary>
    public interface IRevitAddInEntryBuilder
    {
        /// <summary>
        /// Creates a new add-in entry with the specified type.
        /// </summary>
        /// <param name="type">The type of the add-in entry. Defaults to "Application".</param>
        /// <returns>
        /// An <see cref="RevitAddInEntryBuilder"/> instance for further configuration of the add-in entry.
        /// </returns>
        RevitAddInEntryBuilder CreateEntry(string type = "Application");
    }
}