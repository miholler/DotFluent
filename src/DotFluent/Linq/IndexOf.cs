using DotFluent.Internal;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Returns the zero-based index of a specified element in a sequence by
        /// using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <returns>
        /// The zero-based index of the specified element if the source sequence contains 
        /// an element that has the specified value; otherwise, minus 1.
        /// </returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource value)
            => source.IndexOf(value, default(IEqualityComparer<TSource>));

        /// <summary>
        /// Returns the zero-based index of a specified element in a sequence by
        /// using a specified compare function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="comparer">A function to compare values.</param>
        /// <returns>
        /// The zero-based index of the specified element if the source sequence contains 
        /// an element that has the specified value; otherwise, minus 1.
        /// </returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> comparer)
            => source.IndexOf(value, GenericEqualityComparer<TSource>.Create(comparer));

        /// <summary>
        /// Returns the zero-based index of a specified element in a sequence by
        /// using a specified equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="comparer">The equality comparer to compare values.</param>
        /// <returns>
        /// The zero-based index of the specified element if the source sequence contains 
        /// an element that has the specified value; otherwise, minus 1.
        /// </returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            source.ThrowIfNull(nameof(source));
            comparer = comparer ?? EqualityComparer<TSource>.Default;

            var index = 0;
            foreach (var item in source)
            {
                if (comparer.Equals(item, value))
                    return index;

                checked { index++; };
            }
            return -1;
        }

        #endregion
    }
}
