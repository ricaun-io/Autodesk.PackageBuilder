namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    public class RevitAddInsEntryBuilder : SingleBuilderBase<RevitAddInsEntryBuilder, RevitAddIns>
    {
        public RevitAddInsEntryBuilder(RevitAddIns model)
        {
            SetDataInternal(model);
        }
    }
}