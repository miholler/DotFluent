using DotFluent.Optional;
using DotFluent.Optional.Unsafe;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the element at a specified index in an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'element at' operation. The value of the TResult parameter contains
    /// the element at the specified position in the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> ElementAtAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableElementAtAsync(IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken)
        {
            var option = await source
                .GetElementAtAsync(index, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new ArgumentOutOfRangeException(nameof(index)));
        }
        return AsyncEnumerableElementAtAsync(source, index, cancellationToken);
    }

    private static ValueTask<Option<TSource>> GetElementAtAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken = default)
        => source switch
        {
            AsyncIterator<TSource> iterator => iterator.GetElementAtAsync(index, cancellationToken),
            _ => GetElementAtNonIteratorAsync(source, index, cancellationToken)
        };

    private static async ValueTask<Option<TSource>> GetElementAtNonIteratorAsync<TSource>(IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken = default)
    {
        if (index >= 0)
        {
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                if (index == 0)
                    return Option.Some(enumerator.Current);

                index--;
            }
        }
        return Option.None<TSource>();
    }

    #endregion
}
