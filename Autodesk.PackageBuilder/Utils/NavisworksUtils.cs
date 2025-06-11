using System;

namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides utility extension methods for configuring Navisworks-specific application packages and components.
/// </summary>
/// <remarks>
/// For more information, see the Navisworks Developer Documentation:
/// https://aps.autodesk.com/developer/overview/navisworks
/// https://adndevblog.typepad.com/aec/navisworks/
/// </remarks>
public static class NavisworksUtils
{
    /// <summary>
    /// The default operating system for Navisworks application packages (Windows 64-bit).
    /// </summary>
    public const string Os = "Win64";

    /// <summary>
    /// The default platform string for all Navisworks-based products ("NAVMAN|NAVSIM").
    /// </summary>
    public const string Platform = "NAVMAN|NAVSIM";

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for a Navisworks application package.
    /// </summary>
    /// <param name="applicationPackageBuilder">The application package builder instance.</param>
    /// <returns>
    /// The <see cref="ApplicationPackageBuilder"/> instance for chaining, configured for Navisworks.
    /// </returns>
    public static ApplicationPackageBuilder NavisworksApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Navisworks);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Navisworks platform and operating system.
    /// </summary>
    /// <param name="componentsBuilder">The components builder instance.</param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for Navisworks's default OS and platform.
    /// </returns>
    public static ComponentsBuilder NavisworksPlatform(this ComponentsBuilder componentsBuilder)
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
    public static ComponentsBuilder NavisworksPlatform(this ComponentsBuilder componentsBuilder, string os, string platform)
    {
        return componentsBuilder
            .OS(os)
            .Platform(platform);
    }

    ///<summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Navisworks platform and operating system,
    /// and restricts the supported internal Navisworks version range using integer major versions.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="minInternalVersion">The minimum supported internal Navisworks version as an integer.</param>
    /// <param name="maxInternalVersion">The maximum supported internal Navisworks version as an integer.</param>
    /// <param name="maxVersionMinusOne">
    /// If <c>true</c>, the maximum version is treated as inclusive (i.e., less than or equal to <paramref name="maxInternalVersion"/>).
    /// If <c>false</c> (default), the maximum version is exclusive (i.e., less than <paramref name="maxInternalVersion"/> minus one).
    /// </param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for Navisworks's default OS, platform, and version range.
    /// </returns>
    public static ComponentsBuilder NavisworksPlatform(this ComponentsBuilder componentsBuilder, int minInternalVersion, int maxInternalVersion, bool maxVersionMinusOne = false)
    {
        return componentsBuilder.NavisworksPlatform(new Version(minInternalVersion, 0), new Version(maxInternalVersion, 0), maxVersionMinusOne);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the default Navisworks platform and operating system,
    /// and restricts the supported internal Navisworks version range.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="minVersion">The minimum supported internal Navisworks version as a <see cref="Version"/>.</param>
    /// <param name="maxVersion">The maximum supported internal Navisworks version as a <see cref="Version"/>.</param>
    /// <param name="maxVersionMinusOne">
    /// If <c>true</c>, the maximum version is treated as inclusive (i.e., less than or equal to <paramref name="maxVersion"/>).
    /// If <c>false</c> (default), the maximum version is exclusive (i.e., less than <paramref name="maxVersion"/> minus one).
    /// </param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for Navisworks's default OS, platform, and version range.
    /// </returns>
    public static ComponentsBuilder NavisworksPlatform(this ComponentsBuilder componentsBuilder, Version minVersion, Version maxVersion, bool maxVersionMinusOne = false)
    {
        return componentsBuilder.NavisworksPlatform(Os, Platform, minVersion, maxVersion, maxVersionMinusOne);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for a specified operating system, platform, and Navisworks version range.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="os">The operating system to set (e.g., "Win64").</param>
    /// <param name="platform">The platform to set (e.g., "NAVMAN|NAVSIM").</param>
    /// <param name="minVersion">The minimum supported internal Navisworks version as a <see cref="Version"/>.</param>
    /// <param name="maxVersion">The maximum supported internal Navisworks version as a <see cref="Version"/>. If <c>null</c> or major is 0, no upper bound is set.</param>
    /// <param name="maxVersionMinusOne">
    /// If <c>true</c>, the maximum version is treated as inclusive (i.e., less than or equal to <paramref name="maxVersion"/>).
    /// If <c>false</c> (default), the maximum version is exclusive (i.e., less than <paramref name="maxVersion"/> minus one).
    /// </param>
    /// <returns>
    /// The <see cref="ComponentsBuilder"/> instance for chaining, configured for the specified OS, platform, and version range.
    /// </returns>
    public static ComponentsBuilder NavisworksPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, Version minVersion, Version maxVersion, bool maxVersionMinusOne = false)
    {
        var minVersionString = minVersion.ToNavisworksMajorString();
        var maxVersionString = maxVersion?.ToNavisworksMajorString();

        componentsBuilder
            .OS(os)
            .Platform(platform)
            .SeriesMin(minVersionString);

        if (minVersionString == maxVersionString)
        {
            return componentsBuilder
                .SeriesMax(maxVersionString);
        }

        if (maxVersion is null || maxVersion.Major == 0)
            return componentsBuilder;

        if (maxVersionMinusOne)
        {
            maxVersionString = maxVersion.ToNavisworksMajorString(-1);
        }

        return componentsBuilder
            .SeriesMax(maxVersionString);
    }

    
    ///<summary>
    /// Converts a <see cref="Version"/> object to a Navisworks major version string (e.g., "Nw21").
    /// </summary>
    /// <param name="version">The <see cref="Version"/> instance to convert.</param>
    /// <param name="majorPlus">
    /// An optional integer to add to the major version. Defaults to 0.
    /// Use negative values to decrement the major version (e.g., for exclusive upper bounds).
    /// </param>
    /// <returns>
    /// A string in the format "Nw{major}", or <c>null</c> if <paramref name="version"/> is <c>null</c>.
    /// </returns>
    private static string ToNavisworksMajorString(this Version version, int majorPlus = 0)
    {
        if (version is null)
            return null;

        return $"Nw{version.Major + majorPlus}";
    }
}
