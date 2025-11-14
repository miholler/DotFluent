namespace DotFluent;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Determines whether an object does not satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to check for a condition.</param>
    /// <param name="predicate">A function to test the object for a condition.</param>
    /// <returns><see langword="true"/> if the object does not satisfy the condition in the predicate function; otherwise, <see langword="false"/>.</returns>
    public static bool IsNot<TSource>(this TSource? source, Func<TSource, bool> predicate)
    {
        predicate.ThrowIfNull();

        return source.IsNull() || !predicate(source);
    }
}
