using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTaskExtensions
{
    #region Methods

    /// <summary>
    /// Asynchronously removes the value from an option if it does not satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option whose value is to be filtered.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous filter operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value satisfies the condition in the predicate function; 
    /// otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> FilterAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        return source.Then(x => x.Filter(predicate), cancellationToken);
    }

    /// <summary>
    /// Asynchronously removes the value from an option if it does not satisfy a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option whose value is to be filtered.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous filter operation. The value of the TResult parameter contains
    /// an <see cref="Option{TSource}"/> whose value satisfies the condition in the predicate function; 
    /// otherwise, an empty <see cref="Option{TSource}"/>.
    /// </returns>
    public static Task<Option<TSource>> FilterAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        predicate.ThrowIfNull();

        return source.Then(x => x.FilterAsync(predicate, cancellationToken), cancellationToken);
    }

    #endregion
}
