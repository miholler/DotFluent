using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key selector function and a key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values.</returns>
    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.ToDictionary(keySelector, EqualityComparer.Create(comparison));

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key selector function and key compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by keySelector.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>A <see cref="Dictionary{TKey, TSource}"/> that contains keys and values.</returns>
    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.ToDictionary(keySelector, EqualityComparer.Create(comparison, hashCodeSelector));

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key selector function, an element selector function and a 
    /// key compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.ToDictionary(keySelector, elementSelector, EqualityComparer.Create(comparison));

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key selector function, an element selector function and key
    /// compare functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>A <see cref="Dictionary{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.ToDictionary(keySelector, elementSelector, EqualityComparer.Create(comparison, hashCodeSelector));

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.ToDictionary(EqualityComparer.Create(comparison));

    /// <summary>
    /// Creates a dictionary from a sequence according to specified 
    /// key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.ToDictionary(EqualityComparer.Create(comparison, hashCodeSelector));

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified 
    /// key compare function.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison) where TKey : notnull
        => source.ToDictionary(EqualityComparer.Create(comparison));

    /// <summary>
    /// Creates a dictionary from a sequence according to specified 
    /// key compare functions.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector) where TKey : notnull
        => source.ToDictionary(EqualityComparer.Create(comparison, hashCodeSelector));

#if NETSTANDARD

    /// <summary>
    /// Creates a dictionary from a sequence according to the default comparer for
    /// the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer
    /// for the key type.
    /// </returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
        => source.ToDictionary(EqualityComparer<TKey>.Default);

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        source.ThrowIfNull();

        return source.ToDictionary(x => x.Key, x => x.Value, comparer);
    }

    /// <summary>
    /// Creates a dictionary from a sequence according to the default comparer for
    /// the key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source and uses the default comparer
    /// for the key type.
    /// </returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source) where TKey : notnull
        => source.ToDictionary(EqualityComparer<TKey>.Default);

    /// <summary>
    /// Creates a dictionary from a sequence according to a specified key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys from elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the values from elements of source.</typeparam>
    /// <param name="source">The sequence to create a dictionary from.</param>
    /// <param name="comparer">The equality comparer to compare keys.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values from source.</returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
    {
        source.ThrowIfNull();

        return source.ToDictionary(x => x.Key, x => x.Value, comparer);
    }

#endif

    #endregion
}
