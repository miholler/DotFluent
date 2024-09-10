namespace DotFluent.Optional;

public static partial class Option
{
    #region Methods

    /// <summary>
    /// Returns the underlying type argument of the specified option type.
    /// </summary>
    /// <param name="optionType">The type that describes a closed generic option type.</param>
    /// <returns>
    /// The type argument of the optionType parameter, if the optionType parameter
    /// is a closed generic option type; otherwise, null.
    /// </returns>
    public static Type? GetUnderlyingType(Type optionType)
    {
        optionType.ThrowIfNull();

        return optionType.IsGenericType
            && !optionType.IsGenericTypeDefinition
            && typeof(Option<>).IsAssignableFrom(optionType.GetGenericTypeDefinition())
             ? optionType
                .GetGenericArguments()
                .FirstOrDefault()
             : null;
    }

    #endregion
}

public static partial class Result
{
    #region Methods

    /// <summary>
    /// Returns the underlying type argument of the specified result type.
    /// </summary>
    /// <param name="resultType">The type that describes a closed generic result type.</param>
    /// <returns>
    /// The type argument of the resultType parameter, if the resultType parameter
    /// is a closed generic result type; otherwise, null.
    /// </returns>
    public static Type? GetUnderlyingType(Type resultType)
    {
        resultType.ThrowIfNull();

        return resultType.IsGenericType
            && !resultType.IsGenericTypeDefinition
            && typeof(Result<>).IsAssignableFrom(resultType.GetGenericTypeDefinition())
             ? resultType
                .GetGenericArguments()
                .FirstOrDefault()
             : null;
    }

    #endregion
}
