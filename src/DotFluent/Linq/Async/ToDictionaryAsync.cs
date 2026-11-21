namespace DotFluent.Linq;

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function, an element selector function and a
    /// key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function, an element selector function and a
    /// key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="elementSelector">An asynchronous transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function, an element selector function and key
    /// compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key selector function, an element selector function and key
    /// compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="elementSelector">An asynchronous transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to specified
    /// key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified
    /// key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer<TKey>.Create(comparison), cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to specified
    /// key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer<TKey>.Create(comparison, hashCodeSelector), cancellationToken);

#if !NET10_0_OR_GREATER

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TSource>> Core(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TSource>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(keySelector(item), item);

            return result;
        }
        return Core(source, keySelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The
    /// values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, IEqualityComparer<TKey>? comparer = null, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TSource>> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TSource>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(
                    await keySelector(item, cancellationToken).ConfigureAwait(false),
                    item);

            return result;
        }
        return Core(source, keySelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to specified key selector and element selector functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        elementSelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TElement>> Core(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TElement>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(keySelector(item), elementSelector(item));

            return result;
        }
        return Core(source, keySelector, elementSelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to specified key selector and element selector functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="keySelector">An asynchronous function to extract a key from each element.</param>
    /// <param name="elementSelector">An asynchronous transform function to produce a result element value from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer = null, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        elementSelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TElement>> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TElement>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(
                    await keySelector(item, cancellationToken).ConfigureAwait(false),
                    await elementSelector(item, cancellationToken).ConfigureAwait(false));

            return result;
        }
        return Core(source, keySelector, elementSelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to the default comparer for
    /// the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer
    /// for the key type.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(comparer: null, cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TValue>> Core(IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TValue>(comparer);
            await foreach (var pair in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(pair.Key, pair.Value);

            return result;
        }
        return Core(source, comparer, cancellationToken);
    }

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to the default comparer for
    /// the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer
    /// for the key type.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(comparer: null, cancellationToken);

    /// <summary>
    /// Creates a dictionary from an asynchronous sequence according to a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TValue>> Core(IAsyncEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var result = new Dictionary<TKey, TValue>(comparer);
            await foreach (var (key, value) in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result.Add(key, value);

            return result;
        }
        return Core(source, comparer, cancellationToken);
    }

#endif
}
