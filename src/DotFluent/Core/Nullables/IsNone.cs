using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class NullableExtensions
{
    /// <summary>
    /// Determines whether a nullable object has no value (is a 'None' value).
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <returns>true if the nullable object has no value; otherwise, false.</returns>
    public static bool IsNone<TSource>([NotNullWhen(false)]this TSource? source) where TSource : struct
        => !source.HasValue;
}
