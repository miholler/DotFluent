using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent;

[TestFixture]
public sealed class ObjectThrowIfNullTest
{
    #region Methods

    [Test]
    public void ObjectNullThrowsException()
    {
        object obj = null;
        Action action = () => obj.ThrowIfNull();

        action
            .ShouldThrow<ArgumentNullException>()
            .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(obj)));
    }

    [Test]
    public void ObjectNullThrowsFactoryException()
    {
        object obj = null;

        obj.Invoking(x => x.ThrowIfNull(() => new ArgumentNullException(nameof(obj))))
           .ShouldThrow<ArgumentNullException>()
           .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(obj)));
    }

    [Test]
    public void ObjectNotNullReturnsObject()
    {
        var obj = new object();

        obj.ThrowIfNull()
           .ShouldBe(obj);
    }

    [Test]
    public void ObjectNotNullReturnsObjectWithFactory()
    {
        var obj = new object();

        obj.ThrowIfNull(() => new ArgumentNullException(nameof(obj)))
           .ShouldBe(obj);
    }

    #endregion
}
