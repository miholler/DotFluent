namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Returns an async-sequence typed as <see cref="IAsyncEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to type as <see cref="IAsyncEnumerable{TSource}"/>.</param>
    /// <returns>The input async-sequence typed as <see cref="IAsyncEnumerable{TSource}"/>.</returns>
    public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
        => source;

    #endregion
}
