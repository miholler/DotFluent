namespace DotFluent.Optional.Tasks;

public static partial class ResultTask
{
    #region Methods

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

    #endregion
}
