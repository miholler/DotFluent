using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class DictionaryTryUpdateTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IDictionary<int, int> source = null;

        source
            .Invoking(x => x.TryUpdate(1, 2, 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeyNullThrowsException()
    {
        var source = new Dictionary<object, int>();

        source
            .Invoking(x => x.TryUpdate(null, 2, 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, 2, false, false)]
    [TestCase(1, 2, 1, true, false)]
    [TestCase(1, 2, 2, true, true)]
    public void TryUpdate(int key, int value, int comparisonValue, bool isExisting, bool expectedResult)
    {
        var source = isExisting
            ? new Dictionary<int, int>()
            {
                [key] = value
            }
            : new Dictionary<int, int>();

        source
            .TryUpdate(key, value, comparisonValue)
            .ShouldBe(expectedResult);
    }

    #endregion
}
