namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Creates an async-sequence from a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to create an async-sequence from.</param>
    /// <returns>An <see cref="IAsyncEnumerable{TSource}"/> that contains the elements from the input sequence.</returns>
    public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
    {
        source.ThrowIfNull();

        return new AsyncEnumerableIterator<TSource>(source);
    }

    #endregion

    #region Nested Classes

    private sealed class AsyncEnumerableIterator<T>(IEnumerable<T> source) : AsyncIterator<T>
    {
        #region Fields

        private readonly IEnumerable<T> _source = source;
        private IEnumerator<T>? _enumerator;

        #endregion

        #region Methods

        public override async ValueTask<bool> MoveNextAsync()
        {
            switch (State)
            {
                case AsyncIteratorState.Allocated:
                    _enumerator = _source.GetEnumerator();
                    State = AsyncIteratorState.Iterating;
                    goto case AsyncIteratorState.Iterating;
                case AsyncIteratorState.Iterating:
                    _enumerator.ThrowIfNull();
                    if (_enumerator.MoveNext())
                    {
                        Current = _enumerator.Current;
                        return true;
                    }
                    await DisposeAsync().ConfigureAwait(false);
                    break;
            }
            return false;
        }

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

        public override ValueTask DisposeAsync()
        {
            if (_enumerator.IsNotNull())
            {
                _enumerator.Dispose();
                _enumerator = null;
            }
            return base.DisposeAsync();
        }

        protected override AsyncIterator<T> Clone()
            => new AsyncEnumerableIterator<T>(_source);

        #endregion
    }

    #endregion
}
