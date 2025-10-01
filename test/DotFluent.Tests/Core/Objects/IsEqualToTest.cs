using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsEqualToTest
{
    [Test]
    public void IsEqual()
    {
        var a = 1;
        var b = 1;

        a.IsEqualTo(b)
         .ShouldBeTrue();
    }

    [Test]
    public void IsNotEqual()
    {
        var a = 1;
        var b = 2;

        a.IsEqualTo(b)
         .ShouldBeFalse();
    }

    [Test]
    public void IsReferenceEqual()
    {
        var a = new object();
        var b = a;

        a.IsEqualTo(b, true)
         .ShouldBeTrue();
    }

    [Test]
    public void IsReferenceNotEqual()
    {
        var a = new object();
        var b = new object();

        a.IsEqualTo(b, true)
         .ShouldBeFalse();
    }
}
