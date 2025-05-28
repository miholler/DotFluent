using static System.Convert;

namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Computes the average of a sequence of int values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<int> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of int values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault(this IEnumerable<int> source, double defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of int values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<int> source, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable int values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<int?> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of nullable int values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<int?> source, double? defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable int values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<int?> source, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .OfType<int>()
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of long values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<long> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of long values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault(this IEnumerable<long> source, double defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of long values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<long> source, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable long values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<long?> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of nullable long values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<long?> source, double? defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable long values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<long?> source, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .OfType<long>()
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of float values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float AverageOrDefault(this IEnumerable<float> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of float values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static float AverageOrDefault(this IEnumerable<float> source, float defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of float values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float AverageOrDefault(this IEnumerable<float> source, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => ToSingle(sum / count), defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable float values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault(this IEnumerable<float?> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of nullable float values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault(this IEnumerable<float?> source, float? defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable float values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault(this IEnumerable<float?> source, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .OfType<float>()
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => ToSingle(sum / count), defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of double values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<double> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of double values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault(this IEnumerable<double> source, double defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of double values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault(this IEnumerable<double> source, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable double values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<double?> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of nullable double values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<double?> source, double? defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable double values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault(this IEnumerable<double?> source, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .OfType<double>()
            .Aggregate(default(double?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of decimal values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal AverageOrDefault(this IEnumerable<decimal> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of decimal values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static decimal AverageOrDefault(this IEnumerable<decimal> source, decimal defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of decimal values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal AverageOrDefault(this IEnumerable<decimal> source, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .Aggregate(default(decimal?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the average of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault(this IEnumerable<decimal?> source)
        => source.AverageOrDefault(() => default);

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the average of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault(this IEnumerable<decimal?> source, decimal? defaultValue)
        => source.AverageOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the average of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault(this IEnumerable<decimal?> source, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        var count = 0L;
        return source
            .OfType<decimal>()
            .Aggregate(default(decimal?), (sum, value) =>
            {
                count++;
                return sum.Match(x => checked(x + value), value);
            })
            .Match(sum => sum / count, defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, double defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, double? defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, double defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, double? defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static float AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float? defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static float? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double? defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.</returns>
    public static decimal AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        => source.AverageOrDefault(selector, () => default);

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal? defaultValue)
        => source.AverageOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the average of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the average of the sequence of values.
    /// </returns>
    public static decimal? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .AverageOrDefault(defaultFactory);
    }

    #endregion
}
