namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private sealed partial class AsyncEnumerableIterator<T>
    {
        #region Methods

        public override ValueTask<T[]> ToArrayAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? new(Task.FromCanceled<T[]>(cancellationToken))
                : new(_source.ToArray());

        public override ValueTask<List<T>> ToListAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? new(Task.FromCanceled<List<T>>(cancellationToken))
                : new(_source.ToList());

        public override ValueTask<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? new(Task.FromCanceled<int>(cancellationToken))
                : onlyIfCheap
                ? new(_source.TryGetNonEnumeratedCount(out var count) ? count : -1)
                : new(_source.Count());

        public override ValueTask<(T? First, bool Found)> TryGetFirstAsync(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested
                ? new(Task.FromCanceled<(T?, bool)>(cancellationToken))
                : new(_source
                    .Select(x => (x, true))
                    .FirstOrDefault());

        #endregion
    }

    #endregion
}
