using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function
    /// and using a specified compare function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose keys that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer)
        => first.ExceptBy(second, keySelector, GenericEqualityComparer<TKey>.Create(comparer));

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose keys that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
        => first.ExceptBy(second, keySelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

#if NETSTANDARD

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose keys that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
        => first.ExceptBy(second, keySelector, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose keys that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        keySelector.ThrowIfNull();

        return ExceptByIterator(first, second, keySelector, comparer);
    }

    private static IEnumerable<TSource> ExceptByIterator<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
    {
        var set = new HashSet<TKey>(second, comparer);
        foreach (var item in first)
            if (set.Add(keySelector(item)))
                yield return item;
    }

#endif

    #endregion
}
