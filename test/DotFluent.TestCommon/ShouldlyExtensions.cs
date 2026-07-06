namespace Shouldly;

[ShouldlyMethods]
public static class ShouldlyExtensions
{
    public static Func<Task> Awaiting<TSource>(this TSource source, Func<TSource, Task> selector)
        => () => selector(source);

    public static Func<Task> Awaiting<TSource>(this TSource source, Func<TSource, ValueTask> selector)
        => () => selector(source).AsTask();

    public static Func<Task> Awaiting<TSource, TResult>(this TSource source, Func<TSource, Task<TResult>> selector)
        => () => selector(source);

    public static Func<Task> Awaiting<TSource, TResult>(this TSource source, Func<TSource, ValueTask<TResult>> selector)
        => () => selector(source).AsTask();

    public static Action Invoking<TSource>(this TSource source, Action<TSource> action)
        => () => action(source);

    public static Func<object> Invoking<TSource, TResult>(this TSource source, Func<TSource, TResult> selector)
        => () => selector(source);
}
