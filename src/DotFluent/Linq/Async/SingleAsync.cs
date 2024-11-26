using DotFluent.Internal;
using DotFluent.Optional;
using DotFluent.Optional.Unsafe;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence, or throws an exception
    /// if there is not exactly one element in the async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the single element from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous single operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence.
    /// </returns>
    public static ValueTask<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoElements));
        }
        return AsyncEnumerableSingleAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a specified condition,
    /// or throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous single operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies a condition.
    /// </returns>
    public static ValueTask<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoElements));
        }
        return AsyncEnumerableSingleAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a specified condition,
    /// or throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous single operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies a condition.
    /// </returns>
    public static ValueTask<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(() => throw new InvalidOperationException(Errors.NoElements));
        }
        return AsyncEnumerableSingleAsync(source, predicate, cancellationToken);
    }

    private static async ValueTask<Option<TSource>> GetSingleAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        await using var enumerator = source
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false)
            .GetAsyncEnumerator();
        if (!await enumerator.MoveNextAsync())
            return Option.None<TSource>();

        var result = enumerator.Current;
        return !await enumerator.MoveNextAsync()
            ? Option.Some(result)
            : throw new InvalidOperationException(Errors.MoreThanOneElement);
    }

    private static async ValueTask<Option<TSource>> GetSingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
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
                    if (predicate(enumerator.Current))
                        throw new InvalidOperationException(Errors.MoreThanOneMatch);

                return Option.Some(result);
            }
        }
        return Option.None<TSource>();
    }

    private static async ValueTask<Option<TSource>> GetSingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
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
                    if (await predicate(enumerator.Current).ConfigureAwait(false))
                        throw new InvalidOperationException(Errors.MoreThanOneMatch);

                return Option.Some(result);
            }
        }
        return Option.None<TSource>();
    }

    #endregion
}
