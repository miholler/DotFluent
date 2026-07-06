namespace DotFluent.Optional;

public static partial class Result
{
    /// <summary>
    /// Creates a result value that is an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="error">The error value.</param>
    /// <returns>A <see cref="Result{TResult}"/> representing the error value.</returns>
    public static Result<TResult> Error<TResult>(Exception error)
        => Result<TResult>.Error(error);

    /// <summary>
    /// Creates a result value that is an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value.</typeparam>
    /// <typeparam name="TError">The type of the error value.</typeparam>
    /// <param name="error">The error value.</param>
    /// <returns>A <see cref="Result{TValue, TError}"/> representing the error value.</returns>
    public static Result<TValue, TError> Error<TValue, TError>(TError error)
        => Result<TValue, TError>.Error(error);
}
