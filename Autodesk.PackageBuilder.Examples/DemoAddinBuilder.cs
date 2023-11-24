namespace Examples;

public class DemoAddinBuilder : RevitAddInsBuilder
{
    public DemoAddinBuilder()
    {
        AddIn.CreateEntry("Application")
            .Name("RevitAddin")
            .AddInId("F6DB5994-D788-4060-9C97-16F6C1B07857")
            .Assembly("RevitAddin.dll")
            .FullClassName("RevitAddin.App")
            .VendorId("RevitAddin")
            .VendorDescription("RevitAddin");
    }
}