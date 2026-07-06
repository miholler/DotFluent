namespace DotFluent.Linq;

#if !NET10_0_OR_GREATER

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns a sequence that incorporates the element's index into a tuple.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The source sequence providing the elements.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that incorporates each element index into a tuple.</returns>
    public static IEnumerable<(int Index, TSource Item)> Index<TSource>(this IEnumerable<TSource> source)
    {
        source.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : IndexIterator(source);
    }

    private static IEnumerable<(int Index, TSource Item)> IndexIterator<TSource>(IEnumerable<TSource> source)
    {
        var index = 0;
        foreach (var item in source)
            yield return (checked(index++), item);
    }
}

#endif