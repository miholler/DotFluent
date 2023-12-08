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
        
        if (optionType.IsGenericType && !optionType.IsGenericTypeDefinition)
        {
            var genericType = optionType.GetGenericTypeDefinition();
            if (typeof(Option<>).IsAssignableFrom(genericType))
                return optionType.GetGenericArguments().FirstOrDefault();
        }
        return null;
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

        if (resultType.IsGenericType && !resultType.IsGenericTypeDefinition)
        {
            var genericType = resultType.GetGenericTypeDefinition();
            if (typeof(Result<>).IsAssignableFrom(genericType))
                return resultType.GetGenericArguments().FirstOrDefault();
        }
        return null;
    }

    #endregion
}
