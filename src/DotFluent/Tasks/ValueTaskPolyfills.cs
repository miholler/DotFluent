namespace System.Threading.Tasks;

/// <summary>
/// Provides extension members for <see cref="ValueTask"/> 
/// and <see cref="ValueTask{TResult}"/> objects.
/// </summary>
public static class ValueTaskPolyfills
{
    extension(ValueTask)
    {
        /// <summary>
        /// Gets a task that has already completed successfully.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> that has already completed successfully.</returns>
        public static ValueTask CompletedTask => ValueTaskValues.CompletedTask;

        /// <summary>
        /// Creates a <see cref="ValueTask"/> that has completed due to cancellation
        /// with the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token with which to complete the task.</param>
        /// <returns>The canceled <see cref="ValueTask"/>.</returns>
        public static ValueTask FromCanceled(CancellationToken cancellationToken)
            => new(Task.FromCanceled(cancellationToken));

        /// <summary>
        /// Creates a <see cref="ValueTask{TResult}"/> that has completed due to cancellation
        /// with the specified cancellation token.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the returned task.</typeparam>
        /// <param name="cancellationToken">The cancellation token with which to complete the task.</param>
        /// <returns>The canceled <see cref="ValueTask{TResult}"/>.</returns>
        public static ValueTask<TResult> FromCanceled<TResult>(CancellationToken cancellationToken)
            => new(Task.FromCanceled<TResult>(cancellationToken));

        /// <summary>
        /// Creates a <see cref="ValueTask"/> that has completed with the specified
        /// exception.
        /// </summary>
        /// <param name="exception">The exception with which to complete the task.</param>
        /// <returns>The faulted <see cref="ValueTask"/>.</returns>
        public static ValueTask FromException(Exception exception)
            => new(Task.FromException(exception));

        /// <summary>
        /// Creates a <see cref="ValueTask{TResult}"/> that has completed with the specified
        /// exception.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the returned task.</typeparam>
        /// <param name="exception">The exception with which to complete the task.</param>
        /// <returns>The faulted <see cref="ValueTask{TResult}"/>.</returns>
        public static ValueTask<TResult> FromException<TResult>(Exception exception)
            => new(Task.FromException<TResult>(exception));

        /// <summary>
        /// Creates a <see cref="ValueTask{TResult}"/> that's completed successfully with
        /// the specified result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="result">The result to store into the completed task.</param>
        /// <returns>The successfully completed <see cref="ValueTask{TResult}"/>.</returns>
        public static ValueTask<TResult> FromResult<TResult>(TResult result)
            => new(result);
    }
}

file static class ValueTaskValues
{
    public static readonly ValueTask CompletedTask;
}
