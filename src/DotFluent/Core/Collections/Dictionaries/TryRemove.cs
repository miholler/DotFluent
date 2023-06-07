using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class DictionaryExtensions
{
    #region Methods

    /// <summary>
    /// Attempts to remove and return the value that has the specified key from a dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key of the element to remove and return.</param>
    /// <param name="value">
    /// When this method returns, contains the value of the element removed from the dictionary
    /// or the default value of the TValue type if the key does not exist.
    /// </param>
    /// <returns>true if the element was removed successfully; otherwise, false.</returns>
    public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, [MaybeNullWhen(false)]out TValue value)
    {
        source.ThrowIfNull();

        return source.TryGetValue(key, out value) && source.Remove(key);
    }

    #endregion
}
