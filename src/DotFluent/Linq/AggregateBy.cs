namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.AggregateBy(keySelector, seed, func, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.AggregateBy(keySelector, seed, func, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seedSelector">A function to create the initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.AggregateBy(keySelector, seedSelector, func, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seedSelector">A function to create the initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.AggregateBy(keySelector, seedSelector, func, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

#if !NET10_0_OR_GREATER

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) where TKey : notnull
        => source.AggregateBy(keySelector, seed, func, comparer: null);

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        func.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : AggregateByIterator(source, keySelector, seed, func, comparer);
    }

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seedSelector">A function to create the initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func) where TKey : notnull
        => source.AggregateBy(keySelector, seedSelector, func, comparer: null);

    /// <summary>
    /// Applies an accumulator function over a sequence, grouping results by key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The sequence to aggregate over.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="seedSelector">A function to create the initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the aggregates corresponding to each key deriving from source.</returns>
    public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        seedSelector.ThrowIfNull();
        func.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : AggregateByIterator(source, keySelector, seedSelector, func, comparer);
    }

    private static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateByIterator<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        using var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            var dictionary = new Dictionary<TKey, TAccumulate>(comparer);
            do
            {
                var item = enumerator.Current;
                dictionary.AddOrUpdate(keySelector(item), _ => func(seed, item), (_, accumulate) => func(accumulate, item));
            }
            while (enumerator.MoveNext());

            foreach (var pair in dictionary)
                yield return pair;
        }
    }

    private static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateByIterator<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        using var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            var dictionary = new Dictionary<TKey, TAccumulate>(comparer);
            do
            {
                var item = enumerator.Current;
                dictionary.AddOrUpdate(keySelector(item), key => func(seedSelector(key), item), (_, accumulate) => func(accumulate, item));
            }
            while (enumerator.MoveNext());

            foreach (var pair in dictionary)
                yield return pair;
        }
    }

#endif
}
