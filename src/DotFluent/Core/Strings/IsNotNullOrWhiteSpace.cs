using System;

namespace DotFluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a string is not null, nor empty and does not
        /// consist only of white-space characters.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is not null, nor empty and does not consist exclusively of white-space characters; otherwise, false.</returns>
        [Obsolete("This method has a misleading name and will be removed in the next update. Please use 'IsNotNullNorWhiteSpace' instead.")]
        public static bool IsNotNullOrWhiteSpace(this string source)
            => !string.IsNullOrWhiteSpace(source);

        #endregion
    }
}
