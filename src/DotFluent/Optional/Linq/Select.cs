using System;

namespace DotFluent.Optional.Linq
{
    /// <summary>
    /// Provides extension methods for <see cref="Option{T}"/> objects.
    /// </summary>
    public static partial class OptionLinqExtensions
    {
        #region Methods

        /// <summary>
        /// Projects the value of an option into a new form using a specified function,
        /// or returns an empty option based on whether the instance is a 'Some' or a 'None' value.
        /// </summary>
        /// <typeparam name="TSource">The type of the value of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <param name="source">The option whose value is to be transformed.</param>
        /// <param name="selector">A transform function to apply to the value.</param>
        /// <returns>
        /// A <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the value of source; 
        /// otherwise, an empty <see cref="Option{TResult}"/>.
        /// </returns>
        public static Option<TResult> Select<TSource, TResult>(this Option<TSource> source, Func<TSource, TResult> selector)
            => source.Map(selector);

        #endregion
    }
}
