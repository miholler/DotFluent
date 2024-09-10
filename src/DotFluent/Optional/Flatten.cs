namespace DotFluent.Optional;

/// <summary>
/// Provides a set of static methods for working 
/// with <see cref="Option{T}"/> instances.
/// </summary>
public static partial class Option
{
    #region Methods

    /// <summary>
    /// Flattens an option with a nested option into one option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of the nested option.</typeparam>
    /// <param name="source">The option with a nested option to flatten.</param>
    /// <returns>An <see cref="Option{TSource}"/> representing the flattened result.</returns>
    public static Option<TSource> Flatten<TSource>(this Option<Option<TSource>> source)
        => source.FlatMap(x => x);

    #endregion
}

public static partial class Result
{
    #region Methods

    /// <summary>
    /// Flattens a result with a nested result into one result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of the nested result.</typeparam>
    /// <param name="source">The result with a nested result to flatten.</param>
    /// <returns>An <see cref="Result{TSource}"/> representing the flattened result.</returns>
    public static Result<TSource> Flatten<TSource>(this Result<Result<TSource>> source)
        => source.FlatMap(x => x);

    /// <summary>
    /// Flattens a result with a nested result into one result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of the nested result.</typeparam>
    /// <typeparam name="TError">The type of the error value of the nested result.</typeparam>
    /// <param name="source">The result with a nested result to flatten.</param>
    /// <returns>A <see cref="Result{TValue, TError}"/> representing the flattened result.</returns>
    public static Result<TValue, TError> Flatten<TValue, TError>(this Result<Result<TValue, TError>, TError> source)
        => source.FlatMap(x => x);

    #endregion
}
