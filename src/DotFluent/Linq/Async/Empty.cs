namespace DotFluent.Linq;

#if !NET10_0_OR_GREATER

public static partial class AsyncEnumerable
{
    /// <summary>
    /// Returns an empty asynchronous sequence that has the specified type argument.
    /// </summary>
    /// <typeparam name="TResult">The type of the elements of the sequence.</typeparam>
    /// <returns>An empty <see cref="IAsyncEnumerable{TResult}"/> whose type argument is TResult.</returns>
    public static IAsyncEnumerable<TResult> Empty<TResult>()
        => EmptyAsyncEnumerable<TResult>.Instance;
}

file sealed class EmptyAsyncEnumerable<T> : IAsyncEnumerable<T>, IAsyncEnumerator<T>
{
    public static readonly EmptyAsyncEnumerable<T> Instance = new();

    public T Current => default!;

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => this;

    public ValueTask<bool> MoveNextAsync()
        => ValueTask.FromResult(false);

    public ValueTask DisposeAsync()
        => ValueTask.CompletedTask;
}

#endif