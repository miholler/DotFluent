using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Throws an exception if a string is null or an empty string; otherwise, returns the string.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <param name="paramName">The parameter name to use when throwing the exception.</param>
    /// <returns>The <see cref="string"/> if not null nor an empty <see cref="string"/> ("").</returns>
    [return: NotNull]
    public static string ThrowIfNullOrEmpty([NotNull]this string? source, [CallerArgumentExpression(nameof(source))]string? paramName = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(source, paramName); 

        return source;
    }
}
