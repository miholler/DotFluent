namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Produces the set difference of two sequences by using a specified compare function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence whose elements that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
        => first.Except(second, EqualityComparer<TSource>.Create(comparison));

    /// <summary>
    /// Produces the set difference of two sequences by using specified compare functions to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence whose elements that are not also in second will be returned.</param>
    /// <param name="second">The sequence whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a value.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the set difference of the elements of two sequences.</returns>
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison, HashFunc<TSource>? hashCodeSelector)
        => first.Except(second, EqualityComparer<TSource>.Create(comparison, hashCodeSelector));
}
