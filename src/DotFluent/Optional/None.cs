namespace DotFluent.Optional
{
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Creates an option value that is a 'None' value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns>An <see cref="Option{TValue}"/> representing the absense of a value of type <typeparamref name="TValue"/>.</returns>
        public static Option<TValue> None<TValue>()
            => Option<TValue>.None;

        #endregion
    }
}
