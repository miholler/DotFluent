using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. The default
    /// equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource?, TSource, TResult> resultSelector)
        => outer.RightJoin(inner, keySelector, resultSelector, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. A specified
    /// function is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource?, TSource, TResult> resultSelector, Func<TKey, TKey, bool> comparer)
        => outer.RightJoin(inner, keySelector, resultSelector, GenericEqualityComparer<TKey>.Create(comparer));

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. Specified
    /// functions are used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource?, TSource, TResult> resultSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
        => outer.RightJoin(inner, keySelector, resultSelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. A specified
    /// equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource?, TSource, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
    {
        keySelector.ThrowIfNull();

        return outer.RightJoin(inner, keySelector, keySelector, resultSelector, comparer);
    }

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. The default
    /// equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector)
        => outer.RightJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. A specified
    /// function is used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, Func<TKey, TKey, bool> comparer)
        => outer.RightJoin(inner, outerKeySelector, innerKeySelector, resultSelector, GenericEqualityComparer<TKey>.Create(comparer));

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. Specified
    /// functions are used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">A function to compare keys.</param>
    /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
        => outer.RightJoin(inner, outerKeySelector, innerKeySelector, resultSelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

    /// <summary>
    /// Correlates the elements of two sequences based on matching keys. A specified
    /// equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements or from one element having no match.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing a right outer join on two sequences.</returns>
    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
    {
        outer.ThrowIfNull();
        inner.ThrowIfNull();
        outerKeySelector.ThrowIfNull();
        innerKeySelector.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return from g in inner.GroupJoin(outer, innerKeySelector, outerKeySelector, (i, ie) => new { Inner = i, Outers = ie }, comparer)
               from o in g.Outers.DefaultIfEmpty()
               select resultSelector(o, g.Inner);
    }

    #endregion
}
