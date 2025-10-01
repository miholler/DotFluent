using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Creates a hashset from a sequence using a specified
    /// compare function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to create a hashset from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>
    /// A <see cref="HashSet{TSource}"/> that contains values of type TSource selected
    /// from the input sequence.
    /// </returns>
    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, EqualityComparison<TSource> comparison)
        => source.ToHashSet(EqualityComparer.Create(comparison));

    /// <summary>
    /// Creates a hashset from a sequence using specified
    /// compare functions to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to create a hashset from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a value.</param>
    /// <returns>
    /// A <see cref="HashSet{TSource}"/> that contains values of type TSource selected
    /// from the input sequence.
    /// </returns>
    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, EqualityComparison<TSource> comparison, HashFunc<TSource>? hashCodeSelector)
        => source.ToHashSet(EqualityComparer.Create(comparison, hashCodeSelector));
}
