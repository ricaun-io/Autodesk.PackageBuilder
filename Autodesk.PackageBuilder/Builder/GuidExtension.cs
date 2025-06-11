using System;

namespace Autodesk.PackageBuilder;

/// <summary>
/// Provides extension methods for the <see cref="Guid"/> structure.
/// </summary>
internal static class GuidExtension
{
    /// <summary>
    /// Converts a <see cref="Guid"/> to its string representation in "B" format (enclosed in braces) and upper case.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> to convert.</param>
    /// <returns>
    /// A string representation of the GUID in "B" format (e.g., "{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}") and upper case.
    /// </returns>
    public static string ToStringBraces(this Guid guid)
    {
        return guid.ToString("B").ToUpperInvariant();
    }
}
