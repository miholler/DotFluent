namespace DotFluent.Optional.Tasks;

public static partial class ResultTask
{
    #region Methods

    /// <summary>
    /// Creates a task returning a result value that is an 'Ok' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains
    /// a <see cref="Result{TResult}"/> representing the success value.
    /// </returns>
    public static Task<Result<TResult>> Ok<TResult>(TResult value)
        => Task.FromResult(Result.Ok(value));

    /// <summary>
    /// Creates a task returning a result value that is an 'Ok' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value.</typeparam>
    /// <typeparam name="TError">The type of the error value.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains
    /// a <see cref="Result{TValue, TError}"/> representing the success value.
    /// </returns>
    public static Task<Result<TValue, TError>> Ok<TValue, TError>(TValue value)
        => Task.FromResult(Result.Ok<TValue, TError>(value));

    #endregion
}
