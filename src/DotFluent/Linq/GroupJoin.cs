namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. The default equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector)
        => outer.GroupJoin(inner, keySelector, resultSelector, comparer: null);

    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. A specified function is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison)
        => outer.GroupJoin(inner, keySelector, resultSelector, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. Specified functions are used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => outer.GroupJoin(inner, keySelector, resultSelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));

    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. A specified equality comparer is used to compare keys.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the sequences.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector function.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="keySelector">A function to extract the join key from each element of the sequences.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <param name="comparer">The equality comparer to hash and compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(this IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
    {
        keySelector.ThrowIfNull();

        return outer.GroupJoin(inner, keySelector, keySelector, resultSelector, comparer);
    }

    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. A specified function is used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, EqualityComparison<TKey> comparison)
        => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Create(comparison));

    /// <summary>
    /// Correlates the elements of two sequences based on key equality and groups the
    /// results. Specified functions are used to compare keys.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result elements.</typeparam>
    /// <param name="outer">The first sequence to join.</param>
    /// <param name="inner">The sequence to join to the first sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
    /// <param name="resultSelector">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
    /// <param name="comparison">A function to compare keys.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a key.</param>
    /// <returns>An <see cref="IEnumerable{TResult}"/> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey>? hashCodeSelector)
        => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Create(comparison, hashCodeSelector));
}
