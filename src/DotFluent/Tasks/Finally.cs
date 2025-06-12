namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    #region Methods

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform even if any of the previous tasks failes or is canceled.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Finally(this Task source, Action action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Action action)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            finally
            {
                action();
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke even if any of the previous tasks failes or is canceled.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Finally(this Task source, Func<Task> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<Task> selector)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            finally
            {
                await selector()
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform even if any of the previous tasks failes or is canceled.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Finally<TSource>(this Task<TSource> source, Action action)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Action action)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            finally
            {
                action();
            }
        }
        return ContinueWithAsync(source, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="selector">A function to invoke even if any of the previous tasks failes or is canceled.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Finally<TSource>(this Task<TSource> source, Func<Task> selector)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<Task> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            finally
            {
                await selector()
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, selector);
    }

    #endregion
}
