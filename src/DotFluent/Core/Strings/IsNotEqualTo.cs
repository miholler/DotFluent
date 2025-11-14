namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Determines whether two strings are not considered equal.
    /// </summary>
    /// <param name="source">The first string to compare.</param>
    /// <param name="value">The second string to compare.</param>
    /// <returns><see langword="true"/> if the strings are not considered equal; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEqualTo(this string? source, string? value)
        => !string.Equals(source, value);

    /// <summary>
    /// Determines whether two strings are not considered equal based on a specified comparison type.
    /// </summary>
    /// <param name="source">The first string to compare.</param>
    /// <param name="value">The second string to compare.</param>
    /// <param name="comparison">The comparison type to use.</param>
    /// <returns><see langword="true"/> if the strings are not considered equal; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEqualTo(this string? source, string? value, StringComparison comparison)
        => !string.Equals(source, value, comparison);
}
