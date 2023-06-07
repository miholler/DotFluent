namespace System.Diagnostics.CodeAnalysis;

#if NETSTANDARD

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter may be null
/// even if the corresponding type disallows it.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class MaybeNullWhenAttribute : Attribute
{
    //Ctor
    public MaybeNullWhenAttribute(bool returnValue)
    {
        ReturnValue = returnValue;
    }

    #region Properties

    /// <summary>
    /// Gets the return value condition.
    /// </summary>
    public bool ReturnValue { get; }

    #endregion
}

/// <summary>
/// Specifies that an output will not be null even if the corresponding type allows it. 
/// Specifies that an input argument was not null when the call returns.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class NotNullAttribute : Attribute
{ }

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will not be null 
/// even if the corresponding type allows it.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class NotNullWhenAttribute : Attribute
{
    //Ctor
    public NotNullWhenAttribute(bool returnValue)
    {
        ReturnValue = returnValue;
    }

    #region Properties

    /// <summary>
    /// Gets the return value condition.
    /// </summary>
    public bool ReturnValue { get; }

    #endregion
}

#endif