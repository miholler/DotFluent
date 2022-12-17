namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Returns the maximum value in a generic sequence according to a specified key selector function
    /// and using a specified function to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>The value with the maximum key in the sequence.</returns>
    public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
        => source.MaxBy(keySelector, Comparer<TKey>.Create(comparison));

#if NETSTANDARD

    /// <summary>
    /// Returns the maximum value in a generic sequence according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>The value with the maximum key in the sequence.</returns>
    public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        => source.MaxBy(keySelector, Comparer<TKey>.Default);

    /// <summary>
    /// Returns the maximum value in a generic sequence according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The comparer to compare keys.</param>
    /// <returns>The value with the maximum key in the sequence.</returns>
    public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        comparer ??= Comparer<TKey>.Default;

        using var enumerator = source.GetEnumerator();
        var max = default(TSource?);
        var maxKey = default(TKey?);
        if (maxKey.IsNull())
        {
            do
            {
                if (!enumerator.MoveNext())
                    return max;

                max = enumerator.Current;
                maxKey = keySelector(max);
            }
            while (maxKey.IsNull());

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var currentKey = keySelector(current);
                if (currentKey.IsNotNull() && comparer.Compare(currentKey, maxKey) > 0)
                {
                    max = current;
                    maxKey = currentKey;
                }
            }
        }
        else
        {
            max = enumerator.MoveNext()
                ? enumerator.Current
                : throw new InvalidOperationException("Sequence contains no elements.");
            maxKey = keySelector(max);

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var currentKey = keySelector(current);
                if (comparer.Compare(currentKey, maxKey) > 0)
                {
                    max = current;
                    maxKey = currentKey;
                }
            }
        }
        return max;
    }

#endif

    #endregion
}
