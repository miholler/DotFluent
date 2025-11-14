using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Determines whether an object satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to check for a condition.</param>
    /// <param name="predicate">A function to test the object for a condition.</param>
    /// <returns><see langword="true"/> if the object satisfies the condition in the predicate function; otherwise, <see langword="false"/>.</returns>
    public static bool Is<TSource>([NotNullWhen(true)]this TSource? source, Func<TSource, bool> predicate)
    {
        predicate.ThrowIfNull();

        return source.IsNotNull() && predicate(source);
    }
}
