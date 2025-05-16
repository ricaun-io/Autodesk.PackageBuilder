namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    using System.Collections.Generic;
    /// <summary>
    /// Provides a builder for creating and configuring <see cref="AddInModel"/> entries.
    /// </summary>
    public class AddInEntryBuilder : ListBuilderBase<AddInEntryBuilder, AddInModel>, IAddInEntryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddInEntryBuilder"/> class with the specified list of <see cref="AddInModel"/> objects.
        /// </summary>
        /// <param name="models">The list of <see cref="AddInModel"/> objects to initialize the builder with.</param>
        public AddInEntryBuilder(List<AddInModel> models)
        {
            SetDataInternal(models);
        }

        /// <summary>
        /// Creates a new add-in entry and sets its type.
        /// </summary>
        /// <param name="type">The type of the add-in entry (e.g., "Application").</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder CreateEntry(string type)
        {
            CreateEntryInternal();
            Type(type);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="AddInModel.Type"/> property for the current entry.
        /// </summary>
        /// <param name="value">The type value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        private AddInEntryBuilder Type(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.Name"/> property for the current entry.
        /// </summary>
        /// <param name="value">The name value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder Name(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.Assembly"/> property for the current entry.
        /// </summary>
        /// <param name="value">The assembly value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder Assembly(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.AddInId"/> property for the current entry.
        /// </summary>
        /// <param name="value">The add-in ID value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder AddInId(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.FullClassName"/> property for the current entry.
        /// </summary>
        /// <param name="value">The fully qualified class name to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder FullClassName(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.VendorId"/> property for the current entry.
        /// </summary>
        /// <param name="value">The vendor ID value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder VendorId(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="AddInModel.VendorDescription"/> property for the current entry.
        /// </summary>
        /// <param name="value">The vendor description value to set.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        public AddInEntryBuilder VendorDescription(string value) => SetPropertyValue(value);

        /// <summary>
        /// (Obsolete) Sets the AllowLoadingIntoExistingSession property for the current entry.
        /// This method is obsolete and will be removed in a future version.
        /// </summary>
        /// <param name="value">A value indicating whether loading into an existing session is allowed.</param>
        /// <returns>The current <see cref="AddInEntryBuilder"/> instance for method chaining.</returns>
        [System.Obsolete("This method does not have a Property 'AllowLoadingIntoExistingSession' in class AddInModel, will be removed in a future version.")]
        internal AddInEntryBuilder AllowLoadingIntoExistingSession(bool value) => SetPropertyValue(value);
    }
}