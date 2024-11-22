using DotFluent.Internal;
using DotFluent.Optional;
using DotFluent.Optional.Unsafe;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the first element of an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the first element of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous first operation. The value of the TResult parameter contains
    /// the first element in the specified async-sequence.
    /// </returns>
    public static ValueTask<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableFirstAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var option = await source
                .GetFirstAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoElements));
        }
        return AsyncEnumerableFirstAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the first element in an async-sequence that satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous first operation. The value of the TResult parameter contains
    /// the first element in the async-sequence that passes the test in the specified predicate function.
    /// </returns>
    public static ValueTask<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableFirstAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetFirstAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoMatch));
        }
        return AsyncEnumerableFirstAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the first element in an async-sequence that satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous first operation. The value of the TResult parameter contains
    /// the first element in the async-sequence that passes the test in the specified predicate function.
    /// </returns>
    public static ValueTask<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableFirstAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetFirstAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoMatch));
        }
        return AsyncEnumerableFirstAsync(source, predicate, cancellationToken);
    }

    private static ValueTask<Option<TSource>> GetFirstAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        => source switch
        {
            AsyncIterator<TSource> iterator => iterator.GetFirstAsync(cancellationToken),
            _ => GetFirstNonIteratorAsync(source, cancellationToken)
        };

    private static async ValueTask<Option<TSource>> GetFirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            if (predicate(item))
                return Option.Some(item);
        }
        return Option.None<TSource>();
    }

    private static async ValueTask<Option<TSource>> GetFirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            if (await predicate(item).ConfigureAwait(false))
                return Option.Some(item);
        }
        return Option.None<TSource>();
    }

    private static async ValueTask<Option<TSource>> GetFirstNonIteratorAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        return await enumerator.MoveNextAsync()
            ? Option.Some(enumerator.Current)
            : Option.None<TSource>();
    }

    #endregion
}
