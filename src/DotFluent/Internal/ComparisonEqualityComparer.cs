using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal sealed class ComparisonEqualityComparer<T>(EqualityComparison<T> comparison, Func<T, int> hashCodeSelector) : EqualityComparer<T>
{
    #region Fields

    private readonly EqualityComparison<T> _comparison = comparison.ThrowIfNull();
    private readonly Func<T, int> _hashCodeSelector = hashCodeSelector.ThrowIfNull();

    #endregion

    #region Methods

    public static ComparisonEqualityComparer<T> Create(EqualityComparison<T> comparison)
        => new(comparison, _ => 0);

    public static ComparisonEqualityComparer<T> Create(EqualityComparison<T> comparison, Func<T, int> hashCodeSelector)
        => new(comparison, hashCodeSelector);

    public override bool Equals(T? x, T? y)
        => _comparison(x!, y!);

    public override int GetHashCode(T obj)
        => _hashCodeSelector(obj);

    #endregion
}
