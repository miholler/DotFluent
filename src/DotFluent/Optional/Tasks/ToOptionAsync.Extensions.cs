using DotFluent.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTaskExtensions
    {
        #region Methods

        /// <summary>
        /// Asynchronously creates an option from a nullable object.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The task returning the nullable object to create an option from.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous 'to option' operation. The value of the TResult parameter contains
        /// an <see cref="Option{TSource}"/> representing the value of source.
        /// </returns>
        public static Task<Option<TSource>> ToOptionAsync<TSource>(this Task<TSource?> source, CancellationToken cancellationToken = default) where TSource : struct
        {
            source.ThrowIfNull();

            return source.Then(x => x.ToOption(), cancellationToken);
        }

        #endregion
    }
}
