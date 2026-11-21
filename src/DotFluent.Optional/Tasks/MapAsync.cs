using DotFluent.Optional.Internal;
using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously projects the value of an option into a new form using a specified function,
    /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TResult>>(cancellationToken)
            : source.Match(value => 
                mapper(value)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper))))
                    .Then(Option.Some, cancellationToken),
                None<TResult>);
    }

    /// <summary>
    /// Asynchronously projects the value of an option into a new form using a specified function,
    /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, TResult> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(option => option.Map(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the value of an option into a new form using a specified function,
    /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(option => option.MapAsync(mapper, cancellationToken), cancellationToken);
    }
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> MapAsync<TSource, TResult>(this Result<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TResult>>(cancellationToken)
            : source.Match(value =>
                mapper(value)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper))))
                    .Then(Result.Ok, cancellationToken),
                Error<TResult>);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> MapAsync<TSource, TResult>(this Task<Result<TSource>> source, Func<TSource, TResult> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.Map(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> MapAsync<TSource, TResult>(this Task<Result<TSource>> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapAsync(mapper, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult, TError}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(this Result<TValue, TError> source, Func<TValue, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TResult, TError>>(cancellationToken)
            : source.Match(value =>
                mapper(value)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(mapper))))
                    .Then(Result.Ok<TResult, TError>, cancellationToken),
                Error<TResult, TError>);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult, TError}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(this Task<Result<TValue, TError>> source, Func<TValue, TResult> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.Map(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult, TError}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(this Task<Result<TValue, TError>> source, Func<TValue, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(result => result.MapAsync(mapper, cancellationToken), cancellationToken);
    }
}
