namespace DotFluent.Linq;

/// <summary>
/// Provides extension members for querying objects
/// that implement <see cref="IEnumerable{T}"/>.
/// </summary>
public static partial class EnumerableExtensions
{
    private static bool IsEmptyArray<TSource>(this IEnumerable<TSource> source)
        => source is TSource[] { Length: 0 };
}
