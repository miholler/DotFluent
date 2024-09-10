namespace DotFluent.Optional.Linq;

public static partial class OptionLinqExtensions
{
    #region Methods

    /// <summary>
    /// Projects the value of an option into another option using a specified function
    /// and flattens the result, or returns an empty option based on whether the instance 
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value of the option returned by selector.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// An <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the value of source; 
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Option<TResult> SelectMany<TSource, TResult>(this Option<TSource> source, Func<TSource, Option<TResult>> selector)
        => source.FlatMap(selector);

    /// <summary>
    /// Projects the value of an option into another option using a specified function,
    /// flattens the result, and invokes a specified result selector function, or returns 
    /// an empty option based on whether the instance is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TOption">The type of the value of the option returned by optionSelector.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by resultSelector.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="optionSelector">A transform function to apply to the value.</param>
    /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
    /// <returns>
    /// An <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the value of source and then mapping 
    /// the value of this <see cref="Option{TOption}"/> and it's corresponding source value to a result value; otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Option<TResult> SelectMany<TSource, TOption, TResult>(this Option<TSource> source, Func<TSource, Option<TOption>> optionSelector, Func<TSource, TOption, TResult> resultSelector)
    {
        optionSelector.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return source
            .FlatMap(x => optionSelector(x)
                .Map(y => resultSelector(x, y)));
    }

    #endregion
}

public static partial class ResultLinqExtensions
{
    #region Methods

    /// <summary>
    /// Projects the success value of a result into another result using a specified function
    /// and flattens the result, or returns an 'Error' result based on whether the instance
    /// is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by selector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult}"/> whose success value is the flattened result of invoking the transform
    /// function on the success value of source; otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Result<TResult> SelectMany<TSource, TResult>(this Result<TSource> source, Func<TSource, Result<TResult>> selector)
        => source.FlatMap(selector);

    /// <summary>
    /// Projects the success value of a result into another result using a specified function,
    /// flattens the result, and invokes a specified result selector function, or returns
    /// an 'Error' result based on whether the instance is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TInterim">The type of the success value of the result returned by interimSelector.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by resultSelector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="interimSelector">A transform function to apply to the value.</param>
    /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
    /// <returns>
    /// An <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on the success value of source and then mapping 
    /// the success value of this <see cref="Result{TInterim}"/> and it's corresponding source value to a result value; otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Result<TResult> SelectMany<TSource, TInterim, TResult>(this Result<TSource> source, Func<TSource, Result<TInterim>> interimSelector, Func<TSource, TInterim, TResult> resultSelector)
    {
        interimSelector.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return source
            .FlatMap(x => interimSelector(x)
                .Map(y => resultSelector(x, y)));
    }

    /// <summary>
    /// Projects the success value of a result into another result using a specified function
    /// and flattens the result, or returns an 'Error' result based on whether the instance
    /// is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by selector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult, TError}"/> whose success value is the flattened result of invoking the transform
    /// function on the success value of source; otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Result<TResult, TError> SelectMany<TValue, TError, TResult>(this Result<TValue, TError> source, Func<TValue, Result<TResult, TError>> selector)
        => source.FlatMap(selector);

    /// <summary>
    /// Projects the success value of a result into another result using a specified function,
    /// flattens the result, and invokes a specified result selector function, or returns
    /// an 'Error' result based on whether the instance is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <typeparam name="TInterim">The type of the success value of the result returned by interimSelector.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by resultSelector.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="interimSelector">A transform function to apply to the value.</param>
    /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
    /// <returns>
    /// An <see cref="Result{TResult, TError}"/> whose success value is the result of invoking the transform function on the success value of source and then mapping 
    /// the success value of this <see cref="Result{TInterim, TError}"/> and it's corresponding source value to a result value; otherwise, an 'Error' <see cref="Result{TResult, TError}"/>.
    /// </returns>
    public static Result<TResult, TError> SelectMany<TValue, TError, TInterim, TResult>(this Result<TValue, TError> source, Func<TValue, Result<TInterim, TError>> interimSelector, Func<TValue, TInterim, TResult> resultSelector)
    {
        interimSelector.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return source
            .FlatMap(x => interimSelector(x)
                .Map(y => resultSelector(x, y)));
    }

    #endregion
}
