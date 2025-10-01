using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Determines wheter an object is not null.
    /// </summary>
    /// <param name="source">The object to check for null.</param>
    /// <returns>true if the object is not null; otherwise, false.</returns>
    public static bool IsNotNull([NotNullWhen(true)]this object? source)
        => source is not null;
}
