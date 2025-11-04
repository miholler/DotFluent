using DotFluent.Internal;

namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Then(this Task source, Action action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Action action, CancellationToken cancellationToken)
        {
            await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            action();
        }
        return ContinueWithAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Then(this Task source, Func<Task> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<Task> selector, CancellationToken cancellationToken)
        {
            await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            await selector()
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                .ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
    public static Task<TResult> Then<TResult>(this Task source, Func<TResult> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TResult> ContinueWithAsync(Task source, Func<TResult> selector, CancellationToken cancellationToken)
        {
            await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return selector();
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
    public static Task<TResult> Then<TResult>(this Task source, Func<Task<TResult>> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TResult> ContinueWithAsync(Task source, Func<Task<TResult>> selector, CancellationToken cancellationToken)
        {
            await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return await selector()
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                .ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Then<TSource>(this Task<TSource> source, Action<TSource> action, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task<TSource> source, Action<TSource> action, CancellationToken cancellationToken)
        {
            var result = await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            action(result);
        }
        return ContinueWithAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Then<TSource>(this Task<TSource> source, Func<TSource, Task> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task<TSource> source, Func<TSource, Task> selector, CancellationToken cancellationToken)
        {
            var result = await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            await selector(result)
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                .ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
    public static Task<TResult> Then<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TResult> ContinueWithAsync(Task<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken)
        {
            var result = await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return selector(result);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
    public static Task<TResult> Then<TSource, TResult>(this Task<TSource> source, Func<TSource, Task<TResult>> selector, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TResult> ContinueWithAsync(Task<TSource> source, Func<TSource, Task<TResult>> selector, CancellationToken cancellationToken)
        {
            var result = await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return await selector(result)
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                .ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }
}

public static partial class ValueTaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then(this in ValueTask source, Action action, CancellationToken cancellationToken = default)
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Action action, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            action();
        }
        return ContinueWithAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then(this in ValueTask source, Func<ValueTask> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<ValueTask> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector();
            if (!handler.IsCompletedSuccessfully)
                await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TResult>(this in ValueTask source, Func<TResult> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask source, Func<TResult> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return selector();
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TResult>(this in ValueTask source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector();
            return handler.IsCompletedSuccessfully
                ? handler.Result
                : await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then<TSource>(this in ValueTask<TSource> source, Action action, CancellationToken cancellationToken = default)
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Action action, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            action();
        }
        return ContinueWithAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then<TSource>(this in ValueTask<TSource> source, Func<ValueTask> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<ValueTask> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector();
            if (!handler.IsCompletedSuccessfully)
                await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then<TSource>(this in ValueTask<TSource> source, Action<TSource> action, CancellationToken cancellationToken = default)
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Action<TSource> action, CancellationToken cancellationToken)
        {
            var result = source.IsCompletedSuccessfully
                ? source.Result
                : await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            action(result);
        }
        return ContinueWithAsync(source, action, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Then<TSource>(this in ValueTask<TSource> source, Func<TSource, ValueTask> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<TSource, ValueTask> selector, CancellationToken cancellationToken)
        {
            var result = source.IsCompletedSuccessfully
                ? source.Result
                : await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector(result);
            if (!handler.IsCompletedSuccessfully)
                await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TSource, TResult>(this in ValueTask<TSource> source, Func<TResult> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask<TSource> source, Func<TResult> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return selector();
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TSource, TResult>(this in ValueTask<TSource> source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask<TSource> source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken)
        {
            if (!source.IsCompletedSuccessfully)
                await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector();
            return handler.IsCompletedSuccessfully
                ? handler.Result
                : await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TSource, TResult>(this in ValueTask<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken)
        {
            var result = source.IsCompletedSuccessfully
                ? source.Result
                : await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();
            return selector(result);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when the previous task completes.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A continuation <see cref="ValueTask{TResult}"/>.</returns>
    public static ValueTask<TResult> Then<TSource, TResult>(this in ValueTask<TSource> source, Func<TSource, ValueTask<TResult>> selector, CancellationToken cancellationToken = default)
    {
        selector.ThrowIfNull();

        static async ValueTask<TResult> ContinueWithAsync(ValueTask<TSource> source, Func<TSource, ValueTask<TResult>> selector, CancellationToken cancellationToken)
        {
            var result = source.IsCompletedSuccessfully
                ? source.Result
                : await source.ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var handler = selector(result);
            return handler.IsCompletedSuccessfully
                ? handler.Result
                : await handler.ConfigureAwait(false);
        }
        return ContinueWithAsync(source, selector, cancellationToken);
    }
}
