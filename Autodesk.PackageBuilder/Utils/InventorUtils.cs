using System;

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

    /// <summary>
    /// Configures the supported Inventor software version for the add-in entry builder using an integer major version.
    /// </summary>
    /// <param name="builder">The <see cref="InventorAddInEntryBuilder"/> instance to configure.</param>
    /// <param name="version">The major version of Inventor to support.</param>
    /// <returns>
    /// The <see cref="InventorAddInEntryBuilder"/> instance for chaining, configured with the specified supported software version.
    /// </returns>
    public static InventorAddInEntryBuilder SupportedSoftwareVersion(this InventorAddInEntryBuilder builder, int version)
    {
        return builder.SupportedSoftwareVersion(new Version(version, 0));
    }

    /// <summary>
    /// Configures the supported Inventor software version for the add-in entry builder using a <see cref="Version"/> object.
    /// </summary>
    /// <param name="builder">The <see cref="InventorAddInEntryBuilder"/> instance to configure.</param>
    /// <param name="version">The <see cref="Version"/> of Inventor to support.</param>
    /// <returns>
    /// The <see cref="InventorAddInEntryBuilder"/> instance for chaining, configured with the specified supported software version.
    /// </returns>
    public static InventorAddInEntryBuilder SupportedSoftwareVersion(this InventorAddInEntryBuilder builder, Version version)
    {
        return builder.SupportedSoftwareVersion(version, version);
    }

    /// <summary>
    /// Configures the supported Inventor software version range for the add-in entry builder using integer major versions.
    /// </summary>
    /// <param name="builder">The <see cref="InventorAddInEntryBuilder"/> instance to configure.</param>
    /// <param name="minVersion">The minimum supported major version (inclusive if equal to <paramref name="maxVersion"/>, otherwise exclusive).</param>
    /// <param name="maxVersion">
    /// The maximum supported major version (exclusive by default, or inclusive if <paramref name="maxVersionMinusOne"/> is <c>true</c>).
    /// </param>
    /// <param name="maxVersionMinusOne">
    /// If <c>true</c>, the maximum version is treated as inclusive (i.e., less than or equal to <paramref name="maxVersion"/>).
    /// If <c>false</c> (default), the maximum version is exclusive (i.e., less than <paramref name="maxVersion"/> plus one).
    /// </param>
    /// <returns>
    /// The <see cref="InventorAddInEntryBuilder"/> instance for chaining, configured with the specified supported software version range.
    /// </returns>
    public static InventorAddInEntryBuilder SupportedSoftwareVersion(this InventorAddInEntryBuilder builder, int minVersion, int maxVersion, bool maxVersionMinusOne = false)
    {
        return builder.SupportedSoftwareVersion(new Version(minVersion, 0), new Version(maxVersion, 0), maxVersionMinusOne);
    }

    /// <summary>
    /// Configures the supported Inventor software version range for the add-in entry builder.
    /// </summary>
    /// <param name="builder">The <see cref="InventorAddInEntryBuilder"/> instance to configure.</param>
    /// <param name="minVersion">The minimum supported <see cref="Version"/> (inclusive if equal to <paramref name="maxVersion"/>, otherwise exclusive).</param>
    /// <param name="maxVersion">
    /// The maximum supported <see cref="Version"/> (exclusive by default, or inclusive if <paramref name="maxVersionMinusOne"/> is <c>true</c>).
    /// If <c>null</c>, no upper bound is set.
    /// </param>
    /// <param name="maxVersionMinusOne">
    /// If <c>true</c>, the maximum version is treated as inclusive (i.e., less than or equal to <paramref name="maxVersion"/>).
    /// If <c>false</c> (default), the maximum version is exclusive (i.e., less than <paramref name="maxVersion"/> plus one).
    /// </param>
    /// <returns>
    /// The <see cref="InventorAddInEntryBuilder"/> instance for chaining, configured with the specified supported software version range.
    /// </returns>
    public static InventorAddInEntryBuilder SupportedSoftwareVersion(this InventorAddInEntryBuilder builder, Version minVersion, Version maxVersion, bool maxVersionMinusOne = false)
    {
        var minVersionString = minVersion.ToMajorString();
        var maxVersionString = maxVersion?.ToMajorString();

        if (minVersionString == maxVersionString)
        {
            return builder.SupportedSoftwareVersionEqualTo(minVersionString);
        }

        var greaterVersionString = minVersion.ToMajorString(-1);
        builder.SupportedSoftwareVersionGreaterThan(greaterVersionString);

        if (maxVersion is null || maxVersion.Major == 0)
            return builder;

        var lessVersionString = maxVersion.ToMajorString(1);
        if (maxVersionMinusOne)
        {
            lessVersionString = maxVersionString;
        }

        builder.SupportedSoftwareVersionLessThan(lessVersionString);

        return builder;
    }


    /// <summary>
    /// Converts a <see cref="Version"/> object to a string containing only its major version followed by two dots.
    /// </summary>
    /// <param name="version">The <see cref="Version"/> instance to convert.</param>
    /// <param name="majorPlus">An optional value to add to the major version before converting to string.</param>
    /// <returns>
    /// A string in the format "{major}..", where {major} is the major version number of the specified <paramref name="version"/> plus <paramref name="majorPlus"/>.
    /// Returns <c>null</c> if <paramref name="version"/> is <c>null</c>.
    /// </returns>
    private static string ToMajorString(this Version version, int majorPlus = 0)
    {
        if (version is null)
            return null;

        return $"{version.Major + majorPlus}..";
    }
}
