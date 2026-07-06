namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Produces the Cartesian product of two sequences by pairing every element of the first
    /// sequence with every element of the second sequence.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <c>(TOuter Outer, TInner Inner)</c> tuples that are obtained by performing a cross join on two sequences.</returns>
    public static IEnumerable<(TOuter Outer, TInner Inner)> CrossJoin<TOuter, TInner>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner)
        => outer.CrossJoin(inner, static (x, y) => (x, y));

    /// <summary>
    /// Produces the Cartesian product of two sequences by pairing every element of the first
    /// sequence with every element of the second sequence.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two elements.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a cross join on two sequences.</returns>
    public static IEnumerable<TResult> CrossJoin<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TInner, TResult> resultSelector)
    {
        outer.ThrowIfNull();
        inner.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return CrossJoinIterator(outer, inner, resultSelector);
    }

    private static IEnumerable<TResult> CrossJoinIterator<TOuter, TInner, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TInner, TResult> resultSelector)
    {
        if (inner is not ICollection<TInner> elements)
            elements = [.. inner];

        foreach (var outerItem in outer)
            foreach (var innerItem in elements)
                yield return resultSelector(outerItem, innerItem);
    }
}
