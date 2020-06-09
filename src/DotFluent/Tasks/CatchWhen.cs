using DotFluent.Tasks.Internal;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    public static partial class TaskExtensions
    {
        #region Methods

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition.
        /// </summary>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="action">
        /// An action to perform when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task CatchWhen<TException>(this Task source, Func<TException, bool> predicate, Action<TException> action, CancellationToken cancellationToken = default) where TException : Exception
            => source.CatchWhen(predicate, action, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition. The continuation task 
        /// uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="action">
        /// An action to perform when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task CatchWhen<TException>(this Task source, Func<TException, bool> predicate, Action<TException> action, TaskScheduler scheduler, CancellationToken cancellationToken = default) where TException : Exception
        {
            source.ThrowIfNull(nameof(source));
            predicate.ThrowIfNull(nameof(predicate));
            action.ThrowIfNull(nameof(action));

            var tcs = new TaskCompletionSource<VoidResult>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                {
                    var exception = x.Exception.InnerExceptions.OfType<TException>().FirstOrDefault();
                    if (exception.IsNotNull() && predicate(exception))
                    {
                        try
                        {
                            action(exception);
                            tcs.TrySetResult(default);
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }
                    }
                    else
                        tcs.TrySetException(x.Exception.InnerExceptions);
                }
                else
                    tcs.TrySetResult(default);
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="selector">
        /// A function to invoke when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
        public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector, CancellationToken cancellationToken = default) where TException : Exception
            => source.CatchWhen(predicate, selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition. The continuation task 
        /// uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="selector">
        /// A function to invoke when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
        public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default) where TException : Exception
        {
            source.ThrowIfNull(nameof(source));
            predicate.ThrowIfNull(nameof(predicate));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<TSource>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                {
                    var exception = x.Exception.InnerExceptions.OfType<TException>().FirstOrDefault();
                    if (exception.IsNotNull() && predicate(exception))
                    {
                        try
                        {
                            tcs.TrySetResult(selector(exception));
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }
                    }
                    else
                        tcs.TrySetException(x.Exception.InnerExceptions);
                }
                else
                    tcs.TrySetResult(x.Result);
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="selector">
        /// A function to invoke when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
        public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, Task<TSource>> selector, CancellationToken cancellationToken = default) where TException : Exception
            => source.CatchWhen(predicate, selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when any of the
        /// previous tasks in the chain failes due to the specified exception type
        /// and the exception itself satisfies a condition. The continuation task 
        /// uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TException">The type of exception to catch.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="predicate">A function to test the exception for a condition.</param>
        /// <param name="selector">
        /// A function to invoke when any of the previous tasks failes due to the specified exception type
        /// and the exception itself satifies a condition.
        /// </param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
        public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, Task<TSource>> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default) where TException : Exception
        {
            source.ThrowIfNull(nameof(source));
            predicate.ThrowIfNull(nameof(predicate));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<Task<TSource>>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                {
                    var exception = x.Exception.InnerExceptions.OfType<TException>().FirstOrDefault();
                    if (exception.IsNotNull() && predicate(exception))
                    {
                        try
                        {
                            tcs.TrySetResult(selector(exception));
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }
                    }
                    else
                        tcs.TrySetException(x.Exception.InnerExceptions);
                }
                else
                    tcs.TrySetResult(x);
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task.Unwrap();
        }

        #endregion
    }
}
