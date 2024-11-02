namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Sorts the elements of a sequence in descending order 
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order.</returns>
    public static IOrderedEnumerable<TSource> OrderDescending<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.OrderDescending(Comparer<TSource>.Create(comparison));

#if !NET8_0_OR_GREATER

    /// <summary>
    /// Sorts the elements of a sequence in descending order.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order.</returns>
    public static IOrderedEnumerable<TSource> OrderDescending<TSource>(this IEnumerable<TSource> source)
        => source.OrderDescending(comparer: null);

    /// <summary>
    /// Sorts the elements of a sequence in descending order 
    /// by using a specified comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <param name="comparer">The comparer to compare values.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order.</returns>
    public static IOrderedEnumerable<TSource> OrderDescending<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
        => source.OrderByDescending(x => x, comparer);

#endif

    #endregion
}
