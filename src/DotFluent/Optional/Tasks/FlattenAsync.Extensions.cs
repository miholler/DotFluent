using DotFluent.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously flattens an option with a nested option into one option.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of the nested option.</typeparam>
        /// <param name="source">The task returning the option with a nested option to flatten.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous flatten operation. The value of the TResult parameter contains
        /// an <see cref="Option{TSource}"/> representing the flattened result.
        /// </returns>
        public static Task<Option<TSource>> FlattenAsync<TSource>(this Task<Option<Option<TSource>>> source, CancellationToken cancellationToken = default)
        {
            source.ThrowIfNull(nameof(source));

            return source.Then(x => x.Flatten(), cancellationToken);
        }

        #endregion
    }
}
