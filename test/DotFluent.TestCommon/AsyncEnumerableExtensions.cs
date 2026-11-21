using System.Runtime.CompilerServices;

namespace System.Linq;

public static class AsyncEnumerableExtensions
{
    public static IAsyncEnumerable<TSource> AsAsyncIterator<TSource>(this IAsyncEnumerable<TSource> source)
    {
        static async IAsyncEnumerable<TSource> Core(IAsyncEnumerable<TSource> source, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }
        }
        return Core(source);
    }
}
