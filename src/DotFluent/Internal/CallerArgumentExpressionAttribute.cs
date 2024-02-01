using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

#if NETSTANDARD

/// <summary>
/// Allows capturing of the expressions passed to a method.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
internal sealed class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    #region Properties

    /// <summary>
    /// Gets the target parameter name of the CallerArgumentExpression.
    /// </summary>
    public string ParameterName { get; } = parameterName;

    #endregion
}

#endif