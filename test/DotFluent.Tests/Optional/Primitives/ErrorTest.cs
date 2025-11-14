using NUnit.Framework;
using Shouldly;
using System.Net;

namespace DotFluent.Optional.Primitives;

[TestFixture]
public sealed class ErrorTest
{
    [Test]
    public void Set_Value()
    {
        var error = new Error<HttpStatusCode>()
        {
            Value = HttpStatusCode.InternalServerError
        };
        error.Value.ShouldBe(HttpStatusCode.InternalServerError);
    }

    [Test]
    public void OP_Implicit()
    {
        Error<HttpStatusCode> error = HttpStatusCode.InternalServerError;
        HttpStatusCode statusCode = error;
        statusCode.ShouldBe(HttpStatusCode.InternalServerError);
    }
}
