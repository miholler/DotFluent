using DotFluent.Internal;
using DotFluent.Tasks;

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
                : otherFactory().ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(otherFactory))));
    }

    /// <summary>
    /// Asynchronously returns an alternative option if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to check for having a value.</param>
    /// <param name="other">The option to return if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing a value; otherwise, the specified alternative <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> OrElseAsync<TSource>(this Task<Option<TSource>> source, Option<TSource> other, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.OrElse(other), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative option created by a specified function
    /// if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to check for having a value.</param>
    /// <param name="otherFactory">A function to create an alternative option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing a value; otherwise, an alternative <see cref="Option{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Option<TSource>> OrElseAsync<TSource>(this Task<Option<TSource>> source, Func<Option<TSource>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElse(otherFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative option created by a specified function
    /// if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to check for having a value.</param>
    /// <param name="otherFactory">A function to create an alternative option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing a value; otherwise, an alternative <see cref="Option{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Option<TSource>> OrElseAsync<TSource>(this Task<Option<TSource>> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElseAsync(otherFactory, cancellationToken), cancellationToken);
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
                : otherFactory().ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(otherFactory))));
    }

    /// <summary>
    /// Asynchronously returns an alternative result if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="other">The result to return if an error value is present.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> representing a success value; otherwise, the specified alternative <see cref="Result{TSource}"/>.
    /// </returns>
    public static Task<Result<TSource>> OrElseAsync<TSource>(this Task<Result<TSource>> source, Result<TSource> other, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.OrElse(other), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> representing a success value; otherwise, an alternative <see cref="Result{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Result<TSource>> OrElseAsync<TSource>(this Task<Result<TSource>> source, Func<Result<TSource>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElse(otherFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> representing a success value; otherwise, an alternative <see cref="Result{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Result<TSource>> OrElseAsync<TSource>(this Task<Result<TSource>> source, Func<Task<Result<TSource>>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElseAsync(otherFactory, cancellationToken), cancellationToken);
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
                : otherFactory().ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(otherFactory))));
    }

    /// <summary>
    /// Asynchronously returns an alternative result if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="other">The result to return if an error value is present.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing a success value; otherwise, the specified alternative <see cref="Result{TValue, TError}"/>.
    /// </returns>
    public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Result<TValue, TError> other, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.OrElse(other), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing a success value; otherwise, an alternative <see cref="Result{TValue, TError}"/>
    /// created by the specified function.
    /// </returns>
    public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Func<Result<TValue, TError>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElse(otherFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns an alternative result created by a specified function
    /// if a result is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to check for a success or an error value.</param>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing a success value; otherwise, an alternative <see cref="Result{TValue, TError}"/>
    /// created by the specified function.
    /// </returns>
    public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Func<Task<Result<TValue, TError>>> otherFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        otherFactory.ThrowIfNull();

        return source.Then(x => x.OrElseAsync(otherFactory, cancellationToken), cancellationToken);
    }
}
