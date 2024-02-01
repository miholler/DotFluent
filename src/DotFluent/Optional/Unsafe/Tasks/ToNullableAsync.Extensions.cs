using DotFluent.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

public static partial class UnsafeOptionTaskExtensions
{
    #region Methods

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

    #endregion
}

public static partial class UnsafeResultTaskExtensions
{
    #region Methods

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

    #endregion
}
