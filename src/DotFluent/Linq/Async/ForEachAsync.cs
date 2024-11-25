namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously performs a specified action on each element of an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the async-sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous foreach operation.</returns>
    public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task AsyncEnumerableForEachAsync(IAsyncEnumerable<TSource> source, Action<TSource> action, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                action(item);
        }
        return AsyncEnumerableForEachAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Asynchronously performs a specified action on each element of an async-sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the async-sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous foreach operation.</returns>
    public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task AsyncEnumerableForEachAsync(IAsyncEnumerable<TSource> source, Action<TSource, int> action, CancellationToken cancellationToken)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                action(item, checked(index++));
        }
        return AsyncEnumerableForEachAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Asynchronously performs a specified action on each element of an async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the async-sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous foreach operation.</returns>
    public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task AsyncEnumerableForEachAsync(IAsyncEnumerable<TSource> source, Func<TSource, Task> action, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                await action(item)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(action)} must not return null."))
                    .ConfigureAwait(false);
        }
        return AsyncEnumerableForEachAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Asynchronously performs a specified action on each element of an async-sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the async-sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous foreach operation.</returns>
    public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task AsyncEnumerableForEachAsync(IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action, CancellationToken cancellationToken)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                await action(item, checked(index++))
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(action)} must not return null."))
                    .ConfigureAwait(false);
        }
        return AsyncEnumerableForEachAsync(source, action, cancellationToken);
    }

    #endregion
}
