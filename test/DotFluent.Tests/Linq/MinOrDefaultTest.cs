using NUnit.Framework;
using Shouldly;
using System.Collections;
using static System.Convert;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableMinOrDefaultTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> intSource = null;

        intSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(y => y, 0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<int?> nullableIntSource = null;

        nullableIntSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(y => y, 0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<long> longSource = null;

        longSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(y => y, 0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<long?> nullableLongSource = null;

        nullableLongSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(y => y, 0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<float> floatSource = null;

        floatSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(() => 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<float?> nullableFloatSource = null;

        nullableFloatSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(() => 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<double> doubleSource = null;

        doubleSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<double?> nullableDoubleSource = null;

        nullableDoubleSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(() => 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<decimal> decimalSource = null;

        decimalSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(() => 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();

        IEnumerable<decimal?> nullableDecimalSource = null;

        nullableDecimalSource
            .Invoking(x => x.MinOrDefault())
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(() => 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(y => y))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(y => y, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(y => y, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var intSource = Enumerable.Empty<int>();
        Func<int, int> intSelector = null;

        intSource
            .Invoking(x => x.MinOrDefault(intSelector))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(intSelector, 0))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(intSelector, () => 0))
            .ShouldThrow<ArgumentNullException>();

        var nullableIntSource = Enumerable.Empty<int?>();
        Func<int?, int?> nullableIntSelector = null;

        nullableIntSource
            .Invoking(x => x.MinOrDefault(nullableIntSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(nullableIntSelector, 0))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(nullableIntSelector, () => 0))
            .ShouldThrow<ArgumentNullException>();

        var longSource = Enumerable.Empty<long>();
        Func<long, long> longSelector = null;

        longSource
            .Invoking(x => x.MinOrDefault(longSelector))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(longSelector, 0))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(longSelector, () => 0))
            .ShouldThrow<ArgumentNullException>();

        var nullableLongSource = Enumerable.Empty<long?>();
        Func<long?, long?> nullableLongSelector = null;

        nullableLongSource
            .Invoking(x => x.MinOrDefault(nullableLongSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(nullableLongSelector, 0))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(nullableLongSelector, () => 0))
            .ShouldThrow<ArgumentNullException>();

        var floatSource = Enumerable.Empty<float>();
        Func<float, float> floatSelector = null;

        floatSource
            .Invoking(x => x.MinOrDefault(floatSelector))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(floatSelector, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(floatSelector, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        var nullableFloatSource = Enumerable.Empty<float?>();
        Func<float?, float?> nullableFloatSelector = null;

        nullableFloatSource
            .Invoking(x => x.MinOrDefault(nullableFloatSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(nullableFloatSelector, 0.0f))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(nullableFloatSelector, () => 0.0f))
            .ShouldThrow<ArgumentNullException>();

        var doubleSource = Enumerable.Empty<double>();
        Func<double, double> doubleSelector = null;

        doubleSource
            .Invoking(x => x.MinOrDefault(doubleSelector))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(doubleSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(doubleSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var nullableDoubleSource = Enumerable.Empty<double?>();
        Func<double?, double?> nullableDoubleSelector = null;

        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(nullableDoubleSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(nullableDoubleSelector, 0.0))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(nullableDoubleSelector, () => 0.0))
            .ShouldThrow<ArgumentNullException>();

        var decimalSource = Enumerable.Empty<decimal>();
        Func<decimal, decimal> decimalSelector = null;

        decimalSource
            .Invoking(x => x.MinOrDefault(decimalSelector))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(decimalSelector, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(decimalSelector, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();

        var nullableDecimalSource = Enumerable.Empty<decimal?>();
        Func<decimal?, decimal?> nullableDecimalSelector = null;

        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(nullableDecimalSelector))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(nullableDecimalSelector, 0.0m))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(nullableDecimalSelector, () => 0.0m))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        Func<int> intFactory = null;
        Func<int?> nullableIntFactory = null;
        Func<long> longFactory = null;
        Func<long?> nullableLongFactory = null;
        Func<float> floatFactory = null;
        Func<float?> nullableFloatFactory = null;
        Func<double> doubleFactory = null;
        Func<double?> nullableDoubleFactory = null;
        Func<decimal> decimalFactory = null;
        Func<decimal?> nullableDecimalFactory = null;

        var intSource = Enumerable.Empty<int>();
        intSource
            .Invoking(x => x.MinOrDefault(intFactory))
            .ShouldThrow<ArgumentNullException>();
        intSource
            .Invoking(x => x.MinOrDefault(y => y, intFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableIntSource = Enumerable.Empty<int?>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(nullableIntFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableIntSource
            .Invoking(x => x.MinOrDefault(y => y, nullableIntFactory))
            .ShouldThrow<ArgumentNullException>();

        var longSource = Enumerable.Empty<long>();
        longSource
            .Invoking(x => x.MinOrDefault(longFactory))
            .ShouldThrow<ArgumentNullException>();
        longSource
            .Invoking(x => x.MinOrDefault(y => y, longFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableLongSource = Enumerable.Empty<long?>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(nullableLongFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableLongSource
            .Invoking(x => x.MinOrDefault(y => y, nullableLongFactory))
            .ShouldThrow<ArgumentNullException>();

        var floatSource = Enumerable.Empty<float>();
        floatSource
            .Invoking(x => x.MinOrDefault(floatFactory))
            .ShouldThrow<ArgumentNullException>();
        floatSource
            .Invoking(x => x.MinOrDefault(y => y, floatFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableFloatSource = Enumerable.Empty<float?>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(nullableFloatFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableFloatSource
            .Invoking(x => x.MinOrDefault(y => y, nullableFloatFactory))
            .ShouldThrow<ArgumentNullException>();

        var doubleSource = Enumerable.Empty<double>();
        doubleSource
            .Invoking(x => x.MinOrDefault(doubleFactory))
            .ShouldThrow<ArgumentNullException>();
        doubleSource
            .Invoking(x => x.MinOrDefault(y => y, doubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableDoubleSource = Enumerable.Empty<double?>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableDoubleSource
            .Invoking(x => x.MinOrDefault(y => y, nullableDoubleFactory))
            .ShouldThrow<ArgumentNullException>();

        var decimalSource = Enumerable.Empty<decimal>();
        decimalSource
            .Invoking(x => x.MinOrDefault(decimalFactory))
            .ShouldThrow<ArgumentNullException>();
        decimalSource
            .Invoking(x => x.MinOrDefault(y => y, decimalFactory))
            .ShouldThrow<ArgumentNullException>();

        var nullableDecimalSource = Enumerable.Empty<decimal?>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(nullableDecimalFactory))
            .ShouldThrow<ArgumentNullException>();
        nullableDecimalSource
            .Invoking(x => x.MinOrDefault(y => y, nullableDecimalFactory))
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
    [TestCase(new[] { 3, 1, 2 }, 1.0, 0)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 1)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 2)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 3)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 4)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 5)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 6)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 7)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 8)]
    [TestCase(new[] { 3, 1, 2 }, 1.0, 9)]
    public void MinOrDefault(IEnumerable<int> source, double expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.MinOrDefault(x => x),
            2 => source.Select(ToInt64).MinOrDefault(),
            3 => source.Select(ToInt64).MinOrDefault(x => x),
            4 => source.Select(ToSingle).MinOrDefault(),
            5 => source.Select(ToSingle).MinOrDefault(x => x),
            6 => source.Select(ToDouble).MinOrDefault(),
            7 => source.Select(ToDouble).MinOrDefault(x => x),
            8 => ToDouble(source.Select(ToDecimal).MinOrDefault()),
            9 => ToDouble(source.Select(ToDecimal).MinOrDefault(x => x)),
            _ => source.MinOrDefault()
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
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, 1.0, 9 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 0 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 1 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 2 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 3 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 4 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 5 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 6 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 7 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 8 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, 1.0, 9 })]
    public void MinOrDefaultNullable(IEnumerable source, double? expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.OfType<int?>().MinOrDefault(x => x),
            2 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(),
            3 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(x => x),
            4 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(),
            5 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(x => x),
            6 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(),
            7 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(x => x),
            8 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(),
            9 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(x => x),
            _ => source.OfType<int?>().MinOrDefault()
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
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 0)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 1)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 2)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 3)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 4)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 5)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 6)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 7)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 8)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 9)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 10)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 11)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 12)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 13)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 14)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 15)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 16)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 17)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 18)]
    [TestCase(new[] { 3, 1, 2 }, -1.0, 1.0, 19)]
    public void MinOrDefaultWithDefaultValue(IEnumerable<int> source, double defaultValue, double expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.MinOrDefault(() => ToInt32(defaultValue)),
            2 => source.MinOrDefault(x => x, ToInt32(defaultValue)),
            3 => source.MinOrDefault(x => x, () => ToInt32(defaultValue)),
            4 => source.Select(ToInt64).MinOrDefault(ToInt64(defaultValue)),
            5 => source.Select(ToInt64).MinOrDefault(() => ToInt64(defaultValue)),
            6 => source.Select(ToInt64).MinOrDefault(x => x, ToInt64(defaultValue)),
            7 => source.Select(ToInt64).MinOrDefault(x => x, () => ToInt64(defaultValue)),
            8 => source.Select(ToSingle).MinOrDefault(ToSingle(defaultValue)),
            9 => source.Select(ToSingle).MinOrDefault(() => ToSingle(defaultValue)),
            10 => source.Select(ToSingle).MinOrDefault(x => x, ToSingle(defaultValue)),
            11 => source.Select(ToSingle).MinOrDefault(x => x, () => ToSingle(defaultValue)),
            12 => source.Select(ToDouble).MinOrDefault(defaultValue),
            13 => source.Select(ToDouble).MinOrDefault(() => defaultValue),
            14 => source.Select(ToDouble).MinOrDefault(x => x, defaultValue),
            15 => source.Select(ToDouble).MinOrDefault(x => x, () => defaultValue),
            16 => ToDouble(source.Select(ToDecimal).MinOrDefault(ToDecimal(defaultValue))),
            17 => ToDouble(source.Select(ToDecimal).MinOrDefault(() => ToDecimal(defaultValue))),
            18 => ToDouble(source.Select(ToDecimal).MinOrDefault(x => x, ToDecimal(defaultValue))),
            19 => ToDouble(source.Select(ToDecimal).MinOrDefault(x => x, () => ToDecimal(defaultValue))),
            _ => source.MinOrDefault(ToInt32(defaultValue))
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
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 0 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 1 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 2 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 3 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 4 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 5 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 6 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 7 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 8 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 9 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 10 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 11 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 12 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 13 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 14 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 15 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 16 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 17 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 18 })]
    [TestCase(new object[] { new object[] { 1, 2, null, }, -1.0, 1.0, 19 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 0 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 1 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 2 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 3 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 4 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 5 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 6 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 7 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 8 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 9 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 10 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 11 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 12 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 13 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 14 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 15 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 16 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 17 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 18 })]
    [TestCase(new object[] { new object[] { 3, 1, 2 }, -1.0, 1.0, 19 })]
    public void MinOrDefaultNullableWithDefaultValue(IEnumerable source, double? defaultValue, double? expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.OfType<int?>().MinOrDefault(() => ToInt32(defaultValue)),
            2 => source.OfType<int?>().MinOrDefault(x => x, ToInt32(defaultValue)),
            3 => source.OfType<int?>().MinOrDefault(x => x, () => ToInt32(defaultValue)),
            4 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(ToInt64(defaultValue)),
            5 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(() => ToInt64(defaultValue)),
            6 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(x => x, ToInt64(defaultValue)),
            7 => source.OfType<int?>().Select(x => x.Map(ToInt64)).MinOrDefault(x => x, () => ToInt64(defaultValue)),
            8 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(ToSingle(defaultValue)),
            9 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(() => ToSingle(defaultValue)),
            10 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(x => x, ToSingle(defaultValue)),
            11 => source.OfType<int?>().Select(x => x.Map(ToSingle)).MinOrDefault(x => x, () => ToSingle(defaultValue)),
            12 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(defaultValue),
            13 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(() => defaultValue),
            14 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(x => x, defaultValue),
            15 => source.OfType<int?>().Select(x => x.Map(ToDouble)).MinOrDefault(x => x, () => defaultValue),
            16 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(ToDecimal(defaultValue)),
            17 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(() => ToDecimal(defaultValue)),
            18 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(x => x, ToDecimal(defaultValue)),
            19 => (double?)source.OfType<int?>().Select(x => x.Map(ToDecimal)).MinOrDefault(x => x, () => ToDecimal(defaultValue)),
            _ => source.OfType<int?>().MinOrDefault(ToInt32(defaultValue))
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
