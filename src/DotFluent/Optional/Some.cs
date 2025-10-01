namespace DotFluent.Optional;

public static partial class Option
{
    /// <summary>
    /// Creates an option value that is a 'Some' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value.</typeparam>
    /// <param name="value">The input value.</param>
    /// <returns>An <see cref="Option{TResult}"/> representing the value.</returns>
    public static Option<TResult> Some<TResult>(TResult value)
        => Option<TResult>.Some(value);
}
