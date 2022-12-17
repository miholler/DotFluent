using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function
    /// and using a specified compare function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer)
        => first.UnionBy(second, keySelector, GenericEqualityComparer<TKey>.Create(comparer));

    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
        => first.UnionBy(second, keySelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

#if NETSTANDARD

    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
        => first.UnionBy(second, keySelector, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        keySelector.ThrowIfNull();

        return UnionByIterator(first, second, keySelector, comparer);
    }

    private static IEnumerable<TSource> UnionByIterator<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        var set = new HashSet<TKey>(comparer);
        foreach (var item in first)
            if (set.Add(keySelector(item)))
                yield return item;

        foreach (var item in second)
            if (set.Add(keySelector(item)))
                yield return item;
    }

#endif

    #endregion
}
