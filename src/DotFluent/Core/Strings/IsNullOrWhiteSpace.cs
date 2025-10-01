using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Determines whether a string is null, empty, or consists only of 
    /// white-space characters.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <returns>true if the string is null, empty, or consists exclusively of white-space characters; otherwise, false.</returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)]this string? source)
        => string.IsNullOrWhiteSpace(source);
}
