namespace DotFluent.Tasks.Linq;

public static partial class TaskLinqExtensions
{
    #region Methods

    /// <summary>
    /// Projects the return value of a task object into a new form using a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value returned by source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
    /// <param name="source">The task whose return value is to be transformed.</param>
    /// <param name="selector">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A cancellation token that will be assigned to the continuation task.</param>
    /// <returns>A <see cref="Task{TResult}"/> whose return value is the result of invoking the transform function on the return value of source.</returns>
    public static Task<TResult> Select<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
        => source.Then(selector, cancellationToken);

    #endregion
}
