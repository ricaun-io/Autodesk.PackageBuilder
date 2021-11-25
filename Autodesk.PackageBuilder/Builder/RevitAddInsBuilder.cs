namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    public class RevitAddInsBuilder : IBuilder
    {
        private readonly RevitAddIns revitAddIns;

        private readonly RevitAddInsEntryBuilder _revitAddInsEntryBuilder;
        private readonly AddInEntryBuilder _addInEntryBuilder;

        public IAddInEntryBuilder AddIn => _addInEntryBuilder;

        public RevitAddInsBuilder()
        {
            revitAddIns = new RevitAddIns();
            _revitAddInsEntryBuilder = new RevitAddInsEntryBuilder(revitAddIns);
            _addInEntryBuilder = new AddInEntryBuilder(revitAddIns.AddIn);
        }

        public string Build(string path)
        {
            return revitAddIns.SerializeFile(path, ".addin");
        }

        public override string ToString()
        {
            return revitAddIns.SerializeObject();
        }
    }

}