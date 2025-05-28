using System;

namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides utility extension methods for configuring AutoCAD-specific application packages and components.
/// </summary>
/// <remarks>
/// For more information, see the AutoCAD Developer Documentation:
/// https://help.autodesk.com/view/OARX/2025/ENU/?guid=GUID-BC76355D-682B-46ED-B9B7-66C95EEF2BD0
/// </remarks>
public static class AutoCADUtils
{
    private const string Os = "Win64";
    private const string Platform = "AutoCAD*"; // AutoCAD* - All AutoCAD-based products 

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for an AutoCAD application package.
    /// </summary>
    /// <param name="applicationPackageBuilder">The application package builder instance.</param>
    /// <returns>The <see cref="ApplicationPackageBuilder"/> instance for chaining.</returns>
    public static ApplicationPackageBuilder AutoCADApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.AutoCAD);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified AutoCAD version on Windows 64-bit.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="autoCADVersion">The AutoCAD version.</param>
    /// <returns>The <see cref="ComponentsBuilder"/> instance for chaining.</returns>
    /// <remarks>
    /// The platform is set to "AutoCAD*" to include all AutoCAD-based products.
    /// </remarks>
    public static ComponentsBuilder AutoCADPlatform(this ComponentsBuilder componentsBuilder, Version autoCADVersion)
    {
        return componentsBuilder.AutoCADPlatform(Os, Platform, autoCADVersion);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified OS, platform, and AutoCAD version.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="os">The operating system (e.g., "Win64").</param>
    /// <param name="platform">The platform (e.g., "AutoCAD*").</param>
    /// <param name="autoCADVersion">The AutoCAD version.</param>
    /// <returns>The <see cref="ComponentsBuilder"/> instance for chaining.</returns>
    /// <remarks>
    /// For more information, see the AutoCAD Developer Documentation:
    /// https://help.autodesk.com/view/OARX/2024/ENU/?guid=GUID-1591CA01-EF87-48CD-952B-772FE26037F1
    /// </remarks>
    public static ComponentsBuilder AutoCADPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, Version autoCADVersion)
    {
        return componentsBuilder.AutoCADPlatform(os, platform, autoCADVersion, autoCADVersion);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a range of AutoCAD versions on Windows 64-bit.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="minVersion">The minimum AutoCAD version.</param>
    /// <param name="maxVersion">The maximum AutoCAD version.</param>
    /// <param name="maxVersionMinusOne">If true, sets the maximum version to one less than <paramref name="maxVersion"/>.</param>
    /// <returns>The <see cref="ComponentsBuilder"/> instance for chaining.</returns>
    /// <remarks>
    /// The platform is set to "AutoCAD*" to include all AutoCAD-based products.
    /// </remarks>
    public static ComponentsBuilder AutoCADPlatform(this ComponentsBuilder componentsBuilder, Version minVersion, Version maxVersion, bool maxVersionMinusOne = false)
    {
        return componentsBuilder.AutoCADPlatform(Os, Platform, minVersion, maxVersion, maxVersionMinusOne);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a range of AutoCAD versions, with options for OS, platform, and version range.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <param name="os">The operating system (e.g., "Win64").</param>
    /// <param name="platform">The platform (e.g., "AutoCAD*").</param>
    /// <param name="minVersion">The minimum AutoCAD version.</param>
    /// <param name="maxVersion">The maximum AutoCAD version.</param>
    /// <param name="maxVersionMinusOne">If true, sets the maximum version to one less than <paramref name="maxVersion"/>.</param>
    /// <returns>The <see cref="ComponentsBuilder"/> instance for chaining.</returns>
    /// <remarks>
    /// For more information, see the AutoCAD Developer Documentation:
    /// https://help.autodesk.com/view/OARX/2024/ENU/?guid=GUID-1591CA01-EF87-48CD-952B-772FE26037F1
    /// </remarks>
    public static ComponentsBuilder AutoCADPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, Version minVersion, Version maxVersion, bool maxVersionMinusOne = false)
    {
        var minVersionString = "R" + minVersion.ToString(2);
        var maxVersionString = "R" + maxVersion?.ToString(2);

        componentsBuilder
            .OS(os)
            .Platform(platform)
            .SeriesMin(minVersionString);

        if (maxVersion is null)
            return componentsBuilder;

        componentsBuilder.SeriesMax(maxVersionString);

        if (minVersionString == maxVersionString)
            return componentsBuilder;

        if (maxVersionMinusOne)
        {
            var maxVersionMinus = maxVersion.Minor == 0 ?
                new Version(maxVersion.Major - 1, 9) :
                new Version(maxVersion.Major, maxVersion.Minor - 1);

            componentsBuilder.SeriesMax("R" + maxVersionMinus.ToString(2));
        }

        return componentsBuilder;
    }
}
