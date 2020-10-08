namespace DotFluent.Optional
{
    /// <summary>
    /// Provides a set of static methods for working 
    /// with <see cref="Option{T}"/> instances.
    /// </summary>
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Creates an option value that is a 'None' value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <returns>An <see cref="Option{T}"/> representing the absense of a value of type <typeparamref name="TResult"/>.</returns>
        public static Option<TResult> None<TResult>()
            => Option<TResult>.None;

        #endregion
    }
}
