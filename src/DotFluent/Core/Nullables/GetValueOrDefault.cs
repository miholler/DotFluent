using System;

namespace DotFluent
{
    public static partial class NullableExtensions
    {
        #region Methods

        /// <summary>
        /// Retrieves the value of a nullable object, or a default value 
        /// created by a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <param name="source">The nullable object to retrieve the value of.</param>
        /// <param name="defaultFactory">A function to create a default value.</param>
        /// <returns>The value of the <see cref="Nullable{TSource}"/> object; otherwise, the default value created by the specified function.</returns>
        public static TSource GetValueOrDefault<TSource>(this TSource? source, Func<TSource> defaultFactory) where TSource : struct
        {
            defaultFactory.ThrowIfNull();

            return source ?? defaultFactory();
        }

        #endregion
    }
}
