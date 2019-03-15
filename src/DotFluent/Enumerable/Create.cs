using System.Collections.Generic;
using System.Linq;

namespace DotFluent
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Returns a sequence containing all specified elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements.</typeparam>
        /// <param name="elements">The elements to create the sequence with.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> containing all specified elements.</returns>
        public static IEnumerable<TSource> Create<TSource>(params TSource[] elements)
            => elements ?? Enumerable.Empty<TSource>();

        #endregion
    }
}
