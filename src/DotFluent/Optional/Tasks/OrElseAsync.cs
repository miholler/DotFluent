namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously returns an alternative option created by a specified function
    /// if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="otherFactory">A function to create an alternative option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing a value; otherwise, an alternative <see cref="Option{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Option<TSource>> OrElseAsync<TSource>(this Option<TSource> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken = default)
    {
        otherFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : source.IsSome
                ? Task.FromResult(source)
                : otherFactory().ThrowIfNull(() => new InvalidOperationException($"{nameof(otherFactory)} must not return null."));
    }
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> representing a success value; otherwise, an alternative <see cref="Result{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Result<TSource>> OrElseAsync<TSource>(this Result<TSource> source, Func<Task<Result<TSource>>> otherFactory, CancellationToken cancellationToken = default)
    {
        otherFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TSource>>(cancellationToken)
            : source.IsOk
                ? Task.FromResult(source)
                : otherFactory().ThrowIfNull(() => new InvalidOperationException($"{nameof(otherFactory)} must not return null."));
    }

    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing a success value; otherwise, an alternative <see cref="Result{TValue, TError}"/>
    /// created by the specified function.
    /// </returns>
    public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(this Result<TValue, TError> source, Func<Task<Result<TValue, TError>>> otherFactory, CancellationToken cancellationToken = default)
    {
        otherFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TValue, TError>>(cancellationToken)
            : source.IsOk
                ? Task.FromResult(source)
                : otherFactory().ThrowIfNull(() => new InvalidOperationException($"{nameof(otherFactory)} must not return null."));
    }
}
