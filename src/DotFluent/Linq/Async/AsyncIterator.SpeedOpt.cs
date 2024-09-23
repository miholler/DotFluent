namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Nested Classes

    private abstract partial class AsyncIterator<TSource>
    {
        #region Methods

        public abstract ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default);

        public abstract ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default);

        #endregion
    }

    #endregion
}
