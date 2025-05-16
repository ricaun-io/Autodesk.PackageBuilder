namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Provides extension methods for <see cref="BuilderBase{TBuilder, TData}"/> to simplify attribute and element creation.
    /// </summary>
    public static class BuilderBaseExtension
    {
        /// <summary>
        /// Creates a data attribute with the specified name and value, and adds it to the builder's data.
        /// </summary>
        /// <typeparam name="T">The type of the builder.</typeparam>
        /// <typeparam name="TBuilder">The builder type parameter.</typeparam>
        /// <typeparam name="TData">The data type parameter.</typeparam>
        /// <typeparam name="TElement">The element type parameter (not used in this method).</typeparam>
        /// <param name="builder">The builder instance.</param>
        /// <param name="name">The name of the attribute to create.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The builder instance for method chaining.</returns>
        public static T CreateAttribute<T, TBuilder, TData, TElement>(this T builder, string name, object value)
            where T : BuilderBase<TBuilder, TData>
            where TBuilder : class
            where TData : DataBase, new()
        {
            builder.DataBuilder.CreateDataAttribute(name, value);
            return builder;
        }

        /// <summary>
        /// Creates a data element with the specified name and value, and adds it to the builder's data.
        /// </summary>
        /// <typeparam name="T">The type of the builder.</typeparam>
        /// <typeparam name="TBuilder">The builder type parameter.</typeparam>
        /// <typeparam name="TData">The data type parameter.</typeparam>
        /// <typeparam name="TElement">The type of the element to add.</typeparam>
        /// <param name="builder">The builder instance.</param>
        /// <param name="name">The name of the element to create.</param>
        /// <param name="value">The element value to add.</param>
        /// <returns>The builder instance for method chaining.</returns>
        public static T CreateEntryElement<T, TBuilder, TData, TElement>(this T builder, string name, TElement value)
            where T : BuilderBase<TBuilder, TData>
            where TBuilder : class
            where TData : DataBase, new()
            where TElement : DataBase
        {
            builder.DataBuilder.CreateDataElement(name, value);
            return builder;
        }

        /// <summary>
        /// Creates a data element with the specified name and adds it to the builder's data.
        /// </summary>
        /// <typeparam name="T">The type of the builder.</typeparam>
        /// <typeparam name="TBuilder">The builder type parameter.</typeparam>
        /// <typeparam name="TData">The data type parameter.</typeparam>
        /// <param name="builder">The builder instance.</param>
        /// <param name="name">The name of the element to create.</param>
        /// <returns>The builder instance for method chaining.</returns>
        public static T CreateEntryElement<T, TBuilder, TData>(this T builder, string name)
            where T : BuilderBase<TBuilder, TData>
            where TBuilder : class
            where TData : DataBase, new()
        {
            builder.DataBuilder.CreateDataElement(name);
            return builder;
        }
    }
}