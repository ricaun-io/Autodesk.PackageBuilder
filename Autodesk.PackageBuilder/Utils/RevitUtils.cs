namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides extension methods for configuring <see cref="ApplicationPackageBuilder"/> and <see cref="ComponentsBuilder"/> for Autodesk Revit.
/// </summary>
public static class RevitUtils
{
    /// <summary>
    /// The default operating system value for Revit components ("Win64").
    /// </summary>
    public const string Os = "Win64";
    /// <summary>
    /// The default platform value for Revit components ("Revit").
    /// </summary>
    public const string Platform = "Revit";

    /// <summary>
    /// Configures the <see cref="ApplicationPackageBuilder"/> for Autodesk Revit as an application product type.
    /// </summary>
    /// <param name="applicationPackageBuilder">The <see cref="ApplicationPackageBuilder"/> instance to configure.</param>
    /// <returns>
    /// The configured <see cref="ApplicationPackageBuilder"/> instance with
    /// <see cref="ProductTypes.Application"/> as the product type and
    /// <see cref="AutodeskProducts.Revit"/> as the Autodesk product.
    /// </returns>
    public static ApplicationPackageBuilder RevitApplication(this ApplicationPackageBuilder applicationPackageBuilder)
    {
        return applicationPackageBuilder
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Revit);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified Revit version, using "Win64" as the OS and "Revit" as the platform.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="version">The Revit version (e.g., 2024).</param>
    /// <returns>
    /// The configured <see cref="ComponentsBuilder"/> instance with the specified Revit version, "Win64" OS, and "Revit" platform.
    /// </returns>
    public static ComponentsBuilder RevitPlatform(this ComponentsBuilder componentsBuilder, int version)
    {
        return componentsBuilder.RevitPlatform(version, version);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified minimum and maximum Revit versions,
    /// using "Win64" as the OS and "Revit" as the platform.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="minVersion">The minimum Revit version (e.g., 2023).</param>
    /// <param name="maxVersion">The maximum Revit version (e.g., 2024).</param>
    /// <returns>
    /// The configured <see cref="ComponentsBuilder"/> instance with the specified minimum and maximum Revit versions,
    /// "Win64" OS, and "Revit" platform.
    /// </returns>
    public static ComponentsBuilder RevitPlatform(this ComponentsBuilder componentsBuilder, int minVersion, int maxVersion)
    {
        return componentsBuilder.RevitPlatform(Os, Platform, minVersion, maxVersion);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified OS, platform, and Revit version.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="os">The operating system (e.g., "Win64").</param>
    /// <param name="platform">The platform (e.g., "Revit").</param>
    /// <param name="version">The Revit version (e.g., 2024).</param>
    /// <returns>
    /// The configured <see cref="ComponentsBuilder"/> instance with the specified OS, platform, and Revit version.
    /// /// </returns>
    public static ComponentsBuilder RevitPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, int version)
    {
        return componentsBuilder.RevitPlatform(os, platform, version, version);
    }

    /// <summary>
    /// Configures the <see cref="ComponentsBuilder"/> for the specified operating system, platform, and Revit version range.
    /// </summary>
    /// <param name="componentsBuilder">The <see cref="ComponentsBuilder"/> instance to configure.</param>
    /// <param name="os">The operating system requirement (e.g., "Win64").</param>
    /// <param name="platform">The platform requirement (e.g., "Revit").</param>
    /// <param name="minVersion">The minimum supported Revit version (e.g., 2023).</param>
    /// <param name="maxVersion">The maximum supported Revit version (e.g., 2024).</param>
    /// <returns>
    /// The configured <see cref="ComponentsBuilder"/> instance with the specified OS, platform, and Revit version range.
    /// </returns>
    public static ComponentsBuilder RevitPlatform(this ComponentsBuilder componentsBuilder, string os, string platform, int minVersion, int maxVersion)
    {
        componentsBuilder.OS(os)
            .Platform(platform);

        if (minVersion > 0)
        {
            componentsBuilder.SeriesMin("R" + minVersion.ToString());
        }
        if (maxVersion > 0)
        {
            componentsBuilder.SeriesMax("R" + maxVersion.ToString());
        }

        return componentsBuilder;
    }
}