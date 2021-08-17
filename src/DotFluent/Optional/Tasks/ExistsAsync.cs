using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously determines whether an option contains a value that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option in which to locate a value.</param>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous exists operation. The value of the TResult parameter contains
        /// true if the option contains a value that satisfies the condition; otherwise, false.
        /// </returns>
        public static Task<bool> ExistsAsync<TSource>(this Option<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            predicate.ThrowIfNull(nameof(predicate));
            
            return cancellationToken.IsCancellationRequested
                ? Task.FromCanceled<bool>(cancellationToken)
                : source.Match(predicate, () => Task.FromResult(false));
        }

        #endregion
    }
}
