using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class DictionaryGetOrAddTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IDictionary<int, int> source = null;

        source
            .Invoking(x => x.GetOrAdd(1, 1))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GetOrAdd(1, k => 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeyNullThrowsException()
    {
        var source = new Dictionary<object, int>();

        source
            .Invoking(x => x.GetOrAdd(null, 1))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GetOrAdd(null, k => 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ValueFactoryNullThrowsException()
    {
        var source = new Dictionary<int, int>();
        Func<int, int> valueFactory = null;

        source
            .Invoking(x => x.GetOrAdd(1, valueFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, true, 0)]
    [TestCase(1, 2, true, 1)]
    public void GetOrAdd(int key, int value, bool isExisting, int overload)
    {
        var source = isExisting
            ? new Dictionary<int, int>()
            { 
                [key] = value
            }
            : new Dictionary<int, int>();
        var result = overload switch
        {
            1 => source.GetOrAdd(key, k => value),
            _ => source.GetOrAdd(key, value)
        };
        result.ShouldBe(value);
    }

    #endregion
}
