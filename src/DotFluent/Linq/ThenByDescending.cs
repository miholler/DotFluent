namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Performs a subsequent ordering of the elements in a sequence in descending order
    /// by using a specified function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to sort.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order according to a key.</returns>
    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
        => source.ThenByDescending(keySelector, Comparer<TKey>.Create(comparison));

    #endregion
}
