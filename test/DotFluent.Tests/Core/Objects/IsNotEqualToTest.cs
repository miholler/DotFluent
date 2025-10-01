using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsNotEqualToTest
{
    [Test]
    public void IsEqual()
    {
        var a = 1;
        var b = 1;

        a.IsNotEqualTo(b)
         .ShouldBeFalse();
    }

    [Test]
    public void IsNotEqual()
    {
        var a = 1;
        var b = 2;

        a.IsNotEqualTo(b)
         .ShouldBeTrue();
    }

    [Test]
    public void IsReferenceEqual()
    {
        var a = new object();
        var b = a;

        a.IsNotEqualTo(b, true)
         .ShouldBeFalse();
    }

    [Test]
    public void IsReferenceNotEqual()
    {
        var a = new object();
        var b = new object();

        a.IsNotEqualTo(b, true)
         .ShouldBeTrue();
    }
}
