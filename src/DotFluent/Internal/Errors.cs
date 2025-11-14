using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal static class Errors
{
    public const string ArgumentEmptyOrWhiteSpaceString = "The value cannot be an empty string or composed entirely of whitespace.";
    public const string ArgumentEmptyString = "The value cannot be an empty string.";
    public const string ArgumentOutOfRangeMustBeLessOrEqual = "{0} ('{1}') must be less than or equal to '{2}'.";
    public const string ArgumentOutOfRangeMustBeNonNegative = "{0} ('{1}') must be a non-negative value.";
    public const string FunctionMustNotReturnNull = "{0} must not return null.";
    public const string OptionNoValue = "Option has no value.";
    public const string SequenceMoreThanOneElement = "Sequence contains more than one element.";
    public const string SequenceMoreThanOneMatch = "Sequence contains more than one matching element.";
    public const string SequenceNoElements = "Sequence contains no elements.";
}
