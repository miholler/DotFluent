using DotFluent.Internal;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously projects the value of an option into another option using a specified function and
    /// flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value of the option returned by mapper.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<Option<TResult>>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TResult>>(cancellationToken)
            : source.Match(x => 
                mapper(x).ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper)))),
                None<TResult>);
    }
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously projects the success value of a result into another result using a specified function and
    /// flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by mapper.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the flattened result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(this Result<TSource> source, Func<TSource, Task<Result<TResult>>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TResult>>(cancellationToken)
            : source.Match(x =>
                mapper(x).ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper)))),
                Error<TResult>);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into another result using a specified function and
    /// flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by mapper.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult, TError}"/> whose success value is the flattened result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Task<Result<TResult, TError>> FlatMapAsync<TValue, TError, TResult>(this Result<TValue, TError> source, Func<TValue, Task<Result<TResult, TError>>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TResult, TError>>(cancellationToken)
            : source.Match(x =>
                mapper(x).ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper)))),
                Error<TResult, TError>);
    }
}
