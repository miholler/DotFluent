namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    private static async ValueTask<(TSource? First, bool Found)> TryGetFirstNonIteratorAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        return await enumerator.MoveNextAsync()
            ? (enumerator.Current, true)
            : (default, false);
    }

    #endregion
}
