namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously flattens an option with a nested option into one option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of the nested option.</typeparam>
    /// <param name="source">The option with a nested option to flatten.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flatten operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the flattened result.
    /// </returns>
    public static Task<Option<TSource>> FlattenAsync<TSource>(this Option<Option<TSource>> source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.Flatten());
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously flattens a result with a nested result into one result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of the nested result.</typeparam>
    /// <param name="source">The result with a nested result to flatten.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flatten operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> representing the flattened result.
    /// </returns>
    public static Task<Result<TSource>> FlattenAsync<TSource>(this Result<Result<TSource>> source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TSource>>(cancellationToken)
            : Task.FromResult(source.Flatten());

    /// <summary>
    /// Asynchronously flattens a result with a nested result into one result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result with a nested result to flatten.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flatten operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing the flattened result.
    /// </returns>
    public static Task<Result<TValue, TError>> FlattenAsync<TValue, TError>(this Result<Result<TValue, TError>, TError> source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TValue, TError>>(cancellationToken)
            : Task.FromResult(source.Flatten());
}
