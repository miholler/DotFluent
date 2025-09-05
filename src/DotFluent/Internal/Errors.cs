using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal static class Errors
{
    #region Fields

    public const string ArgumentEmptyOrWhiteSpaceString = "The value cannot be an empty string or composed entirely of whitespace.";
    public const string ArgumentEmptyString = "The value cannot be an empty string.";
    public const string OptionNoValue = "Option has no value.";
    public const string SequenceMoreThanOneElement = "Sequence contains more than one element.";
    public const string SequenceMoreThanOneMatch = "Sequence contains more than one matching element.";

    #endregion
}
