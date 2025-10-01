namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns the first element of a sequence, or a default value created by a specified function if
    /// the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return the first element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>The default value created by the specified function if the source sequence is empty; otherwise, the first element in the source sequence.</returns>
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        switch (source)
        {
            case IList<TSource> list:
                if (list.Count > 0)
                    return list[0];
                break;
            default:
                using (var enumerator = source.GetEnumerator())
                    if (enumerator.MoveNext())
                        return enumerator.Current;
                break;
        }
        return defaultFactory();
    }

    /// <summary>
    /// Returns the first element of the sequence that satisfies a condition, or a default value created by
    /// a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or if no element passes the test in the predicate function;
    /// otherwise, the first element that passes the test in the predicate function.
    /// </returns>
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        foreach (var item in source)
        {
            if (predicate(item))
                return item;
        }
        return defaultFactory();
    }
}
