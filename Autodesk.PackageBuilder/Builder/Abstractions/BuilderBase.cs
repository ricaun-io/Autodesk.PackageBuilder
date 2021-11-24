namespace Autodesk.PackageBuilder
{
    using System;
    using System.Runtime.CompilerServices;
    public abstract class BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : new()
    {
        protected TData Data { get; set; }

        protected TBuilder SetNewPropertyValue<T>(object value, [CallerMemberName] string name = null) where T : new()
        {
            return SetNewPropertyValue<T>(Data, name, value);
        }

        private TBuilder SetNewPropertyValue<T>(object instance, string method, object value) where T : new()
        {
            var data = new T();
            var name = data.GetType().Name;

            var type = instance.GetType();
            var property = type.GetProperty(name) ??
                           throw new NullReferenceException(
                               $"Property '{name}' in class {type.Name} not found");

            if (property.GetValue(instance) == null)
                property.SetValue(instance, data);

            return SetPropertyValue(property.GetValue(instance), method, value);
        }

        protected TBuilder SetPropertyValue(object value, [CallerMemberName] string name = null)
        {
            return SetPropertyValue(Data, name, value);
        }

        private TBuilder SetPropertyValue(object instance, string method, object value)
        {
            var propertyName = method;
            var type = instance.GetType();
            var property = type.GetProperty(propertyName) ??
                           throw new NullReferenceException(
                               $"Property '{propertyName}' in class {type.Name} not found");
            property.SetValue(instance, value);
            return this as TBuilder;
        }
    }
}