using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function and a key comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TSource}"/> that contains keys and values. The values within each group are in the same order as in source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TSource>> AsyncEnumerableToDictionaryAsync(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var dict = new Dictionary<TKey, TSource>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                dict.Add(keySelector(item), item);

            return dict;
        }
        return AsyncEnumerableToDictionaryAsync(source, keySelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to specified
    /// key selector and element selector functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and a key comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        elementSelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TElement>> AsyncEnumerableToDictionaryAsync(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var dict = new Dictionary<TKey, TElement>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                dict.Add(keySelector(item), elementSelector(item));

            return dict;
        }
        return AsyncEnumerableToDictionaryAsync(source, keySelector, elementSelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to specified
    /// key selector and element selector functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(keySelector, elementSelector, EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to a specified
    /// key selector function, an element selector function and a key comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input async-sequence.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
    {
        source.ThrowIfNull();
        keySelector.ThrowIfNull();
        elementSelector.ThrowIfNull();

        static async ValueTask<Dictionary<TKey, TElement>> AsyncEnumerableToDictionaryAsync(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
        {
            var dict = new Dictionary<TKey, TElement>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                dict.Add(keySelector(item), await elementSelector(item).ConfigureAwait(false));

            return dict;
        }
        return AsyncEnumerableToDictionaryAsync(source, keySelector, elementSelector, comparer, cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// the default comparer for the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer for the key type.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// a specified key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// specified key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(x => x.Key, x => x.Value, comparer, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// the default comparer for the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer for the key type.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// a specified key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// specified key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a dictionary from an async-sequence according to
    /// a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to dictionary' operation. The value of the TResult parameter contains
    /// a <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.
    /// </returns>
    public static ValueTask<Dictionary<TKey, TValue>> ToDictionaryAsync<TKey, TValue>(this IAsyncEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
        => source.ToDictionaryAsync(x => x.Key, x => x.Value, comparer, cancellationToken);

    #endregion
}
