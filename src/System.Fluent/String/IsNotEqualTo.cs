namespace System.Fluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether two strings are not considered equal based on a provided comparison type.
        /// </summary>
        /// <param name="source">The first string to compare.</param>
        /// <param name="value">The second string to compare.</param>
        /// <param name="comparison">The comparison type to use.</param>
        /// <returns>true if the strings are not considered equal; otherwise, false.</returns>
        public static bool IsNotEqualTo(this string source, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
            => string.Compare(source, value, comparison) != 0;

        #endregion
    }
}
