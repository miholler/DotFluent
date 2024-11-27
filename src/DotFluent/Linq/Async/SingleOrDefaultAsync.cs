using DotFluent.Optional.Unsafe;
using DotFluent.Optional.Unsafe.Tasks;

namespace DotFluent.Linq;

public static partial class AsyncSequence
{
    #region Methods

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence, or a default value
    /// if the async-sequence is empty; this method throws an exception if there is more
    /// than one element in the async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the single element of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence, or default(TSource) if the async-sequence contains no elements.
    /// </returns>
    public static ValueTask<TSource?> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence, or a specified default value
    /// if the async-sequence is empty; this method throws an exception if there is more than one
    /// element in the async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the single element of.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence, or defaultValue if the async-sequence contains no elements.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence, or a default value created by a specified function
    /// if the async-sequence is empty; this method throws an exception if there is more than one element in the async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the single element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if the source async-sequence is empty; otherwise, the single element of the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence, or a default value created by a specified function
    /// if the async-sequence is empty; this method throws an exception if there is more than one element in the async-sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return the single element of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the default value created by the specified function if the source async-sequence is empty; otherwise, the single element of the source async-sequence.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value if no such element exists; this method throws an exception if more than one
    /// element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or default(TSource) if no such element is found.
    /// </returns>
    public static ValueTask<TSource?> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value if no such element exists; this method throws an exception if more than one
    /// element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or default(TSource) if no such element is found.
    /// </returns>
    public static ValueTask<TSource?> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource?> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault();
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a specified default value if no such element exists; this method throws an exception if more
    /// than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty or if no element passes the test.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or defaultValue if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a specified default value if no such element exists; this method throws an exception if more
    /// than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultValue">The default value to return if the async-sequence is empty or if no element passes the test.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or defaultValue if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, TSource defaultValue, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultValue);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultValue, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value created by a specified function if no such element exists; this method throws
    /// an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or the default value created by the specified function if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value created by a specified function if no such element exists; this method throws
    /// an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or the default value created by the specified function if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<TSource> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return option.GetValueOrDefault(defaultFactory);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value created by a specified function if no such element exists; this method throws
    /// an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or the default value created by the specified function if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    /// <summary>
    /// Asynchronously returns the only element of an async-sequence that satisfies a condition, or
    /// a default value created by a specified function if no such element exists; this method throws
    /// an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The async-sequence to return a single element from.</param>
    /// <param name="predicate">A function to test an element for a condition.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous 'single or default' operation. The value of the TResult parameter contains
    /// the single element of the input async-sequence that satisfies the condition, or the default value created by the specified function if no such element is found.
    /// </returns>
    public static ValueTask<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        static async ValueTask<TSource> AsyncEnumerableSingleOrDefaultAsync(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, Func<ValueTask<TSource>> defaultFactory, CancellationToken cancellationToken)
        {
            var option = await source
                .GetSingleAsync(predicate, cancellationToken)
                .ConfigureAwait(false);

            return await option
                .GetValueOrDefaultAsync(() => defaultFactory().AsTask(), cancellationToken)
                .ConfigureAwait(false);
        }
        return AsyncEnumerableSingleOrDefaultAsync(source, predicate, defaultFactory, cancellationToken);
    }

    #endregion
}
