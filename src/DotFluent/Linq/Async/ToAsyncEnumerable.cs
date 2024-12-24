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

        return new EnumerableAsyncIterator<TSource>(source);
    }

    #endregion

    #region Nested Classes

    private sealed partial class EnumerableAsyncIterator<T>(IEnumerable<T> source) : AsyncIterator<T>
    {
        #region Fields

        private readonly IEnumerable<T> _source = source;
        private IEnumerator<T>? _enumerator;

        #endregion

        #region Methods

        public override async ValueTask<bool> MoveNextAsync()
        {
            switch (_state)
            {
                case AsyncIteratorState.Allocated:
                    _enumerator = _source.GetEnumerator();
                    _state = AsyncIteratorState.Iterating;
                    goto case AsyncIteratorState.Iterating;
                case AsyncIteratorState.Iterating:
                    _enumerator.ThrowIfNull();
                    if (_enumerator.MoveNext())
                    {
                        _current = _enumerator.Current;
                        return true;
                    }
                    await DisposeAsync().ConfigureAwait(false);
                    break;
            }
            return false;
        }

        public override ValueTask DisposeAsync()
        {
            if (_enumerator.IsNotNull())
            {
                _enumerator.Dispose();
                _enumerator = null;
            }
            return base.DisposeAsync();
        }

        private protected override AsyncIterator<T> Clone()
            => new EnumerableAsyncIterator<T>(_source);

        #endregion
    }

    #endregion
}
