namespace DotFluent.Optional;

/// <summary>
/// Provides a set of static methods for working
/// with <see cref="Result{T}"/> instances.
/// </summary>
public static partial class Result
{
    #region Methods

    /// <summary>
    /// Creates a result value that is an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the success value.</typeparam>
    /// <param name="error">The error value.</param>
    /// <returns>A <see cref="Result{TResult}"/> representing the error value.</returns>
    public static Result<TResult> Error<TResult>(Exception error)
        => Result<TResult>.Error(error);

    #endregion
}
