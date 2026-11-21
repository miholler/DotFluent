using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
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

#if NETSTANDARD

    /// <summary>
    /// Returns the minimum value in a generic sequence according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>The value with the minimum key in the sequence.</returns>
    public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        => source.MinBy(keySelector, comparer: null);

    /// <summary>
    /// Returns the minimum value in a generic sequence according to a specified key selector function
    /// and using a specified comparer to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The comparer to compare keys.</param>
    /// <returns>The value with the minimum key in the sequence.</returns>
    public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        comparer ??= Comparer<TKey>.Default;

        using var enumerator = source.GetEnumerator();
        var min = default(TSource?);
        var minKey = default(TKey?);
        if (minKey.IsNull())
        {
            do
            {
                if (!enumerator.MoveNext())
                    return min;

                min = enumerator.Current;
                minKey = keySelector(min);
            }
            while (minKey.IsNull());

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var currentKey = keySelector(current);
                if (currentKey.IsNotNull() && comparer.Compare(currentKey, minKey) < 0)
                {
                    min = current;
                    minKey = currentKey;
                }
            }
        }
        else
        {
            min = enumerator.MoveNext()
                ? enumerator.Current
                : throw new InvalidOperationException(Errors.SequenceNoElements);
            minKey = keySelector(min);

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var currentKey = keySelector(current);
                if (comparer.Compare(currentKey, minKey) < 0)
                {
                    min = current;
                    minKey = currentKey;
                }
            }
        }
        return min;
    }

#endif
}
