namespace DotFluent.Optional.Tasks;

public static partial class OptionTask
{
    /// <summary>
    /// Creates a task returning an option value that is a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value.</typeparam>
    /// <returns>
    /// A <see cref="Task{TResult}"/> whose TResult parameter contains 
    /// an <see cref="Option{TResult}"/> representing the absense of a value of type <typeparamref name="TResult"/>.
    /// </returns>
    public static Task<Option<TResult>> None<TResult>()
        => Task.FromResult(Option.None<TResult>());
}
