using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal static class EqualityComparer
{
    #region Methods

    public static EqualityComparer<T> Create<T>(EqualityComparison<T> comparison, HashFunc<T>? hashFunc = null)
    {
        comparison.ThrowIfNull();
        hashFunc ??= _ => 0;

        return new ComparisonEqualityComparer<T>(comparison, hashFunc);
    }

    #endregion
}

[ExcludeFromCodeCoverage]
file sealed class ComparisonEqualityComparer<T>(EqualityComparison<T> comparison, HashFunc<T> hashFunc) : EqualityComparer<T>
{
    #region Fields

    private readonly EqualityComparison<T> _comparison = comparison;
    private readonly HashFunc<T> _hashFunc = hashFunc;

    #endregion

    #region Methods

    public override bool Equals(T? x, T? y)
        => _comparison(x!, y!);

    public override int GetHashCode(T obj)
        => _hashFunc(obj);

    #endregion
}
