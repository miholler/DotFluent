using DotFluent.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously determines whether an option contains a value that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option in which to locate a value.</param>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous exists operation. The value of the TResult parameter contains
        /// true if the option contains a value that satisfies the condition; otherwise, false.
        /// </returns>
        public static Task<bool> ExistsAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            predicate.ThrowIfNull();

            return source.Then(x => x.Exists(predicate), cancellationToken);
        }

        /// <summary>
        /// Asynchronously determines whether an option contains a value that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option in which to locate a value.</param>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous exists operation. The value of the TResult parameter contains
        /// true if the option contains a value that satisfies the condition; otherwise, false.
        /// </returns>
        public static Task<bool> ExistsAsync<TSource>(this Task<Option<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();
            predicate.ThrowIfNull();

            return source.Then(x => x.ExistsAsync(predicate, cancellationToken), cancellationToken);
        }

        #endregion
    }
}
