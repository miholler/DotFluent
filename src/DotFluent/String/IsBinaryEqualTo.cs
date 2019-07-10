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
        /// Determines whether two strings are considered binary (ordinal) equal.
        /// </summary>
        /// <param name="source">The first string to compare.</param>
        /// <param name="value">The second string to compare.</param>
        /// <param name="ignoreCase">Specifies whether to perform a case insensitive comparison.</param>
        /// <returns>true if the strings are considered equal; otherwise, false.</returns>
        public static bool IsBinaryEqualTo(this string source, string value, bool ignoreCase = true)
            => string.Equals(source, value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        #endregion
    }
}
