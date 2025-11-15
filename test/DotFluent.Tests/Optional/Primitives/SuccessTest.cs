using NUnit.Framework;
using Shouldly;
using System.Net;

namespace DotFluent.Optional.Primitives;

[TestFixture]
public sealed class SuccessTest
{
    [Test]
    public void Set_Value()
    {
        var success = new Success<HttpStatusCode>()
        {
            Value = HttpStatusCode.OK
        };
        success.Value.ShouldBe(HttpStatusCode.OK);
    }

    [Test]
    public void OP_Implicit()
    {
        Success<HttpStatusCode> success = HttpStatusCode.OK;
        HttpStatusCode statusCode = success;
        statusCode.ShouldBe(HttpStatusCode.OK);
    }
}
