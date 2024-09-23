namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously creates an array from an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create an array from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to array' operation. The value of the TResult parameter contains
    /// an array that contains the elements from the input async-sequence.
    /// </returns>
    public static ValueTask<TSource[]> ToArrayAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source switch
        {
            AsyncIterator<TSource> iterator => iterator.ToArrayAsync(cancellationToken),
            _ => AsyncEnumerableToArrayAsync(source, cancellationToken)
        };
    }

    private static async ValueTask<TSource[]> AsyncEnumerableToArrayAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        var list = await source
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
        return [.. list];
    }

    #endregion
}
