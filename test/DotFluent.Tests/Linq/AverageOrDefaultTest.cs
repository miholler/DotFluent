using NUnit.Framework;
using Shouldly;
using System.Collections;
using static System.Convert;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableAverageOrDefaultTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> intSource = null;

        intSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<int?> nullableIntSource = null;

        nullableIntSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<long> longSource = null;

        longSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<long?> nullableLongSource = null;

        nullableLongSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<float> floatSource = null;

        floatSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(() => 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<float?> nullableFloatSource = null;

        nullableFloatSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(() => 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<double> doubleSource = null;

        doubleSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<double?> nullableDoubleSource = null;

        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<decimal> decimalSource = null;

        decimalSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(() => 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<decimal?> nullableDecimalSource = null;

        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(() => 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(y => y, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(y => y, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var intSource = Enumerable.Empty<int>();
        Func<int, int> intSelector = null;

        intSource
            .Invoking(x => x.AverageOrDefault(intSelector))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(intSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(intSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var nullableIntSource = Enumerable.Empty<int?>();
        Func<int?, int?> nullableIntSelector = null;

        nullableIntSource
            .Invoking(x => x.AverageOrDefault(nullableIntSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(nullableIntSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(nullableIntSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var longSource = Enumerable.Empty<long>();
        Func<long, long> longSelector = null;

        longSource
            .Invoking(x => x.AverageOrDefault(longSelector))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(longSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(longSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var nullableLongSource = Enumerable.Empty<long?>();
        Func<long?, long?> nullableLongSelector = null;

        nullableLongSource
            .Invoking(x => x.AverageOrDefault(nullableLongSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(nullableLongSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(nullableLongSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var floatSource = Enumerable.Empty<float>();
        Func<float, float> floatSelector = null;

        floatSource
            .Invoking(x => x.AverageOrDefault(floatSelector))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(floatSelector, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(floatSelector, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        var nullableFloatSource = Enumerable.Empty<float?>();
        Func<float?, float?> nullableFloatSelector = null;

        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(nullableFloatSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(nullableFloatSelector, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(nullableFloatSelector, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        var doubleSource = Enumerable.Empty<double>();
        Func<double, double> doubleSelector = null;

        doubleSource
            .Invoking(x => x.AverageOrDefault(doubleSelector))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(doubleSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(doubleSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var nullableDoubleSource = Enumerable.Empty<double?>();
        Func<double?, double?> nullableDoubleSelector = null;

        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var decimalSource = Enumerable.Empty<decimal>();
        Func<decimal, decimal> decimalSelector = null;

        decimalSource
            .Invoking(x => x.AverageOrDefault(decimalSelector))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(decimalSelector, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(decimalSelector, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();

        var nullableDecimalSource = Enumerable.Empty<decimal?>();
        Func<decimal?, decimal?> nullableDecimalSelector = null;

        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(nullableDecimalSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(nullableDecimalSelector, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(nullableDecimalSelector, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        Func<float> floatFactory = null;
        Func<float?> nullableFloatFactory = null;
        Func<double> doubleFactory = null;
        Func<double?> nullableDoubleFactory = null;
        Func<decimal> decimalFactory = null;
        Func<decimal?> nullableDecimalFactory = null;

        var intSource = Enumerable.Empty<int>();
        intSource
            .Invoking(x => x.AverageOrDefault(doubleFactory))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.AverageOrDefault(y => y, doubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableIntSource = Enumerable.Empty<int?>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.AverageOrDefault(y => y, nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var longSource = Enumerable.Empty<long>();
        longSource
            .Invoking(x => x.AverageOrDefault(doubleFactory))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.AverageOrDefault(y => y, doubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableLongSource = Enumerable.Empty<long?>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.AverageOrDefault(y => y, nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var floatSource = Enumerable.Empty<float>();
        floatSource
            .Invoking(x => x.AverageOrDefault(floatFactory))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.AverageOrDefault(y => y, floatFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableFloatSource = Enumerable.Empty<float?>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(nullableFloatFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.AverageOrDefault(y => y, nullableFloatFactory))
            .ShouldThrow<ArgumentNullException>();

        var doubleSource = Enumerable.Empty<double>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(doubleFactory))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.AverageOrDefault(y => y, doubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableDoubleSource = Enumerable.Empty<double?>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.AverageOrDefault(y => y, nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var decimalSource = Enumerable.Empty<decimal>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(decimalFactory))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.AverageOrDefault(y => y, decimalFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableDecimalSource = Enumerable.Empty<decimal?>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(nullableDecimalFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.AverageOrDefault(y => y, nullableDecimalFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0.0, 0)]
    [TestCase(new int[0], 0.0, 1)]
    [TestCase(new int[0], 0.0, 2)]
    [TestCase(new int[0], 0.0, 3)]
    [TestCase(new int[0], 0.0, 4)]
    [TestCase(new int[0], 0.0, 5)]
    [TestCase(new int[0], 0.0, 6)]
    [TestCase(new int[0], 0.0, 7)]
    [TestCase(new int[0], 0.0, 8)]
    [TestCase(new int[0], 0.0, 9)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 4)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 5)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 6)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 7)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 8)]
    [TestCase(new[] { 1, 2, 3 }, 2.0, 9)]
    public void AverageOrDefault(IEnumerable<int> source, double expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.AverageOrDefault(x => x),
            2 => source.Select(ToInt64).AverageOrDefault(),
            3 => source.Select(ToInt64).AverageOrDefault(x => x),
            4 => source.Select(ToSingle).AverageOrDefault(),
            5 => source.Select(ToSingle).AverageOrDefault(x => x),
            6 => source.Select(ToDouble).AverageOrDefault(),
            7 => source.Select(ToDouble).AverageOrDefault(x => x),
            8 => ToDouble(source.Select(ToDecimal).AverageOrDefault()),
            9 => ToDouble(source.Select(ToDecimal).AverageOrDefault(x => x)),
            _ => source.AverageOrDefault()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(new int[0], null, 0)]
    [TestCase(new int[0], null, 1)]
    [TestCase(new int[0], null, 2)]
    [TestCase(new int[0], null, 3)]
    [TestCase(new int[0], null, 4)]
    [TestCase(new int[0], null, 5)]
    [TestCase(new int[0], null, 6)]
    [TestCase(new int[0], null, 7)]
    [TestCase(new int[0], null, 8)]
    [TestCase(new int[0], null, 9)]
    [TestCase(new object[] { new object[] { null, null, null }, null, 0 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 1 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 2 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 3 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 4 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 5 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 6 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 7 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 8 })]
    [TestCase(new object[] { new object[] { null, null, null }, null, 9 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.5, 9 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, 2.0, 9 })]
    public void AverageOrDefaultNullable(IEnumerable source, double? expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.OfType<int?>().AverageOrDefault(x => x),
            2 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(),
            3 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(x => x),
            4 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(),
            5 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(x => x),
            6 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(),
            7 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(x => x),
            8 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(),
            9 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(x => x),
            _ => source.OfType<int?>().AverageOrDefault()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(new int[0], -1.0, -1.0, 0)]
    [TestCase(new int[0], -1.0, -1.0, 1)]
    [TestCase(new int[0], -1.0, -1.0, 2)]
    [TestCase(new int[0], -1.0, -1.0, 3)]
    [TestCase(new int[0], -1.0, -1.0, 4)]
    [TestCase(new int[0], -1.0, -1.0, 5)]
    [TestCase(new int[0], -1.0, -1.0, 6)]
    [TestCase(new int[0], -1.0, -1.0, 7)]
    [TestCase(new int[0], -1.0, -1.0, 8)]
    [TestCase(new int[0], -1.0, -1.0, 9)]
    [TestCase(new int[0], -1.0, -1.0, 10)]
    [TestCase(new int[0], -1.0, -1.0, 11)]
    [TestCase(new int[0], -1.0, -1.0, 12)]
    [TestCase(new int[0], -1.0, -1.0, 13)]
    [TestCase(new int[0], -1.0, -1.0, 14)]
    [TestCase(new int[0], -1.0, -1.0, 15)]
    [TestCase(new int[0], -1.0, -1.0, 16)]
    [TestCase(new int[0], -1.0, -1.0, 17)]
    [TestCase(new int[0], -1.0, -1.0, 18)]
    [TestCase(new int[0], -1.0, -1.0, 19)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 0)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 1)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 2)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 3)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 4)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 5)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 6)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 7)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 8)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 9)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 10)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 11)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 12)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 13)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 14)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 15)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 16)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 17)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 18)]
    [TestCase(new[] { 1, 2, 3 }, -1.0, 2.0, 19)]
    public void AverageOrDefaultWithDefaultValue(IEnumerable<int> source, double defaultValue, double expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.AverageOrDefault(() => defaultValue),
            2 => source.AverageOrDefault(x => x, defaultValue),
            3 => source.AverageOrDefault(x => x, () => defaultValue),
            4 => source.Select(ToInt64).AverageOrDefault(defaultValue),
            5 => source.Select(ToInt64).AverageOrDefault(() => defaultValue),
            6 => source.Select(ToInt64).AverageOrDefault(x => x, defaultValue),
            7 => source.Select(ToInt64).AverageOrDefault(x => x, () => defaultValue),
            8 => source.Select(ToSingle).AverageOrDefault(ToSingle(defaultValue)),
            9 => source.Select(ToSingle).AverageOrDefault(() => ToSingle(defaultValue)),
            10 => source.Select(ToSingle).AverageOrDefault(x => x, ToSingle(defaultValue)),
            11 => source.Select(ToSingle).AverageOrDefault(x => x, () => ToSingle(defaultValue)),
            12 => source.Select(ToDouble).AverageOrDefault(defaultValue),
            13 => source.Select(ToDouble).AverageOrDefault(() => defaultValue),
            14 => source.Select(ToDouble).AverageOrDefault(x => x, defaultValue),
            15 => source.Select(ToDouble).AverageOrDefault(x => x, () => defaultValue),
            16 => ToDouble(source.Select(ToDecimal).AverageOrDefault(ToDecimal(defaultValue))),
            17 => ToDouble(source.Select(ToDecimal).AverageOrDefault(() => ToDecimal(defaultValue))),
            18 => ToDouble(source.Select(ToDecimal).AverageOrDefault(x => x, ToDecimal(defaultValue))),
            19 => ToDouble(source.Select(ToDecimal).AverageOrDefault(x => x, () => ToDecimal(defaultValue))),
            _ => source.AverageOrDefault(defaultValue)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(new int[0], -1.0, -1.0, 0)]
    [TestCase(new int[0], -1.0, -1.0, 1)]
    [TestCase(new int[0], -1.0, -1.0, 2)]
    [TestCase(new int[0], -1.0, -1.0, 3)]
    [TestCase(new int[0], -1.0, -1.0, 4)]
    [TestCase(new int[0], -1.0, -1.0, 5)]
    [TestCase(new int[0], -1.0, -1.0, 6)]
    [TestCase(new int[0], -1.0, -1.0, 7)]
    [TestCase(new int[0], -1.0, -1.0, 8)]
    [TestCase(new int[0], -1.0, -1.0, 9)]
    [TestCase(new int[0], -1.0, -1.0, 10)]
    [TestCase(new int[0], -1.0, -1.0, 11)]
    [TestCase(new int[0], -1.0, -1.0, 12)]
    [TestCase(new int[0], -1.0, -1.0, 13)]
    [TestCase(new int[0], -1.0, -1.0, 14)]
    [TestCase(new int[0], -1.0, -1.0, 15)]
    [TestCase(new int[0], -1.0, -1.0, 16)]
    [TestCase(new int[0], -1.0, -1.0, 17)]
    [TestCase(new int[0], -1.0, -1.0, 18)]
    [TestCase(new int[0], -1.0, -1.0, 19)]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 0 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 1 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 2 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 3 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 4 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 5 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 6 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 7 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 8 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 9 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 10 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 11 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 12 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 13 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 14 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 15 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 16 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 17 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 18 })]
    [TestCase(new object[] { new object[] { null, null, null }, -1.0, -1.0, 19 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 9 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 10 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 11 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 12 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 13 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 14 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 15 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 16 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 17 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 18 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.5, 19 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 9 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 10 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 11 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 12 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 13 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 14 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 15 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 16 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 17 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 18 })]
    [TestCase(new object[] { new object[] { 1, 2, 3 }, -1.0, 2.0, 19 })]
    public void AverageOrDefaultNullableWithDefaultValue(IEnumerable source, double? defaultValue, double? expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.OfType<int?>().AverageOrDefault(() => defaultValue),
            2 => source.OfType<int?>().AverageOrDefault(x => x, defaultValue),
            3 => source.OfType<int?>().AverageOrDefault(x => x, () => defaultValue),
            4 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(defaultValue),
            5 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(() => defaultValue),
            6 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(x => x, defaultValue),
            7 => source.OfType<int?>().Select(x => x.Map(ToInt64)).AverageOrDefault(x => x, () => defaultValue),
            8 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(ToSingle(defaultValue)),
            9 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(() => ToSingle(defaultValue)),
            10 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(x => x, ToSingle(defaultValue)),
            11 => source.OfType<int?>().Select(x => x.Map(ToSingle)).AverageOrDefault(x => x, () => ToSingle(defaultValue)),
            12 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(defaultValue),
            13 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(() => defaultValue),
            14 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(x => x, defaultValue),
            15 => source.OfType<int?>().Select(x => x.Map(ToDouble)).AverageOrDefault(x => x, () => defaultValue),
            16 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(ToDecimal(defaultValue)),
            17 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(() => ToDecimal(defaultValue)),
            18 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(x => x, ToDecimal(defaultValue)),
            19 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).AverageOrDefault(x => x, () => ToDecimal(defaultValue)),
            _ => source.OfType<int?>().AverageOrDefault(defaultValue)
        };

        result.ShouldBe(expectedResult);
    }
}
