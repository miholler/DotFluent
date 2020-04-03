using System;

namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if an object is null; otherwise, returns the object.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <param name="source">The object to check for null.</param>
        /// <param name="paramName">The parameter name to use when throwing the <see cref="ArgumentNullException"/>.</param>
        /// <returns>The object if not null.</returns>
        public static TSource ThrowIfNull<TSource>(this TSource source, string paramName = null)
        {
            if (source.IsNull())
                throw new ArgumentNullException(paramName);

            return source;
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> created by a specified function if an object is null; otherwise, returns the object.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <param name="source">The object to check for null.</param>
        /// <param name="factory">A function to create the <see cref="Exception"/>.</param>
        /// <returns>The object if not null.</returns>
        public static TSource ThrowIfNull<TSource>(this TSource source, Func<Exception> factory)
        {
            if (source.IsNull())
                throw factory();

            return source;
        }

        #endregion
    }
}
