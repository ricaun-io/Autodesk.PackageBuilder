namespace Autodesk.PackageBuilder
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// Provides a base class for builders that construct and manipulate data models of type <typeparamref name="TData"/>.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the builder class inheriting from this base class.</typeparam>
    /// <typeparam name="TData">The type of the data model being built, which must inherit from <see cref="ExtensibleData"/> and have a parameterless constructor.</typeparam>
    public abstract class BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : ExtensibleData, new()
    {
        /// <summary>
        /// Gets or sets the data model being built.
        /// </summary>
        protected TData Data { get; set; }

        /// <summary>
        /// Gets a <see cref="DataBuilderBase"/> instance for manipulating the underlying data model.
        /// </summary>
        public DataBuilderBase DataBuilder => new(Data);

        /// <summary>
        /// Sets a new property value on the data model, creating the property if it does not already exist.
        /// </summary>
        /// <typeparam name="T">The type of the property to set, which must have a parameterless constructor.</typeparam>
        /// <param name="value">The value to set for the property.</param>
        /// <param name="propertyName">The name of the property to set. Defaults to the name of the calling member.</param>
        /// <returns>The current builder instance for method chaining.</returns>
        protected TBuilder SetNewPropertyValue<T>(object value, [CallerMemberName] string propertyName = null) where T : new()
        {
            return SetNewPropertyValue<T>(Data, propertyName, value);
        }

        /// <summary>
        /// Retrieves the value of a property of the specified type from the given instance, creating the property if it does not already exist.
        /// </summary>
        /// <typeparam name="T">The type of the property to retrieve, which must have a parameterless constructor.</typeparam>
        /// <param name="instance">The object instance from which to retrieve the property value.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="NullReferenceException">Thrown if no property of the specified type exists on the instance.</exception>
        internal T GetNewPropertyValue<T>(object instance) where T : new()
        {
            var type = instance.GetType();
            var property = type.GetProperties().FirstOrDefault(e => e.PropertyType == typeof(T)) ??
                           throw new NullReferenceException(
                               $"Property with type '{typeof(T)}' in class {type.Name} not found");

            if (property.GetValue(instance) == null)
                property.SetValue(instance, new T());

            return (T)property.GetValue(instance);
        }

        /// <summary>
        /// Sets a new property value on the specified instance, creating the property if it does not already exist.
        /// </summary>
        /// <typeparam name="T">The type of the property to set, which must have a parameterless constructor.</typeparam>
        /// <param name="instance">The object instance on which to set the property value.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The value to set for the property.</param>
        /// <returns>The current builder instance for method chaining.</returns>
        private TBuilder SetNewPropertyValue<T>(object instance, string propertyName, object value) where T : new()
        {
            var data = GetNewPropertyValue<T>(instance);
            return SetPropertyValue(data, propertyName, value);
        }

        /// <summary>
        /// Sets the value of a property on the data model.
        /// </summary>
        /// <param name="value">The value to set for the property.</param>
        /// <param name="propertyName">The name of the property to set. Defaults to the name of the calling member.</param>
        /// <returns>The current builder instance for method chaining.</returns>
        protected TBuilder SetPropertyValue(object value, [CallerMemberName] string propertyName = null)
        {
            return SetPropertyValue(Data, propertyName, value);
        }

        /// <summary>
        /// Sets the value of a property on the specified instance.
        /// </summary>
        /// <param name="instance">The object instance on which to set the property value.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The value to set for the property.</param>
        /// <returns>The current builder instance for method chaining.</returns>
        /// <exception cref="NullReferenceException">Thrown if the specified property does not exist on the instance.</exception>
        private TBuilder SetPropertyValue(object instance, string propertyName, object value)
        {
            var type = instance.GetType();
            var property = type.GetProperty(propertyName) ??
                           throw new NullReferenceException(
                               $"Property '{propertyName}' in class {type.Name} not found");
            property.SetValue(instance, value);
            return this as TBuilder;
        }
    }
}