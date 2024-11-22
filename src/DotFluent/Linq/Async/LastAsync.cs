using DotFluent.Internal;
using DotFluent.Optional;
using DotFluent.Optional.Unsafe;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the last element of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous last operation. The value of the TResult parameter contains
    /// the last element in the specified async-sequence.
    /// </returns>
    public static ValueTask<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoElements));
        }
        return AsyncEnumerableLastAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element in an async-sequence that satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous last operation. The value of the TResult parameter contains
    /// the last element in the async-sequence that passes the test in the specified predicate function.
    /// </returns>
    public static ValueTask<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoMatch));
        }
        return AsyncEnumerableLastAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element in an async-sequence that satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous last operation. The value of the TResult parameter contains
    /// the last element in the async-sequence that passes the test in the specified predicate function.
    /// </returns>
    public static ValueTask<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoMatch));
        }
        return AsyncEnumerableLastAsync(source, predicate, cancellationToken);
    }

    private static ValueTask<Option<TSource>> GetLastAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        => source switch
        {
            AsyncIterator<TSource> iterator => iterator.GetLastAsync(cancellationToken),
            _ => GetLastNonIteratorAsync(source, cancellationToken)
        };

    private static async ValueTask<Option<TSource>> GetLastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync())
        {
            var result = enumerator.Current;
            if (predicate(result))
            {
                while (await enumerator.MoveNextAsync())
                {
                    var item = enumerator.Current;
                    if (predicate(item))
                        result = item;
                }
                return Option.Some(result);
            }
        }
        return Option.None<TSource>();
    }

    private static async ValueTask<Option<TSource>> GetLastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync())
        {
            var result = enumerator.Current;
            if (await predicate(result).ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync())
                {
                    var item = enumerator.Current;
                    if (await predicate(item).ConfigureAwait(false))
                        result = item;
                }
                return Option.Some(result);
            }
        }
        return Option.None<TSource>();
    }

    private static async ValueTask<Option<TSource>> GetLastNonIteratorAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        if (await enumerator.MoveNextAsync())
        {
            var result = enumerator.Current;
            while (await enumerator.MoveNextAsync())
                result = enumerator.Current;

            return Option.Some(result);
        }
        return Option.None<TSource>();
    }

    #endregion
}
