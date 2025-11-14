namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Determines whether two strings are not considered equal regardless of their case.
    /// </summary>
    /// <param name="source">The first string to compare.</param>
    /// <param name="value">The second string to compare.</param>
    /// <returns><see langword="true"/> if the strings are not considered equal regardless of their case; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotLike(this string? source, string? value)
        => !string.Equals(source, value, StringComparison.OrdinalIgnoreCase);
}
