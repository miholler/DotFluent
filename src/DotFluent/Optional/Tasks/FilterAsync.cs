using DotFluent.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously removes the value from an option if it does not satisfy a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option whose value is to be filtered.</param>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous filter operation. The value of the TResult parameter contains
        /// an <see cref="Option{TSource}"/> whose value satisfies the condition in the predicate function; 
        /// otherwise, an empty <see cref="Option{TSource}"/>.
        /// </returns>
        public static Task<Option<TSource>> FilterAsync<TSource>(this Option<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            predicate.ThrowIfNull(nameof(predicate));
            
            return cancellationToken.IsCancellationRequested
                ? Task.FromCanceled<Option<TSource>>(cancellationToken)
                : source.Match(x => predicate(x)?.Then(y => y ? source : Option.None<TSource>(), cancellationToken), None<TSource>);
        }

        #endregion
    }
}
