using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent;

[TestFixture]
public sealed class NullableMatchTest
{
    #region Methods

    [Test]
    public void NoneNullThrowsException()
    {
        var source = new int?();
        Action none = null;
        Func<int?> noneFunc = null;

        source
            .Invoking(x => x.Match(none))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Match(x => { x++; }, none))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Match(x => x++, noneFunc))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SomeNullThrowsException()
    {
        var source = new int?(0);
        Action<int> some = null;
        Func<int, int> someFunc = null;

        source
            .Invoking(x => x.Match(some))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Match(some, () => { }))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Match(someFunc, 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Match(someFunc, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(1, 1, 2, 2)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(1, 1, 2, 3)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(1, 1, 2, 4)]
    [TestCase(null, 1, 1, 4)]
    public void Match(int? source, int value, int expectedResult, int overload)
    {
        var result = 0;
        
        switch (overload)
        {
            case 1:
                source.Match(x => result = x + value);
                break;
            case 2:
                source.Match(x => { result = x + value; }, () => { result = value; });
                break;
            case 3:
                result = source.Match(x => x + value, value);
                break;
            case 4:
                result = source.Match(x => x + value, () => value);
                break;
            default:
                source.Match(() => result = value);
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
