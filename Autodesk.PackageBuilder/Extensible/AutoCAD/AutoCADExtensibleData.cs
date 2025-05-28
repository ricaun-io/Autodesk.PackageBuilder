using Autodesk.PackageBuilder.Model.Application;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Autodesk.PackageBuilder.Extensible.AutoCAD;

/// <summary>
/// Provides extension methods for configuring AutoCAD-specific extensible data on <see cref="ComponentsBuilder"/> instances.
/// </summary>
/// <remarks>
/// For more information, see the AutoCAD Developer Documentation:
/// https://help.autodesk.com/view/OARX/2025/ENU/?guid=GUID-3C25E517-8660-4BB7-9447-2310462EF06F
/// </remarks>
public static partial class AutoCADExtensibleData
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
    public static ComponentsBuilder LoadOnAppearance(this ComponentsBuilder componentsBuilder, bool value = true)
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
    public static ComponentsBuilder Commands(this ComponentsBuilder componentsBuilder, params IEnumerable<string> globalLocalCommands)
    {
        return componentsBuilder.CommandGroups(string.Empty, globalLocalCommands);
    }

    /// <summary>
    /// Adds command definitions to the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry, optionally grouping them.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="groupName">The group name for the commands, or an empty string for no group.</param>
    /// <param name="globalLocalCommands">An array of command names to add as both global and local commands.</param>
    /// <returns>The current <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
    public static ComponentsBuilder CommandGroups(this ComponentsBuilder componentsBuilder, string groupName, params IEnumerable<string> globalLocalCommands)
    {
        if (globalLocalCommands is null)
            return componentsBuilder;

        if (!globalLocalCommands.Any())
            return componentsBuilder;

        var autoCADCommands = new AutoCADCommands();

        if (!string.IsNullOrWhiteSpace(groupName))
        {
            autoCADCommands.GroupName = groupName;
        }

        foreach (var globalLocalCommand in globalLocalCommands)
        {
            if (string.IsNullOrWhiteSpace(globalLocalCommand)) continue;

            autoCADCommands.Commands.Add(
                new AutoCADCommand
                {
                    Global = globalLocalCommand,
                    Local = globalLocalCommand
                });
        }

        componentsBuilder.DataBuilder.CreateElement<ComponentEntry>("Commands", autoCADCommands);

        return componentsBuilder;
    }

    /// <summary>
    /// Represents a collection of AutoCAD command definitions, optionally grouped by a name.
    /// </summary>
    public class AutoCADCommands : ExtensibleData
    {
        /// <summary>
        /// Gets or sets the group name for the commands. If not specified, commands are not grouped.
        /// </summary>
        [XmlAttribute("GroupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the list of AutoCAD command definitions.
        /// </summary>
        [XmlElement("Command")]
        public List<AutoCADCommand> Commands { get; set; } = new List<AutoCADCommand>();
    }

    /// <summary>
    /// Represents a single AutoCAD command definition with global and local names.
    /// </summary>
    public class AutoCADCommand : ExtensibleData
    {
        /// <summary>
        /// Gets or sets the global name of the command.
        /// </summary>
        [XmlAttribute("Global")]
        public string Global { get; set; }

        /// <summary>
        /// Gets or sets the local name of the command.
        /// </summary>
        [XmlAttribute("Local")]
        public string Local { get; set; }
    }
}
