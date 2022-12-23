using System;

namespace Shouldly;

public static partial class ShouldlyExtensions
{
    #region Methods

    public static Action Invoking<TSource>(this TSource source, Action<TSource> action)
        => () => action(source);

    public static Func<object> Invoking<TSource, TResult>(this TSource source, Func<TSource, TResult> selector)
        => () => selector(source);

    #endregion
}
