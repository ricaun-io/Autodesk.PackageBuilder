using Autodesk.PackageBuilder.Model.Addin;

namespace Autodesk.PackageBuilder;

public class RevitAddInsBuilder : IBuilder
{
    private readonly RevitAddIns _revitAddIns;
    private readonly RevitAddInsEntryBuilder _revitAddInsEntryBuilder;
    private readonly AddInEntryBuilder _addInEntryBuilder;

    public IAddInEntryBuilder AddIn => _addInEntryBuilder;

    public RevitAddInsBuilder()
    {
        _revitAddIns = new RevitAddIns();
        _revitAddInsEntryBuilder = new RevitAddInsEntryBuilder(_revitAddIns);
        _addInEntryBuilder = new AddInEntryBuilder(_revitAddIns.AddIn);
    }

    public string Build(string path)
    {
        return _revitAddIns.SerializeFile(path, ".addin");
    }

    public override string ToString()
    {
        return _revitAddIns.SerializeObject();
    }
}