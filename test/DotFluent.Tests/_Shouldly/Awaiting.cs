using System;
using System.Threading.Tasks;

namespace Shouldly;

[ShouldlyMethods]
public static partial class ShouldlyExtensions
{
    #region Methods

    public static Func<Task> Awaiting<TSource>(this TSource source, Func<TSource, Task> selector)
        => () => selector(source);

    public static Func<Task> Awaiting<TSource>(this TSource source, Func<TSource, ValueTask> selector)
        => () => selector(source).AsTask();

    public static Func<Task> Awaiting<TSource, TResult>(this TSource source, Func<TSource, Task<TResult>> selector)
        => () => selector(source);

    public static Func<Task> Awaiting<TSource, TResult>(this TSource source, Func<TSource, ValueTask<TResult>> selector)
        => () => selector(source).AsTask();

    #endregion
}
