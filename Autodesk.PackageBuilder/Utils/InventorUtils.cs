namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides utility extension methods for configuring Inventor-specific application packages and components.
/// </summary>
/// <remarks>
/// For more information, see the Inventor Developer Documentation:
/// https://help.autodesk.com/view/INVNTOR/2024/ENU/?guid=GUID-52422162-1784-4E8F-B495-CDB7BE9987AB
/// </remarks>
public static class InventorUtils
{
    /// <summary>
    /// The default operating system for Inventor application packages (Windows 64-bit).
    /// </summary>
    public const string Os = "Win64";

    /// <summary>
    /// The default platform string for all Inventor-based products ("Inventor").
    /// </summary>
    public const string Platform = "Inventor";

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for an Inventor application package.
    /// </summary>
    /// <param name="applicationPackageBuilder">The application package builder instance.</param>
    /// <returns>
    /// The <see cref="ApplicationPackageBuilder"/> instance for chaining, configured for Inventor.
    /// </returns>
    public static ApplicationPackageBuilder InventorApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Inventor);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Inventor platform and operating system.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for Inventor's default OS and platform.
    /// </returns>
    public static ComponentsBuilder InventorPlatform(this ComponentsBuilder componentsBuilder)
    {
        return componentsBuilder
            .OS(Os)
            .Platform(Platform);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a specified operating system and platform.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="os">The operating system to set.</param>
    /// <param name="platform">The platform to set.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for the specified OS and platform.
    /// </returns>
    public static ComponentsBuilder InventorPlatform(this ComponentsBuilder componentsBuilder, string os, string platform)
    {
        return componentsBuilder
            .OS(os)
            .Platform(platform);
    }
}
