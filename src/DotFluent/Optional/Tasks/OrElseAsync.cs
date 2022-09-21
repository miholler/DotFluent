namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    #region Methods

    /// <summary>
    /// Asynchronously returns an alternative option created by a specified function
    /// if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="otherFactory">A function to create an alternative option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> representing a value; otherwise, an alternative <see cref="Option{TSource}"/> created by
    /// the specified function.
    /// </returns>
    public static Task<Option<TSource>> OrElseAsync<TSource>(this Option<TSource> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken = default)
    {
        otherFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<Option<TSource>>(cancellationToken)
            : source.IsSome
                ? Task.FromResult(source)
                : otherFactory().ThrowIfNull(() => new InvalidOperationException($"{nameof(otherFactory)} must not return null."));
    }

    #endregion
}
