using System;

namespace DotFluent;

public static partial class StringExtensions
{
    #region Methods

    /// <summary>
    /// Determines whether two strings are not considered equal regardless of their case.
    /// </summary>
    /// <param name="source">The first string to compare.</param>
    /// <param name="value">The second string to compare.</param>
    /// <returns>true if the strings are not considered equal regardless of their case; otherwise, false.</returns>
    public static bool IsNotLike(this string? source, string? value)
        => !string.Equals(source, value, StringComparison.OrdinalIgnoreCase);

    #endregion
}
