using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously projects the value of an option into another option using a specified function and
        /// flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value of the option returned by mapper.</typeparam>
        /// <param name="source">The option whose value is to be transformed.</param>
        /// <param name="mapper">A transform function to apply to the value.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous flat map operation. The value of the TResult parameter contains
        /// an <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the source value;
        /// otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(this Option<TSource> source, Func<TSource, Task<Option<TResult>>> mapper, CancellationToken cancellationToken = default)
        {
            mapper.ThrowIfNull();

            return cancellationToken.IsCancellationRequested
                ? Task.FromCanceled<Option<TResult>>(cancellationToken)
                : source.Match(x => 
                    mapper(x).ThrowIfNull(() => new InvalidOperationException($"{nameof(mapper)} must not return null.")),
                    None<TResult>);
        }

        #endregion
    }
}
