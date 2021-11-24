namespace Autodesk.PackageBuilder
{
    public static class RevitUtils
    {
        /// <summary>
        /// Set <see cref="AutodeskProducts.Revit"/> and <see cref="ProductTypes.Application"/>.
        /// </summary>
        /// <param name="applicationPackageBuilder"></param>
        /// <returns></returns>
        public static ApplicationPackageBuilder RevitApplication(this ApplicationPackageBuilder applicationPackageBuilder)
        {
            return applicationPackageBuilder
                .ProductType(ProductTypes.Application)
                .AutodeskProduct(AutodeskProducts.Revit);
        }

        /// <summary>
        /// Set Win64 / Revit / R <paramref name="revitVersion"/> / R <paramref name="revitVersion"/>
        /// </summary>
        /// <param name="componentsBuilder"></param>
        /// <param name="revitVersion"></param>
        /// <returns></returns>
        public static ComponentsBuilder RevitPlatform(this ComponentsBuilder componentsBuilder, int revitVersion)
        {
            return componentsBuilder
                .OS("Win64")
                .Platform("Revit")
                .SeriesMin("R" + revitVersion)
                .SeriesMax("R" + revitVersion);
        }
    }

}