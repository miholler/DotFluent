using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class ResultTask
{
    #region Methods

    /// <summary>
    /// Asynchronously projects the error value of a result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result whose error value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous map error operation. The value of the TResult parameter contains
    /// a <see cref="Result{TSource}"/> whose error value is the result of invoking the transform function on the error value of source;
    /// otherwise, an 'Ok' <see cref="Result{TSource}"/>.
    /// </returns>
    public static Task<Result<TSource>> MapErrorAsync<TSource>(this Result<TSource> source, Func<Exception, Task<Exception>> mapper, CancellationToken cancellationToken = default)
    {
        mapper.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Result<TSource>>(cancellationToken)
            : source.Match(Ok, x =>
                mapper(x)
                    .ThrowIfNull(() => new InvalidOperationException($"{nameof(mapper)} must not return null."))
                    .Then(Error<TSource>, cancellationToken));
    }

    #endregion
}
