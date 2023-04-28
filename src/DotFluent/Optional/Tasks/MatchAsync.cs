namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    #region Methods

    /// <summary>
    /// Asynchronously invokes a specified function if an option is a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
    public static Task MatchAsync<TSource>(this Option<TSource> source, Func<Task> none, CancellationToken cancellationToken = default)
        => source.MatchAsync(_ => Task.CompletedTask, none, cancellationToken);

    /// <summary>
    /// Asynchronously invokes a specified function if an option is a 'Some' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
    public static Task MatchAsync<TSource>(this Option<TSource> source, Func<TSource, Task> some, CancellationToken cancellationToken = default)
        => source.MatchAsync(some, () => Task.CompletedTask, cancellationToken);

    /// <summary>
    /// Asynchronously invokes a specified function based on whether an option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous match operation.</returns>
    public static Task MatchAsync<TSource>(this Option<TSource> source, Func<TSource, Task> some, Func<Task> none, CancellationToken cancellationToken = default)
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled(cancellationToken)
            : source.Match(x => 
                some(x).ThrowIfNull(() => new InvalidOperationException($"{nameof(some)} must not return null.")),
                () => none().ThrowIfNull(() => new InvalidOperationException($"{nameof(none)} must not return null.")));
    }

    /// <summary>
    /// Asynchronously invokes a specified function, or returns a specified alternative value
    /// based on whether an option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">The value to return if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
    /// the result of the invoked function if a value is present; otherwise the specified alternative value.
    /// </returns>
    public static Task<TResult> MatchAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<TResult>> some, TResult none, CancellationToken cancellationToken = default)
        => source.MatchAsync(some, () => Task.FromResult(none), cancellationToken);

    /// <summary>
    /// Asynchronously invokes a specified function based on whether an option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
    /// the result of the invoked function.
    /// </returns>
    public static Task<TResult> MatchAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<TResult>> some, Func<TResult> none, CancellationToken cancellationToken = default)
    {
        none.ThrowIfNull();

        return source.MatchAsync(some, () => Task.FromResult(none()), cancellationToken);
    }

    /// <summary>
    /// Asynchronously invokes a specified function based on whether an option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
    /// the result of the invoked function.
    /// </returns>
    public static Task<TResult> MatchAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, TResult> some, Func<Task<TResult>> none, CancellationToken cancellationToken = default)
    {
        some.ThrowIfNull();

        return source.MatchAsync(x => Task.FromResult(some(x)), none, cancellationToken);
    }

    /// <summary>
    /// Asynchronously invokes a specified function based on whether an option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="source">The option to check for having a value.</param>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous match operation. The value of the TResult parameter contains
    /// the result of the invoked function.
    /// </returns>
    public static Task<TResult> MatchAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<TResult>> some, Func<Task<TResult>> none, CancellationToken cancellationToken = default)
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : source.Match(x =>
                some(x).ThrowIfNull(() => new InvalidOperationException($"{nameof(some)} must not return null.")),
                () => none().ThrowIfNull(() => new InvalidOperationException($"{nameof(none)} must not return null.")));
    }

    #endregion
}
