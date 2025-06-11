namespace Autodesk.PackageBuilder;

using Model.Addin;

/// <summary>
/// Provides a builder for creating and serializing Autodesk Inventor Add-In definitions.
/// </summary>
public class InventorAddInsBuilder : IBuilder
{
    /// <summary>
    /// The Inventor Add-In model instance being built.
    /// </summary>
    private readonly InventorAddIn inventorAddIns;

    /// <summary>
    /// The builder for configuring Inventor Add-In entry properties.
    /// </summary>
    private readonly InventorAddInEntryBuilder _inventorAddInsEntryBuilder;

    /// <summary>
    /// Gets the entry builder for configuring the Inventor Add-In.
    /// </summary>
    public IInventorAddInEntryBuilder AddIn => _inventorAddInsEntryBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventorAddInsBuilder"/> class.
    /// </summary>
    public InventorAddInsBuilder()
    {
        inventorAddIns = new InventorAddIn();
        _inventorAddInsEntryBuilder = new InventorAddInEntryBuilder(inventorAddIns);
    }

    /// <summary>
    /// Serializes the Inventor Add-In definition to a file at the specified path with a ".addin" extension.
    /// </summary>
    /// <param name="path">The file path where the add-in definition will be saved.</param>
    /// <returns>The full path to the serialized add-in file.</returns>
    public string Build(string path)
    {
        return inventorAddIns.SerializeFile(path, ".addin");
    }

    /// <summary>
    /// Serializes the Inventor Add-In definition to an XML string.
    /// </summary>
    /// <returns>The XML representation of the add-in definition.</returns>
    public override string ToString()
    {
        return inventorAddIns.SerializeObject();
    }
}