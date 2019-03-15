using System;
using System.Collections.Generic;

namespace DotFluent
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Determines whether a sequence contains no elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence to check for emptiness.</param>
        /// <returns>true if the source sequence contains no elements; otherwise, false.</returns>
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            source.ThrowIfNull(nameof(source));

            using (var enumerator = source.GetEnumerator())
                return !enumerator.MoveNext();
        }

        /// <summary>
        /// Determines whether no element of a sequence satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if no element in the source sequence passes the test in the specified predicate; otherwise false.</returns>
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            source.ThrowIfNull(nameof(source));
            predicate.ThrowIfNull(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                    return false;
            }
            return true;
        }

        #endregion
    }
}
