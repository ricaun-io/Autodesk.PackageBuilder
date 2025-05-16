namespace Autodesk.PackageBuilder.Model
{
    public static class ModelBaseExtension
    {
        public static T CreateAttribute<T>(this T model, string name, object value)
            where T : ModelBase
        {
            model.Aux.Add(name, (value, false));
            return model;
        }

        public static ModelBase CreateEntryElement<T>(this T model, string name)
            where T : ModelBase
        {
            return model.CreateEntryElement(name, new ModelBase());
        }

        public static TElement CreateEntryElement<T, TElement>(this T model, string name, TElement value)
            where T : ModelBase
        {
            model.Aux.Add(name, (value, true));
            return value;
        }
    }
}