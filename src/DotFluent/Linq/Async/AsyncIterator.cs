namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private abstract partial class AsyncIterator<TSource> : IAsyncEnumerable<TSource>, IAsyncEnumerator<TSource>
    {
        #region Fields

        private readonly int _threadId = Environment.CurrentManagedThreadId;

        #endregion

        #region Properties

        public TSource Current { get; protected set; } = default!;

        protected AsyncIteratorState State { get; set; } = AsyncIteratorState.New;

        protected CancellationToken CancellationToken { get; set; }

        #endregion

        #region Methods

        public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var enumerator = State == AsyncIteratorState.New && _threadId == Environment.CurrentManagedThreadId
                ? this
                : Clone();

            enumerator.State = AsyncIteratorState.Allocated;
            enumerator.CancellationToken = cancellationToken;

            return enumerator;
        }

        public abstract ValueTask<bool> MoveNextAsync();

        public virtual ValueTask DisposeAsync()
        {
            Current = default!;
            State = AsyncIteratorState.Disposed;
            return ValueTask.CompletedTask;
        }

        protected abstract AsyncIterator<TSource> Clone();

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
