using System;

namespace DotFluent
{
    public static partial class ObjectExtensions
    {
        #region Methods

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if an object is null; otherwise, returns the object.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check for null.</param>
        /// <param name="paramName">The parameter name to use when throwing the <see cref="ArgumentNullException"/>.</param>
        /// <returns>The <typeparamref name="T"/> if not null.</returns>
        public static T ThrowIfNull<T>(this T obj, string paramName = null)
        {
            if (obj.IsNull())
                throw new ArgumentNullException(paramName);

            return obj;
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> created by a provided function if an object is null; otherwise, returns the object.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check for null.</param>
        /// <param name="factory">A function to create the <see cref="Exception"/>.</param>
        /// <returns>The <typeparamref name="T"/> if not null.</returns>
        public static T ThrowIfNull<T>(this T obj, Func<Exception> factory)
        {
            if (obj.IsNull())
                throw factory();

            return obj;
        }

        #endregion
    }
}
