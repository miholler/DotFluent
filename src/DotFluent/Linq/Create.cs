namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    extension(Enumerable)
    {
        /// <summary>
        /// Returns a sequence containing all specified elements.
        /// </summary>
        /// <typeparam name="TResult">The type of the elements.</typeparam>
        /// <param name="elements">The elements to create the sequence with.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> containing all specified elements.</returns>
        public static IEnumerable<TResult> Create<TResult>(params IEnumerable<TResult>? elements)
            => elements ?? [];
    }
}
