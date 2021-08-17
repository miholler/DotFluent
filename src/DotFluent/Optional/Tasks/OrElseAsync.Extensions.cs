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
        /// Asynchronously returns an alternative option if an option is a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="other">The option to return if a value is missing.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
        /// an <see cref="Option{TSource}"/> representing a value; otherwise, the specified alternative <see cref="Option{TSource}"/>.
        /// </returns>
        public static Task<Option<TSource>> OrElseAsync<TSource>(this Task<Option<TSource>> source, Option<TSource> other, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));

            return source.Then(x => x.OrElse(other), cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns an alternative option created by a specified function
        /// if an option is a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option to check for having a value.</param>
        /// <param name="otherFactory">A function to create an alternative option.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous 'or else' operation. The value of the TResult parameter contains
        /// an <see cref="Option{TSource}"/> representing a value; otherwise, an alternative <see cref="Option{TSource}"/> created by
        /// the specified function.
        /// </returns>
        public static Task<Option<TSource>> OrElseAsync<TSource>(this Task<Option<TSource>> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            otherFactory.ThrowIfNull(nameof(otherFactory));

            return source.Then(x => x.OrElseAsync(otherFactory, cancellationToken), cancellationToken);
        }

        #endregion
    }
}
