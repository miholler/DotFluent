using DotFluent.Optional.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

public static partial class UnsafeOptionTask
{
    #region Methods

    /// <summary>
    /// Asynchronously retrieves the value of an option, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to retrieve the value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the value of the <see cref="Option{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Option<TSource> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        defaultFactory.ThrowIfNull();

        return source.MatchAsync(Task.FromResult, defaultFactory, cancellationToken);
    }

    #endregion
}

public static partial class UnsafeResultTask
{
    #region Methods

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Result<TSource> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        defaultFactory.ThrowIfNull();

        return source.MatchAsync(Task.FromResult, _ => defaultFactory(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TValue, TError}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(this Result<TValue, TError> source, Func<Task<TValue>> defaultFactory, CancellationToken cancellationToken = default)
    {
        defaultFactory.ThrowIfNull();

        return source.MatchAsync(Task.FromResult, _ => defaultFactory(), cancellationToken);
    }

    #endregion
}
