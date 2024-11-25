using DotFluent.Optional;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private abstract partial class AsyncIterator<TSource>
    {
        #region Methods

        public abstract ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default);

        public abstract ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default);

        public abstract ValueTask<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken = default);

        public virtual ValueTask<Option<TSource>> GetElementAtAsync(int index, CancellationToken cancellationToken = default)
            => index == 0
                ? GetFirstAsync(cancellationToken)
                : GetElementAtNonIteratorAsync(this, index, cancellationToken);

        public virtual ValueTask<Option<TSource>> GetFirstAsync(CancellationToken cancellationToken = default)
            => GetFirstNonIteratorAsync(this, cancellationToken);

        public virtual ValueTask<Option<TSource>> GetLastAsync(CancellationToken cancellationToken = default)
            => GetLastNonIteratorAsync(this, cancellationToken);

        #endregion
    }

    #endregion
}
