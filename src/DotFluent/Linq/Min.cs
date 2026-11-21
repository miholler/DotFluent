using DotFluent.Internal;

namespace DotFluent.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns the minimum value in a generic sequence
    /// by using a specified function to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="comparison">A function to compare values.</param>
    /// <returns>The minimum value in the sequence.</returns>
    public static TSource? Min<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        => source.Min(Comparer<TSource>.Create(comparison));

#if NETSTANDARD

    /// <summary>
    /// Returns the minimum value in a generic sequence
    /// by using a specified comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the minimum value of.</param>
    /// <param name="comparer">The comparer to compare values.</param>
    /// <returns>The minimum value in the sequence.</returns>
    public static TSource? Min<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
    {
        source.ThrowIfNull();
        comparer ??= Comparer<TSource>.Default;

        using var enumerator = source.GetEnumerator();
        var min = default(TSource?);
        if (min.IsNull())
        {
            do
            {
                if (!enumerator.MoveNext())
                    return min;

                min = enumerator.Current;
            }
            while (min.IsNull());

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.IsNotNull() && comparer.Compare(current, min) < 0)
                    min = current;
            }
        }
        else
        {
            min = enumerator.MoveNext()
                ? enumerator.Current
                : throw new InvalidOperationException(Errors.SequenceNoElements);

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (comparer.Compare(current, min) < 0)
                    min = current;
            }
        }
        return min;
    }

#endif
}
