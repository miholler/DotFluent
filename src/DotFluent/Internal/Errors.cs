using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal static class Errors
{
    #region Fields

    public const string ArgumentEmptyOrWhiteSpaceString = "The value cannot be an empty string or composed entirely of whitespace.";
    public const string ArgumentEmptyString = "The value cannot be an empty string.";
    public const string MoreThanOneElement = "Sequence contains more than one element.";
    public const string MoreThanOneMatch = "Sequence contains more than one matching element.";
    public const string NoElements = "Sequence contains no elements.";
    public const string NoValue = "Option has no value.";

    #endregion
}
