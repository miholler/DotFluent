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

        public virtual ValueTask<Option<TSource>> GetFirstAsync(CancellationToken cancellationToken = default)
            => GetFirstNonIteratorAsync(this, cancellationToken);

        #endregion
    }

    #endregion
}
