namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a specified string is not null and not an empty string.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is not null and not an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(this string source)
            => !string.IsNullOrEmpty(source);

        #endregion
    }
}
