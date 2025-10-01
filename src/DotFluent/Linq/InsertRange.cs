namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Inserts the elements of a sequence into another sequence at a specified index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence in which the elements of the second sequence are to be inserted.</param>
    /// <param name="index">The zero-based index at which to insert the elements.</param>
    /// <param name="second">The sequence whose elements are to be inserted into the first sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> that contains the elements of the second input sequence inserted
    /// into the first input sequence at the specified index.
    /// </returns>
    public static IEnumerable<TSource> InsertRange<TSource>(this IEnumerable<TSource> first, int index, IEnumerable<TSource> second)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();

#if NET8_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfNegative(index);
#else
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));
#endif
        return InsertRangeIterator(first, index, second);
    }

    private static IEnumerable<TSource> InsertRangeIterator<TSource>(IEnumerable<TSource> first, int index, IEnumerable<TSource> second)
    {
        using var enumerator = first.GetEnumerator();
        while (index > 0 && enumerator.MoveNext())
        {
            yield return enumerator.Current;
            index--;
        }

#if NET8_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, 0);
#else
        if (index > 0)
            throw new ArgumentOutOfRangeException(nameof(index));
#endif
        foreach (var item in second)
            yield return item;

        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }
}
