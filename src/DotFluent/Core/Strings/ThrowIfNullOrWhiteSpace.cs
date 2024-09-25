using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DotFluent;

public static partial class StringExtensions
{
    #region Methods

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
#if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrWhiteSpace(source, paramName);
#else
        if (source.IsNullOrWhiteSpace())
        {
            source.ThrowIfNull(paramName);
            throw new ArgumentException("The value cannot be an empty string or composed entirely of whitespace.", paramName);
        }
#endif
        return source;
    }

    #endregion
}
