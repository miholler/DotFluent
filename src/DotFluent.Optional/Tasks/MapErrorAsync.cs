using DotFluent.Optional.Internal;
using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TSource}"/>.
    /// </returns>
    public static Task<Result<TSource>> MapErrorAsync<TSource>(this Result<TSource> source, Func<Exception, Task<Exception>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TSource>>(cancellationToken)
            : source.Match(Ok, ex =>
                mapper(ex)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper))))
                    .Then(Error<TSource>, cancellationToken));
    }

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TSource}"/>.
    /// </returns>
    public static Task<Result<TSource>> MapErrorAsync<TSource>(this Task<Result<TSource>> source, Func<Exception, Exception> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapError(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TSource}"/>.
    /// </returns>
    public static Task<Result<TSource>> MapErrorAsync<TSource>(this Task<Result<TSource>> source, Func<Exception, Task<Exception>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapErrorAsync(mapper, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TResult}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TValue, TResult}"/>.
    /// </returns>
    public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(this Result<TValue, TError> source, Func<TError, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TValue, TResult>>(cancellationToken)
            : source.Match(Ok<TValue, TResult>, value =>
                mapper(value)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper))))
                    .Then(Error<TValue, TResult>, cancellationToken));
    }

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TResult}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TValue, TResult}"/>.
    /// </returns>
    public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(this Task<Result<TValue, TError>> source, Func<TError, TResult> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapError(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'map error' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TResult}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TValue, TResult}"/>.
    /// </returns>
    public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(this Task<Result<TValue, TError>> source, Func<TError, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapErrorAsync(mapper, cancellationToken), cancellationToken);
    }
}
