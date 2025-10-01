namespace DotFluent.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Converts a specified task to a value task.
    /// </summary>
    /// <param name="source">The task to convert.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the input <see cref="Task"/>.</returns>
    public static ValueTask AsValueTask(this Task source)
        => new(source);

    /// <summary>
    /// Converts a specified task to a value task.
    /// </summary>
    /// <typeparam name="TSource">The type of the result produced by the source task.</typeparam>
    /// <param name="source">The task to convert.</param>
    /// <returns>A <see cref="ValueTask{TSource}"/> that represents the input <see cref="Task{TSource}"/>.</returns>
    public static ValueTask<TSource> AsValueTask<TSource>(this Task<TSource> source)
        => new(source);
}
