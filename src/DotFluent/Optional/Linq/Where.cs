namespace DotFluent.Optional.Linq;

public static partial class OptionLinqExtensions
{
    #region Methods

    /// <summary>
    /// Removes the value from an option if it does not satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option whose value is to be filtered.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>
    /// An <see cref="Option{TSource}"/> whose value satisfies the condition in the predicate function;
    /// otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Option<TSource> Where<TSource>(this Option<TSource> source, Func<TSource, bool> predicate)
        => source.Filter(predicate);

    #endregion
}
