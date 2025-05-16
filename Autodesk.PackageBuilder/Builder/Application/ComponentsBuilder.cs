namespace Autodesk.PackageBuilder
{
    using Model.Application;
    using System.Collections.Generic;
    /// <summary>
    /// Provides a builder for creating and configuring <see cref="Components"/> entries.
    /// </summary>
    public class ComponentsBuilder : ListBuilderBase<ComponentsBuilder, Components>, IComponentsEntryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsBuilder"/> class with the specified components list.
        /// </summary>
        /// <param name="components">The list of <see cref="Components"/> to initialize the builder with.</param>
        public ComponentsBuilder(List<Components> components)
        {
            SetDataInternal(components);
        }

        /// <summary>
        /// Creates a new <see cref="Components"/> entry with the specified description.
        /// </summary>
        /// <param name="description">The description for the components entry.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
        public ComponentsBuilder CreateEntry(string description)
        {
            CreateEntryInternal();
            Description(description);
            return this;
        }

        /// <summary>
        /// Sets the description for the current <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The description value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        private ComponentsBuilder Description(string value) => SetPropertyValue(value);

        /// <summary>
        /// Sets the operating system requirement for the current <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The operating system value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder OS(string value) => SetNewPropertyValue<RuntimeRequirements>(value);

        /// <summary>
        /// Sets the platform requirement for the current <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The platform value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder Platform(string value) => SetNewPropertyValue<RuntimeRequirements>(value);

        /// <summary>
        /// Sets the minimum supported series version for the current <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The minimum series version value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder SeriesMin(string value) => SetNewPropertyValue<RuntimeRequirements>(value);

        /// <summary>
        /// Sets the maximum supported series version for the current <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The maximum series version value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder SeriesMax(string value) => SetNewPropertyValue<RuntimeRequirements>(value);

        /// <summary>
        /// Sets the application name for the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The application name value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder AppName(string value) => SetNewPropertyValue<ComponentEntry>(value);

        /// <summary>
        /// Sets the module name for the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The module name value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder ModuleName(string value) => SetNewPropertyValue<ComponentEntry>(value);

        /// <summary>
        /// Sets the version for the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The version value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder Version(string value) => SetNewPropertyValue<ComponentEntry>(value);

        /// <summary>
        /// Sets the application description for the current <see cref="ComponentEntry"/> in the <see cref="Components"/> entry.
        /// </summary>
        /// <param name="value">The application description value.</param>
        /// <returns>The current <see cref="ComponentsBuilder"/> instance.</returns>
        public ComponentsBuilder AppDescription(string value) => SetNewPropertyValue<ComponentEntry>(value);
    }

}