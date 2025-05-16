namespace Autodesk.PackageBuilder
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// BuilderBase
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : DataBase, new()
    {
        /// <summary>
        /// Data
        /// </summary>
        protected TData Data { get; set; }
        /// <summary>
        /// DataBuilder
        /// </summary>
        public DataBuilderBase DataBuilder => new(Data);
        /// <summary>
        /// SetNewPropertyValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected TBuilder SetNewPropertyValue<T>(object value, [CallerMemberName] string propertyName = null) where T : new()
        {
            return SetNewPropertyValue<T>(Data, propertyName, value);
        }

        internal T GetNewPropertyValue<T>(object instance) where T : new()
        {
            var type = instance.GetType();
            var property = type.GetProperties().FirstOrDefault(e=>e.PropertyType == typeof(T)) ??
                           throw new NullReferenceException(
                               $"Property with type '{typeof(T)}' in class {type.Name} not found");

            if (property.GetValue(instance) == null)
                property.SetValue(instance, new T());

            return (T)property.GetValue(instance);
        }

        private TBuilder SetNewPropertyValue<T>(object instance, string propertyName, object value) where T : new()
        {
            var data = GetNewPropertyValue<T>(instance);
            return SetPropertyValue(data, propertyName, value);
        }

        /// <summary>
        /// SetPropertyValue
        /// </summary>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected TBuilder SetPropertyValue(object value, [CallerMemberName] string propertyName = null)
        {
            return SetPropertyValue(Data, propertyName, value);
        }

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