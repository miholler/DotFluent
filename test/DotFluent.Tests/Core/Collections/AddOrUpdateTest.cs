using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class DictionaryAddOrUpdateTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IDictionary<int, int> source = null;

        source
            .Invoking(x => x.AddOrUpdate(1, 1, (k, v) => 1))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AddOrUpdate(1, k => 1, (k, v) => 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeyNullThrowsException()
    {
        var source = new Dictionary<object, int>();

        source
            .Invoking(x => x.AddOrUpdate(null, 1, (k, v) => 1))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AddOrUpdate(null, k => 1, (k, v) => 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void AddValueFactoryNullThrowsException()
    {
        var source = new Dictionary<int, int>();
        Func<int, int> addValueFactory = null;

        source
            .Invoking(x => x.AddOrUpdate(1, addValueFactory, (k, v) => 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void UpdateValueFactoryNullThrowsException()
    {
        var source = new Dictionary<int, int>();
        Func<int, int, int> updateValueFactory = null;

        source
            .Invoking(x => x.AddOrUpdate(1, 1, updateValueFactory))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AddOrUpdate(1, k => 1, updateValueFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, false, 2, 0)]
    [TestCase(1, 2, false, 2, 1)]
    [TestCase(1, 2, true, 3, 0)]
    [TestCase(1, 2, true, 3, 1)]
    public void AddOrUpdate(int key, int value, bool isExisting, int expectedResult, int overload)
    {
        var source = isExisting
            ? new Dictionary<int, int>()
            {
                [key] = value
            }
            : new Dictionary<int, int>();
        var result = overload switch
        {
            1 => source.AddOrUpdate(key, k => value, (k, v) => ++v),
            _ => source.AddOrUpdate(key, value, (k, v) => ++v)
        };
        result.ShouldBe(expectedResult);
    }

    #endregion
}
