namespace DotFluent.Optional;

public static partial class Option
{
    /// <summary>
    /// Creates an option from an object.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to create an option from.</param>
    /// <returns>An <see cref="Option{TSource}"/> representing source.</returns>
    public static Option<TSource> ToOption<TSource>(this TSource? source)
        => source;

    /// <summary>
    /// Creates an option from a nullable object.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to create an option from.</param>
    /// <returns>An <see cref="Option{TSource}"/> representing the value of source.</returns>
    public static Option<TSource> ToOption<TSource>(this TSource? source) where TSource : struct
        => source.Match(Some, None<TSource>);

    /// <summary>
    /// Creates an option from a result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result value to create an option from.</param>
    /// <returns>An <see cref="Option{TSource}"/> representing the success value of source.</returns>
    public static Option<TSource> ToOption<TSource>(this Result<TSource> source)
        => source.Match(Some, _ => None<TSource>());

    /// <summary>
    /// Creates an option from a result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result value to create an option from.</param>
    /// <returns>An <see cref="Option{TValue}"/> representing the success value of source.</returns>
    public static Option<TValue> ToOption<TValue, TError>(this Result<TValue, TError> source)
        => source.Match(Some, _ => None<TValue>());
}
