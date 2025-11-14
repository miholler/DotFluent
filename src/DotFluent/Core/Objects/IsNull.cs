using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Determines whether an object is null.
    /// </summary>
    /// <param name="source">The object to check for null.</param>
    /// <returns><see langword="true"/> if the object is null; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull([NotNullWhen(false)]this object? source)
        => source is null;
}
