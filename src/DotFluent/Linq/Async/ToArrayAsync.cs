namespace DotFluent.Linq;

#if !NET10_0_OR_GREATER

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Creates an array from an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create an array from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An array that contains the elements from the asynchronous sequence.</returns>
    public static ValueTask<TSource[]> ToArrayAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource[]> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
            => [.. await source
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false)];

        return Core(source, cancellationToken);
    }
}

#endif