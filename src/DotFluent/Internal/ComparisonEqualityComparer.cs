using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Internal;

[ExcludeFromCodeCoverage]
internal sealed class ComparisonEqualityComparer<T> : EqualityComparer<T>
{
    #region Fields

    private readonly EqualityComparison<T> _comparison;
    private readonly Func<T, int> _hashCodeSelector;

    #endregion

    //Ctor
    private ComparisonEqualityComparer(EqualityComparison<T> comparison, Func<T, int> hashCodeSelector)
    {
        _comparison = comparison.ThrowIfNull();
        _hashCodeSelector = hashCodeSelector.ThrowIfNull();
    }

    #region Methods

    public static ComparisonEqualityComparer<T> Create(EqualityComparison<T> comparison)
        => new(comparison, _ => 0);

    public static ComparisonEqualityComparer<T> Create(EqualityComparison<T> comparison, Func<T, int> hashCodeSelector)
        => new(comparison, hashCodeSelector);

    public override bool Equals(T? x, T? y)
        => _comparison(x!, y!);

    public override int GetHashCode([DisallowNull]T obj)
        => _hashCodeSelector(obj);

    #endregion
}
