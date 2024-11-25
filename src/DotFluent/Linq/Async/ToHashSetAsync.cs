using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously creates a hashset from an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a hashset from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to hashset' operation. The value of the TResult parameter contains
    /// a <see cref="HashSet{TSource}"/> that contains values of type TSource selected from the input async-sequence.
    /// </returns>
    public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        => source.ToHashSetAsync(comparer: null, cancellationToken);

    /// <summary>
    /// Asynchronously creates a hashset from an async-sequence
    /// using a specified compare function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a hashset from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to hashset' operation. The value of the TResult parameter contains
    /// a <see cref="HashSet{TSource}"/> that contains values of type TSource selected from the input async-sequence.
    /// </returns>
    public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this IAsyncEnumerable<TSource> source, EqualityComparison<TSource> comparison, CancellationToken cancellationToken = default)
        => source.ToHashSetAsync(EqualityComparer.Create(comparison), cancellationToken);

    /// <summary>
    /// Asynchronously creates a hashset from an async-sequence
    /// using specified compare functions to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a hashset from.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <param name="hashCodeSelector">A function to resolve a hash code for a value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to hashset' operation. The value of the TResult parameter contains
    /// a <see cref="HashSet{TSource}"/> that contains values of type TSource selected from the input async-sequence.
    /// </returns>
    public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this IAsyncEnumerable<TSource> source, EqualityComparison<TSource> comparison, HashFunc<TSource>? hashCodeSelector, CancellationToken cancellationToken = default)
        => source.ToHashSetAsync(EqualityComparer.Create(comparison, hashCodeSelector), cancellationToken);

    /// <summary>
    /// Asynchronously creates a hashset from an async-sequence
    /// using a specified equality comparer to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to create a hashset from.</param>
    /// <param name="comparer">The equality comparer to compare values.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'to hashset' operation. The value of the TResult parameter contains
    /// a <see cref="HashSet{TSource}"/> that contains values of type TSource selected from the input async-sequence.
    /// </returns>
    public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this IAsyncEnumerable<TSource> source, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<HashSet<TSource>> AsyncEnumerableToHashSetAsync(IAsyncEnumerable<TSource> source, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken)
        {
            var set = new HashSet<TSource>(comparer);
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                set.Add(item);

            return set;
        }
        return AsyncEnumerableToHashSetAsync(source, comparer, cancellationToken);
    }

    #endregion
}
