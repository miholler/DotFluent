using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Returns the elements of a sequence or a singleton collection containing
        /// a default value created by a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence to return a default value for if it is empty.</param>
        /// <param name="defaultFactory">A function to create a default value.</param>
        /// <returns>
        /// An <see cref="IEnumerable{TSource}"/> that contains the default value created by the specified function if the source sequence
        /// is empty; otherwise, the source sequence.
        /// </returns>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultFactory)
        {
            source.ThrowIfNull(nameof(source));
            defaultFactory.ThrowIfNull(nameof(defaultFactory));

            return DefaultIfEmptyIterator(source, defaultFactory);
        }

        private static IEnumerable<TSource> DefaultIfEmptyIterator<TSource>(IEnumerable<TSource> source, Func<TSource> defaultFactory)
        {
            using var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                yield return defaultFactory();
                yield break;
            }
            do
            {
                yield return enumerator.Current;
            }
            while (enumerator.MoveNext());
        }

        #endregion
    }
}
