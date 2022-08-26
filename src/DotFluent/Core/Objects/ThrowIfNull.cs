using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DotFluent;

public static partial class ObjectExtensions
{
    #region Methods

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if an object is null; otherwise, returns the object.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to check for null.</param>
    /// <param name="paramName">The parameter name to use when throwing the <see cref="ArgumentNullException"/>.</param>
    /// <returns>The object if not null.</returns>
    [return: NotNull]
    public static TSource ThrowIfNull<TSource>([NotNull]this TSource? source, [CallerArgumentExpression("source")]string? paramName = null)
        => source ?? throw new ArgumentNullException(paramName);

    /// <summary>
    /// Throws an <see cref="Exception"/> created by a specified function if an object is null; otherwise, returns the object.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to check for null.</param>
    /// <param name="factory">A function to create the <see cref="Exception"/>.</param>
    /// <returns>The object if not null.</returns>
    [return: NotNull]
    public static TSource ThrowIfNull<TSource>([NotNull]this TSource? source, Func<Exception> factory)
        => source ?? throw factory();

    #endregion
}
