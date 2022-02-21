using System.Diagnostics.CodeAnalysis;

namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a string is not null nor an empty string.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is not null nor an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullNorEmpty([NotNullWhen(true)]this string? source)
            => !string.IsNullOrEmpty(source);

        #endregion
    }
}
