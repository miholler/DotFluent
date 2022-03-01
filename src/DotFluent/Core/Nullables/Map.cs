using System;

namespace DotFluent
{
    public static partial class NullableExtensions
    {
        #region Methods

        /// <summary>
        /// Projects the value of a nullable object into a new form using a specified function,
        /// or returns an empty nullable object if the nullable has no value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
        /// <param name="source">The nullable whose value is to be transformed.</param>
        /// <param name="mapper">A transform function to apply to the value.</param>
        /// <returns>
        /// A <see cref="Nullable{TResult}"/> whose value is the result of invoking the transform function on the value of source; 
        /// otherwise, an empty <see cref="Nullable{TResult}"/>.
        /// </returns>
        public static TResult? Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> mapper) where TSource : struct where TResult : struct
        {
            mapper.ThrowIfNull();

            return source.HasValue ? mapper(source.Value) : new TResult?();
        }

        #endregion
    }
}
