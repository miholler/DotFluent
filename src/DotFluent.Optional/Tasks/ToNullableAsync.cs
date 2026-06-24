using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously creates a nullable object from an option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TSource}"/> representing the value of source.
    /// </returns>
    public static Task<TSource?> ToNullableAsync<TSource>(this Option<TSource> source, CancellationToken cancellationToken = default) where TSource : struct
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TSource?>(cancellationToken)
            : Task.FromResult(source.ToNullable());

    /// <summary>
    /// Asynchronously creates a nullable object from an option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TSource}"/> representing the value of source.
    /// </returns>
    public static Task<TSource?> ToNullableAsync<TSource>(this Task<Option<TSource>> source, CancellationToken cancellationToken = default) where TSource : struct
    {
        source.ThrowIfNull();

        return source.Then(x => x.ToNullable(), cancellationToken);
    }
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TSource}"/> representing the success value of source.
    /// </returns>
    public static Task<TSource?> ToNullableAsync<TSource>(this Result<TSource> source, CancellationToken cancellationToken = default) where TSource : struct
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TSource?>(cancellationToken)
            : Task.FromResult(source.ToNullable());

    /// <summary>
    /// Asynchronously creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TSource}"/> representing the success value of source.
    /// </returns>
    public static Task<TSource?> ToNullableAsync<TSource>(this Task<Result<TSource>> source, CancellationToken cancellationToken = default) where TSource : struct
    {
        source.ThrowIfNull();

        return source.Then(x => x.ToNullable(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TValue}"/> representing the success value of source.
    /// </returns>
    public static Task<TValue?> ToNullableAsync<TValue, TError>(this Result<TValue, TError> source, CancellationToken cancellationToken = default) where TValue : struct
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TValue?>(cancellationToken)
            : Task.FromResult(source.ToNullable());

    /// <summary>
    /// Asynchronously creates a nullable object from a result.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to create the nullable object from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
    /// a <see cref="Nullable{TValue}"/> representing the success value of source.
    /// </returns>
    public static Task<TValue?> ToNullableAsync<TValue, TError>(this Task<Result<TValue, TError>> source, CancellationToken cancellationToken = default) where TValue : struct
    {
        source.ThrowIfNull();

        return source.Then(x => x.ToNullable(), cancellationToken);
    }
}
