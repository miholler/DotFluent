namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns distinct elements from a sequence by using a specified compare function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, EqualityComparison<TSource> comparison)
        => source.Distinct(EqualityComparer<TSource>.Create(comparison));

    /// <summary>
    /// Returns distinct elements from a sequence by using specified compare functions to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a value.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, EqualityComparison<TSource> comparison, HashFunc<TSource>? hashCodeSelector)
        => source.Distinct(EqualityComparer<TSource>.Create(comparison, hashCodeSelector));
}
