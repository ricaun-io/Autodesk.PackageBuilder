namespace Examples
{
    using Autodesk.PackageBuilder;
    class Program
    {
        static void Main(string[] args)
        {
            BuildPackageFile();
            BuildPackageDemoFile();
            BuildAddinFile();
            BuildAddinDemoFile();
        }

        static void BuildPackageFile()
        {
            BuilderUtils.Build<PackageContentsBuilder>(builder =>
            {
                builder.ApplicationPackage
                    .Create()
                    .ProductType(ProductTypes.Application)
                    .AutodeskProduct(AutodeskProducts.Revit)
                    .Name("RevitAddin")
                    .AppVersion("1.0.0");

                builder.CompanyDetails
                    .Create("Company Name")
                    .Email("email")
                    .Url("url");

                builder.Components
                    .CreateEntry("Revit 2021")
                    .OS("Win64")
                    .Platform("Revit")
                    .SeriesMin("R2021")
                    .SeriesMax("R2021")
                    .AppName("RevitAddin")
                    .ModuleName(@"./Contents/2021/RevitAddin.addin");

                builder.Components
                    .CreateEntry("Revit 2022")
                    .RevitPlatform(2022)
                    .AppName("RevitAddin")
                    .ModuleName(@"./Contents/2022/RevitAddin.addin");
            }
            , "PackageContentsBuilder.xml");
        }

        static void BuildPackageDemoFile()
        {
            BuilderUtils.Build<DemoPackageBuilder>()
                .Build("DemoPackageBuilder.xml");
        }

        static void BuildAddinFile()
        {
            BuilderUtils.Build<RevitAddInsBuilder>(builder =>
            {
                builder.AddIn.CreateEntry("Application")
                    .Name("RevitAddin")
                    .AddInId("F6DB5994-D788-4060-9C97-16F6C1B07857")
                    .Assembly("RevitAddin.dll")
                    .FullClassName("RevitAddin.App")
                    .VendorId("RevitAddin")
                    .VendorDescription("RevitAddin");
            }, "RevitAddInsBuilder.addin");
        }

        static void BuildAddinDemoFile()
        {
            BuilderUtils.Build<DemoAddinBuilder>("DemoAddinBuilder.addin");
        }
    }
}
