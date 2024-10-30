namespace DotFluent.Linq;

/// <summary>
/// Provides a set of static methods for querying objects
/// that implement <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the final accumulator value.
    /// </returns>
    public static ValueTask<TSource> AggregateAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> accumulator, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> accumulator, CancellationToken cancellationToken = default)
        {
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            if (!await enumerator.MoveNextAsync())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = enumerator.Current;
            while (await enumerator.MoveNextAsync())
                result = accumulator(result, enumerator.Current);

            return result;
        }
        return AsyncEnumerableAggregateAsync(source, accumulator, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the final accumulator value.
    /// </returns>
    public static ValueTask<TSource> AggregateAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, ValueTask<TSource>> accumulator, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, Func<TSource, TSource, ValueTask<TSource>> accumulator, CancellationToken cancellationToken = default)
        {
            await using var enumerator = source
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();
            if (!await enumerator.MoveNextAsync())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = enumerator.Current;
            while (await enumerator.MoveNextAsync())
                result = await accumulator(result, enumerator.Current).ConfigureAwait(false);

            return result;
        }
        return AsyncEnumerableAggregateAsync(source, accumulator, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the final accumulator value.
    /// </returns>
    public static ValueTask<TAccumulate> AggregateAsync<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();

        static async ValueTask<TAccumulate> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = accumulator(result, item);

            return result;
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the final accumulator value.
    /// </returns>
    public static ValueTask<TAccumulate> AggregateAsync<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();

        static async ValueTask<TAccumulate> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = await accumulator(result, item).ConfigureAwait(false);

            return result;
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value, and the specified
    /// selector function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the transformed final accumulator value.
    /// </returns>
    public static ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();
        resultSelector.ThrowIfNull();

        static async ValueTask<TResult> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = accumulator(result, item);

            return resultSelector(result);
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, resultSelector, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value, and the specified
    /// selector function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the transformed final accumulator value.
    /// </returns>
    public static ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();
        resultSelector.ThrowIfNull();

        static async ValueTask<TResult> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = await accumulator(result, item).ConfigureAwait(false);

            return resultSelector(result);
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, resultSelector, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value, and the specified
    /// selector function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the transformed final accumulator value.
    /// </returns>
    public static ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, ValueTask<TResult>> resultSelector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();
        resultSelector.ThrowIfNull();

        static async ValueTask<TResult> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, ValueTask<TResult>> resultSelector, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = accumulator(result, item);

            return await resultSelector(result).ConfigureAwait(false);
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, resultSelector, cancellationToken);
    }

    /// <summary>
    /// Asynchronously applies a specified accumulator function over an async-sequence.
    /// The specified seed value is used as the initial accumulator value, and the specified
    /// selector function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">The async-sequenece to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="accumulator">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous aggregate operation. The value of the TResult parameter contains
    /// the transformed final accumulator value.
    /// </returns>
    public static ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, Func<TAccumulate, ValueTask<TResult>> resultSelector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        accumulator.ThrowIfNull();
        resultSelector.ThrowIfNull();

        static async ValueTask<TResult> AsyncEnumerableAggregateAsync(IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, ValueTask<TAccumulate>> accumulator, Func<TAccumulate, ValueTask<TResult>> resultSelector, CancellationToken cancellationToken = default)
        {
            var result = seed;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                result = await accumulator(result, item).ConfigureAwait(false);

            return await resultSelector(result).ConfigureAwait(false);
        }
        return AsyncEnumerableAggregateAsync(source, seed, accumulator, resultSelector, cancellationToken);
    }

    #endregion
}
