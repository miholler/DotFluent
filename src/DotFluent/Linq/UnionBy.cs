using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function
    /// and using a specified compare function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
        => first.UnionBy(second, keySelector, EqualityComparer.Create(comparison));

    /// <summary>
    /// Produces the set union of two sequences according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
    /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
    public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => first.UnionBy(second, keySelector, EqualityComparer.Create(comparison, hashCodeSelector));
}
