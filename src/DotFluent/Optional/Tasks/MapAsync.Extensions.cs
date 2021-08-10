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
        /// Asynchronously projects the value of an option into a new form using a specified function,
        /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
        /// <param name="source">The task returning the option whose value is to be transformed.</param>
        /// <param name="mapper">A transform function to apply to the value.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
        /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
        /// otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, TResult> mapper, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            mapper.ThrowIfNull(nameof(mapper));

            return source.Then(x => x.Map(mapper), cancellationToken);
        }

        /// <summary>
        /// Asynchronously projects the value of an option into a new form using a specified function,
        /// or returns an empty option based on whether the option is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
        /// <param name="source">The task returning the option whose value is to be transformed.</param>
        /// <param name="mapper">A transform function to apply to the value.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous map operation. The value of the TResult parameter contains
        /// an <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
        /// otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Task<Option<TResult>> MapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));
            mapper.ThrowIfNull(nameof(mapper));

            return source.Then(x => x.MapAsync(mapper, cancellationToken), cancellationToken);
        }

        #endregion
    }
}
