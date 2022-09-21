using DotFluent.Internal;

namespace DotFluent.Linq;

/// <summary>
/// Provides a set of static methods for querying objects
/// that implement <see cref="IEnumerable{T}"/>.
/// </summary>
public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Determines whether a sequence contains a specified element by using a specified compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="comparer">A function to compare values.</param>
    /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> comparer)
        => source.Contains(value, GenericEqualityComparer<TSource>.Create(comparer));

    #endregion
}
