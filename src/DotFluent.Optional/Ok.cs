namespace DotFluent.Optional;

public static partial class Result
{
    /// <summary>
    /// Creates a result value that is an 'Ok' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{TResult}"/> representing the success value.</returns>
    public static Result<TResult> Ok<TResult>(TResult value)
        => Result<TResult>.Ok(value);

    /// <summary>
    /// Creates a result value that is an 'Ok' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value.</typeparam>
    /// <typeparam name="TError">The type of the error value.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{TValue, TError}"/> representing the success value.</returns>
    public static Result<TValue, TError> Ok<TValue, TError>(TValue value)
        => Result<TValue, TError>.Ok(value);
}
