namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the number of elements in an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence that contains elements to be counted.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous count operation. The value of the TResult parameter contains
    /// the number of elements in the input async-sequence.
    /// </returns>
    public static ValueTask<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<long> AsyncEnumerableLongCountAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            var count = 0L;
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
                checked { count++; }

            return count;
        }
        return AsyncEnumerableLongCountAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns a number that represents how many elements in an 
    /// async-sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous count operation. The value of the TResult parameter contains
    /// a number that represents how many elements in the async-sequence satisfy the condition in the predicate function.
    /// </returns>
    public static ValueTask<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<long> AsyncEnumerableLongCountAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            var count = 0L;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                if (predicate(item))
                    checked { count++; }

            return count;
        }
        return AsyncEnumerableLongCountAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns a number that represents how many elements in an 
    /// async-sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous count operation. The value of the TResult parameter contains
    /// a number that represents how many elements in the async-sequence satisfy the condition in the predicate function.
    /// </returns>
    public static ValueTask<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<long> AsyncEnumerableLongCountAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            var count = 0L;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                if (await predicate(item).ConfigureAwait(false))
                    checked { count++; }

            return count;
        }
        return AsyncEnumerableLongCountAsync(source, predicate, cancellationToken);
    }

    #endregion
}
