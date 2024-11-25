using DotFluent.Optional.Unsafe;
using DotFluent.Optional.Unsafe.Tasks;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence, or a default value
    /// if the async-sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the last element of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// default(TSource) if source is empty; otherwise, the last element in source.
    /// </returns>
    public static ValueTask<TSource?> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableLastOrDefaultAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence, or a specified default value
    /// if the async-sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the last element of.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// defaultValue if source is empty; otherwise, the last element in source.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence, or a default value 
    /// created by a specified function if the async-sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the last element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty; otherwise, the last element in source.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence, or a default value 
    /// created by a specified function if the async-sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the last element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty; otherwise, the last element in source.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// default(TSource) if source is empty or if no element passes the test specified by predicate; otherwise, the last element in source that
    /// passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource?> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// default(TSource) if source is empty or if no element passes the test specified by predicate; otherwise, the last element in source that
    /// passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource?> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a specified default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty or if no element passes the test.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// defaultValue if source is empty or if no element passes the test specified by predicate; otherwise, the last element in source that passes
    /// the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a specified default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty or if no element passes the test.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// defaultValue if source is empty or if no element passes the test specified by predicate; otherwise, the last element in source that passes
    /// the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value created by a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty or if no element passes the test specified by predicate; otherwise,
    /// the last element in source that passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value created by a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty or if no element passes the test specified by predicate; otherwise,
    /// the last element in source that passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value created by a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty or if no element passes the test specified by predicate; otherwise,
    /// the last element in source that passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the last element of an async-sequence that satisfies a condition,
    /// or a default value created by a specified function if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'last or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if source is empty or if no element passes the test specified by predicate; otherwise,
    /// the last element in source that passes the test specified by predicate.
    /// </returns>
    public static ValueTask<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableLastOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetLastAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableLastOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    #endregion
}
