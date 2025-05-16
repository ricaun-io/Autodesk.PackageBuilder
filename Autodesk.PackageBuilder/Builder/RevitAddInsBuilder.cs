namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    /// <summary>
    /// Provides a builder for creating and serializing Revit add-in configuration files (.addin).
    /// </summary>
    public class RevitAddInsBuilder : IBuilder
    {
        /// <summary>
        /// The <see cref="RevitAddIns"/> instance representing the collection of add-in entries.
        /// </summary>
        private readonly RevitAddIns revitAddIns;

        /// <summary>
        /// The builder for configuring the <see cref="RevitAddIns"/> entry.
        /// </summary>
        private readonly RevitAddInsEntryBuilder _revitAddInsEntryBuilder;

        /// <summary>
        /// The builder for configuring individual add-in entries.
        /// </summary>
        private readonly AddInEntryBuilder _addInEntryBuilder;

        /// <summary>
        /// Gets the builder for creating and configuring add-in entries.
        /// </summary>
        public IAddInEntryBuilder AddIn => _addInEntryBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevitAddInsBuilder"/> class.
        /// </summary>
        public RevitAddInsBuilder()
        {
            revitAddIns = new RevitAddIns();
            _revitAddInsEntryBuilder = new RevitAddInsEntryBuilder(revitAddIns);
            _addInEntryBuilder = new AddInEntryBuilder(revitAddIns.AddIn);
        }

        /// <summary>
        /// Builds and serializes the Revit add-in configuration to a .addin file at the specified path.
        /// </summary>
        /// <param name="path">The file path where the .addin file will be saved.</param>
        /// <returns>The full path to the serialized .addin file.</returns>
        public string Build(string path)
        {
            return revitAddIns.SerializeFile(path, ".addin");
        }

        /// <summary>
        /// Serializes the <see cref="RevitAddIns"/> object to its XML string representation.
        /// </summary>
        /// <returns>A string containing the XML representation of the Revit add-ins configuration.</returns>
        public override string ToString()
        {
            return revitAddIns.SerializeObject();
        }
    }

}