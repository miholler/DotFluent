namespace DotFluent;

public static partial class NullableExtensions
{
    /// <summary>
    /// Determines whether a nullable object contains a value that
    /// satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object in which to locate a value.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>true if the nullable object contains a value that satisfies the condition; otherwise, false.</returns>
    public static bool Exists<TSource>(this TSource? source, Func<TSource, bool> predicate) where TSource : struct
    {
        predicate.ThrowIfNull();

        return source.IsSome() && predicate(source.Value);
    }
}
