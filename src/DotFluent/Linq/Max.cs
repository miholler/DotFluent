namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Returns the maximum value in a generic sequence
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>The maximum value in the sequence.</returns>
    public static TSource? Max<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.Max(Comparer<TSource>.Create(comparison));

    #endregion
}
