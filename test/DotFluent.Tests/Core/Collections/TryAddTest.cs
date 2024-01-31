using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent;

[TestFixture]
public sealed class DictionaryTryAddTest
{
    #region Methods

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
        var source = new Dictionary<object, int>() as IDictionary<object, int>;

        source
            .Invoking(x => x.TryAdd(null, 1))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, false, true)]
    [TestCase(1, 2, true, false)]
    public void TryAdd(int key, int value, bool isExisting, bool expectedResult)
    {
        var source = isExisting
            ? new Dictionary<int, int>()
            {
                [key] = value
            }
            : new Dictionary<int, int>() as IDictionary<int, int>;

        source
            .TryAdd(key, value)
            .ShouldBe(expectedResult);
    }

    #endregion
}
