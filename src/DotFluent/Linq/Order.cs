namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Sorts the elements of a sequence in ascending order 
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
    public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.Order(Comparer<TSource>.Create(comparison));

#if NETSTANDARD

    /// <summary>
    /// Sorts the elements of a sequence in ascending order.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
    public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source)
        => source.Order(Comparer<TSource>.Default);

    /// <summary>
    /// Sorts the elements of a sequence in ascending order 
    /// by using a specified comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to order.</param>
    /// <param name="comparer">The comparer to compare values.</param>
    /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
    public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
        => source.OrderBy(x => x, comparer);

#endif

    #endregion
}
