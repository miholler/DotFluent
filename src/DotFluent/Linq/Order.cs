using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Sorts the elements of a sequence in ascending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of values to order.</param>
        /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source)
            => source.OrderBy(x => x);

        /// <summary>
        /// Sorts the elements of a sequence in ascending order 
        /// by using a specified function to compare values.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of values to order.</param>
        /// <param name="comparison">A function to compare values.</param>
        /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
            => source.OrderBy(x => x, Comparer<TSource>.Create(comparison));

        /// <summary>
        /// Sorts the elements of a sequence in ascending order 
        /// by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of values to order.</param>
        /// <param name="comparer">A comparer to compare values.</param>
        /// <returns>An <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted.</returns>
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
            => source.OrderBy(x => x, comparer);

        #endregion
    }
}
