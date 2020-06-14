using System.Collections.Generic;

namespace DotFluent.Linq
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Determines whether a sequence is not null and contains any elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence to check for not null and any elements.</param>
        /// <returns>true if the source sequence is not null and contains any elements; otherwise, false.</returns>
        public static bool IsNotNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source.IsNotNull())
            {
                using var enumerator = source.GetEnumerator();
                return enumerator.MoveNext();
            }
            return false;
        }

        #endregion
    }
}
