namespace Autodesk.PackageBuilder
{
    public abstract class SingleBuilderBase<TBuilder, TData> : BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : new()
    {
        protected TBuilder SetDataInternal(TData data)
        {
            Data = data;
            return this as TBuilder;
        }
    }
}