namespace DotFluent;

/// <summary>
/// Represents the method that compares two objects of the same type
/// for equality.
/// </summary>
/// <typeparam name="T">The type of the objects to compare.</typeparam>
/// <param name="x">The first object to compare.</param>
/// <param name="y">The second object to compare.</param>
/// <returns>true if the specified objects are considered equal; otherwise, false.</returns>
public delegate bool EqualityComparison<in T>(T? x, T? y);