using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

/// <summary>
/// Provides a set of static methods for working with 
/// <see cref="Option{T}"/> instances asynchronously.
/// </summary>
public static partial class OptionTask
{
    #region Methods

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
                .ThrowIfNull(() => new InvalidOperationException($"{nameof(valueFactory)} must not return null."))
                .Then(x => source.Contains(x), cancellationToken);
    }

    #endregion
}
