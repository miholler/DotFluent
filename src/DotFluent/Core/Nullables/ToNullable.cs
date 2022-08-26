using System;

namespace DotFluent;

public static partial class NullableExtensions
{
    #region Methods

    /// <summary>
    /// Creates a nullable object from an object.
    /// </summary>
    /// <typeparam name="TSource">The type of the object.</typeparam>
    /// <param name="source">The object to create a nullable object from.</param>
    /// <returns>A <see cref="Nullable{TSource}"/> representing source.</returns>
    public static TSource? ToNullable<TSource>(this TSource source) where TSource : struct
        => source;

    #endregion
}
