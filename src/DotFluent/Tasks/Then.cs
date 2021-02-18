using DotFluent.Tasks.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    public static partial class TaskExtensions
    {
        #region Methods

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// </summary>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="action">An action to perform when the previous task completes.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then(this Task source, Action action, CancellationToken cancellationToken = default)
            => source.Then(action, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="action">An action to perform when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then(this Task source, Action action, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            action.ThrowIfNull(nameof(action));

            var tcs = new TaskCompletionSource<VoidResult>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        action();
                        tcs.TrySetResult(default);
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// </summary>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then(this Task source, Func<Task> selector, CancellationToken cancellationToken = default)
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then(this Task source, Func<Task> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<Task>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector());
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task.Unwrap();
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
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
        public static Task<TResult> Then<TResult>(this Task source, Func<TResult> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<TResult>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector());
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
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
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
        public static Task<TResult> Then<TResult>(this Task source, Func<Task<TResult>> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<Task<TResult>>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector());
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task.Unwrap();
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
            => source.Then(action, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="action">An action to perform when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then<TSource>(this Task<TSource> source, Action<TSource> action, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            action.ThrowIfNull(nameof(action));

            var tcs = new TaskCompletionSource<VoidResult>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        action(x.Result);
                        tcs.TrySetResult(default);
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
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
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task"/>.</returns>
        public static Task Then<TSource>(this Task<TSource> source, Func<TSource, Task> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<Task>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector(x.Result));
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task.Unwrap();
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
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
        public static Task<TResult> Then<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<TResult>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector(x.Result));
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task;
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
            => source.Then(selector, TaskScheduler.Current, cancellationToken);

        /// <summary>
        /// Creates a continuation task that executes asynchronously when the previous task completes and returns a value.
        /// The continuation task uses a specified scheduler.
        /// </summary>
        /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
        /// <typeparam name="TResult">The type of the result produced by the continuation task.</typeparam>
        /// <param name="source">The task to create the continuation task for.</param>
        /// <param name="selector">A function to invoke when the previous task completes.</param>
        /// <param name="scheduler">The task scheduler to associate with the continuation task and to use for its execution.</param>
        /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
        /// <returns>A continuation <see cref="Task{TResult}"/>.</returns>
        public static Task<TResult> Then<TSource, TResult>(this Task<TSource> source, Func<TSource, Task<TResult>> selector, TaskScheduler scheduler, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            var tcs = new TaskCompletionSource<Task<TResult>>();
            source.ContinueWith(x =>
            {
                if (x.IsCanceled || cancellationToken.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else if (x.IsFaulted)
                    tcs.TrySetException(x.Exception.InnerExceptions);
                else
                {
                    try
                    {
                        tcs.TrySetResult(selector(x.Result));
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            }, scheduler ?? TaskScheduler.Current);
            return tcs.Task.Unwrap();
        }

        #endregion
    }
}
