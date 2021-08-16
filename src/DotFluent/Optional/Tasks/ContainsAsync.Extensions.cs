using DotFluent.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    /// <summary>
    /// Provides extension methods for specific kinds of <see cref="Task{TResult}"/> objects.
    /// </summary>
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously determines whether an option contains a specified value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option in which to locate a value.</param>
        /// <param name="value">The value to locate in the option.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
        /// true if the option contains the specified value; otherwise, false.
        /// </returns>
        public static Task<bool> ContainsAsync<TSource>(this Task<Option<TSource>> source, TSource value, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            
            return source.Then(x => x.Contains(value), cancellationToken);
        }

        /// <summary>
        /// Asynchronously determines whether an option contains a value created by a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option in which to locate a value.</param>
        /// <param name="valueFactory">A function to create the value to locate in the option.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous contains operation. The value of the TResult parameter contains
        /// true if the option contains the specified value; otherwise, false.
        /// </returns>
        public static Task<bool> ContainsAsync<TSource>(this Task<Option<TSource>> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            valueFactory.ThrowIfNull(nameof(valueFactory));

            return source.Then(x => x.ContainsAsync(valueFactory, cancellationToken), cancellationToken);
        }

        #endregion
    }
}
