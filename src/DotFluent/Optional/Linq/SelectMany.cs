using System;

namespace DotFluent.Optional.Linq
{
    public static partial class OptionLinqExtensions
    {
        #region Methods

        /// <summary>
        /// Projects the value of an option into another option using a specified function
        /// and flattens the result, or returns an empty option based on whether the instance 
        /// is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value of the option returned by selector.</typeparam>
        /// <param name="source">The option whose value is to be transformed.</param>
        /// <param name="selector">A transform function to apply to the value.</param>
        /// <returns>
        /// An <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the value of source; 
        /// otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Option<TResult> SelectMany<TSource, TResult>(this Option<TSource> source, Func<TSource, Option<TResult>> selector)
            => source.FlatMap(selector);

        /// <summary>
        /// Projects the value of an option into another option using a specified function,
        /// flattens the result, and invokes a specified result selector function, or returns 
        /// an empty option based on whether the instance is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TOption">The type of the value of the option returned by optionSelector.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by resultSelector.</typeparam>
        /// <param name="source">The option whose value is to be transformed.</param>
        /// <param name="optionSelector">A transform function to apply to the value.</param>
        /// <param name="resultSelector">A transform function to apply to the intermediate value.</param>
        /// <returns>
        /// An <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the value of source and then mapping 
        /// the value of this <see cref="Option{TOption}"/> and it's corresponding source value to a result value; otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Option<TResult> SelectMany<TSource, TOption, TResult>(this Option<TSource> source, Func<TSource, Option<TOption>> optionSelector, Func<TSource, TOption, TResult> resultSelector)
        {
            optionSelector.ThrowIfNull();
            resultSelector.ThrowIfNull();

            return source.FlatMap(x => optionSelector(x).Map(y => resultSelector(x, y)));
        }

        #endregion
    }
}
