namespace DotFluent.Optional;

public static partial class Option
{
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
            && optionType
                .GetGenericTypeDefinition()
                .IsEqualTo(typeof(Option<>), reference: true)
             ? optionType
                .GetGenericArguments()
                .FirstOrDefault()
             : null;
    }
}

public static partial class Result
{
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
            && resultType
                .GetGenericTypeDefinition()
                .IsEqualTo(typeof(Result<>), reference: true)
             ? resultType
                .GetGenericArguments()
                .FirstOrDefault()
             : null;
    }
}
