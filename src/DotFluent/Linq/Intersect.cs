using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Produces the set intersection of two sequences by using
    /// a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
        => first.Intersect(second, ComparisonEqualityComparer<TSource>.Create(comparison));

    /// <summary>
    /// Produces the set intersection of two sequences by using
    /// specified functions to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence whose distinct elements that also appear in the second sequence will be returned.</param>
    /// <param name="second">The sequence whose distinct elements that also appear in the first sequence will be returned.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a value.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements that form the set intersection of two sequences.</returns>
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison, Func<TSource, int> hashCodeSelector)
        => first.Intersect(second, ComparisonEqualityComparer<TSource>.Create(comparison, hashCodeSelector));

    #endregion
}
