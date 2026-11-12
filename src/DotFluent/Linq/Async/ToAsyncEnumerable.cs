namespace DotFluent.Linq;

#if !NET10_0_OR_GREATER

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Converts a sequence to an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to convert.</param>
    /// <returns>An <see cref="IAsyncEnumerable{TSource}"/> that contains the elements from the source sequence.</returns>
    public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
    {
        source.ThrowIfNull();

        static async IAsyncEnumerable<TSource> Core(IEnumerable<TSource> source)
        {
            foreach (var item in source)
                yield return item;
        }
        return Core(source);
    }
}

#endif