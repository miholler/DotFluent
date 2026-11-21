namespace DotFluent.Linq;

#if !NET10_0_OR_GREATER

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Creates a list from an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a list from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="List{TSource}"/> that contains the elements from the asynchronous sequence.</returns>
    public static ValueTask<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<List<TSource>> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var result = new List<TSource>();
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(item);

            return result;
        }
        return Core(source, cancellationToken);
    }
}

#endif