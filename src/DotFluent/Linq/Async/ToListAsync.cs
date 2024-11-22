namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously creates a list from an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a list from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to list' operation. The value of the TResult parameter contains
    /// a <see cref="List{TSource}"/> that contains the elements from the input async-sequence.
    /// </returns>
    public static ValueTask<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source switch
        {
            AsyncIterator<TSource> iterator => iterator.ToListAsync(cancellationToken),
            _ => AsyncEnumerableToListAsync(source, cancellationToken)
        };
        static async ValueTask<List<TSource>> AsyncEnumerableToListAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var list = new List<TSource>();
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                list.Add(item);

            return list;
        }
    }

    #endregion
}
