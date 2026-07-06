namespace DotFluent.Optional;

public static partial class Option
{
    /// <summary>
    /// Removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option whose value is to be checked for null.</param>
    /// <returns>
    /// An <see cref="Option{TSource}"/> whose value is not null;
    /// otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Option<TSource> Secure<TSource>(this Option<TSource?> source) where TSource : class
        => source.FlatMap(x => x.ToOption());

    /// <summary>
    /// Removes the value from an option if it is a null value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option whose value is to be checked for null.</param>
    /// <returns>
    /// An <see cref="Option{TSource}"/> whose value is not null;
    /// otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Option<TSource> Secure<TSource>(this Option<TSource?> source) where TSource : struct
        => source.FlatMap(x => x.ToOption());
}
