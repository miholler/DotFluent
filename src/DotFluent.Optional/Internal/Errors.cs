using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Optional.Internal;

[ExcludeFromCodeCoverage]
internal static class Errors
{
    public const string FunctionMustNotReturnNull = "{0} must not return null.";
    public const string OptionNoValue = "Option has no value.";
}
