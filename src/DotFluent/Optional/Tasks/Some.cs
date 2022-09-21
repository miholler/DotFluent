namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    #region Methods

    /// <summary>
    /// Creates a task returning an option value that is a 'Some' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value.</typeparam>
    /// <param name="value">The input value.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains
    /// an <see cref="Option{TResult}"/> representing the value.
    /// </returns>
    public static Task<Option<TResult>> Some<TResult>(TResult value)
        => Task.FromResult(Option.Some(value));

    #endregion
}
