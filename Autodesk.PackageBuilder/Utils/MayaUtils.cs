namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides utility extension methods for configuring Maya-specific application packages and components.
/// </summary>
/// <remarks>
/// For more information, see the Maya Developer Documentation:
/// https://help.autodesk.com/view/MAYAUL/2024/ENU/?guid=Maya_SDK_Distributing_Maya_Plug_ins_DistributingViaTheAppStore_html
/// </remarks>
public static class MayaUtils
{
    /// <summary>
    /// The default operating system for Maya application packages (Windows 64-bit).
    /// </summary>
    public const string Os = "Win64";

    /// <summary>
    /// The default platform string for all Maya-based products ("Maya").
    /// </summary>
    public const string Platform = "Maya";

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for a Maya application package.
    /// </summary>
    /// <param name="applicationPackageBuilder">The application package builder instance.</param>
    /// <returns>
    /// The <see cref="ApplicationPackageBuilder"/> instance for chaining, configured for Maya.
    /// </returns>
    public static ApplicationPackageBuilder MayaApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Maya);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Maya platform and operating system,
    /// targeting a specific Maya version.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="version">The Maya version to target.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for the specified Maya version.
    /// </returns>
    public static ComponentsBuilder MayaPlatform(this ComponentsBuilder componentsBuilder, int version)
    {
        return componentsBuilder.MayaPlatform(version, version);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Maya platform and operating system.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="minVersion">The minimum supported Maya version. If less than or equal to 0, the minimum version is not set.</param>
    /// <param name="maxVersion">The maximum supported Maya version. If less than or equal to 0, the maximum version is not set.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for Maya's default OS and platform.
    /// </returns>
    public static ComponentsBuilder MayaPlatform(this ComponentsBuilder componentsBuilder, int minVersion, int maxVersion)
    {
        return componentsBuilder.MayaPlatform(Os, Platform, minVersion, maxVersion);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a specified operating system, platform, and Maya version range.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="os">The operating system to set (e.g., "Win64").</param>
    /// <param name="platform">The platform to set (e.g., "Maya").</param>
    /// <param name="minVersion">The minimum supported Maya version. If less than or equal to 0, the minimum version is not set.</param>
    /// <param name="maxVersion">The maximum supported Maya version. If less than or equal to 0, the maximum version is not set.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for the specified OS, platform, and version range.
    /// </returns>
    public static ComponentsBuilder MayaPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, int minVersion, int maxVersion)
    {
        componentsBuilder.OS(os)
            .Platform(platform);

        if (minVersion > 0)
        {
            componentsBuilder.SeriesMin(minVersion.ToString());
        }
        if (maxVersion > 0)
        {
            componentsBuilder.SeriesMax(maxVersion.ToString());
        }

        return componentsBuilder;
    }
}
