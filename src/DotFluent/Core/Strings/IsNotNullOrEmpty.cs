using System;

namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a string is not null and not an empty string.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is not null and not an empty string (""); otherwise, false.</returns>
        [Obsolete("This method has a misleading name and will be removed in the next update. Please use 'IsNotNullNorEmpty' instead.")]
        public static bool IsNotNullOrEmpty(this string source)
            => !string.IsNullOrEmpty(source);

        #endregion
    }
}
