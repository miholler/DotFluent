using DotFluent.Optional.Unsafe;
using DotFluent.Optional.Unsafe.Tasks;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the element at a specified index in an async-sequence, or a default value
    /// if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'element at or default' operation. The value of the TResult parameter contains
    /// default(TSource) if the index is outside the bounds of the source async-sequence; otherwise, the element at the specified position in the source async-sequence.
    /// </returns>
    public static ValueTask<TSource?> ElementAtOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableElementAtOrDefaultAsync(IAsyncEnumerable<TSource> source, int index, CancellationToken cancellationToken)
        {
            var option = await source
                .GetElementAtAsync(index, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableElementAtOrDefaultAsync(source, index, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the element at a specified index in an async-sequence, or a specified default value
    /// if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="defaultValue">The value to return if the index is out of range.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'element at or default' operation. The value of the TResult parameter contains
    /// the specified default value if the index is outside the bounds of the source async-sequence; otherwise, the element at the specified position
    /// in the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> ElementAtOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableElementAtOrDefaultAsync(IAsyncEnumerable<TSource> source, int index, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetElementAtAsync(index, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableElementAtOrDefaultAsync(source, index, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the element at a specified index in an async-sequence, or a default value
    /// created by a specified function if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'element at or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if the index is outside the bounds of the source async-sequence; otherwise, the element at
    /// the specified position in the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> ElementAtOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableElementAtOrDefaultAsync(IAsyncEnumerable<TSource> source, int index, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetElementAtAsync(index, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableElementAtOrDefaultAsync(source, index, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the element at a specified index in an async-sequence, or a default value
    /// created by a specified function if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'element at or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if the index is outside the bounds of the source async-sequence; otherwise, the element at
    /// the specified position in the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> ElementAtOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, int index, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableElementAtOrDefaultAsync(IAsyncEnumerable<TSource> source, int index, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetElementAtAsync(index, cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableElementAtOrDefaultAsync(source, index, defaultFactory, cancellationToken);
    }

    #endregion
}
