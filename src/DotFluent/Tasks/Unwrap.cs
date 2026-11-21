namespace DotFluent.Tasks;

public static partial class ValueTaskExtensions
{
    /// <summary>
    /// Creates a task that represents the unwrapping of an outer <see cref="ValueTask"/> that contains an inner <see cref="ValueTask"/>.
    /// </summary>
    /// <param name="source">The outer task to unwrap.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the completion of the inner task.</returns>
    public static ValueTask Unwrap(this in ValueTask<ValueTask> source)
    {
        static async ValueTask Core(ValueTask<ValueTask> source)
            => await (await source.ConfigureAwait(false)).ConfigureAwait(false);

        return Core(source);
    }

    /// <summary>
    /// Creates a task that represents the unwrapping of an outer <see cref="ValueTask"/> that contains an inner <see cref="ValueTask{TResult}"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the inner task.</typeparam>
    /// <param name="source">The outer task to unwrap.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> that represents the completion of the inner task.</returns>
    public static ValueTask<TResult> Unwrap<TResult>(this in ValueTask<ValueTask<TResult>> source)
    {
        static async ValueTask<TResult> Core(ValueTask<ValueTask<TResult>> source)
            => await (await source.ConfigureAwait(false)).ConfigureAwait(false);

        return Core(source);
    }
}
