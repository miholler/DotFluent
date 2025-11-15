namespace DotFluent;

public static partial class NullableExtensions
{
    /// <summary>
    /// Returns an alternative nullable object if a nullable object 
    /// does not have a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="other">The nullable object to return if a value is missing.</param>
    /// <returns>
    /// A <see cref="Nullable{TSource}"/> representing a value; otherwise, the specified 
    /// alternative <see cref="Nullable{TSource}"/>.
    /// </returns>
    public static TSource? OrElse<TSource>(this TSource? source, TSource? other) where TSource : struct
        => source.OrElse(() => other);

    /// <summary>
    /// Returns an alternative nullable object created by a specified function 
    /// if a nullable object does not have a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="otherFactory">A function to create an alternative nullable object.</param>
    /// <returns>
    /// A <see cref="Nullable{TSource}"/> representing a value; otherwise, an alternative
    /// <see cref="Nullable{TSource}"/> created by the specified function.
    /// </returns>
    public static TSource? OrElse<TSource>(this TSource? source, Func<TSource?> otherFactory) where TSource : struct
    {
        otherFactory.ThrowIfNull();

        return source.IsSome
            ? source
            : otherFactory();
    }
}
