namespace DotFluent.Linq;

public static partial class Sequence
{
    #region Methods

    /// <summary>
    /// Computes the sum of a sequence of int values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="int"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int SumOrDefault(this IEnumerable<int> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of int values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static int SumOrDefault(this IEnumerable<int> source, int defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of int values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of int values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int SumOrDefault(this IEnumerable<int> source, Func<int> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(int?), (sum, value) => sum.Match(x => checked(x + value), value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable int values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="int"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault(this IEnumerable<int?> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable int values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault(this IEnumerable<int?> source, int? defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable int values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable int values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault(this IEnumerable<int?> source, Func<int?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<int>()
            .Aggregate(default(int?), (sum, value) => sum.Match(x => checked(x + value), value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of long values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="long"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long SumOrDefault(this IEnumerable<long> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of long values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static long SumOrDefault(this IEnumerable<long> source, long defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of long values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of long values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long SumOrDefault(this IEnumerable<long> source, Func<long> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(long?), (sum, value) => sum.Match(x => checked(x + value), value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable long values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="long"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault(this IEnumerable<long?> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable long values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault(this IEnumerable<long?> source, long? defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable long values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable long values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault(this IEnumerable<long?> source, Func<long?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<long>()
            .Aggregate(default(long?), (sum, value) => sum.Match(x => checked(x + value), value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of float values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float SumOrDefault(this IEnumerable<float> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of float values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static float SumOrDefault(this IEnumerable<float> source, float defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of float values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of float values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float SumOrDefault(this IEnumerable<float> source, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(float?), (sum, value) => sum.Match(x => checked(x + value), value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable float values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault(this IEnumerable<float?> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable float values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault(this IEnumerable<float?> source, float? defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable float values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable float values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault(this IEnumerable<float?> source, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<float>()
            .Aggregate(default(float?), (sum, value) => sum.Match(x => checked(x + value), value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of double values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double SumOrDefault(this IEnumerable<double> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of double values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static double SumOrDefault(this IEnumerable<double> source, double defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of double values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of double values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double SumOrDefault(this IEnumerable<double> source, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(double?), (sum, value) => sum.Match(x => checked(x + value), value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable double values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault(this IEnumerable<double?> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable double values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault(this IEnumerable<double?> source, double? defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable double values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable double values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault(this IEnumerable<double?> source, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<double>()
            .Aggregate(default(double?), (sum, value) => sum.Match(x => checked(x + value), value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of decimal values,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal SumOrDefault(this IEnumerable<decimal> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of decimal values, or returns
    /// a specified default value if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static decimal SumOrDefault(this IEnumerable<decimal> source, decimal defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of decimal values, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The sequence of decimal values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal SumOrDefault(this IEnumerable<decimal> source, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Aggregate(default(decimal?), (sum, value) => sum.Match(x => checked(x + value), value))
            .GetValueOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values,
    /// or returns a default value if the sequence contains no elements 
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the sum of.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault(this IEnumerable<decimal?> source)
        => source.SumOrDefault(() => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values, or returns
    /// a specified default value if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the sum of.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault(this IEnumerable<decimal?> source, decimal? defaultValue)
        => source.SumOrDefault(() => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <param name="source">The sequence of nullable decimal values to calculate the sum of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault(this IEnumerable<decimal?> source, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .OfType<decimal>()
            .Aggregate(default(decimal?), (sum, value) => sum.Match(x => checked(x + value), value))
            .OrElse(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="int"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static int SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, Func<int> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="int"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, int? defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable int values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static int? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, Func<int?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="long"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static long SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, Func<long> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="long"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, long? defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable long values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static long? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, Func<long?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static float SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="float"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float? defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable float values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static float? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, Func<float?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static double SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="double"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double? defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable double values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static double? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, Func<double?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/> if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence,
    /// or returns a specified default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty.</param>
    /// <returns>The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.</returns>
    public static decimal SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// The default value of <see cref="decimal"/>? if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        => source.SumOrDefault(selector, () => default);

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a specified default value if the sequence contains no elements or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultValue">The value to return if the source sequence is empty or contains only values that are null.</param>
    /// <returns>
    /// The specified default value if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal? defaultValue)
        => source.SumOrDefault(selector, () => defaultValue);

    /// <summary>
    /// Computes the sum of a sequence of nullable decimal values that are obtained by
    /// invoking a transform function on each element of the input sequence, or returns
    /// a default value created by a specified function if the sequence contains no elements
    /// or only values that are null.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence of values to calculate the sum of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <returns>
    /// The default value created by the specified function if the source sequence is empty or contains only values that are null;
    /// otherwise, the sum of the sequence of values.
    /// </returns>
    public static decimal? SumOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, Func<decimal?> defaultFactory)
    {
        source.ThrowIfNull();
        selector.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source
            .Select(selector)
            .SumOrDefault(defaultFactory);
    }

    #endregion
}
