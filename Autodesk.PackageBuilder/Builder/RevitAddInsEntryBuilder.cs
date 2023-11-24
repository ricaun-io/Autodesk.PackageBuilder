using Autodesk.PackageBuilder.Model.Addin;

namespace Autodesk.PackageBuilder;

public class RevitAddInsEntryBuilder : SingleBuilderBase<RevitAddInsEntryBuilder, RevitAddIns>
{
    public RevitAddInsEntryBuilder(RevitAddIns model)
    {
        SetDataInternal(model);
    }
}