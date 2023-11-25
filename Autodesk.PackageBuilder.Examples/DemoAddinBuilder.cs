
namespace Examples
{
    using Autodesk.PackageBuilder;
    public class DemoAddinBuilder : RevitAddInsBuilder
    {
        public DemoAddinBuilder()
        {
            AddIn.CreateEntry("Application")
                .Name("RevitAddin")
                .Assembly("RevitAddin.dll")
                .AddInId("11111111-2222-3333-4444-555555555555")
                .FullClassName("RevitAddin.App")
                .VendorId("RevitAddin")
                .VendorDescription("RevitAddin");
        }
    }
}
