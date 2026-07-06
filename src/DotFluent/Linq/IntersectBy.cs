namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Produces the set intersection of two sequences according to a specified key selector function
    /// and using a specified compare function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
        => first.IntersectBy(second, keySelector, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Produces the set intersection of two sequences according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => first.IntersectBy(second, keySelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

#if NETSTANDARD

    /// <summary>
    /// Produces the set intersection of two sequences according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
        => first.IntersectBy(second, keySelector, comparer: null);

    /// <summary>
    /// Produces the set intersection of two sequences according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        keySelector.ThrowIfNull();

        return IntersectByIterator(first, second, keySelector, comparer);
    }

    private static IEnumerable<TSource> IntersectByIterator<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        var set = new HashSet<TKey>(second, comparer);
        foreach (var item in first)
            if (set.Remove(keySelector(item)))
                yield return item;
    }

#endif
}
