using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotFluent.Linq;

public static class AsyncEnumerable
{
    #region Methods

    public static IAsyncEnumerable<TResult> Create<TResult>(IEnumerable<TResult> elements)
        => CreateIterator(elements);

    private static async IAsyncEnumerable<TResult> CreateIterator<TResult>(IEnumerable<TResult> elements)
    {
        await Task.Yield();
        foreach (var element in elements)
            yield return element;
    }

    #endregion
}
