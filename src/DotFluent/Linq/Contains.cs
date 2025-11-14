namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Determines whether a sequence contains a specified element by using a specified compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns><see langword="true"/> if the source sequence contains an element that has the specified value; otherwise, <see langword="false"/>.</returns>
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, EqualityComparison<TSource> comparison)
        => source.Contains(value, EqualityComparer<TSource>.Create(comparison));
}
