using DotFluent.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously returns the number of values contained in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the option that contains values to be counted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous count operation. The value of the TResult parameter contains
        /// an integer indicating the number of values contained in the option.
        /// <para>
        ///     'Some' value: 1
        /// </para>
        /// <para>
        ///     'None' value: 0
        /// </para>
        /// </returns>
        public static Task<int> CountAsync<TSource>(this Task<Option<TSource>> source, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull();

            return source.Then(x => x.Count(), cancellationToken);
        }

        #endregion
    }
}
