using Autodesk.PackageBuilder.Model.Addin;

namespace Autodesk.PackageBuilder;

public class AddInEntryBuilder : ListBuilderBase<AddInEntryBuilder, AddInModel>, IAddInEntryBuilder
{
    public AddInEntryBuilder(List<AddInModel> models)
    {
        SetDataInternal(models);
    }

    public AddInEntryBuilder CreateEntry(string type)
    {
        CreateEntryInternal();
        Type(type);
        return this;
    }

    private AddInEntryBuilder Type(string value) => SetPropertyValue(value);
    public AddInEntryBuilder Name(string value) => SetPropertyValue(value);
    public AddInEntryBuilder Assembly(string value) => SetPropertyValue(value);
    public AddInEntryBuilder AddInId(string value) => SetPropertyValue(value);
    public AddInEntryBuilder FullClassName(string value) => SetPropertyValue(value);
    public AddInEntryBuilder VendorId(string value) => SetPropertyValue(value);
    public AddInEntryBuilder VendorDescription(string value) => SetPropertyValue(value);
    public AddInEntryBuilder AllowLoadingIntoExistingSession(bool value) => SetPropertyValue(value);
}