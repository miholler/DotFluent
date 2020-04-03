using DotFluent.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    public static partial class Sequence
    {
        #region Methods

        /// <summary>
        /// Creates a lookup from a sequence according to a specified 
        /// key selector function and a key compare function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence to create the lookup from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="ILookup{TKey, TSource}"/> that contains keys and values.</returns>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer)
            => source.ToLookup(keySelector, GenericEqualityComparer<TKey>.Create(comparer));

        /// <summary>
        /// Creates a lookup from a sequence according to a specified
        /// key selector function and key compare functions.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence to create the lookup from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="ILookup{TKey, TSource}"/> that contains keys and values.</returns>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.ToLookup(keySelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

        /// <summary>
        /// Creates a lookup from a sequence according to a specified 
        /// key selector function, an element selector function and a 
        /// key compare function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
        /// <param name="source">The sequence to create the lookup from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <returns>An <see cref="ILookup{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TKey, bool> comparer)
            => source.ToLookup(keySelector, elementSelector, GenericEqualityComparer<TKey>.Create(comparer));

        /// <summary>
        /// Creates a lookup from a sequence according to a specified 
        /// key selector function, an element selector function and 
        /// key compare functions.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
        /// <param name="source">The sequence to create the lookup from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="comparer">A function to compare keys.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for a key.</param>
        /// <returns>An <see cref="ILookup{TKey, TElement}"/> that contains values of type TElement selected from the input sequence.</returns>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TKey, bool> comparer, Func<TKey, int> hashCodeProvider)
            => source.ToLookup(keySelector, elementSelector, GenericEqualityComparer<TKey>.Create(comparer, hashCodeProvider));

        #endregion
    }
}
