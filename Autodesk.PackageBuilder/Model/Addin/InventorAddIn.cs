namespace Autodesk.PackageBuilder.Model.Addin;

using System;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Represents an Inventor Add-In definition for Autodesk Inventor packaging.
/// </summary>
/// <remarks>
/// For more information, see the Inventor Developer Documentation:
/// https://help.autodesk.com/view/INVNTOR/2024/ENU/?guid=GUID-52422162-1784-4E8F-B495-CDB7BE9987AB
/// </remarks>
[Serializable]
[XmlRoot("AddIn")]
public class InventorAddIn : ExtensibleData, IPackageSerializable
{
    /// <summary>
    /// Gets or sets the type of the add-in. Typically "Standard" or "Application".
    /// </summary>
    [XmlAttribute]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the COM class ID (GUID) of the add-in.
    /// </summary>
    [XmlElement]
    public string ClassId { get; set; }

    /// <summary>
    /// Gets or sets the client ID (GUID) of the add-in.
    /// </summary>
    [XmlElement]
    public string ClientId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the add-in as shown in Inventor.
    /// </summary>
    [XmlElement]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the description of the add-in.
    /// </summary>
    [XmlElement]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the path to the add-in assembly (DLL).
    /// </summary>
    [XmlElement]
    public string Assembly { get; set; }

    /// <summary>
    /// (Optional) Specifies whether the add-in should be allowed to load automatically as per the load behaviors defined by the add-in.
    /// </summary>
    /// <remarks>
    /// <code>
    /// This option can be specified using one of the following values:
    /// 0 - The add-in needs to be manually loaded using the add-in manager.
    /// 1 - The add-in can be loaded automatically as per the load behaviors defined by the add-in.
    /// Assumed to be 1 if this value is not specified. (add-in loads automatically)
    /// </code>
    /// </remarks>
    [XmlElement]
    public int? LoadAutomatically { get; set; }

    /// <summary>
    /// (Optional) Specifies when the add-in should be loaded in Inventor. This is important for better startup performance.
    /// </summary>
    /// <remarks>
    /// <code>
    /// This option can be specified using one of the following values:
    /// 0 - Load immediately on startup (not recommended)
    /// 1 - Load when any document is opened
    /// 1 - Load when a part document is opened (same as previous)
    /// 2 - Load when an assembly document is opened
    /// 3 - Load when a presentation document is opened
    /// 4 - Load when a drawing document is opened
    /// 10 - Load only on demand, either through the API or using the Add-In Manager.
    /// Assumed to be 0 if this value is not specified. (add-in loads immediately on startup)
    /// </code>
    /// </remarks>
    [XmlElement]
    public int? LoadBehavior { get; set; }

    /// <summary>
    /// (Optional) Specifies whether the add-in can be unloaded by the user using the Add-In Manager.
    /// </summary>
    /// <remarks>
    /// <code>
    /// This option can be specified using one of the following values:
    /// 0 - The add-in cannot be unloaded by the user.
    /// 1 - The add-in can be unloaded by the user.
    /// Assumed to be 1 if this value is not specified. (add-in is unloadable by user)
    /// </code>
    /// </remarks>
    [XmlElement]
    public int? UserUnloadable { get; set; }

    /// <summary>
    /// Specifies whether the add-in should be hidden in the Add-in Manager’s list of add-ins.
    /// </summary>
    /// <remarks>
    /// <code>
    /// This option can be specified using one of the following values:
    /// 0 - The add-in is visible in the Add-in Manager.
    /// 1 - The add-in is hidden in the Add-in Manager.
    /// Assumed to be 0 if this value is not specified. (add-in is visible)
    /// </code>
    /// </remarks>
    [XmlElement]
    public int? Hidden { get; set; }

    /// <summary>
    /// Gets or sets the exact Inventor version this add-in supports.
    /// </summary>
    [XmlElement]
    public string SupportedSoftwareVersionEqualTo { get; set; }

    /// <summary>
    /// Gets or sets the minimum Inventor version (exclusive) this add-in supports.
    /// </summary>
    [XmlElement]
    public string SupportedSoftwareVersionGreaterThan { get; set; }

    /// <summary>
    /// Gets or sets the maximum Inventor version (exclusive) this add-in supports.
    /// </summary>
    [XmlElement]
    public string SupportedSoftwareVersionLessThan { get; set; }

    /// <summary>
    /// Gets or sets the Inventor version this add-in does not support.
    /// </summary>
    [XmlElement]
    public string SupportedSoftwareVersionNotEqualTo { get; set; }
}