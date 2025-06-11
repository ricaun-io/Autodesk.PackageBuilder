namespace Autodesk.PackageBuilder;

/// <summary>
/// Defines a builder interface for constructing <see cref="InventorAddInEntryBuilder"/> instances
/// for Autodesk Inventor add-in packaging.
/// </summary>
public interface IInventorAddInEntryBuilder
{
    /// <summary>
    /// Creates a new <see cref="InventorAddInEntryBuilder"/> instance with the specified add-in type.
    /// </summary>
    /// <param name="type">
    /// The type of the add-in to create (e.g., "Standard" or "Application").
    /// Defaults to "Standard" if not specified.
    /// </param>
    /// <returns>
    /// An <see cref="InventorAddInEntryBuilder"/> instance for further configuration.
    /// </returns>
    InventorAddInEntryBuilder Create(string type = "Standard");
}