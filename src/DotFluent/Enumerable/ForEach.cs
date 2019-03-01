using System;
using System.Collections.Generic;

namespace DotFluent
{
    /// <summary>
    /// Provides extension methods for objects that implement <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region Methods

        /// <summary>
        /// Performs a specified action on each element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence to perform an action on each of its elements on.</param>
        /// <param name="action">An action to perform on each element of the sequence.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            source.ThrowIfNull(nameof(source));
            action.ThrowIfNull(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Performs a specified action on each element of a sequence and incorporates the element's index.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence to perform an action on each of its elements on.</param>
        /// <param name="action">An action to perform on each element of the sequence.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            source.ThrowIfNull(nameof(source));
            action.ThrowIfNull(nameof(action));

            var index = 0;
            foreach (var item in source)
                action(item, checked(index++));
        }

        #endregion
    }
}
