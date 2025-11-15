namespace DotFluent.Linq;

/// <summary>
/// Provides a set of static methods for querying objects
/// that implement <see cref="IEnumerable{T}"/>.
/// </summary>
public static partial class Sequence
{
    private static bool IsEmptyArray<TSource>(this IEnumerable<TSource> source)
        => source is TSource[] { Length: 0 };
}
