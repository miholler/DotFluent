namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private abstract partial class AsyncIterator<TSource> : IAsyncEnumerable<TSource>, IAsyncEnumerator<TSource>
    {
        #region Fields

        private readonly int _threadId = Environment.CurrentManagedThreadId;
        private protected AsyncIteratorState _state = AsyncIteratorState.New;
        private protected CancellationToken _cancellationToken;
        private protected TSource _current = default!;

        #endregion

        #region Properties

        public TSource Current => _current;

        #endregion

        #region Methods

        public AsyncIterator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var enumerator = _state == AsyncIteratorState.New && _threadId == Environment.CurrentManagedThreadId
                ? this
                : Clone();

            enumerator._state = AsyncIteratorState.Allocated;
            enumerator._cancellationToken = cancellationToken;

            return enumerator;
        }

        IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAsyncEnumerator(cancellationToken);

        public abstract ValueTask<bool> MoveNextAsync();

        public virtual ValueTask DisposeAsync()
        {
            _current = default!;
            _state = AsyncIteratorState.Disposed;
            return ValueTask.CompletedTask;
        }

        private protected abstract AsyncIterator<TSource> Clone();

        #endregion
    }

    private enum AsyncIteratorState
    {
        New = 0,
        Allocated = 1,
        Iterating = 2,
        Disposed = -1
    }

    #endregion
}
