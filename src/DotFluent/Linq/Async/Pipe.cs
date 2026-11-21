using System.Runtime.CompilerServices;

namespace DotFluent.Linq;

public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Performs a specified action on each element of an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the asynchronous sequence.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IAsyncEnumerable<TSource> Pipe<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async IAsyncEnumerable<TSource> Core(IAsyncEnumerable<TSource> source, Action<TSource> action, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                action(item);
                yield return item;
            }
        }
        return Core(source, action);
    }

    /// <summary>
    /// Performs a specified action on each element of an asynchronous sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An action to perform on each element of the asynchronous sequence.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IAsyncEnumerable<TSource> Pipe<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async IAsyncEnumerable<TSource> Core(IAsyncEnumerable<TSource> source, Action<TSource, int> action, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                action(item, checked(index++));
                yield return item;
            }
        }
        return Core(source, action);
    }

    /// <summary>
    /// Performs a specified asynchronous action on each element of an asynchronous sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An asynchronous action to perform on each element of the asynchronous sequence.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IAsyncEnumerable<TSource> Pipe<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async IAsyncEnumerable<TSource> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask> action, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                await action(item, cancellationToken).ConfigureAwait(false);
                yield return item;
            }
        }
        return Core(source, action);
    }

    /// <summary>
    /// Performs a specified asynchronous action on each element of an asynchronous sequence and incorporates the element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The asynchronous sequence to perform an action on each of its elements on.</param>
    /// <param name="action">An asynchronous action to perform on each element of the asynchronous sequence.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{TSource}"/> whose elements are the result of
    /// performing the action on each element of source.
    /// </returns>
    public static IAsyncEnumerable<TSource> Pipe<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, CancellationToken, ValueTask> action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async IAsyncEnumerable<TSource> Core(IAsyncEnumerable<TSource> source, Func<TSource, int, CancellationToken, ValueTask> action, [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            var index = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                await action(item, checked(index++), cancellationToken).ConfigureAwait(false);
                yield return item;
            }
        }
        return Core(source, action);
    }
}
