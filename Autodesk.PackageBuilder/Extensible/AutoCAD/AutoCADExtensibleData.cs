using Autodesk.PackageBuilder.Model.Application;

namespace Autodesk.PackageBuilder.Extensible.AutoCAD;

/// <summary>
/// Provides extension methods for configuring AutoCAD-specific extensible data on <see cref="ComponentsBuilder"/> instances.
/// </summary>
/// <remarks>
/// For more information, see the AutoCAD Developer Documentation:
/// https://help.autodesk.com/view/OARX/2025/ENU/?guid=GUID-3C25E517-8660-4BB7-9447-2310462EF06F
/// </remarks>
public static class AutoCADExtensibleData
{
    /// <summary>
    /// Sets the <c>LoadOnAppearance</c> attribute for the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="value">A value indicating whether the component should load on appearance.</param>
    /// <returns>The current <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
    /// <remarks>
    /// LoadOnAppearance. Load when the product detects the application bundle in one of the ApplicationPlugins folders, thereby supporting instant load on installation with no need to restart the AutoCAD-based product. The parameter behaves the same way as LoadOnAutoCADStartup except the load context is relevant to when an application is installed while the product is running, for instance if installed via the Autodesk App Store website. 
    /// </remarks>
    public static ComponentsBuilder LoadOnAppearance(this ComponentsBuilder componentsBuilder, bool value)
    {
        componentsBuilder.DataBuilder.CreateAttribute<ComponentEntry>("LoadOnAppearance", value);
        return componentsBuilder;
    }

    /// <summary>
    /// Adds command definitions to the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="globalLocalCommands">An array of command names to add as both global and local commands.</param>
    /// <returns>The current <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
    public static ComponentsBuilder Commands(this ComponentsBuilder componentsBuilder, params string[] globalLocalCommands)
    {
        return componentsBuilder.Commands(string.Empty, globalLocalCommands);
    }

    /// <summary>
    /// Adds command definitions to the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry, optionally grouping them.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="groupName">The group name for the commands, or an empty string for no group.</param>
    /// <param name="globalLocalCommands">An array of command names to add as both global and local commands.</param>
    /// <returns>The current <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
    public static ComponentsBuilder Commands(this ComponentsBuilder componentsBuilder, string groupName, params string[] globalLocalCommands)
    {
        if (globalLocalCommands.Length == 0)
            return componentsBuilder;

        var commandEntry = componentsBuilder.DataBuilder.CreateElement<ComponentEntry>("Commands");

        if (!string.IsNullOrWhiteSpace(groupName))
        {
            commandEntry.CreateAttribute("GroupName", groupName);
        }

        foreach (var globalLocalCommand in globalLocalCommands)
        {
            if (!string.IsNullOrWhiteSpace(globalLocalCommand)) continue;

            commandEntry.CreateElement("Command")
                .CreateAttribute("Global", globalLocalCommand)
                .CreateAttribute("Local", globalLocalCommand);
        }

        return componentsBuilder;
    }
}
