namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously determines whether an async-sequence contains any elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to check for emptiness.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous any operation. The value of the TResult parameter contains
    /// true if the source async-sequence contains any elements; otherwise, false.
    /// </returns>
    public static ValueTask<bool> AnyAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableAnyAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source is AsyncIterator<TSource> iterator)
            {
                var count = await iterator
                    .GetCountAsync(onlyIfCheap: true, cancellationToken)
                    .ConfigureAwait(false);
                if (count >= 0)
                    return count != 0;

                var (_, found) = await iterator
                    .TryGetFirstAsync(cancellationToken)
                    .ConfigureAwait(false);
                return found;
            }
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            return await enumerator.MoveNextAsync();
        }
        return AsyncEnumerableAnyAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether any element of an async-sequence satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous any operation. The value of the TResult parameter contains
    /// true if the source async-sequence is not empty and at least one of its elements passes
    /// the test in the specified predicate; otherwise, false.
    /// </returns>
    public static ValueTask<bool> AnyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableAnyAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
        return AsyncEnumerableAnyAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether any element of an async-sequence satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous any operation. The value of the TResult parameter contains
    /// true if the source async-sequence is not empty and at least one of its elements passes
    /// the test in the specified predicate; otherwise, false.
    /// </returns>
    public static ValueTask<bool> AnyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableAnyAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (await predicate(item).ConfigureAwait(false))
                    return true;
            }
            return false;
        }
        return AsyncEnumerableAnyAsync(source, predicate, cancellationToken);
    }

    #endregion
}
