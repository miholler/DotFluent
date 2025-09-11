namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="action">
    /// An action to perform when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task CatchWhen(this Task source, Func<bool> condition, Action action)
    {
        source.ThrowIfNull();
        condition.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<bool> condition, Action action)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                action();
            }
        }
        return ContinueWithAsync(source, condition, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task CatchWhen(this Task source, Func<bool> condition, Func<Task> selector)
    {
        source.ThrowIfNull();
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<bool> condition, Func<Task> selector)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                await selector()
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, condition, selector);
    }

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
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task CatchWhen<TException>(this Task source, Func<TException, bool> predicate, Action<TException> action) where TException : Exception
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        action.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<TException, bool> predicate, Action<TException> action)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, predicate, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type
    /// and the exception itself satisfies a condition.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="predicate">A function to test the exception for a condition.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes due to the specified exception type
    /// and the exception itself satifies a condition.
    /// </param>
    /// <returns>A continuation <see cref="Task"/>.</returns>
    public static Task CatchWhen<TException>(this Task source, Func<TException, bool> predicate, Func<TException, Task> selector) where TException : Exception
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task ContinueWithAsync(Task source, Func<TException, bool> predicate, Func<TException, Task> selector)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                await selector(ex)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> CatchWhen<TSource>(this Task<TSource> source, Func<bool> condition, Func<TSource> selector)
    {
        source.ThrowIfNull();
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<bool> condition, Func<TSource> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                return selector();
            }
        }
        return ContinueWithAsync(source, condition, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> CatchWhen<TSource>(this Task<TSource> source, Func<bool> condition, Func<Task<TSource>> selector)
    {
        source.ThrowIfNull();
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<bool> condition, Func<Task<TSource>> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                return await selector()
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, condition, selector);
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
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector) where TException : Exception
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                return selector(ex);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
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
    /// <returns>A continuation <see cref="Task{TSource}"/>.</returns>
    public static Task<TSource> CatchWhen<TSource, TException>(this Task<TSource> source, Func<TException, bool> predicate, Func<TException, Task<TSource>> selector) where TException : Exception
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async Task<TSource> ContinueWithAsync(Task<TSource> source, Func<TException, bool> predicate, Func<TException, Task<TSource>> selector)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                return await selector(ex)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(selector)} must not return null."))
                    .ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
    }
}

public static partial class ValueTaskExtensions
{
    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="action">
    /// An action to perform when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen(this in ValueTask source, Func<bool> condition, Action action)
    {
        condition.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<bool> condition, Action action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                action();
            }
        }
        return ContinueWithAsync(source, condition, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen(this in ValueTask source, Func<bool> condition, Func<ValueTask> selector)
    {
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<bool> condition, Func<ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                var handler = selector();
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, condition, selector);
    }

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
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TException>(this in ValueTask source, Func<TException, bool> predicate, Action<TException> action) where TException : Exception
    {
        predicate.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<TException, bool> predicate, Action<TException> action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, predicate, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes due to the specified exception type
    /// and the exception itself satisfies a condition.
    /// </summary>
    /// <typeparam name="TException">The type of exception to catch.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="predicate">A function to test the exception for a condition.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes due to the specified exception type
    /// and the exception itself satifies a condition.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TException>(this in ValueTask source, Func<TException, bool> predicate, Func<TException, ValueTask> selector) where TException : Exception
    {
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask source, Func<TException, bool> predicate, Func<TException, ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                var handler = selector(ex);
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="action">
    /// An action to perform when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TSource>(this in ValueTask<TSource> source, Func<bool> condition, Action action)
    {
        condition.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<bool> condition, Action action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                action();
            }
        }
        return ContinueWithAsync(source, condition, action);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TSource>(this in ValueTask<TSource> source, Func<bool> condition, Func<ValueTask> selector)
    {
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<bool> condition, Func<ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                var handler = selector();
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, condition, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> CatchWhen<TSource>(this in ValueTask<TSource> source, Func<bool> condition, Func<TSource> selector)
    {
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<bool> condition, Func<TSource> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                return selector();
            }
        }
        return ContinueWithAsync(source, condition, selector);
    }

    /// <summary>
    /// Creates a continuation task that executes asynchronously when any of the
    /// previous tasks in the chain failes and a specified condition is satisfied.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to create the continuation task for.</param>
    /// <param name="condition">A function that evaluates to a Boolean value.</param>
    /// <param name="selector">
    /// A function to invoke when any of the previous tasks failes
    /// and a condition is satisfied.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> CatchWhen<TSource>(this in ValueTask<TSource> source, Func<bool> condition, Func<ValueTask<TSource>> selector)
    {
        condition.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<bool> condition, Func<ValueTask<TSource>> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch when (condition())
            {
                var handler = selector();
                return handler.IsCompletedSuccessfully
                    ? handler.Result
                    : await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, condition, selector);
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
    /// <param name="action">
    /// An action to perform when any of the previous tasks failes due to the specified exception type
    /// and the exception itself satifies a condition.
    /// </param>
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TSource, TException>(this in ValueTask<TSource> source, Func<TException, bool> predicate, Action<TException> action) where TException : Exception
    {
        predicate.ThrowIfNull();
        action.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<TException, bool> predicate, Action<TException> action)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                action(ex);
            }
        }
        return ContinueWithAsync(source, predicate, action);
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
    /// <returns>A continuation <see cref="ValueTask"/>.</returns>
    public static ValueTask CatchWhen<TSource, TException>(this in ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, ValueTask> selector) where TException : Exception
    {
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask ContinueWithAsync(ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, ValueTask> selector)
        {
            try
            {
                if (!source.IsCompletedSuccessfully)
                    await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                var handler = selector(ex);
                if (!handler.IsCompletedSuccessfully)
                    await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
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
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> CatchWhen<TSource, TException>(this in ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector) where TException : Exception
    {
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                return selector(ex);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
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
    /// <returns>A continuation <see cref="ValueTask{TSource}"/>.</returns>
    public static ValueTask<TSource> CatchWhen<TSource, TException>(this in ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, ValueTask<TSource>> selector) where TException : Exception
    {
        predicate.ThrowIfNull();
        selector.ThrowIfNull();

        static async ValueTask<TSource> ContinueWithAsync(ValueTask<TSource> source, Func<TException, bool> predicate, Func<TException, ValueTask<TSource>> selector)
        {
            try
            {
                return source.IsCompletedSuccessfully
                    ? source.Result
                    : await source.ConfigureAwait(false);
            }
            catch (TException ex) when (predicate(ex))
            {
                var handler = selector(ex);
                return handler.IsCompletedSuccessfully
                    ? handler.Result
                    : await handler.ConfigureAwait(false);
            }
        }
        return ContinueWithAsync(source, predicate, selector);
    }
}
