namespace DotFluent.Linq;

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Performs a specified action on each element of an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the asynchronous sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous 'for each' operation.</returns>
    public static ValueTask ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask Core(IAsyncEnumerable<TSource> source, Action<TSource> action, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                action(item);
        }
        return Core(source, action, cancellationToken);
    }

    /// <summary>
    /// Performs a specified action on each element of an asynchronous sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the asynchronous sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous 'for each' operation.</returns>
    public static ValueTask ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask Core(IAsyncEnumerable<TSource> source, Action<TSource, int> action, CancellationToken cancellationToken)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                action(item, checked(index++));
        }
        return Core(source, action, cancellationToken);
    }

    /// <summary>
    /// Performs a specified asynchronous action on each element of an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An asynchronous action to perform on each element of the asynchronous sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous 'for each' operation.</returns>
    public static ValueTask ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask> action, CancellationToken cancellationToken)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                await action(item, cancellationToken).ConfigureAwait(false);
        }
        return Core(source, action, cancellationToken);
    }

    /// <summary>
    /// Performs a specified asynchronous action on each element of an asynchronous sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An asynchronous action to perform on each element of the asynchronous sequence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous 'for each' operation.</returns>
    public static ValueTask ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, CancellationToken, ValueTask> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask Core(IAsyncEnumerable<TSource> source, Func<TSource, int, CancellationToken, ValueTask> action, CancellationToken cancellationToken)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                await action(item, checked(index++), cancellationToken).ConfigureAwait(false);
        }
        return Core(source, action, cancellationToken);
    }
}
