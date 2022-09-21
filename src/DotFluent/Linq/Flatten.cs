namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Flattens a sequence of nested sequences into one sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of nested sequences to flatten.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> containing the elements of all nested sequences of source.</returns>
    public static IEnumerable<TSource> Flatten<TSource>(this IEnumerable<IEnumerable<TSource>> source)
        => FlattenIterator(source.ThrowIfNull());

    /// <summary>
    /// Flattens a sequence of one-to-many linked elements by using a specified function
    /// to project the nested sequence of each element.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to flatten.</param>
    /// <param name="selector">A function to extract the nested sequence of each element.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> containing the elements of source and all nested sequences.</returns>
    public static IEnumerable<TSource> Flatten<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        return FlattenIterator(source, selector);
    }

    private static IEnumerable<TSource> FlattenIterator<TSource>(IEnumerable<IEnumerable<TSource>> source)
    {
        foreach (var item in source)
            foreach (var child in item)
                yield return child;
    }

    private static IEnumerable<TSource> FlattenIterator<TSource>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> selector)
    {
        foreach (var item in source)
        {
            yield return item;
            
            var children = selector(item);
            if (children.IsNotNull())
                foreach (var child in FlattenIterator(children, selector))
                    yield return child;
        }
    }

    #endregion
}
