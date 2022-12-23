namespace DotFluent;

public static partial class NullableExtensions
{
    #region Methods

    /// <summary>
    /// Performs a specified action if a nullable object has no value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="none">An action to perform if a value is missing.</param>
    public static void Match<TSource>(this TSource? source, Action none) where TSource : struct
    {
        none.ThrowIfNull();

        if (source.IsNone())
            none();
    }

    /// <summary>
    /// Performs a specified action if a nullable object has a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="some">An action to perform if a value is present.</param>
    public static void Match<TSource>(this TSource? source, Action<TSource> some) where TSource : struct
    {
        some.ThrowIfNull();

        if (source.IsSome())
            some(source.Value);
    }

    /// <summary>
    /// Performs a specified action based on whether a nullable object has a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="some">An action to perform if a value is present.</param>
    /// <param name="none">An action to perform if a value is missing.</param>
    public static void Match<TSource>(this TSource? source, Action<TSource> some, Action none) where TSource : struct
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        if (source.IsSome())
            some(source.Value);
        else
            none();
    }

    /// <summary>
    /// Invokes a specified function, or returns a specified alternative value 
    /// based on whether a nullable object has a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">The value to return if a value is missing.</param>
    /// <returns>The result of the invoked function if a value is present; otherwise the specified alternative value.</returns>
    public static TResult Match<TSource, TResult>(this TSource? source, Func<TSource, TResult> some, TResult none) where TSource : struct
        => source.Match(some, () => none);

    /// <summary>
    /// Invokes a specified function based on whether a nullable object has a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by the invoked function.</typeparam>
    /// <param name="source">The nullable object to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <returns>The result of the invoked function.</returns>
    public static TResult Match<TSource, TResult>(this TSource? source, Func<TSource, TResult> some, Func<TResult> none) where TSource : struct
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        return source.IsSome()
            ? some(source.Value)
            : none();
    }

    #endregion
}
