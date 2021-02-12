using System;

namespace DotFluent.Linq
{
    public static partial class NullableLinqExtensions
    {
        #region Methods

        /// <summary>
        /// Projects the value of a nullable object into another nullable using a specified function
        /// and flattens the result, or returns an empty nullable object if the instance has no value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value of the nullable returned by selector.</typeparam>
        /// <param name="source">The nullable whose value is to be transformed.</param>
        /// <param name="selector">A transform function to apply to the value.</param>
        /// <returns>
        /// A <see cref="Nullable{TResult}"/> whose value is the flattened result of invoking the transform function on the value of source; 
        /// otherwise, an empty <see cref="Nullable{TResult}"/>.
        /// </returns>
        public static TResult? SelectMany<TSource, TResult>(this TSource? source, Func<TSource, TResult?> selector) where TSource : struct where TResult : struct
            => source.FlatMap(selector);

        /// <summary>
        /// Projects the value of a nullable object into another nullable using a specified function,
        /// flattens the result, and invokes a specified result selector function, or returns an empty 
        /// nullable object if the instance has no value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TNullable">The type of the value of the nullable returned by nullableSelector.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by resultSelector.</typeparam>
        /// <param name="source">The nullable whose value is to be transformed.</param>
        /// <param name="nullableSelector">A transform function to apply to the value.</param>
        /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
        /// <returns>
        /// A <see cref="Nullable{TResult}"/> whose value is the result of invoking the transform function on the value of source and then mapping 
        /// the value of this <see cref="Nullable{TNullable}"/> and it's corresponding source value to a result value; otherwise, an empty <see cref="Nullable{TResult}"/>.
        /// </returns>
        public static TResult? SelectMany<TSource, TNullable, TResult>(this TSource? source, Func<TSource, TNullable?> nullableSelector, Func<TSource, TNullable, TResult> resultSelector) where TSource : struct where TNullable : struct where TResult : struct
        {
            nullableSelector.ThrowIfNull(nameof(nullableSelector));
            resultSelector.ThrowIfNull(nameof(resultSelector));

            return source.FlatMap(x => nullableSelector(x).Map(y => resultSelector(x, y)));
        }

        #endregion
    }
}
