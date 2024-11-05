namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously determines whether an async-sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to check for emptiness.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous none operation. The value of the TResult parameter contains
    /// true if the source async-sequence contains no elements; otherwise, false.
    /// </returns>
    public static ValueTask<bool> NoneAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableNoneAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source is AsyncIterator<TSource> iterator)
            {
                var count = await iterator
                    .GetCountAsync(onlyIfCheap: true, cancellationToken)
                    .ConfigureAwait(false);
                if (count >= 0)
                    return count == 0;

                var option = await iterator
                    .TryGetFirstAsync(cancellationToken)
                    .ConfigureAwait(false);
                return option.IsNone;
            }
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            return !await enumerator.MoveNextAsync();
        }
        return AsyncEnumerableNoneAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether no element of an async-sequence satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous none operation. The value of the TResult parameter contains
    /// true if no element in the source async-sequence passes the test in the specified predicate; otherwise, false.
    /// </returns>
    public static ValueTask<bool> NoneAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableNoneAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (predicate(item))
                    return false;
            }
            return true;
        }
        return AsyncEnumerableNoneAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether no element of an async-sequence satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence whose elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous none operation. The value of the TResult parameter contains
    /// true if no element in the source async-sequence passes the test in the specified predicate; otherwise, false.
    /// </returns>
    public static ValueTask<bool> NoneAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableNoneAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (await predicate(item).ConfigureAwait(false))
                    return false;
            }
            return true;
        }
        return AsyncEnumerableNoneAsync(source, predicate, cancellationToken);
    }

    #endregion
}
