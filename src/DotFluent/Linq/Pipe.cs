namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Performs a specified action on each element of a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IEnumerable<TSource> Pipe<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : PipeIterator(source, action);
    }

    /// <summary>
    /// Performs a specified action on each element of a sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IEnumerable<TSource> Pipe<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        return source.IsEmptyArray()
            ? []
            : PipeIterator(source, action);
    }

    private static IEnumerable<TSource> PipeIterator<TSource>(IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (var item in source)
        {
            action(item);
            yield return item;
        }
    }

    private static IEnumerable<TSource> PipeIterator<TSource>(IEnumerable<TSource> source, Action<TSource, int> action)
    {
        var index = 0;
        foreach (var item in source)
        {
            action(item, checked(index++));
            yield return item;
        }
    }
}
