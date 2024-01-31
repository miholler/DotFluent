namespace DotFluent.Optional;

public static partial class Result
{
    #region Methods

    /// <summary>
    /// Creates a result value that is an 'Ok' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{TResult}"/> representing the success value.</returns>
    public static Result<TResult> Ok<TResult>(TResult value)
        => Result<TResult>.Ok(value);

    #endregion
}
