namespace DotFluent.Linq;

public static partial class AsyncEnumerableExtensions
{
    extension(AsyncEnumerable)
    {
        /// <summary>
        /// Returns an asynchronous sequence containing all specified elements.
        /// </summary>
        /// <typeparam name="TResult">The type of the elements of the sequence.</typeparam>
        /// <param name="elements">The elements to create the asynchronous sequence with.</param>
        /// <returns>An <see cref="IAsyncEnumerable{TResult}"/> containing all specified elements.</returns>
        public static IAsyncEnumerable<TResult> Create<TResult>(params IEnumerable<TResult>? elements)
            => elements?.ToAsyncEnumerable() ?? AsyncEnumerable.Empty<TResult>();
    }
}
