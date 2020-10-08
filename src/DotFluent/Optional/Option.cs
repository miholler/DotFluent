using System;

namespace DotFluent.Optional
{
    /// <summary>
    /// Represents an optional value.
    /// </summary>
    /// <typeparam name="T">The underlying type of the <see cref="Option{T}"/> generic type.</typeparam>
    public struct Option<T>
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

        #endregion

        #region Operators

        /// <summary>
        /// Implicitly converts a value into an option that is a 'Some' value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
        public static implicit operator Option<T>(T value)
            => new Option<T>(value);

        #endregion
    }
}
