namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Returns an empty <see cref="IAsyncEnumerable{TResult}"/> that has the specified
    /// type argument.
    /// </summary>
    /// <typeparam name="TResult">The type to assign to the type parameter of the returned generic <see cref="IAsyncEnumerable{TResult}"/>.</typeparam>
    /// <returns>An empty <see cref="IAsyncEnumerable{TResult}"/> whose type argument is TResult.</returns>
    public static IAsyncEnumerable<TResult> Empty<TResult>()
        => Enumerable
            .Empty<TResult>()
            .ToAsyncEnumerable();

    #endregion
}
