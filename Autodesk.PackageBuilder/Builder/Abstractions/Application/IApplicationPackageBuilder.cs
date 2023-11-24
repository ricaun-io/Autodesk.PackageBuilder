namespace Autodesk.PackageBuilder
{
    public interface IApplicationPackageBuilder
    {
        ApplicationPackageBuilder Create(string schemaVersion = "1.0");
    }
}