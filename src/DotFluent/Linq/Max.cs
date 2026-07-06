using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns the maximum value in a generic sequence
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>The maximum value in the sequence.</returns>
    public static TSource? Max<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.Max(Comparer<TSource>.Create(comparison));

#if NETSTANDARD

    /// <summary>
    /// Returns the maximum value in a generic sequence
    /// by using a specified comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="comparer">The comparer to compare values.</param>
    /// <returns>The maximum value in the sequence.</returns>
    public static TSource? Max<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
    {
        source.ThrowIfNull();
        comparer ??= Comparer<TSource>.Default;

        using var enumerator = source.GetEnumerator();
        var max = default(TSource?);
        if (max.IsNull())
        {
            do
            {
                if (!enumerator.MoveNext())
                    return max;

                max = enumerator.Current;
            }
            while (max.IsNull());

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.IsNotNull() && comparer.Compare(current, max) > 0)
                    max = current;
            }
        }
        else
        {
            max = enumerator.MoveNext()
                ? enumerator.Current
                : throw new InvalidOperationException(Errors.SequenceNoElements);

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (comparer.Compare(current, max) > 0)
                    max = current;
            }
        }
        return max;
    }

#endif
}
