namespace DotFluent;

public static partial class DictionaryExtensions
{
    #region Methods

    /// <summary>
    /// Adds a key/value pair to a dictionary if the key does not already exist,
    /// or returns the existing value if the key exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key of the element to add.</param>
    /// <param name="value">The value to be added, if the key does not already exist.</param>
    /// <returns>
    /// The value for the key. This will be either the existing value for the key if
    /// the key is already in the dictionary, or the new value if the key was not in
    /// the dictionary.
    /// </returns>
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        => source.GetOrAdd(key, _ => value);

    /// <summary>
    /// Adds a key/value pair to a dictionary by using a specified function if the key does not already exist, 
    /// or returns the existing value if the key exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key of the element to add.</param>
    /// <param name="valueFactory">A function used to generate a value for the key.</param>
    /// <returns>
    /// The value for the key. This will be either the existing value for the key if
    /// the key is already in the dictionary, or the new value if the key was not in
    /// the dictionary.
    /// </returns>
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> valueFactory)
    {
        source.ThrowIfNull();
        valueFactory.ThrowIfNull();

        if (!source.TryGetValue(key, out var value))
        {
            value = valueFactory(key);
            source[key] = value;
        }
        return value;
    }

    #endregion
}
