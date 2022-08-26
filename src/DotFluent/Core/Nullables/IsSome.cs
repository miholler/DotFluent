using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class NullableExtensions
{
    #region Methods

    /// <summary>
    /// Determines whether a nullable object has a value (is a 'Some' value).
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <returns>true if the nullable object has a value; otherwise, false.</returns>
    public static bool IsSome<TSource>([NotNullWhen(true)]this TSource? source) where TSource : struct
        => source.HasValue;

    #endregion
}
