namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Returns the minimum value in a generic sequence according to a specified key selector function
    /// and using a specified function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>The value with the minimum key in the sequence.</returns>
    public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
        => source.MinBy(keySelector, Comparer<TKey>.Create(comparison));

    #endregion
}
