using DotFluent.Internal;

namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Catch(this Task source, Action action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Action action)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch
            {
                action();
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Catch(this Task source, Func<Task> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<Task> selector)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch
            {
                await selector()
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Catch<TException>(this Task source, Action<TException> action) where TException : Exception
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Action<TException> action)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Catch<TException>(this Task source, Func<TException, Task> selector) where TException : Exception
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<TException, Task> selector)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                await selector(ex)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Catch<TSource>(this Task<TSource> source, Func<TSource> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<TSource> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch
            {
                return selector();
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Catch<TSource>(this Task<TSource> source, Func<Task<TSource>> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<Task<TSource>> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch
            {
                return await selector()
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Catch<TSource, TException>(this Task<TSource> source, Func<TException, TSource> selector) where TException : Exception
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<TException, TSource> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                return selector(ex);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Catch<TSource, TException>(this Task<TSource> source, Func<TException, Task<TSource>> selector) where TException : Exception
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<TException, Task<TSource>> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                return await selector(ex)
                    .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(selector))))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }
}

public static partial class ValueTaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch(this in ValueTask source, Action action)
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Action action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch
            {
                action();
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch(this in ValueTask source, Func<ValueTask> selector)
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch
            {
                var handler = selector();
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TException>(this in ValueTask source, Action<TException> action) where TException : Exception
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Action<TException> action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TException>(this in ValueTask source, Func<TException, ValueTask> selector) where TException : Exception
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<TException, ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                var handler = selector(ex);
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TSource>(this in ValueTask<TSource> source, Action action)
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Action action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch
            {
                action();
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TSource>(this in ValueTask<TSource> source, Func<ValueTask> selector)
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch
            {
                var handler = selector();
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> Catch<TSource>(this in ValueTask<TSource> source, Func<TSource> selector)
    {
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<TSource> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch
            {
                return selector();
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes.</param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> Catch<TSource>(this in ValueTask<TSource> source, Func<ValueTask<TSource>> selector)
    {
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<ValueTask<TSource>> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch
            {
                var handler = selector();
                return handler.IsCompletedSuccessfully
                    ? handler.Result
                    : await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TSource, TException>(this in ValueTask<TSource> source, Action<TException> action) where TException : Exception
    {
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Action<TException> action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask Catch<TSource, TException>(this in ValueTask<TSource> source, Func<TException, ValueTask> selector) where TException : Exception
    {
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<TException, ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                var handler = selector(ex);
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> Catch<TSource, TException>(this in ValueTask<TSource> source, Func<TException, TSource> selector) where TException : Exception
    {
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<TException, TSource> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                return selector(ex);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke when any of the previous tasks failes due to the specified exception type.</param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> Catch<TSource, TException>(this in ValueTask<TSource> source, Func<TException, ValueTask<TSource>> selector) where TException : Exception
    {
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<TException, ValueTask<TSource>> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch (TException ex)
            {
                var handler = selector(ex);
                return handler.IsCompletedSuccessfully
                    ? handler.Result
                    : await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }
}
