namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Inserts an element into a sequence at a specified index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence in which the element is to be inserted.</param>
    /// <param name="index">The zero-based index at which to insert the element.</param>
    /// <param name="item">The element to be inserted into the source sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> that contains the element inserted into
    /// the input sequence at the specified index.
    /// </returns>
    public static IEnumerable<TSource> Insert<TSource>(this IEnumerable<TSource> source, int index, TSource item)
    {
        source.ThrowIfNull();
        ArgumentOutOfRangeException.ThrowIfNegative(index);

        return InsertIterator(source, index, item);
    }

    private static IEnumerable<TSource> InsertIterator<TSource>(IEnumerable<TSource> source, int index, TSource item)
    {
        using var enumerator = source.GetEnumerator();
        while (index > 0 && enumerator.MoveNext())
        {
            yield return enumerator.Current;
            index--;
        }

        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, 0);
        yield return item;

        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }
}
