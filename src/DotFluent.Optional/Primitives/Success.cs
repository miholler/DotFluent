namespace DotFluent.Optional.Primitives;

/// <summary>
/// Represents a success value.
/// </summary>
public readonly record struct Success;

/// <summary>
/// Represents a success value.
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Success{T}"/> generic type.</typeparam>
/// <param name="Value">The input value.</param>
public readonly record struct Success<T>(T Value)
{
    /// <summary>
    /// Implicitly converts a value into a success.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Success<T>(T value)
        => new(value);

    /// <summary>
    /// Implicitly converts a success into a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="success">The success to convert.</param>
    public static implicit operator T(Success<T> success)
        => success.Value;
}
