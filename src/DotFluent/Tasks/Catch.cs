namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    #region Methods

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
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
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
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
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
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
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
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    #endregion
}
