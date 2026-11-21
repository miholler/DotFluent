namespace DotFluent.Linq;

public static partial class EnumerableExtensions
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
        => source.ToHashSet(EqualityComparer<TSource>.Create(comparison));

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
        => source.ToHashSet(EqualityComparer<TSource>.Create(comparison, hashCodeSelector));

#if NETSTANDARD

    /// <summary>
    /// Creates a hashset from a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to create a hashset from.</param>
    /// <returns>
    /// A <see cref="HashSet{TSource}"/> that contains values of type TSource selected
    /// from the input sequence.
    /// </returns>
    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        => source.ToHashSet(comparer: null);

    /// <summary>
    /// Creates a hashset from a sequence using a specified
    /// comparer to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to create a hashset from.</param>
    /// <param name="comparer">The equality comparer to compare values.</param>
    /// <returns>
    /// A <see cref="HashSet{TSource}"/> that contains values of type TSource selected
    /// from the input sequence.
    /// </returns>
    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
    {
        source.ThrowIfNull();

        return new(source, comparer);
    }

#endif
}
