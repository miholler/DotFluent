using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously determines whether an async-sequence contains a specified element
    /// by using the default equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the async-sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// true if the source async-sequence contains an element that has the specified value; otherwise, false.
    /// </returns>
    public static ValueTask<bool> ContainsAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource value, CancellationToken cancellationToken = default)
        => source.ContainsAsync(value, comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously determines whether an async-sequence contains a specified element
    /// by using a specified compare function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the async-sequence.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// true if the source async-sequence contains an element that has the specified value; otherwise, false.
    /// </returns>
    public static ValueTask<bool> ContainsAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource value, EqualityComparison<TSource> comparison, CancellationToken cancellationToken = default)
        => source.ContainsAsync(value, EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously determines whether an async-sequence contains a specified element
    /// by using a specified equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence in which to locate a value.</param>
    /// <param name="value">The value to locate in the async-sequence.</param>
    /// <param name="comparer">The equality comparer to compare values.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// true if the source async-sequence contains an element that has the specified value; otherwise, false.
    /// </returns>
    public static ValueTask<bool> ContainsAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<bool> AsyncEnumerableContainsAsync(IAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken)
        {
            comparer ??= EqualityComparer<TSource>.Default;

            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                if (comparer.Equals(item, value))
                    return true;
            }
            return false;
        }
        return AsyncEnumerableContainsAsync(source, value, comparer, cancellationToken);
    }

    #endregion
}
