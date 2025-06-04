namespace Autodesk.PackageBuilder
{
    using Model.Addin;
    using System.Collections.Generic;
    /// <summary>
    /// Provides a builder for creating and configuring <see cref="RevitAddInData"/> entries.
    /// </summary>
    public class RevitAddInEntryBuilder : ListBuilderBase<RevitAddInEntryBuilder, RevitAddInData>, IRevitAddInEntryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevitAddInEntryBuilder"/> class with the specified list of <see cref="RevitAddInData"/> objects.
        /// </summary>
        /// <param name="models">The list of <see cref="RevitAddInData"/> objects to initialize the builder with.</param>
        public RevitAddInEntryBuilder(List<RevitAddInData> models)
        {
            SetDataInternal(models);
        }

        /// <summary>
        /// Creates a new add-in entry and sets its type.
        /// </summary>
        /// <param name="type">The type of the add-in entry (e.g., "Application").</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder CreateEntry(string type)
        {
            CreateEntryInternal();
            Type(type);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="RevitAddInData.Type"/> property for the current entry.
        /// </summary>
        /// <param name="value">The type value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        private RevitAddInEntryBuilder Type(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.Name"/> property for the current entry.
        /// </summary>
        /// <param name="value">The name value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder Name(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.Assembly"/> property for the current entry.
        /// </summary>
        /// <param name="value">The assembly value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder Assembly(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.AddInId"/> property for the current entry.
        /// </summary>
        /// <param name="value">The add-in ID value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder AddInId(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.FullClassName"/> property for the current entry.
        /// </summary>
        /// <param name="value">The fully qualified class name to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder FullClassName(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.VendorId"/> property for the current entry.
        /// </summary>
        /// <param name="value">The vendor ID value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder VendorId(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the <see cref="RevitAddInData.VendorDescription"/> property for the current entry.
        /// </summary>
        /// <param name="value">The vendor description value to set.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        public RevitAddInEntryBuilder VendorDescription(string value) => SetPropertyValue(value);

        /// <summary>
        /// (Obsolete) Sets the AllowLoadingIntoExistingSession property for the current entry.
        /// This method is obsolete and will be removed in a future version.
        /// </summary>
        /// <param name="value">A value indicating whether loading into an existing session is allowed.</param>
        /// <returns>The current <see cref="RevitAddInEntryBuilder"/> instance for method chaining.</returns>
        [System.Obsolete("This method does not have a Property 'AllowLoadingIntoExistingSession' in class AddInModel, will be removed in a future version.")]
        internal RevitAddInEntryBuilder AllowLoadingIntoExistingSession(bool value) => SetPropertyValue(value);
    }
}