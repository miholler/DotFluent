namespace DotFluent.Optional.Linq;

/// <summary>
/// Provides extension methods for <see cref="Option{T}"/> objects.
/// </summary>
public static partial class OptionLinqExtensions
{
    #region Methods

    /// <summary>
    /// Projects the value of an option into a new form using a specified function,
    /// or returns an empty option based on whether the instance is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// An <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the value of source; 
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Option<TResult> Select<TSource, TResult>(this Option<TSource> source, Func<TSource, TResult> selector)
        => source.Map(selector);

    #endregion
}

/// <summary>
/// Provides extension methods for <see cref="Result{T}"/>
/// and <see cref="Result{TValue, TError}"/> objects.
/// </summary>
public static partial class ResultLinqExtensions
{
    #region Methods

    /// <summary>
    /// Projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the instance is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on
    /// the success value of source; otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Result<TResult> Select<TSource, TResult>(this Result<TSource> source, Func<TSource, TResult> selector)
        => source.Map(selector);

    /// <summary>
    /// Projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the instance is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult, TError}"/> whose success value is the result of invoking the transform function on
    /// the success value of source; otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Result<TResult, TError> Select<TValue, TError, TResult>(this Result<TValue, TError> source, Func<TValue, TResult> selector)
        => source.Map(selector);

    #endregion
}
