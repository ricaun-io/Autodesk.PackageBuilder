namespace Autodesk.PackageBuilder;

public interface IAddInEntryBuilder
{
    AddInEntryBuilder CreateEntry(string type = "Application");
}