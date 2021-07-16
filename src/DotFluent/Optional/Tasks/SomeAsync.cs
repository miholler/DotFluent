using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    public static partial class OptionTask
    {
        #region Methods

        /// <summary>
        /// Asynchronously creates an option value that is a 'Some' value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <param name="value">The input value.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that represents the asynchronous creation of an <see cref="Option{TResult}"/> 
        /// representing the value.
        /// </returns>
        public static Task<Option<TResult>> SomeAsync<TResult>(TResult value)
            => Task.FromResult(Option.Some(value));

        #endregion
    }
}
