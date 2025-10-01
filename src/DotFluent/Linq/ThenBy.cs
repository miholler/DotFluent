namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Performs a subsequent ordering of the elements in a sequence in ascending order
    /// by using a specified function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">The sequence that contains elements to sort.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted according to a key.</returns>
    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
        => source.ThenBy(keySelector, Comparer<TKey>.Create(comparison));
}
