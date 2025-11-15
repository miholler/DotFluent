namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns the number of elements in a sequence grouped by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to be counted.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the frequencies of each key occurrence in source.</returns>
    public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.CountBy(keySelector, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Returns the number of elements in a sequence grouped by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to be counted.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the frequencies of each key occurrence in source.</returns>
    public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.CountBy(keySelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

#if !NET10_0_OR_GREATER

    /// <summary>
    /// Returns the number of elements in a sequence grouped by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to be counted.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the frequencies of each key occurrence in source.</returns>
    public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull
        => source.CountBy(keySelector, comparer: null);

    /// <summary>
    /// Returns the number of elements in a sequence grouped by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to be counted.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the frequencies of each key occurrence in source.</returns>
    public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : CountByIterator(source, keySelector, comparer);
    }

    private static IEnumerable<KeyValuePair<TKey, int>> CountByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        using var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            const int seed = 1;
            var dictionary = new Dictionary<TKey, int>(comparer);
            do
            {
                var item = enumerator.Current;
                dictionary.AddOrUpdate(keySelector(item), seed, (_, count) => checked(++count));
            }
            while (enumerator.MoveNext());

            foreach (var pair in dictionary)
                yield return pair;
        }
    }

#endif
}
