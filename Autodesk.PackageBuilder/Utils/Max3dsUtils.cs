namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides utility extension methods for configuring 3ds Max-specific application packages and components.
/// </summary>
/// <remarks>
/// For more information, see the 3ds Max Developer Documentation:
/// https://help.autodesk.com/view/3DSMAX/2019/ENU/?guid=__developer_writing_plug_ins_packaging_plugins_packagexml_example_html
/// </remarks>
public static class Max3dsUtils
{
    /// <summary>
    /// The default operating system for 3ds Max application packages (Windows 64-bit).
    /// </summary>
    public const string Os = "Win64";

    /// <summary>
    /// The default platform string for all 3ds Max-based products ("3ds Max").
    /// </summary>
    public const string Platform = "3ds Max";

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for a 3ds Max application package.
    /// </summary>
    /// <param name="applicationPackageBuilder">The application package builder instance.</param>
    /// <returns>
    /// The <see cref="ApplicationPackageBuilder"/> instance for chaining, configured for 3ds Max.
    /// </returns>
    public static ApplicationPackageBuilder Max3dsApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Max3ds);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default 3ds Max platform and operating system.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="max3dsMinVersion">The minimum supported 3ds Max version. If less than or equal to 0, the minimum version is not set.</param>
    /// <param name="max3dsMaxVersion">The maximum supported 3ds Max version. If less than or equal to 0, the maximum version is not set.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for 3ds Max's default OS and platform.
    /// </returns>
    public static ComponentsBuilder Max3dsPlatform(this ComponentsBuilder componentsBuilder, int max3dsMinVersion, int max3dsMaxVersion)
    {
        return componentsBuilder.Max3dsPlatform(max3dsMinVersion, max3dsMaxVersion);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a specified operating system, platform, and 3ds Max version range.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="os">The operating system to set (e.g., "Win64").</param>
    /// <param name="platform">The platform to set (e.g., "3ds Max").</param>
    /// <param name="max3dsMinVersion">The minimum supported 3ds Max version. If less than or equal to 0, the minimum version is not set.</param>
    /// <param name="max3dsMaxVersion">The maximum supported 3ds Max version. If less than or equal to 0, the maximum version is not set.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for the specified OS, platform, and version range.
    /// </returns>
    public static ComponentsBuilder Max3dsPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, int max3dsMinVersion, int max3dsMaxVersion)
    {
        componentsBuilder.OS(os)
            .Platform(platform);

        if (max3dsMinVersion > 0)
        {
            componentsBuilder.SeriesMin(max3dsMinVersion.ToString());
        }
        if (max3dsMaxVersion > 0)
        {
            componentsBuilder.SeriesMax(max3dsMaxVersion.ToString());
        }

        return componentsBuilder;
    }
}
