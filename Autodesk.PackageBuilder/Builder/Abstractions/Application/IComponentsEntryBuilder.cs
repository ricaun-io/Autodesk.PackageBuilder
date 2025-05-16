namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// Defines a builder interface for creating <see cref="ComponentsBuilder"/> entries.
    /// </summary>
    public interface IComponentsEntryBuilder
    {
        /// <summary>
        /// Creates a new <see cref="ComponentsBuilder"/> entry with the specified description.
        /// </summary>
        /// <param name="description">The description for the components entry.</param>
        /// <returns>A <see cref="ComponentsBuilder"/> instance for further configuration.</returns>
        ComponentsBuilder CreateEntry(string description);
    }
}