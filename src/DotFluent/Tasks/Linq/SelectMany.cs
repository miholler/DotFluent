using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq
{
    public static partial class TaskLinqExtensions
    {
        #region Methods

        /// <summary>
        /// Projects the return value of a task object into another task using a specified function
        /// and flattens the result.
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by source.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the task returned by selector.</typeparam>
        /// <param name="source">The task whose return value is to be transformed.</param>
        /// <param name="selector">A transform function to apply to the value.</param>
        /// <returns>A <see cref="Task{TResult}"/> whose return value is the flattened result of invoking the transform function on the return value of source.</returns>
        public static Task<TResult> SelectMany<TSource, TResult>(this Task<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            source.ThrowIfNull(nameof(source));
            selector.ThrowIfNull(nameof(selector));

            return source.ContinueWith(x => selector(x.Result)).Unwrap();
        }

        /// <summary>
        /// Projects the return value of a task object into another task using a specified function,
        /// flattens the result, and invokes a specified result selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by source.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the task returned by taskSelector.</typeparam>
        /// <typeparam name="TNewResult">The type of the value returned by resultSelector.</typeparam>
        /// <param name="source">The task whose return value is to be transformed.</param>
        /// <param name="taskSelector">A transform function to apply to the value.</param>
        /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
        /// <returns>
        /// A <see cref="Task{TNewResult}"/> whose return value is the result of invoking the transform function on the return value of source 
        /// and then mapping the return value of this <see cref="Task{TResult}"/> and it's corresponding source value to a result value. 
        /// </returns>
        public static Task<TNewResult> SelectMany<TSource, TResult, TNewResult>(this Task<TSource> source, Func<TSource, Task<TResult>> taskSelector, Func<TSource, TResult, TNewResult> resultSelector)
        {
            source.ThrowIfNull(nameof(source));
            taskSelector.ThrowIfNull(nameof(taskSelector));
            resultSelector.ThrowIfNull(nameof(resultSelector));

            return source.ContinueWith(x => taskSelector(x.Result).ContinueWith(y => resultSelector(x.Result, y.Result))).Unwrap();
        }

        #endregion
    }
}
