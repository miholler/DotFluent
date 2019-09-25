using System;

namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether two strings are not considered binary (ordinal) equal.
        /// </summary>
        /// <param name="source">The first string to compare.</param>
        /// <param name="value">The second string to compare.</param>
        /// <param name="ignoreCase">Specifies whether to perform a case insensitive comparison.</param>
        /// <returns>true if the strings are not considered equal; otherwise, false.</returns>
        [Obsolete("This method has been deprecated und will be removed in the next update. Please use the IsNotLike(...) method for case insensitive comparison instead.")]
        public static bool IsNotBinaryEqualTo(this string source, string value, bool ignoreCase = true)
            => !string.Equals(source, value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        #endregion
    }
}
