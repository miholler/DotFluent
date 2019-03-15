using DotFluent.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Produces the set union of two sequences by using a specified compare function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
        /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
        /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
        /// <param name="comparer">A function to compare values.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
            => first.Union(second, GenericEqualityComparer<TSource>.Create(comparer));

        /// <summary>
        /// Produces the set union of two sequences by using specified compare functions.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
        /// <param name="first">The sequence whose distinct elements form the first set for the union.</param>
        /// <param name="second">The sequence whose distinct elements form the second set for the union.</param>
        /// <param name="comparer">A function to compare values.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a value.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the elements from both input sequences, excluding duplicates.</returns>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer, Func<TSource, int> hashCodeProvider)
            => first.Union(second, GenericEqualityComparer<TSource>.Create(comparer, hashCodeProvider));

        #endregion
    }
}
