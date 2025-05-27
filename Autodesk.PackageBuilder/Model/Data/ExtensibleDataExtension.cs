namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides extension methods for the <see cref="ExtensibleData"/> class to add dynamic attributes and elements.
/// </summary>
public static class ExtensibleDataExtension
{
    /// <summary>
    /// Adds an attribute to the <see cref="ExtensibleData"/> model.
    /// </summary>
    /// <typeparam name="T">A type derived from <see cref="ExtensibleData"/>.</typeparam>
    /// <param name="model">The model to which the attribute will be added.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <returns>The modified model instance.</returns>
    public static T CreateDataAttribute<T>(this T model, string name, object value) where T : ExtensibleData
    {
        model.Auxiliary.Add(name, (value, false));
        return model;
    }

    /// <summary>
    /// Adds a new entry element with the specified name to the <see cref="ExtensibleData"/> model.
    /// </summary>
    /// <typeparam name="T">A type derived from <see cref="ExtensibleData"/>.</typeparam>
    /// <param name="model">The model to which the entry element will be added.</param>
    /// <param name="name">The name of the entry element.</param>
    /// <returns>The newly created <see cref="ExtensibleData"/> entry element.</returns>
    public static ExtensibleData CreateDataElement<T>(this T model, string name) where T : ExtensibleData
    {
        return model.CreateDataElement(name, new ExtensibleData());
    }

    /// <summary>
    /// Adds a new entry element with the specified name and value to the <see cref="ExtensibleData"/> model.
    /// </summary>
    /// <typeparam name="T">A type derived from <see cref="ExtensibleData"/>.</typeparam>
    /// <typeparam name="TElement">The type of the entry element value.</typeparam>
    /// <param name="model">The model to which the entry element will be added.</param>
    /// <param name="name">The name of the entry element.</param>
    /// <param name="value">The value of the entry element.</param>
    /// <returns>The entry element value.</returns>
    public static TElement CreateDataElement<T, TElement>(this T model, string name, TElement value) where T : ExtensibleData
    {
        model.Auxiliary.Add(name, (value, true));
        return value;
    }
}
