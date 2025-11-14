namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Determines whether two sequences are equal by comparing their elements 
    /// by using a specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">The sequence to compare to the second sequence.</param>
    /// <param name="second">The sequence to compare to the first sequence.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>true if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, false.</returns>
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
        => first.SequenceEqual(second, EqualityComparer<TSource>.Create(comparison));
}
