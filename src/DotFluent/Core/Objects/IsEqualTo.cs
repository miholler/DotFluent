namespace DotFluent;

/// <summary>
/// Provides extension methods for all objects.
/// </summary>
public static partial class ObjectExtensions
{
    #region Methods

    /// <summary>
    /// Determines whether two object instances are considered equal.
    /// </summary>
    /// <param name="source">The first object to compare.</param>
    /// <param name="value">The second object to compare.</param>
    /// <param name="reference">Specifies whether to check for reference equality.</param>
    /// <returns>true if the objects are considered equal or if both are null; otherwise, false.</returns>
    public static bool IsEqualTo(this object? source, object? value, bool reference = false)
        => reference
            ? ReferenceEquals(source, value)
            : Equals(source, value);

    #endregion
}
