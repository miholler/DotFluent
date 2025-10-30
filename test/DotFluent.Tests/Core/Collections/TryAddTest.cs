using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class DictionaryTryAddTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IDictionary<int, int> source = null;

        source
            .Invoking(x => x.TryAdd(1, 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeyNullThrowsException()
    {
        var source = CreateDictionary<object, int>();

        source
            .Invoking(x => x.TryAdd(null, 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, false, true)]
    [TestCase(1, 2, true, false)]
    public void TryAdd(int key, int value, bool isExisting, bool expectedResult)
    {
        var source = CreateDictionary<int, int>();
        if (isExisting)
            source[key] = value;

        source
            .TryAdd(key, value)
            .ShouldBe(expectedResult);
    }

    private static IDictionary<TKey, TValue> CreateDictionary<TKey, TValue>()
        => new Dictionary<TKey, TValue>();
}
