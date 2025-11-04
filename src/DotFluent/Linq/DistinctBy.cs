namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns distinct elements from a sequence according to a specified key selector function
    /// and using a specified compare function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
        => source.DistinctBy(keySelector, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Returns distinct elements from a sequence according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => source.DistinctBy(keySelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

#if NETSTANDARD

    /// <summary>
    /// Returns distinct elements from a sequence according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        => source.DistinctBy(keySelector, comparer: null);

    /// <summary>
    /// Returns distinct elements from a sequence according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : DistinctByIterator(source, keySelector, comparer);
    }

    private static IEnumerable<TSource> DistinctByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        using var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            var set = new HashSet<TKey>(comparer);
            do
            {
                var item = enumerator.Current;
                if (set.Add(keySelector(item)))
                    yield return item;
            }
            while (enumerator.MoveNext());
        }
    }

#endif
}
