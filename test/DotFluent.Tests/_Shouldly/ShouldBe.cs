using System.Collections.Generic;

namespace Shouldly
{
    public static partial class ShouldlyExtensions
    {
        #region Methods

        public static void ShouldBe<TSource>(this IEnumerable<TSource> source, params TSource[] expected)
            => source.ShouldBe(expected, false);

        #endregion
    }
}
