namespace DotFluent.Optional;

public static partial class Option
{
    /// <summary>
    /// Creates a nullable object from an option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the value of source.</returns>
    public static TSource? ToNullable<TSource>(this Option<TSource> source) where TSource : struct
        => source.Match(value => new TSource?(value), () => default);
}

public static partial class Result
{
    /// <summary>
    /// Creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the success value of source.</returns>
    public static TSource? ToNullable<TSource>(this Result<TSource> source) where TSource : struct
        => source.Match(value => new TSource?(value), _ => default);

    /// <summary>
    /// Creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TValue}"/> representing the success value of source.</returns>
    public static TValue? ToNullable<TValue, TError>(this Result<TValue, TError> source) where TValue : struct
        => source.Match(value => new TValue?(value), _ => default);
}
