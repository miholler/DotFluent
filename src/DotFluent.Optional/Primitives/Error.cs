namespace DotFluent.Optional.Primitives;

/// <summary>
/// Represents an error value.
/// </summary>
public readonly record struct Error;

/// <summary>
/// Represents an error value.
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Error{T}"/> generic type.</typeparam>
/// <param name="Value">The input value.</param>
public readonly record struct Error<T>(T Value)
{
    /// <summary>
    /// Implicitly converts a value into an error.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Error<T>(T value)
        => new(value);

    /// <summary>
    /// Implicitly converts an error into a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator T(Error<T> error)
        => error.Value;
}
