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

        /// <summary>
        /// Build and serialize the .addin file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Build(string path)
        {
            return revitAddIns.SerializeFile(path, ".addin");
        }

        /// <summary>
        /// Serialize the RevitAddIns object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return revitAddIns.SerializeObject();
        }
    }

}