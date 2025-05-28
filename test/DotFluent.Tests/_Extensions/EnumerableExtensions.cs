using System.Collections.Generic;

namespace DotFluent;

public static class EnumerableExtensions
{
    #region Methods

    public static IEnumerable<TSource> AsIterator<TSource>(this IEnumerable<TSource> source)
        => Iterator(source);

    private static IEnumerable<TSource> Iterator<TSource>(IEnumerable<TSource> source)
    {
        foreach (var item in source)
            yield return item;
    }

    #endregion
}
