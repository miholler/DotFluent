namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Returns an async-sequence containing all specified elements.
    /// </summary>
    /// <typeparam name="TResult">The type of the elements.</typeparam>
    /// <param name="elements">The elements to create the async-sequence with.</param>
    /// <returns>An <see cref="IAsyncEnumerable{TResult}"/> containing all specified elements.</returns>
    public static IAsyncEnumerable<TResult> Create<TResult>(params TResult[]? elements)
        => Sequence
            .Create(elements)
            .ToAsyncEnumerable();

    #endregion
}
