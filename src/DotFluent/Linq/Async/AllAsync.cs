namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously determines whether all elements of an async-sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous all operation. The value of the TResult parameter contains
    /// true if every element of the source async-sequence passes the test in the specified predicate, or if the async-sequence is empty;
    /// otherwise, false.
    /// </returns>
    public static ValueTask<bool> AllAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableAllAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }
        return AsyncEnumerableAllAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether all elements of an async-sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous all operation. The value of the TResult parameter contains
    /// true if every element of the source async-sequence passes the test in the specified predicate, or if the async-sequence is empty;
    /// otherwise, false.
    /// </returns>
    public static ValueTask<bool> AllAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableAllAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (!await predicate(item).ConfigureAwait(false))
                    return false;
            }
            return true;
        }
        return AsyncEnumerableAllAsync(source, predicate, cancellationToken);
    }

    #endregion
}
