using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    #region Methods

    /// <summary>
    /// Asynchronously projects the value of an option into a new form using a specified function,
    /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TResult>>(cancellationToken)
            : source.Match(x => 
                mapper(x)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(mapper)} must not return null."))
                    .Then(Option.Some, cancellationToken),
                None<TResult>);
    }

    #endregion
}

public static partial class ResultTask
{
    #region Methods

    /// <summary>
    /// Asynchronously projects the success value of a result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> MapAsync<TSource, TResult>(this Result<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TResult>>(cancellationToken)
            : source.Match(x =>
                mapper(x)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(mapper)} must not return null."))
                    .Then(Result.Ok, cancellationToken),
                Error<TResult>);
    }

    #endregion
}
