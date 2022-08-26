namespace DotFluent.Optional;

/// <summary>
/// Provides a set of static methods for working 
/// with <see cref="Option{T}"/> instances.
/// </summary>
public static partial class Option
{
    #region Methods

    /// <summary>
    /// Flattens an option with a nested option into one option.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of the nested option.</typeparam>
    /// <param name="source">The option with a nested option to flatten.</param>
    /// <returns>An <see cref="Option{TSource}"/> representing the flattened result.</returns>
    public static Option<TSource> Flatten<TSource>(this Option<Option<TSource>> source)
        => source.FlatMap(x => x);

    #endregion
}
