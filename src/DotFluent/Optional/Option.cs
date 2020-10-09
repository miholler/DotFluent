using System;
using System.Collections;
using System.Collections.Generic;

namespace DotFluent.Optional
{
    /// <summary>
    /// Represents an optional value.
    /// </summary>
    /// <typeparam name="T">The underlying type of the <see cref="Option{T}"/> generic type.</typeparam>
    public struct Option<T> : IEnumerable<T>, IEquatable<Option<T>>, IComparable<Option<T>>, IComparable
    {
        #region Fields

        private readonly T _value;
        
        #endregion

        //Ctor
        private Option(T value)
        {
            _value = value;
            IsSome = true;
        }

        #region Properties

        /// <summary>
        /// Gets an option value that is a 'None' value.
        /// </summary>
        /// <returns>An <see cref="Option{T}"/> representing the absense of a value of type <typeparamref name="T"/>.</returns>
        public static Option<T> None => default;

        /// <summary>
        /// Get the value of the current option if it is a 'Some' option.
        /// An <see cref="InvalidOperationException"/> is thrown if the option is 'None'.
        /// </summary>
        /// <returns>The value of the option if it is a 'Some' option.</returns>
        public T Value => IsSome ? _value : throw new InvalidOperationException("Option has no value.");

        /// <summary>
        /// Gets whether the current option is a 'Some' value.
        /// </summary>
        /// <returns>true if the option is a 'Some' value; otherwise, false.</returns>
        public bool IsSome { get; private set; }

        /// <summary>
        /// Gets whether the current option is a 'None' value. 
        /// </summary>
        /// <returns>true if the option is a 'None' value; otherwise, false.</returns>
        public bool IsNone => !IsSome;

        #endregion

        #region Methods

        /// <summary>
        /// Creates an option value that is a 'Some' value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
        public static Option<T> Some(T value)
            => new Option<T>(value);

        /// <summary>
        /// Returns an enumerator for the current option.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> for the option.</returns>
        public IEnumerator<T> GetEnumerator()
            => AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// Converts the current option to a sequence with one or zero elements.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing one or zero elements.</returns>
        public IEnumerable<T> AsEnumerable()
        {
            if (IsSome)
                yield return _value;
        }

        /// <summary>
        /// Compares the specified option with the current option.
        /// </summary>
        /// <param name="other">The option to compare with the current option.</param>
        /// <returns>An integer indicating the order of the current option relative to the specified option.</returns>
        public int CompareTo(Option<T> other)
            => IsNone && other.IsNone ? 0 : IsSome && other.IsNone ? 1 : IsNone && other.IsSome ? -1 : Comparer<T>.Default.Compare(_value, other._value);

        /// <summary>
        /// Compares the specified object with the current option.
        /// </summary>
        /// <param name="obj">The object to compare with the current option.</param>
        /// <returns>An integer indicating the order of the current option relative to the specified object.</returns>
        public int CompareTo(object obj)
            => obj is Option<T> option ? CompareTo(option) : 1;

        /// <summary>
        /// Determines whether the specified option is equal to the current option.
        /// </summary>
        /// <param name="other">The option to compare with the current option.</param>
        /// <returns>true if the specified option is equal to the current option; otherwise, false.</returns>
        public bool Equals(Option<T> other)
            => (IsNone && other.IsNone) || (IsSome && other.IsSome && EqualityComparer<T>.Default.Equals(_value, other._value));

        /// <summary>
        /// Determines whether the specified object is equal to the current option.
        /// </summary>
        /// <param name="obj">The object to compare with the current option.</param>
        /// <returns>true if the specified object is equal to the current option; otherwise, false.</returns>
        public override bool Equals(object obj)
            => obj is Option<T> option && Equals(option);

        /// <summary>
        /// Returns a hash code for the current option.
        /// </summary>
        /// <returns>A hash code for the current option.</returns>
        public override int GetHashCode()
            => IsSome ? _value?.GetHashCode() ?? 1 : 0;

        /// <summary>
        /// Returns a string that represents the current option.
        /// </summary>
        /// <returns>A string that represents the current option.</returns>
        public override string ToString()
            => IsSome ? $"Some({_value?.ToString() ?? "null"})" : "None";

        #endregion

        #region Operators

        /// <summary>
        /// Implicitly converts a value into an option that is a 'Some' value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
        public static implicit operator Option<T>(T value)
            => new Option<T>(value);

        /// <summary>
        /// Determines whether a specified option is less than another specified option.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the left option is less than the right option; otherwise false.</returns>
        public static bool operator <(Option<T> left, Option<T> right)
            => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether a specified option is less than or equal to another specified option.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the left option is less than or equal to the right option; otherwise false.</returns>
        public static bool operator <=(Option<T> left, Option<T> right)
            => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines whether a specified option is greater than another specified option.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the left option is greater than the right option; otherwise false.</returns>
        public static bool operator >(Option<T> left, Option<T> right)
            => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether a specified option is greater than or equal to another specified option.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the left option is greater than or equal to the right option; otherwise false.</returns>
        public static bool operator >=(Option<T> left, Option<T> right)
            => left.CompareTo(right) >= 0;

        /// <summary>
        /// Determines whether two specified options are equal.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the specified options are equal; otherwise false.</returns>
        public static bool operator ==(Option<T> left, Option<T> right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two specified options are not equal.
        /// </summary>
        /// <param name="left">The first option to compare.</param>
        /// <param name="right">The second option to compare.</param>
        /// <returns>true if the specified options are not equal; otherwise false.</returns>
        public static bool operator !=(Option<T> left, Option<T> right)
            => !left.Equals(right);

        #endregion
    }
}
