using DotFluent.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DotFluent;

public static partial class StringExtensions
{
    #region Methods

    /// <summary>
    /// Throws an exception if a string is null or an empty string; otherwise, returns the string.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <param name="paramName">The parameter name to use when throwing the exception.</param>
    /// <returns>The <see cref="string"/> if not null nor an empty string ("").</returns>
    [return: NotNull]
    public static string ThrowIfNullOrEmpty([NotNull]this string? source, [CallerArgumentExpression(nameof(source))]string? paramName = null)
    {
#if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(source, paramName); 
#else
        if (source.IsNullOrEmpty())
        {
            source.ThrowIfNull(paramName);
            throw new ArgumentException(Errors.ArgumentEmptyString, paramName);
        }
#endif
        return source;
    }

    #endregion
}
