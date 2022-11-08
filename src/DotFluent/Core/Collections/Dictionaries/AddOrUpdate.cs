namespace DotFluent;

/// <summary>
/// Provides extension methods for <see cref="IDictionary{TKey, TValue}"/> objects.
/// </summary>
public static partial class DictionaryExtensions
{
    #region Methods

    /// <summary>
    /// Adds a key/value pair to a dictionary if the key does not already exist,
    /// or updates a key/value pair in the dictionary by using a specified function 
    /// if the key already exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValue">The value to be added for an absent key.</param>
    /// <param name="updateValueFactory">A function used to generate a new value for an existing key based on the key's existing value.</param>
    /// <returns>
    /// The new value for the key. This will either be addValue (if the key was absent) 
    /// or the result of updateValueFactory (if the key was present).
    /// </returns>
    public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        => source.AddOrUpdate(key, _ => addValue, updateValueFactory);

    /// <summary>
    /// Uses specified functions to add a key/value pair to a dictionary if the key does not already exist,
    /// or to update a key/value pair in the dictionary if the key already exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValueFactory">A function used to generate a value for an absent key.</param>
    /// <param name="updateValueFactory">A function used to generate a new value for an existing key based on the key's existing value.</param>
    /// <returns>
    /// The new value for the key. This will either be the result of addValueFactory (if the key was absent)
    /// or the result of updateValueFactory (if the key was present).
    /// </returns>
    public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
    {
        source.ThrowIfNull();
        addValueFactory.ThrowIfNull();
        updateValueFactory.ThrowIfNull();

        var value = source.TryGetValue(key, out var existing)
            ? updateValueFactory(key, existing)
            : addValueFactory(key);
        source[key] = value;
        return value;
    }

    #endregion
}
