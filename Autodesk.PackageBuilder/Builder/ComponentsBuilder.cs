using Autodesk.PackageBuilder.Model.Application;

namespace Autodesk.PackageBuilder;

public sealed class ComponentsBuilder : ListBuilderBase<ComponentsBuilder, Components>, IComponentsEntryBuilder
{
    public ComponentsBuilder(List<Components> components)
    {
        SetDataInternal(components);
    }

    public ComponentsBuilder CreateEntry(string description)
    {
        CreateEntryInternal();
        Description(description);
        return this;
    }

    private ComponentsBuilder Description(string value) => SetPropertyValue(value);
    public ComponentsBuilder OS(string value) => SetNewPropertyValue<RuntimeRequirements>(value);
    public ComponentsBuilder Platform(string value) => SetNewPropertyValue<RuntimeRequirements>(value);
    public ComponentsBuilder SeriesMin(string value) => SetNewPropertyValue<RuntimeRequirements>(value);
    public ComponentsBuilder SeriesMax(string value) => SetNewPropertyValue<RuntimeRequirements>(value);
    public ComponentsBuilder AppName(string value) => SetNewPropertyValue<ComponentEntry>(value);
    public ComponentsBuilder ModuleName(string value) => SetNewPropertyValue<ComponentEntry>(value);
    public ComponentsBuilder Version(string value) => SetNewPropertyValue<ComponentEntry>(value);
    public ComponentsBuilder AppDescription(string value) => SetNewPropertyValue<ComponentEntry>(value);
}