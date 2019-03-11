using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent
{
    public static partial class EnumerableExtensions
    {
        #region Methods

        /// <summary>
        /// Sorts the elements of a sequence in descending order
        /// by using a specified function to compare keys.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparison">A function to compare keys.</param>
        /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order according to a key.</returns>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
            => source.OrderByDescending(keySelector, Comparer<TKey>.Create(comparison));

        #endregion
    }
}
