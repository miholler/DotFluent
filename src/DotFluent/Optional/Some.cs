namespace DotFluent.Optional
{
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Creates an option value that is a 'Some' value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The input value.</param>
        /// <returns>An <see cref="Option{TValue}"/> representing the value.</returns>
        public static Option<TValue> Some<TValue>(TValue value)
            => Option<TValue>.Some(value);

        #endregion
    }
}
