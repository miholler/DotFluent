using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Determines whether a string is not null nor an empty string.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <returns><see langword="true"/> if the string is not null nor an empty string (""); otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullNorEmpty([NotNullWhen(true)]this string? source)
        => !string.IsNullOrEmpty(source);
}
