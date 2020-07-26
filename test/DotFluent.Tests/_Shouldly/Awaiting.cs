using System;
using System.Threading.Tasks;

namespace Shouldly
{
    [ShouldlyMethods]
    public static partial class ShouldlyExtensions
    {
        #region Methods

        public static Func<Task> Awaiting<TSource>(this TSource source, Func<TSource, Task> selector)
            => () => selector(source);

        #endregion
    }
}
