using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Optional.Internal;

[ExcludeFromCodeCoverage]
internal static class Errors
{
    public const string ArgumentMustBeOfType = "Argument must be of type {0}.";
    public const string FunctionMustNotReturnNull = "{0} must not return null.";
}
