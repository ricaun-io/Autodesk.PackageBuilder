namespace Autodesk.PackageBuilder;

using Model.Addin;
using System;

/// <summary>
/// Provides a builder for constructing <see cref="InventorAddIn"/> entries for Autodesk Inventor packaging.
/// </summary>
public class InventorAddInEntryBuilder : SingleBuilderBase<InventorAddInEntryBuilder, InventorAddIn>, IInventorAddInEntryBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventorAddInEntryBuilder"/> class with the specified <see cref="InventorAddIn"/> model.
    /// </summary>
    /// <param name="model">The <see cref="InventorAddIn"/> model to initialize the builder with.</param>
    public InventorAddInEntryBuilder(InventorAddIn model)
    {
        SetDataInternal(model);
    }

    /// <summary>
    /// Sets the type of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="type">The type of the add-in (e.g., "Standard" or "Application").</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder Create(string type)
    {
        return Type(type);
    }

    /// <summary>
    /// Converts a <see cref="Guid"/> to a string in "B" format and upper case.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> to convert.</param>
    /// <returns>The string representation of the GUID in "B" format and upper case.</returns>
    private string GuidToString(Guid guid)
    {
        return guid.ToString("B").ToUpperInvariant();
    }

    /// <summary>
    /// Sets the type of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The type value to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    private InventorAddInEntryBuilder Type(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the COM class ID (GUID) of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The class ID as a string.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder ClassId(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the COM class ID (GUID) of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The class ID as a <see cref="Guid"/>.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder ClassId(Guid value) => ClassId(GuidToString(value));

    /// <summary>
    /// Sets the client ID (GUID) of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The client ID as a string.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder ClientId(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the client ID (GUID) of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The client ID as a <see cref="Guid"/>.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder ClientId(Guid value) => ClientId(GuidToString(value));

    /// <summary>
    /// Sets the display name of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The display name to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder DisplayName(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the description of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The description to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder Description(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the assembly path of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The assembly path to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder Assembly(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets whether the add-in should load automatically and returns the builder instance.
    /// </summary>
    /// <param name="value">1 to load automatically, 0 otherwise.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder LoadAutomatically(int? value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the load behavior of the add-in and returns the builder instance.
    /// </summary>
    /// <param name="value">The load behavior value to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder LoadBehavior(int? value) => SetPropertyValue(value);

    /// <summary>
    /// Sets whether the add-in can be unloaded by the user and returns the builder instance.
    /// </summary>
    /// <param name="value">1 if user can unload, 0 otherwise.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder UserUnloadable(int? value) => SetPropertyValue(value);

    /// <summary>
    /// Sets whether the add-in is hidden in the Add-in Manager and returns the builder instance.
    /// </summary>
    /// <param name="value">1 if hidden, 0 otherwise.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder Hidden(int? value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the exact Inventor version this add-in supports and returns the builder instance.
    /// </summary>
    /// <param name="value">The version string to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder SupportedSoftwareVersionEqualTo(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the minimum Inventor version (exclusive) this add-in supports and returns the builder instance.
    /// </summary>
    /// <param name="value">The version string to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder SupportedSoftwareVersionGreaterThan(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the maximum Inventor version (exclusive) this add-in supports and returns the builder instance.
    /// </summary>
    /// <param name="value">The version string to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder SupportedSoftwareVersionLessThan(string value) => SetPropertyValue(value);

    /// <summary>
    /// Sets the Inventor version this add-in does not support and returns the builder instance.
    /// </summary>
    /// <param name="value">The version string to set.</param>
    /// <returns>The current <see cref="InventorAddInEntryBuilder"/> instance.</returns>
    public InventorAddInEntryBuilder SupportedSoftwareVersionNotEqualTo(string value) => SetPropertyValue(value);

}