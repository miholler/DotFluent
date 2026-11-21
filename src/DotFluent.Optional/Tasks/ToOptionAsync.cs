using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously creates an option from an object.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The object to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this TSource? source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.ToOption());

    /// <summary>
    /// Asynchronously creates an option from a nullable object.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the value of source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this TSource? source, CancellationToken cancellationToken = default) where TSource : struct
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.ToOption());

    /// <summary>
    /// Asynchronously creates an option from a result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result value to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the success value of source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this Result<TSource> source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.ToOption());

    /// <summary>
    /// Asynchronously creates an option from a result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result value to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TValue}"/> representing the success value of source.
    /// </returns>
    public static Task<Option<TValue>> ToOptionAsync<TValue, TError>(this Result<TValue, TError> source, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TValue>>(cancellationToken)
            : Task.FromResult(source.ToOption());

    /// <summary>
    /// Asynchronously creates an option from an object.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the object to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the value of source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this Task<TSource?> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(value => value.ToOption(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates an option from a nullable object.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the nullable object to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the value of source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this Task<TSource?> source, CancellationToken cancellationToken = default) where TSource : struct
    {
        source.ThrowIfNull();

        return source.Then(value => value.ToOption(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates an option from a result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result value to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing the success value of source.
    /// </returns>
    public static Task<Option<TSource>> ToOptionAsync<TSource>(this Task<Result<TSource>> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(result => result.ToOption(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates an option from a result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result value to create an option from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TValue}"/> representing the success value of source.
    /// </returns>
    public static Task<Option<TValue>> ToOptionAsync<TValue, TError>(this Task<Result<TValue, TError>> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(result => result.ToOption(), cancellationToken);
    }
}
