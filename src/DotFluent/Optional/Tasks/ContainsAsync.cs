using DotFluent.Internal;
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
    /// true if the option contains the specified value; otherwise, false.
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
    /// true if the result contains the specified value; otherwise, false.
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
    /// Asynchronously determines whether a result contains a value created by a specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The result in which to locate a value.</param>
    /// <param name="valueFactory">A function to create the value to locate in the result.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
    /// true if the result contains the specified value; otherwise, false.
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
}
