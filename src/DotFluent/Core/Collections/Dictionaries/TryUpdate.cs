namespace DotFluent;

public static partial class DictionaryExtensions
{
    #region Methods

    /// <summary>
    /// Attempts to update an existing value for the specified key by comparing the existing
    /// value with a specified value, and if they are equal, updates the key with a third value.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to modify.</param>
    /// <param name="key">The key whose value is compared with comparisonValue and possibly replaced.</param>
    /// <param name="newValue">
    /// The value that replaces the value of the element that has the specified key if 
    /// the comparison results in equality.
    /// </param>
    /// <param name="comparisonValue">The value that is compared to the value of the element that has the specified key.</param>
    /// <returns>true if the value with key was equal to comparisonValue and was replaced with newValue; otherwise, false.</returns>
    public static bool TryUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue newValue, TValue comparisonValue)
    {
        source.ThrowIfNull();

        if (source.TryGetValue(key, out var value) && value.IsEqualTo(comparisonValue))
        {
            source[key] = newValue;
            return true;
        }
        return false;
    }

    #endregion
}
