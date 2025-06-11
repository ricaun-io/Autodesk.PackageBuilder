namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Provides a base builder for constructing and manipulating <see cref="ExtensibleData"/> objects.
    /// </summary>
    /// <remarks>
    /// This builder offers a fluent API for creating and modifying attributes and elements
    /// within a <see cref="ExtensibleData"/> instance. It supports both direct manipulation of the
    /// underlying data model and creation of nested elements or attributes using generic overloads.
    /// </remarks>
    public class DataBuilderBase : SingleBuilderBase<DataBuilderBase, ExtensibleData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuilderBase"/> class with the specified <see cref="ExtensibleData"/> model.
        /// </summary>
        /// <param name="model">The <see cref="ExtensibleData"/> instance to wrap and build upon.</param>
        public DataBuilderBase(ExtensibleData model)
        {
            SetDataInternal(model);
        }

        /// <summary>
        /// Creates a new data attribute with the specified name and value in the underlying <see cref="ExtensibleData"/>.
        /// </summary>
        /// <param name="name">The name of the attribute to create.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The current <see cref="DataBuilderBase"/> instance for method chaining.</returns>
        public DataBuilderBase CreateAttribute(string name, object value)
        {
            Data.CreateDataAttribute(name, value);
            return this;
        }

        /// <summary>
        /// Creates a new data element with the specified name and returns a builder for the new element.
        /// </summary>
        /// <param name="name">The name of the data element to create.</param>
        /// <returns>A new <see cref="DataBuilderBase"/> instance for the created data element.</returns>
        public DataBuilderBase CreateElement(string name)
        {
            return new DataBuilderBase(Data.CreateDataElement(name));
        }

        /// <summary>
        /// Creates a new data element with the specified name and value in the underlying <see cref="ExtensibleData"/>.
        /// </summary>
        /// <param name="name">The name of the data element to create.</param>
        /// <param name="value">
        /// The value to associate with the new data element. If the value is a <see cref="ExtensibleData"/>, it will be used to create a nested element.
        /// Otherwise, the value will be set directly.
        /// </param>
        /// <returns>
        /// A new <see cref="DataBuilderBase"/> instance for the created data element if <paramref name="value"/> is a <see cref="ExtensibleData"/>; otherwise, <c>null</c>.
        /// </returns>
        public DataBuilderBase CreateElement(string name, object value)
        {
            if (value is ExtensibleData extensibleData)
                return new DataBuilderBase(Data.CreateDataElement(name, extensibleData));

            Data.CreateDataElement(name, value);
            return null;
        }

        /// <summary>
        /// Creates a new data attribute with the specified name and value in a new instance of <typeparamref name="T"/> derived from <see cref="ExtensibleData"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ExtensibleData"/> to use for creating the attribute. Must have a parameterless constructor.</typeparam>
        /// <param name="name">The name of the attribute to create.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The current <see cref="DataBuilderBase"/> instance for method chaining.</returns>
        public DataBuilderBase CreateAttribute<T>(string name, object value) where T : ExtensibleData, new()
        {
            var data = GetNewPropertyValue<T>(Data);
            data.CreateDataAttribute(name, value);
            return this;
        }

        /// <summary>
        /// Creates a new data element with the specified name in a new instance of <typeparamref name="T"/> derived from <see cref="ExtensibleData"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ExtensibleData"/> to use for creating the element. Must have a parameterless constructor.</typeparam>
        /// <param name="name">The name of the data element to create.</param>
        /// <returns>A new <see cref="DataBuilderBase"/> instance for the created data element.</returns>
        public DataBuilderBase CreateElement<T>(string name) where T : ExtensibleData, new()
        {
            var data = GetNewPropertyValue<T>(Data);
            return new DataBuilderBase(data.CreateDataElement(name));
        }

        /// <summary>
        /// Creates a new data element with the specified name and value in a new instance of <typeparamref name="T"/> derived from <see cref="ExtensibleData"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ExtensibleData"/> to use for creating the element. Must have a parameterless constructor.</typeparam>
        /// <param name="name">The name of the data element to create.</param>
        /// <param name="value">The value to associate with the new data element. If the value is a <see cref="ExtensibleData"/>, it will be used to create a nested element.</param>
        /// <returns>
        /// A new <see cref="DataBuilderBase"/> instance for the created data element if <paramref name="value"/> is a <see cref="ExtensibleData"/>; otherwise, <c>null</c>.
        /// </returns>
        public DataBuilderBase CreateElement<T>(string name, object value) where T : ExtensibleData, new()
        {
            var data = GetNewPropertyValue<T>(Data);

            if (value is ExtensibleData extensibleData)
                return new DataBuilderBase(data.CreateDataElement(name, extensibleData));

            data.CreateDataElement(name, value);
            return null;
        }
    }
}