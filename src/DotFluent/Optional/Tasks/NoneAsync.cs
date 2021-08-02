using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously creates an option value that is a 'None' value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that represents the asynchronous creation of an <see cref="Option{TResult}"/> 
        /// representing the absense of a value of type <typeparamref name="TResult"/>.
        /// </returns>
        public static Task<Option<TResult>> NoneAsync<TResult>(CancellationToken cancellationToken = default)
            => cancellationToken.IsCancellationRequested 
                ? Task.FromCanceled<Option<TResult>>(cancellationToken) 
                : Task.FromResult(Option.None<TResult>());

        #endregion
    }
}
