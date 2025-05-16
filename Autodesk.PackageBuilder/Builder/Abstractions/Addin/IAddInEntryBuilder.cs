namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Defines a builder interface for creating add-in entry configurations.
    /// </summary>
    public interface IAddInEntryBuilder
    {
        /// <summary>
        /// Creates a new add-in entry with the specified type.
        /// </summary>
        /// <param name="type">The type of the add-in entry. Defaults to "Application".</param>
        /// <returns>
        /// An <see cref="AddInEntryBuilder"/> instance for further configuration of the add-in entry.
        /// </returns>
        AddInEntryBuilder CreateEntry(string type = "Application");
    }
}