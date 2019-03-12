using DotFluent.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and compares the keys by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="IGrouping{TKey, TSource}"/> where each object contains a collection of objects and a key.</returns>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer)
            => source.GroupBy(keySelector, new GenericEqualityComparer<TKey>(comparer));

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and compares the keys by using specified functions.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="IGrouping{TKey, TSource}"/> where each object contains a collection of objects and a key.</returns>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.GroupBy(keySelector, new GenericEqualityComparer<TKey>(comparer, hashCodeProvider));

        /// <summary>
        /// Groups the elements of a sequence according to a key selector function. The keys
        /// are compared by using a specified function and each group's elements are
        /// projected by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/>.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/>.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="IGrouping{TKey, TElement}"/> where each object contains a collection of objects of type TElement and a key.</returns>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TKey, bool> comparer)
            => source.GroupBy(keySelector, elementSelector, new GenericEqualityComparer<TKey>(comparer));

        /// <summary>
        /// Groups the elements of a sequence according to a key selector function. The keys
        /// are compared by using specified functions and each group's elements are
        /// projected by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/>.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/>.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="IGrouping{TKey, TElement}"/> where each object contains a collection of objects of type TElement and a key.</returns>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.GroupBy(keySelector, elementSelector, new GenericEqualityComparer<TKey>(comparer, hashCodeProvider));

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. The keys are compared
        /// by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by resultSelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> where each element represents a projection over a group and its key.</returns>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TKey, TKey, bool> comparer)
            => source.GroupBy(keySelector, resultSelector, new GenericEqualityComparer<TKey>(comparer));

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. The keys are compared
        /// by using specified functions.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by resultSelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> where each element represents a projection over a group and its key.</returns>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.GroupBy(keySelector, resultSelector, new GenericEqualityComparer<TKey>(comparer, hashCodeProvider));

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. Key values are compared
        /// by using a specified function, and the elements of each group are projected
        /// by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by resultSelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/>.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> where each element represents a projection over a group and its key.</returns>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, Func<TKey, TKey, bool> comparer)
            => source.GroupBy(keySelector, elementSelector, resultSelector, new GenericEqualityComparer<TKey>(comparer));

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. Key values are compared
        /// by using specified functions, and the elements of each group are projected
        /// by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by resultSelector.</typeparam>
        /// <param name="source">The sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/>.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> where each element represents a projection over a group and its key.</returns>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.GroupBy(keySelector, elementSelector, resultSelector, new GenericEqualityComparer<TKey>(comparer, hashCodeProvider));

        #endregion
    }
}
