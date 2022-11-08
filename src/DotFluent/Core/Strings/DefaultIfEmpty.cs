namespace DotFluent;

/// <summary>
/// Provides extension methods for <see cref="string"/> objects.
/// </summary>
public static partial class StringExtensions
{
    #region Methods

    /// <summary>
    /// Returns a specified default value if a string is null, empty, or consists only of 
    /// white-space characters; otherwise, returns the string.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <param name="defaultValue">The value to return if the string is null, empty or consists exclusively of white-space characters.</param>
    /// <returns>
    /// The specified default value if the string is null, empty, or consists exclusively of white-space characters;
    /// otherwise, the string.
    /// </returns>
    public static string DefaultIfEmpty(this string? source, string defaultValue)
        => source.DefaultIfEmpty(() => defaultValue);

    /// <summary>
    /// Returns a default value created by a specified function if a string is null, empty, or consists only of
    /// white-space characters; otherwise, returns the string.
    /// </summary>
    /// <param name="source">The string to test.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the string is null, empty, or consists exclusively of 
    /// white-space characters; otherwise, the string.
    /// </returns>
    public static string DefaultIfEmpty(this string? source, Func<string> defaultFactory)
    {
        defaultFactory.ThrowIfNull();

        return source.IsNullOrWhiteSpace()
            ? defaultFactory()
            : source;
    }

    #endregion
}
