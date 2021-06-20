using System;

namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if an object instance is null; otherwise, returns the instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <param name="source">The object to check for null.</param>
        /// <param name="paramName">The parameter name to use when throwing the <see cref="ArgumentNullException"/>.</param>
        /// <returns>The object if not null.</returns>
        public static TSource ThrowIfNull<TSource>(this TSource source, string paramName = null)
            => source ?? throw new ArgumentNullException(paramName);

        /// <summary>
        /// Throws an <see cref="Exception"/> created by a specified function if an object instance is null; 
        /// otherwise, returns the instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <param name="source">The object to check for null.</param>
        /// <param name="factory">A function to create the <see cref="Exception"/>.</param>
        /// <returns>The object if not null.</returns>
        public static TSource ThrowIfNull<TSource>(this TSource source, Func<Exception> factory)
            => source ?? throw factory();

        #endregion
    }
}
