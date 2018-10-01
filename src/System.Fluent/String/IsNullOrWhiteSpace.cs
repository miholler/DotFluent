namespace System.Fluent
{
    public static partial class StringExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a specified string is null, empty, or consists only of 
        /// white-space characters.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is null, empty, or consists exclusively of white-space characters; otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace(this string source)
            => string.IsNullOrWhiteSpace(source);

        #endregion
    }
}
