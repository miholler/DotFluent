namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns the minimum value in a generic sequence
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>The minimum value in the sequence.</returns>
    public static TSource? Min<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.Min(Comparer<TSource>.Create(comparison));
}
