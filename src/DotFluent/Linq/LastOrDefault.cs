namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Returns the last element of a sequence, or a default value created by a specified function if 
    /// the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return the last element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>The default value created by the specified function if the source sequence is empty; otherwise, the last element in the source sequence.</returns>
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        switch (source)
        {
            case IList<TSource> list:
                if (list.Count > 0)
                    return list[list.Count - 1];
                break;
            default:
                using (var enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        var item = enumerator.Current;
                        while (enumerator.MoveNext())
                            item = enumerator.Current;

                        return item;
                    }
                }
                break;
        }
        return defaultFactory();
    }

    /// <summary>
    /// Returns the last element of the sequence that satisfies a condition or a default value created by
    /// a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or if no element passes the test in the predicate function;
    /// otherwise, the last element that passes the test in the predicate function.
    /// </returns>
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var resultFactory = defaultFactory;
        foreach (var item in source)
        {
            if (predicate(item))
                resultFactory = () => item;
        }
        return resultFactory();
    }

#if NETSTANDARD

    /// <summary>
    /// Returns the last element of a sequence, or a specified default value if the sequence contains
    /// no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return the last element of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the last element in the source sequence.</returns>
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        => source.LastOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the last element of the sequence that satisfies a condition or a specified default
    /// value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or if no element satisfies the condition.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or if no element passes the test in the predicate function;
    /// otherwise, the last element that passes the test in the predicate function.
    /// </returns>
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        => source.LastOrDefault(predicate, () => defaultValue);

#endif

    #endregion
}
