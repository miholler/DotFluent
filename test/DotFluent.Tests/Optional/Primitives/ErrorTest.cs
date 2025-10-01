using NUnit.Framework;
using Shouldly;
using System.Net;

namespace DotFluent.Optional.Primitives;

[TestFixture]
public sealed class ErrorTest
{
    [Test]
    public void OP_Implicit()
    {
        Error<HttpStatusCode> error = HttpStatusCode.InternalServerError;
        HttpStatusCode statusCode = error;
        statusCode.ShouldBe(HttpStatusCode.InternalServerError);
    }
}
