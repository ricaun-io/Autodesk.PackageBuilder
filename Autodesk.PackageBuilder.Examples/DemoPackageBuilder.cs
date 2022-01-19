namespace Examples
{
    using Autodesk.PackageBuilder;

    public class DemoPackageBuilder : PackageContentsBuilder
    {
        public DemoPackageBuilder()
        {
            ApplicationPackage
                .Create()
                .ProductType(ProductTypes.Application)
                .AutodeskProduct(AutodeskProducts.Revit)
                .Name("RevitAddin")
                .AppVersion("1.0.0");

            CompanyDetails
                .Create("Company Name")
                .Email("email")
                .Url("url");

            Components
                .CreateEntry("Revit 2021")
                .OS("Win64")
                .Platform("Revit")
                .SeriesMin("R2021")
                .SeriesMax("R2021")
                .AppName("RevitAddin")
                .ModuleName(@"./Contents/2021/RevitAddin.addin");

            Components
                .CreateEntry("Revit 2022")
                .RevitPlatform(2022)
                .AppName("RevitAddin")
                .ModuleName(@"./Contents/2022/RevitAddin.addin");
        }
    }
}
