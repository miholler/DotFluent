namespace DotFluent.Linq;

public static partial class NullableLinqExtensions
{
    #region Methods

    /// <summary>
    /// Removes the value from a nullable object if it does not
    /// satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object whose value is to be filtered.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>
    /// A <see cref="Nullable{TSource}"/> whose value satisfies the condition in the predicate function;
    /// otherwise, an empty <see cref="Nullable{TSource}"/>.
    /// </returns>
    public static TSource? Where<TSource>(this TSource? source, Func<TSource, bool> predicate) where TSource : struct
        => source.Filter(predicate);

    #endregion
}
