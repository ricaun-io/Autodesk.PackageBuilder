using Autodesk.PackageBuilder;
using Autodesk.PackageBuilder.Model.Application;

namespace Autodesk.PackageBuilder.Extensible.Navisworks;

/// <summary>
/// Provides extension methods for adding extensible data to Navisworks components.
/// </summary>
/// <remarks>
/// For more information, see the Navisworks Developer Documentation:
/// https://aps.autodesk.com/app-store/publisher-center/navisworks
/// </remarks>
public static class NavisworksExtensibleData
{
    /// <summary>
    /// Adds an <c>AppType</c> attribute to the <see cref="ComponentsBuilder"/> extensible data.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to extend.</param>
    /// <param name="value">The value to assign to the <c>AppType</c> attribute.</param>
    /// <returns>The updated <see cref="ComponentsBuilder"/> instance.</returns>
    public static ComponentsBuilder AppType(this ComponentsBuilder componentsBuilder, string value = "ManagedPlugin")
    {
        componentsBuilder.DataBuilder.CreateAttribute<ComponentEntry>(nameof(AppType), value);
        return componentsBuilder;
    }
}