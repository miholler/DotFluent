using System.Collections.Generic;

namespace DotFluent
{
    public static partial class DictionaryExtensions
    {
        #region Methods

        /// <summary>
        /// Attempts to add the specified key and value to a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="source">The dictionary to modify.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <returns>true if the key/value pair was added to the dictionary successfully; false if the key already exists.</returns>
        public static bool TryAdd<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            source.ThrowIfNull(nameof(source));

            if (!source.ContainsKey(key))
            {
                source[key] = value;
                return true;
            }
            return false;
        }

        #endregion
    }
}
