using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectThrowIfNullTest
{
    [Test]
    public void ObjectNullThrowsException()
    {
        object source = null;
        Action action = () => source.ThrowIfNull();
        Action factoryAction = () => source.ThrowIfNull(() => new ArgumentNullException(nameof(source)));

        action.ShouldThrow<ArgumentNullException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));
        factoryAction
              .ShouldThrow<ArgumentNullException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void ObjectNotNullReturnsObject(int overload)
    {
        var source = new object();
        var result = overload switch
        {
            1 => source.ThrowIfNull(() => new ArgumentNullException(nameof(source))),
            _ => source.ThrowIfNull()
        };

        result.ShouldBe(source);
    }
}
