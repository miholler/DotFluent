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
        => source.Finally(action, TaskScheduler.Current);

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// The continuation task uses a specified scheduler.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform even if any of the previous tasks failes or is canceled.</param>
    /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task Finally(this Task source, Action action, TaskScheduler? scheduler)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        var tcs = new TaskCompletionSource();
        source.ContinueWith(x =>
        {
            var exception = default(Exception);
            try
            {
                action();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (exception.IsNotNull())
                    tcs.TrySetException(exception);
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception!.InnerExceptions);
                else if (x.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult();
            }
        }, scheduler ?? TaskScheduler.Current);
        return tcs.Task;
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
        => source.Finally(action, TaskScheduler.Current);

    /// <summary>
    /// Creates a continuation task that executes asynchronously even if any of the
    /// previous tasks in the chain failes or is canceled.
    /// The continuation task uses a specified scheduler.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="action">An action to perform even if any of the previous tasks failes or is canceled.</param>
    /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> Finally<TSource>(this Task<TSource> source, Action action, TaskScheduler? scheduler)
    {
        source.ThrowIfNull();
        action.ThrowIfNull();

        var tcs = new TaskCompletionSource<TSource>();
        source.ContinueWith(x =>
        {
            var exception = default(Exception);
            try
            {
                action();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (exception.IsNotNull())
                    tcs.TrySetException(exception);
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception!.InnerExceptions);
                else if (x.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(x.Result);
            }
        }, scheduler ?? TaskScheduler.Current);
        return tcs.Task;
    }

    #endregion
}
