using DotFluent.Optional.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks
{
    /// <summary>
    /// Provides a set of static methods for working with 
    /// <see cref="Option{T}"/> instances asynchronously.
    /// </summary>
    public static partial class UnsafeOptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously retrieves the value of an option, or a default value created by a
        /// specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option to retrieve the value of.</param>
        /// <param name="defaultFactory">A function to create a default value.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
        /// the value of the <see cref="Option{TSource}"/>; otherwise, the default value created by the specified function.
        /// </returns>
        public static Task<TSource?> GetValueOrDefaultAsync<TSource>(this Option<TSource> source, Func<Task<TSource?>> defaultFactory, CancellationToken cancellationToken = default)
        {
            defaultFactory.ThrowIfNull();

            return source.MatchAsync(x => Task.FromResult<TSource?>(x), defaultFactory, cancellationToken);
        }

        #endregion
    }
}
