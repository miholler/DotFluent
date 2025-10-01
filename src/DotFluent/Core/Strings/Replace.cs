using System.Text;

namespace DotFluent;

public static partial class StringExtensions
{
    /// <summary>
    /// Returns a new string in which all occurrences of each specified character
    /// in a string are replaced with another specified character.
    /// </summary>
    /// <param name="source">The string in which characters are to be replaced.</param>
    /// <param name="oldChars">The characters to be replaced.</param>
    /// <param name="newChar">The character to replace all occurrences of each character in oldChars.</param>
    /// <returns>
    /// A <see cref="string"/> that is equivalent to the source string except that all instances 
    /// of each character in oldChars are replaced with newChar.
    /// </returns>
    public static string Replace(this string source, char[] oldChars, char newChar)
    {
        source.ThrowIfNull();
        oldChars.ThrowIfNull();

        var builder = new StringBuilder(source);
        foreach (var oldChar in oldChars)
            builder.Replace(oldChar, newChar);

        return builder.ToString();
    }

    /// <summary>
    /// Returns a new string in which all occurrences of each specified string
    /// in a string are replaced with another specified string.
    /// </summary>
    /// <param name="source">The string in which strings are to be replaced.</param>
    /// <param name="oldValues">The strings to be replaced.</param>
    /// <param name="newValue">The string to replace all occurrences of each string in oldValues.</param>
    /// <returns>
    /// A <see cref="string"/> that is equivalent to the source string except that all instances 
    /// of each string in oldValues are replaced with newValue.
    /// </returns>
    public static string Replace(this string source, string[] oldValues, string newValue)
    {
        source.ThrowIfNull();
        oldValues.ThrowIfNull();

        var builder = new StringBuilder(source);
        foreach (var oldValue in oldValues)
            builder.Replace(oldValue, newValue);

        return builder.ToString();
    }
}
