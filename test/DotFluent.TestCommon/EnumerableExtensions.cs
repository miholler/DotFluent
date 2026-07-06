namespace System.Linq;

public static class EnumerableExtensions
{
    public static IEnumerable<TSource> AsIterator<TSource>(this IEnumerable<TSource> source)
        => Iterator(source);

    private static IEnumerable<TSource> Iterator<TSource>(IEnumerable<TSource> source)
    {
        foreach (var item in source)
            yield return item;
    }
}
