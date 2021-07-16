using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    /// <summary>
    /// Provides a set of static methods for working with 
    /// <see cref="Option{T}"/> instances asynchronously.
    /// </summary>
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously creates an option value that is a 'None' value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that represents the asynchronous creation of an <see cref="Option{TResult}"/> 
        /// representing the absense of a value of type <typeparamref name="TResult"/>.
        /// </returns>
        public static Task<Option<TResult>> NoneAsync<TResult>()
            => Task.FromResult(Option.None<TResult>());

        #endregion
    }
}
