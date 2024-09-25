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
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
        => first.ExceptBy(second, keySelector, EqualityComparer.Create(comparison));

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function
    /// and using specified compare functions to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TKey">The type of key to identify elements by.</typeparam>
    /// <param name="first">The sequence whose keys that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => first.ExceptBy(second, keySelector, EqualityComparer.Create(comparison, hashCodeSelector));

    #endregion
}
