using System;
using System.Collections.Generic;

namespace DotFluent.Internal
{
    /// <summary>
    /// Represents a generic object equality comparer.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    public sealed class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        #region Fields

        private readonly Func<T, T, bool> _comparer;
        private readonly Func<T, int> _hashCodeProvider;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericEqualityComparer{T}"/> class 
        /// using a specified compare function to compare objects for equality.
        /// </summary>
        /// <param name="comparer">A function to compare objects.</param>
        public GenericEqualityComparer(Func<T, T, bool> comparer) : this(comparer, x => 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericEqualityComparer{T}"/> class
        /// using specified compare functions to compare objects for equality.
        /// </summary>
        /// <param name="comparer">A function to compare objects.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for an object.</param>
        public GenericEqualityComparer(Func<T, T, bool> comparer, Func<T, int> hashCodeProvider)
        {
            _comparer = comparer.ThrowIfNull(nameof(comparer));
            _hashCodeProvider = hashCodeProvider.ThrowIfNull(nameof(hashCodeProvider));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an equality comparer by using a specified compare function
        /// to compare objects for equality.
        /// </summary>
        /// <param name="comparer">A function to compare objects.</param>
        /// <returns>A new <see cref="GenericEqualityComparer{T}"/>.</returns>
        public static GenericEqualityComparer<T> Create(Func<T, T, bool> comparer)
            => new GenericEqualityComparer<T>(comparer);

        /// <summary>
        /// Creates an equality comparer by using specified compare functions
        /// to compare objects for equality.
        /// </summary>
        /// <param name="comparer">A function to compare objects.</param>
        /// <param name="hashCodeProvider">A function to resolve a hash code for an object.</param>
        /// <returns>A new <see cref="GenericEqualityComparer{T}"/>.</returns>
        public static GenericEqualityComparer<T> Create(Func<T, T, bool> comparer, Func<T, int> hashCodeProvider)
            => new GenericEqualityComparer<T>(comparer, hashCodeProvider);

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(T x, T y)
            => _comparer(x, y);

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The object of type T for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(T obj)
            => _hashCodeProvider(obj);

        #endregion
    }
}
