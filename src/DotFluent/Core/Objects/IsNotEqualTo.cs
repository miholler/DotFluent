namespace DotFluent;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Determines whether two objects are not considered equal.
    /// </summary>
    /// <param name="source">The first object to compare.</param>
    /// <param name="value">The second object to compare.</param>
    /// <param name="reference">Specifies whether to check for reference equality.</param>
    /// <returns>true if the objects are not null and not considered equal; otherwise, false.</returns>
    public static bool IsNotEqualTo(this object? source, object? value, bool reference = false)
        => reference
            ? !ReferenceEquals(source, value)
            : !Equals(source, value);
}
