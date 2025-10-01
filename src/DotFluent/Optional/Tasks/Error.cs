namespace DotFluent.Optional.Tasks;

public static partial class ResultTask
{
    /// <summary>
    /// Creates a task returning a result value that is an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="error">The error value.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains
    /// a <see cref="Result{TResult}"/> representing the error value.
    /// </returns>
    public static Task<Result<TResult>> Error<TResult>(Exception error)
        => Task.FromResult(Result.Error<TResult>(error));

    /// <summary>
    /// Creates a task returning a result value that is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value.</typeparam>
    /// <typeparam name="TError">The type of the error value.</typeparam>
    /// <param name="error">The error value.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing the error value.
    /// </returns>
    public static Task<Result<TValue, TError>> Error<TValue, TError>(TError error)
        => Task.FromResult(Result.Error<TValue, TError>(error));
}
