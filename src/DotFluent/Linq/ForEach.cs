namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Performs a specified action on each element of a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the sequence.</param>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        foreach (var item in source)
            action(item);
    }

    /// <summary>
    /// Performs a specified action on each element of a sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the sequence.</param>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        var index = 0;
        foreach (var item in source)
            action(item, checked(index++));
    }
}
