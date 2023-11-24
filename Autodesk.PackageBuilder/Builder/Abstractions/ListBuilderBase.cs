namespace Autodesk.PackageBuilder;

using System.Collections.Generic;
public abstract class ListBuilderBase<TBuilder, TData> : BuilderBase<TBuilder, TData>
    where TBuilder : class
    where TData : new()
{
    private List<TData> _entryList;

    protected TBuilder CreateEntryInternal()
    {
        _entryList.Add(Data = new TData());
        return this as TBuilder;
    }
    protected TBuilder SetDataInternal(List<TData> list)
    {
        _entryList = list;
        return this as TBuilder;
    }
}