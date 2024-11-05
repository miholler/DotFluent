using DotFluent.Optional;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    private static async ValueTask<Option<TSource>> TryGetFirstNonIteratorAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        return await enumerator.MoveNextAsync()
            ? Option.Some(enumerator.Current)
            : Option.None<TSource>();
    }

    #endregion
}
