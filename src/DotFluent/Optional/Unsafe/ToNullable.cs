namespace DotFluent.Optional.Unsafe;

public static partial class UnsafeOption
{
    #region Methods

    /// <summary>
    /// Creates a nullable object from an option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the value of source.</returns>
    public static TSource? ToNullable<TSource>(this Option<TSource> source) where TSource : struct
        => source.Match(x => new TSource?(x), () => default);

    #endregion
}

public static partial class UnsafeResult
{
    #region Methods

    /// <summary>
    /// Creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing the success value of source.</returns>
    public static TSource? ToNullable<TSource>(this Result<TSource> source) where TSource : struct
        => source.Match(x => new TSource?(x), _ => default);

    #endregion
}
