using System.Diagnostics.CodeAnalysis;

namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a string is null or an empty string.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty([NotNullWhen(false)]this string? source)
            => string.IsNullOrEmpty(source);

        #endregion
    }
}
