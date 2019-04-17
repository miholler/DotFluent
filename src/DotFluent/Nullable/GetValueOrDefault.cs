using System;

namespace DotFluent
{
    /// <summary>
    /// Provides extension methods for <see cref="Nullable{T}"/> objects.
    /// </summary>
    public static partial class NullableExtensions
    {
        #region Methods

        /// <summary>
        /// Retrieves the value of a nullable object, or a default value 
        /// created by a specified factory function.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="source">The nullable object to retrieve the value of.</param>
        /// <param name="defaultFactory">A factory function to create a default value.</param>
        /// <returns>The value of the <see cref="Nullable{T}"/> object; otherwise, the default value created by the provided factory function.</returns>
        public static T GetValueOrDefault<T>(this T? source, Func<T> defaultFactory) where T : struct
        {
            defaultFactory.ThrowIfNull(nameof(defaultFactory));

            return source ?? defaultFactory();
        }

        #endregion
    }
}
