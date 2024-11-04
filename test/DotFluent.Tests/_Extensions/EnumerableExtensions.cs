using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotFluent;

public static class EnumerableExtensions
{
    #region Methods

    public static IEnumerable<TSource> ToIterator<TSource>(this IEnumerable<TSource> source)
        => Iterator(source);

    public static IAsyncEnumerable<TSource> ToAsyncIterator<TSource>(this IEnumerable<TSource> source)
        => AsyncIterator(source);

    private static IEnumerable<TSource> Iterator<TSource>(IEnumerable<TSource> source)
    {
        foreach (var item in source)
            yield return item;
    }

    private static async IAsyncEnumerable<TSource> AsyncIterator<TSource>(IEnumerable<TSource> source)
    {
        await Task.Yield();
        foreach (var item in source)
            yield return item;
    }

    #endregion
}
