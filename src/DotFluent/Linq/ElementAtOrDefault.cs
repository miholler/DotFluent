namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns the element at a specified index in a sequence or a specified default value 
    /// if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="defaultValue">The value to return if the index is out of range.</param>
    /// <returns>
    /// The specified default value if the index is outside the bounds of the source sequence; otherwise,
    /// the element at the specified position in the source sequence.
    /// </returns>
    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource defaultValue)
        => source.ElementAtOrDefault(index, () => defaultValue);

    /// <summary>
    /// Returns the element at a specified index in a sequence or a default value
    /// created by a specified function if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the index is outside the bounds of the source sequence; otherwise,
    /// the element at the specified position in the source sequence.
    /// </returns>
    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index, Func<TSource> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        if (index >= 0)
        {
            switch (source)
            {
                case IList<TSource> list:
                    if (list.Count > index)
                        return list[index];
                    break;
                default:
                    using (var enumerator = source.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if (index == 0)
                                return enumerator.Current;

                            index--;
                        }
                    }
                    break;
            }
        }
        return defaultFactory();
    }
}
