namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Provides a base builder for constructing and manipulating <see cref="DataBase"/> objects.
    /// </summary>
    public class DataBuilderBase : SingleBuilderBase<DataBuilderBase, DataBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuilderBase"/> class with the specified <see cref="DataBase"/> model.
        /// </summary>
        /// <param name="model">The <see cref="DataBase"/> instance to wrap and build upon.</param>
        public DataBuilderBase(DataBase model)
        {
            SetDataInternal(model);
        }

        /// <summary>
        /// Creates a new data attribute with the specified name and value in the underlying <see cref="DataBase"/>.
        /// </summary>
        /// <param name="name">The name of the attribute to create.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The current <see cref="DataBuilderBase"/> instance for method chaining.</returns>
        public DataBuilderBase CreateDataAttribute(string name, object value)
        {
            Data.CreateAttribute(name, value);
            return this;
        }

        /// <summary>
        /// Creates a new data element with the specified name and returns a builder for the new element.
        /// </summary>
        /// <param name="name">The name of the data element to create.</param>
        /// <returns>A new <see cref="DataBuilderBase"/> instance for the created data element.</returns>
        public DataBuilderBase CreateDataElement(string name)
        {
            return new DataBuilderBase(Data.CreateEntryElement(name));
        }

        /// <summary>
        /// Creates a new data element with the specified name and value, and returns a builder for the new element.
        /// </summary>
        /// <typeparam name="TElement">The type of the data element, which must derive from <see cref="DataBase"/>.</typeparam>
        /// <param name="name">The name of the data element to create.</param>
        /// <param name="value">The value of the data element.</param>
        /// <returns>A new <see cref="DataBuilderBase"/> instance for the created data element.</returns>
        public DataBuilderBase CreateDataElement<TElement>(string name, TElement value) where TElement : DataBase
        {
            return new DataBuilderBase(Data.CreateEntryElement(name, value));
        }
    }
}