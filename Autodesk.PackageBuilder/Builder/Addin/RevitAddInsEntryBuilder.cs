namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    /// <summary>
    /// Provides a builder for <see cref="RevitAddIns"/> entries, enabling fluent construction and configuration of Revit add-in collections.
    /// </summary>
    public class RevitAddInsEntryBuilder : SingleBuilderBase<RevitAddInsEntryBuilder, RevitAddIns>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevitAddInsEntryBuilder"/> class with the specified <see cref="RevitAddIns"/> model.
        /// </summary>
        /// <param name="model">The <see cref="RevitAddIns"/> model to initialize the builder with.</param>
        public RevitAddInsEntryBuilder(RevitAddIns model)
        {
            SetDataInternal(model);
        }
    }
}