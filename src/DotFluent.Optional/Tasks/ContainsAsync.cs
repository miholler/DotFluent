using DotFluent.Optional.Internal;
using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Asynchronously determines whether an option contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The option in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the option contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Option<TSource> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken = default)
    {
        valueFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<bool>(cancellationToken)
            : valueFactory()
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(valueFactory))))
                .Then(source.Contains, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether an option contains a specified value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option in which to locate a value.</param>
    /// <param name="value">The value to locate in the option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the option contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Task<Option<TSource>> source, TSource value, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(option => option.Contains(value), cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether an option contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the option.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the option contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Task<Option<TSource>> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        valueFactory.ThrowIfNull();

        return source.Then(option => option.ContainsAsync(valueFactory, cancellationToken), cancellationToken);
    }
}

public static partial class ResultTask
{
    /// <summary>
    /// Asynchronously determines whether a result contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The result in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Result<TSource> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken = default)
    {
        valueFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<bool>(cancellationToken)
            : valueFactory()
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(valueFactory))))
                .Then(source.Contains, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether a result contains a specified value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result in which to locate a value.</param>
    /// <param name="value">The value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Task<Result<TSource>> source, TSource value, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(result => result.Contains(value), cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether a result contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TSource>(this Task<Result<TSource>> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        valueFactory.ThrowIfNull();

        return source.Then(result => result.ContainsAsync(valueFactory, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether a result contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TValue, TError>(this Result<TValue, TError> source, Func<Task<TValue>> valueFactory, CancellationToken cancellationToken = default)
    {
        valueFactory.ThrowIfNull();

        return cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<bool>(cancellationToken)
            : valueFactory()
                .ThrowIfNull(() => new InvalidOperationException(string.Format(Errors.FunctionMustNotReturnNull, nameof(valueFactory))))
                .Then(source.Contains, cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether a result contains a specified value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result in which to locate a value.</param>
    /// <param name="value">The value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TValue, TError>(this Task<Result<TValue, TError>> source, TValue value, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(result => result.Contains(value), cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether a result contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// <see langword="true"/> if the result contains the specified value; otherwise, <see langword="false"/>.
    /// </returns>
    public static Task<bool> ContainsAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Func<Task<TValue>> valueFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        valueFactory.ThrowIfNull();

        return source.Then(result => result.ContainsAsync(valueFactory, cancellationToken), cancellationToken);
    }
}
