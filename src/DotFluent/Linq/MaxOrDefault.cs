namespace DotFluent.Linq;

public static partial class Sequence
{
    /// <summary>
    /// Returns the maximum value in a sequence of int values,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="int"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int MaxOrDefault(this IEnumerable<int> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of int values,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static int MaxOrDefault(this IEnumerable<int> source, int defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of int values,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int MaxOrDefault(this IEnumerable<int> source, Func<int> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(int?), (max, value) => max.Match(x => x > value ? x : value, value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of nullable int values,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="int"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault(this IEnumerable<int?> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable int values,
    /// or a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault(this IEnumerable<int?> source, int? defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable int values,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault(this IEnumerable<int?> source, Func<int?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<int>()
            .Aggregate(default(int?), (max, value) => max.Match(x => x > value ? x : value, value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of long values,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="long"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long MaxOrDefault(this IEnumerable<long> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of long values,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static long MaxOrDefault(this IEnumerable<long> source, long defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of long values,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long MaxOrDefault(this IEnumerable<long> source, Func<long> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(long?), (max, value) => max.Match(x => x > value ? x : value, value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of nullable long values,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="long"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault(this IEnumerable<long?> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable long values,
    /// or a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault(this IEnumerable<long?> source, long? defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable long values,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault(this IEnumerable<long?> source, Func<long?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<long>()
            .Aggregate(default(long?), (max, value) => max.Match(x => x > value ? x : value, value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of float values,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float MaxOrDefault(this IEnumerable<float> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of float values,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static float MaxOrDefault(this IEnumerable<float> source, float defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of float values,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float MaxOrDefault(this IEnumerable<float> source, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(float?), (max, value) => max.Match(x => x > value ? x : value, value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of nullable float values,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault(this IEnumerable<float?> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable float values,
    /// or a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault(this IEnumerable<float?> source, float? defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable float values,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault(this IEnumerable<float?> source, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<float>()
            .Aggregate(default(float?), (max, value) => max.Match(x => x > value ? x : value, value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of double values,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double MaxOrDefault(this IEnumerable<double> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of double values,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static double MaxOrDefault(this IEnumerable<double> source, double defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of double values,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double MaxOrDefault(this IEnumerable<double> source, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(double?), (max, value) => max.Match(x => x > value ? x : value, value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of nullable double values,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault(this IEnumerable<double?> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable double values,
    /// or a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault(this IEnumerable<double?> source, double? defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable double values,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault(this IEnumerable<double?> source, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<double>()
            .Aggregate(default(double?), (max, value) => max.Match(x => x > value ? x : value, value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of decimal values,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal MaxOrDefault(this IEnumerable<decimal> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of decimal values,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static decimal MaxOrDefault(this IEnumerable<decimal> source, decimal defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of decimal values,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal MaxOrDefault(this IEnumerable<decimal> source, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(decimal?), (max, value) => max.Match(x => x > value ? x : value, value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Returns the maximum value in a sequence of nullable decimal values,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to determine the maximum value of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault(this IEnumerable<decimal?> source)
        => source.MaxOrDefault(() => default);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable decimal values,
    /// or a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to determine the maximum value of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault(this IEnumerable<decimal?> source, decimal? defaultValue)
        => source.MaxOrDefault(() => defaultValue);

    /// <summary>
    /// Returns the maximum value in a sequence of nullable decimal values,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to determine the maximum value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault(this IEnumerable<decimal?> source, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<decimal>()
            .Aggregate(default(decimal?), (max, value) => max.Match(x => x > value ? x : value, value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum int value,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="int"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum int value,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static int MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum int value,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, Func<int> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="int"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
    /// or a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, int? defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static int? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, Func<int?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum long value,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="long"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum long value,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static long MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum long value,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, Func<long> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="long"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
    /// or a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, long? defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static long? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, Func<long?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum float value,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum float value,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static float MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum float value,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
    /// or a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float? defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static float? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum double value,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum double value,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static double MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum double value,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
    /// or a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double? defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static double? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum decimal value,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum decimal value,
    /// or a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.</returns>
    public static decimal MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum decimal value,
    /// or a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
    /// or a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        => source.MaxOrDefault(selector, () => default);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
    /// or a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal? defaultValue)
        => source.MaxOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
    /// or a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the maximum value in the sequence.
    /// </returns>
    public static decimal? MaxOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .MaxOrDefault(defaultFactory);
    }
}
