using System;

namespace DotFluent
{
    /// <summary>
    /// Provides extension methods for <see cref="string"/> objects.
    /// </summary>
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether two strings are considered equal.
        /// </summary>
        /// <param name="source">The first string to compare.</param>
        /// <param name="value">The second string to compare.</param>
        /// <returns>true if the strings are considered equal; otherwise, false.</returns>
        public static bool IsEqualTo(this string source, string value)
            => string.Equals(source, value);

        /// <summary>
        /// Determines whether two strings are considered equal based on a provided comparison type.
        /// </summary>
        /// <param name="source">The first string to compare.</param>
        /// <param name="value">The second string to compare.</param>
        /// <param name="comparison">The comparison type to use.</param>
        /// <returns>true if the strings are considered equal; otherwise, false.</returns>
        public static bool IsEqualTo(this string source, string value, StringComparison comparison)
            => string.Equals(source, value, comparison);

        #endregion
    }
}
