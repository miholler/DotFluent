using System;

namespace DotFluent.Optional.Unsafe
{
    /// <summary>
    /// Provides a set of static methods for working 
    /// with <see cref="Option{T}"/> instances.
    /// </summary>
    public static partial class OptionUnsafe
    {
        #region Methods

        /// <summary>
        /// Retrieves the value of an option, or the type parameter's default value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option to retrieve the value of.</param>
        /// <returns>The value of the <see cref="Option{TSource}"/>; otherwise, the default value for the <typeparamref name="TSource"/> type.</returns>
        public static TSource GetValueOrDefault<TSource>(this Option<TSource> source)
            => source.GetValueOrDefault(() => default);

        /// <summary>
        /// Retrieves the value of an option, or a specified default value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option to retrieve the value of.</param>
        /// <param name="defaultValue">The value to return if the option is a 'None' value.</param>
        /// <returns>The value of the <see cref="Option{TSource}"/>; otherwise, the defaultValue parameter.</returns>
        public static TSource GetValueOrDefault<TSource>(this Option<TSource> source, TSource defaultValue)
            => source.GetValueOrDefault(() => defaultValue);

        /// <summary>
        /// Retrieves the value of an option, or a default value created by a
        /// specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The option to retrieve the value of.</param>
        /// <param name="defaultFactory">A function to create a default value.</param>
        /// <returns>The value of the <see cref="Option{TSource}"/>; otherwise, the default value created by the specified function.</returns>
        public static TSource GetValueOrDefault<TSource>(this Option<TSource> source, Func<TSource> defaultFactory)
        {
            defaultFactory.ThrowIfNull(nameof(defaultFactory));

            return source.Match(x => x, defaultFactory);
        }

        #endregion
    }
}
