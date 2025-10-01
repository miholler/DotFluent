namespace DotFluent.Optional.Unsafe;

public static partial class UnsafeOption
{
    /// <summary>
    /// Creates a nullable object from an option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the value of source.</returns>
    public static TSource? ToNullable<TSource>(this Option<TSource> source) where TSource : struct
        => source.Match(x => new TSource?(x), () => default);
}

public static partial class UnsafeResult
{
    /// <summary>
    /// Creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the success value of source.</returns>
    public static TSource? ToNullable<TSource>(this Result<TSource> source) where TSource : struct
        => source.Match(x => new TSource?(x), _ => default);

    /// <summary>
    /// Creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TValue}"/> representing the success value of source.</returns>
    public static TValue? ToNullable<TValue, TError>(this Result<TValue, TError> source) where TValue : struct
        => source.Match(x => new TValue?(x), _ => default);
}
