namespace Autodesk.PackageBuilder
{
    using System.Collections.Generic;
    /// <summary>
    /// ListBuilderBase
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class ListBuilderBase<TBuilder, TData> : BuilderBase<TBuilder, TData>
        where TBuilder : class
        where TData : ExtensibleData, new()
    {
        private List<TData> _entryList;

        /// <summary>
        /// CreateEntryInternal
        /// </summary>
        /// <returns></returns>
        protected TBuilder CreateEntryInternal()
        {
            _entryList.Add(Data = new TData());
            return this as TBuilder;
        }
        /// <summary>
        /// SetDataInternal
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected TBuilder SetDataInternal(List<TData> list)
        {
            _entryList = list;
            return this as TBuilder;
        }
    }
}