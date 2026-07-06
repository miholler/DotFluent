using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option whose value is to be checked for null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous secure operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value is not null; otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> SecureAsync<TSource>(this Option<TSource?> source, CancellationToken cancellationToken = default) where TSource : class
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.Secure());

    /// <summary>
    /// Asynchronously removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option whose value is to be checked for null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous secure operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value is not null; otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> SecureAsync<TSource>(this Option<TSource?> source, CancellationToken cancellationToken = default) where TSource : struct
        => cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : Task.FromResult(source.Secure());

    /// <summary>
    /// Asynchronously removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option whose value is to be checked for null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous secure operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value is not null; otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> SecureAsync<TSource>(this Task<Option<TSource?>> source, CancellationToken cancellationToken = default) where TSource : class
    {
        source.ThrowIfNull();

        return source.Then(x => x.Secure(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option whose value is to be checked for null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous secure operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value is not null; otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> SecureAsync<TSource>(this Task<Option<TSource?>> source, CancellationToken cancellationToken = default) where TSource : struct
    {
        source.ThrowIfNull();

        return source.Then(x => x.Secure(), cancellationToken);
    }
}
