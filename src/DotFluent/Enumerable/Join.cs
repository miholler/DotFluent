using DotFluent.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent
{
    public static partial class EnumerableExtensions
    {
        #region Methods

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. 
        /// A specified function is used to compare keys.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
        /// <typeparam name="TResult">The type of the result elements.</typeparam>
        /// <param name="outer">The first sequence to join.</param>
        /// <param name="inner">The sequence to join to the first sequence.</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing an inner join on two sequences.</returns>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, Func<TKey, TKey, bool> comparer)
            => outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, new GenericEqualityComparer<TKey>(comparer));

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. 
        /// Specified functions are used to compare keys.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
        /// <typeparam name="TResult">The type of the result elements.</typeparam>
        /// <param name="outer">The first sequence to join.</param>
        /// <param name="inner">The sequence to join to the first sequence.</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that has elements of type TResult that are obtained by performing an inner join on two sequences.</returns>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, new GenericEqualityComparer<TKey>(comparer, hashCodeProvider));

        #endregion
    }
}
