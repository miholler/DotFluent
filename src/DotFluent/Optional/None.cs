namespace DotFluent.Optional
{
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Creates an option value that is a 'None' value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <returns>An <see cref="Option{TResult}"/> representing the absense of a value of type <typeparamref name="TResult"/>.</returns>
        public static Option<TResult> None<TResult>()
            => Option<TResult>.None;

        #endregion
    }
}
