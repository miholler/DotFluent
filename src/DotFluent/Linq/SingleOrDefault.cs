namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Returns the only element of a sequence, or a default value created by a specified function
    /// if the sequence is empty; this method throws an exception if there is more than one element 
    /// in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return the single element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>The default value created by the specified function if the source sequence is empty; otherwise, the single element of the source sequence.</returns>
    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        switch (source)
        {
            case IList<TSource> list:
                if (list.Count == 0)
                    return defaultFactory();
                if (list.Count == 1)
                    return list[0];
                break;
            default:
                using (var enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                        return defaultFactory();

                    var item = enumerator.Current;
                    if (!enumerator.MoveNext())
                        return item;
                }
                break;
        }
        throw new InvalidOperationException("Sequence contains more than one element.");
    }

    /// <summary>
    /// Returns the only element of a sequence that satisfies a specified condition or
    /// a default value created by a specified function if no such element exists; this method 
    /// throws an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The single element of the source sequence that satisfies the condition; otherwise, the default value created by the specified function 
    /// if no such element is found.
    /// </returns>
    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        var resultFactory = defaultFactory;
        foreach (var item in source)
        {
            if (predicate(item))
            {
                resultFactory = () => item;
                checked { count++; }
            }
        }
        return count <= 1
            ? resultFactory()
            : throw new InvalidOperationException("Sequence contains more than one matching element.");
    }

    #endregion
}
