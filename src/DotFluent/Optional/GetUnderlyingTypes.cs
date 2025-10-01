namespace DotFluent.Optional;

public static partial class Result
{
    /// <summary>
    /// Returns the underlying type arguments of the specified result type.
    /// </summary>
    /// <param name="resultType">The type that describes a closed generic result type.</param>
    /// <returns>
    /// An array of <see cref="Type"/> objects that represent the type arguments of the resultType parameter,
    /// if the resultType parameter is a closed generic result type; otherwise, an empty array.
    /// </returns>
    public static Type[] GetUnderlyingTypes(Type resultType)
    {
        resultType.ThrowIfNull();

        return resultType.IsGenericType
            && !resultType.IsGenericTypeDefinition
            && typeof(Result<,>).IsAssignableFrom(resultType.GetGenericTypeDefinition())
             ? resultType.GetGenericArguments()
             : [];
    }
}
