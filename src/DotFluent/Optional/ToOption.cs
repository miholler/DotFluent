namespace DotFluent.Optional
{
    public static partial class Option
    {
        #region Methods

        /// <summary>
        /// Creates an option from a nullable object.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The nullable object to create an option from.</param>
        /// <returns>An <see cref="Option{TSource}"/> representing the value of source.</returns>
        public static Option<TSource> ToOption<TSource>(this TSource? source) where TSource : struct
            => source.Match(Some, None<TSource>);

        #endregion
    }
}
