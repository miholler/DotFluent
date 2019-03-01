using System.Collections.Generic;

namespace System.Fluent
{
    public static partial class EnumerableExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether a sequence is null or contains no elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence to check for null or emptiness.</param>
        /// <returns>true if the source sequence is null or contains no elements; otherwise, false.</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source.IsNotNull())
            {
                using (var enumerator = source.GetEnumerator())
                    return !enumerator.MoveNext();
            }
            return true;
        }

        #endregion
    }
}
