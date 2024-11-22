using DotFluent.Optional;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private sealed partial class AsyncEnumerableIterator<T>
    {
        #region Methods

        public override ValueTask<T[]> ToArrayAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? ValueTask.FromCanceled<T[]>(cancellationToken)
                : new(_source.ToArray());

        public override ValueTask<List<T>> ToListAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? ValueTask.FromCanceled<List<T>>(cancellationToken)
                : new(_source.ToList());

        public override ValueTask<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? ValueTask.FromCanceled<int>(cancellationToken)
                : onlyIfCheap
                ? new(_source.TryGetNonEnumeratedCount(out var count) ? count : -1)
                : new(_source.Count());

        public override ValueTask<Option<T>> GetFirstAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? ValueTask.FromCanceled<Option<T>>(cancellationToken)
                : new(_source
                    .Select(Option.Some)
                    .FirstOrDefault());

        public override ValueTask<Option<T>> GetLastAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? ValueTask.FromCanceled<Option<T>>(cancellationToken)
                : new(_source
                    .Select(Option.Some)
                    .LastOrDefault());

        #endregion
    }

    #endregion
}
