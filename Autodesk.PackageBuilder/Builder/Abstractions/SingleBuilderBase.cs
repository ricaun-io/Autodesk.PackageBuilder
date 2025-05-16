namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// SingleBuilderBase
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class SingleBuilderBase<TBuilder, TData> : BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : DataBase, new()
    {
        /// <summary>
        /// SetDataInternal
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected TBuilder SetDataInternal(TData data)
        {
            Data = data;
            return this as TBuilder;
        }
    }
}