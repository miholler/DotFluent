using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Throws an exception if a string is null, empty, or consists only of
    /// white-space characters.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <param name="paramName">The parameter name to use when throwing the exception.</param>
    /// <returns>The <see cref="string"/> if not null, nor empty and if it does not consist exclusively of white-space characters.</returns>
    [return: NotNull]
    public static string ThrowIfNullOrWhiteSpace([NotNull]this string? source, [CallerArgumentExpression(nameof(source))]string? paramName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(source, paramName);

        return source;
    }
}
