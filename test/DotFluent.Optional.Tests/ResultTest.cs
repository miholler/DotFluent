using DotFluent.Linq;
using NUnit.Framework;
using Shouldly;
using System.Collections;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ResultTest
{
    [Test]
    public void IsOk()
    {
        var result = Result<int>.Ok(1);

        result.IsOk.ShouldBeTrue();
        result.IsError.ShouldBeFalse();
    }

    [Test]
    public void IsError()
    {
        var result = Result<int>.Error(new());

        result.IsOk.ShouldBeFalse();
        result.IsError.ShouldBeTrue();
    }

    [Test]
    public void MatchOkNullThrowsException()
    {
        var result = Result<int>.Ok(0);
        Action<int> ok = null;
        Func<int, int> okFunc = null;

        result
            .Invoking(x => x.Match(ok, _ => { }))
            .ShouldThrow<ArgumentNullException>();
        result
            .Invoking(x => x.Match(okFunc, _ => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void MatchErrorNullThrowsException()
    {
        var result = Result<int>.Error(new());
        Action<Exception> error = null;
        Func<Exception, int> errorFunc = null;

        result
            .Invoking(x => x.Match(_ => { }, error))
            .ShouldThrow<ArgumentNullException>();
        result
            .Invoking(x => x.Match(_ => 0, errorFunc))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, 2, 0)]
    [TestCase(null, 0, 0, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(null, 0, 0, 1)]
    public void Match(int? source, int value, int expectedResult, int overload)
    {
        var currentResult = 0;
        var result = source.Match(Result<int>.Ok, () => Result<int>.Error(new HResultException(value)));
        switch (overload)
        {
            case 1:
                currentResult = result.Match(x => x + value, x => x.HResult);
                break;
            default:
                result.Match(x => { currentResult = x + value; }, x => { currentResult = x.HResult; });
                break;
        }
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public void MapMapperNullThrowsException()
    {
        var result = Result<int>.Ok(0);
        Func<int, int> mapper = null;

        result
            .Invoking(x => x.Map(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 2 })]
    [TestCase(null, new int[0])]
    public void Map(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .Map(x => x + 1)
            .ShouldBe(expectedResult);

    [Test]
    public void MapErrorMapperNullThrowsException()
    {
        var result = Result<int>.Error(new());
        Func<Exception, Exception> mapper = null;

        result
            .Invoking(x => x.MapError(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1)]
    [TestCase(null)]
    public void MapError(int? source)
        => source
            .Match(Result<int>.Ok, Result<int>.Error(new()))
            .MapError(x => new AggregateException(x))
            .Match(x => x == source, x => x is AggregateException)
            .ShouldBeTrue();

    [Test]
    public void FlatMapMapperNullThrowsException()
    {
        var result = Result<int>.Ok(0);
        Func<int, Result<int>> mapper = null;

        result
            .Invoking(x => x.FlatMap(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void FlatMap(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .FlatMap(Result<int>.Ok)
            .ShouldBe(expectedResult);

    [Test]
    public void OrElseOtherFactoryNullThrowsException()
    {
        var result = Result<int>.Ok(0);
        Func<Result<int>> otherFactory = null;

        result
            .Invoking(x => x.OrElse(otherFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    public void OrElse(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var result = source.Match(Result<int>.Ok, () => Result<int>.Error(new()));
        var currentResult = overload switch
        {
            1 => result.OrElse(() => other.Match(Result<int>.Ok, () => Result<int>.Error(new()))),
            _ => result.OrElse(other.Match(Result<int>.Ok, () => Result<int>.Error(new())))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(null, 1, false)]
    public void Contains(int? source, int value, bool expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .Contains(value)
            .ShouldBe(expectedResult);

    [Test]
    public void ExistsPredicateNullThrowsException()
    {
        var result = Result<int>.Ok(0);
        Func<int, bool> predicate = null;

        result
            .Invoking(x => x.Exists(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(null, 1, false)]
    public void Exists(int? source, int value, bool expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .Exists(x => x == value)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, true)]
    [TestCase(null, false)]
    public void GetEnumerator(int? source, bool expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .GetEnumerator()
            .MoveNext()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void AsEnumerable(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int>.Ok, () => Result<int>.Error(new()))
            .AsEnumerable()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 1, 1)]
    [TestCase(1, 1, 0, 2)]
    [TestCase(1, 1, 1, 3)]
    [TestCase(1, 1, 0, 4)]
    [TestCase(1, 2, -1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(1, 2, -1, 2)]
    [TestCase(1, 2, 1, 3)]
    [TestCase(1, 2, -1, 4)]
    [TestCase(2, 1, 1, 0)]
    [TestCase(2, 1, 1, 1)]
    [TestCase(2, 1, 1, 2)]
    [TestCase(2, 1, 1, 3)]
    [TestCase(2, 1, 1, 4)]
    [TestCase(null, 1, -1, 0)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(null, 1, -1, 2)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(null, 1, -1, 4)]
    [TestCase(1, null, 1, 0)]
    [TestCase(1, null, 1, 1)]
    [TestCase(1, null, 1, 2)]
    [TestCase(1, null, 1, 3)]
    [TestCase(1, null, 1, 4)]
    [TestCase(null, null, 0, 0)]
    [TestCase(null, null, 1, 1)]
    [TestCase(null, null, 0, 2)]
    [TestCase(null, null, 1, 3)]
    [TestCase(null, null, 0, 4)]
    public void CompareTo(int? source, int? value, int expectedResult, int overload)
    {
        var result = source.Match(Result<int>.Ok, () => Result<int>.Error(new()));
        var currentResult = overload switch
        {
            1 => Comparer<object>.Default.Compare(result, value),
            2 => Comparer<object>.Default.Compare(result, value.Match(Result<int>.Ok, () => Result<int>.Error(new()))),
            3 => StructuralComparisons.StructuralComparer.Compare(result, value),
            4 => StructuralComparisons.StructuralComparer.Compare(result, value.Match(Result<int>.Ok, () => Result<int>.Error(new()))),
            _ => result.CompareTo(value.Match(Result<int>.Ok, () => Result<int>.Error(new())))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, false, 1)]
    [TestCase(1, 1, true, 2)]
    [TestCase(1, 1, false, 3)]
    [TestCase(1, 1, true, 4)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, false, 2)]
    [TestCase(1, 2, false, 3)]
    [TestCase(1, 2, false, 4)]
    [TestCase(2, 1, false, 0)]
    [TestCase(2, 1, false, 1)]
    [TestCase(2, 1, false, 2)]
    [TestCase(2, 1, false, 3)]
    [TestCase(2, 1, false, 4)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(null, 1, false, 2)]
    [TestCase(null, 1, false, 3)]
    [TestCase(null, 1, false, 4)]
    [TestCase(1, null, false, 0)]
    [TestCase(1, null, false, 1)]
    [TestCase(1, null, false, 2)]
    [TestCase(1, null, false, 3)]
    [TestCase(1, null, false, 4)]
    [TestCase(null, null, true, 0)]
    [TestCase(null, null, false, 1)]
    [TestCase(null, null, true, 2)]
    [TestCase(null, null, false, 3)]
    [TestCase(null, null, true, 4)]
    public void Equals(int? source, int? value, bool expectedResult, int overload)
    {
        var result = source.Match(Result<int>.Ok, () => Result<int>.Error(new()));
        var currentResult = overload switch
        {
            1 => EqualityComparer<object>.Default.Equals(result, value),
            2 => EqualityComparer<object>.Default.Equals(result, value.Match(Result<int>.Ok, () => Result<int>.Error(new()))),
            3 => StructuralComparisons.StructuralEqualityComparer.Equals(result, value),
            4 => StructuralComparisons.StructuralEqualityComparer.Equals(result, value.Match(Result<int>.Ok, () => Result<int>.Error(new()))),
            _ => result.Equals(value.Match(Result<int>.Ok, () => Result<int>.Error(new())))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, true, 0)]
    [TestCase(1, true, 1)]
    [TestCase(null, true, 0)]
    [TestCase(null, true, 1)]
    [TestCase(null, false, 0)]
    [TestCase(null, false, 1)]
    public void GetHashCode(object source, bool isOk, int overload)
    {
        var result = isOk
            ? Result<object>.Ok(source)
            : Result<object>.Error(new());
        var currentResult = overload switch
        {
            1 => StructuralComparisons.StructuralEqualityComparer.GetHashCode(result),
            _ => result.GetHashCode()
        };
        var expectedResult = result.Match(x => x?.GetHashCode() ?? 1, x => x.GetHashCode());

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, "Ok(1)", true)]
    [TestCase(null, "Ok(null)", true)]
    [TestCase(null, "Error(System.Exception)", false)]
    public void ToString(object source, string expectedResult, bool isOk)
    {
        var result = isOk
            ? Result<object>.Ok(source)
            : Result<object>.Error(new(string.Empty));

        result
            .ToString()
            .ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1)]
    [TestCase(null)]
    public void OP_Implicit_Value(object source)
    {
        Result<object> result = source;

        result
            .Contains(source)
            .ShouldBeTrue();
    }

    [Test]
    public void OP_Implicit_Error()
    {
        Result<int> result = new Exception();

        result.IsOk.ShouldBeFalse();
        result.IsError.ShouldBeTrue();
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, false)]
    public void OP_LessThan(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) < right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    public void OP_LessThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) <= right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]

    public void OP_GreaterThan(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) > right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, true)]
    public void OP_GreaterThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) >= right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    public void OP_Equality(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) == right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]
    public void OP_Inequality(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int>.Ok, () => Result<int>.Error(new())) != right.Match(Result<int>.Ok, () => Result<int>.Error(new()));

        currentResult.ShouldBe(expectedResult);
    }
}

[TestFixture]
public sealed class Result2Test
{
    [Test]
    public void IsOk()
    {
        var result = Result<int, int>.Ok(1);

        result.IsOk.ShouldBeTrue();
        result.IsError.ShouldBeFalse();
    }

    [Test]
    public void IsError()
    {
        var result = Result<int, int>.Error(0);

        result.IsOk.ShouldBeFalse();
        result.IsError.ShouldBeTrue();
    }

    [Test]
    public void MatchOkNullThrowsException()
    {
        var result = Result<int, int>.Ok(0);
        Action<int> ok = null;
        Func<int, int> okFunc = null;

        result
            .Invoking(x => x.Match(ok, _ => { }))
            .ShouldThrow<ArgumentNullException>();
        result
            .Invoking(x => x.Match(okFunc, _ => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void MatchErrorNullThrowsException()
    {
        var result = Result<int, int>.Error(0);
        Action<int> error = null;
        Func<int, int> errorFunc = null;

        result
            .Invoking(x => x.Match(_ => { }, error))
            .ShouldThrow<ArgumentNullException>();
        result
            .Invoking(x => x.Match(_ => 0, errorFunc))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, 2, 0)]
    [TestCase(null, 0, 0, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(null, 0, 0, 1)]
    public void Match(int? source, int value, int expectedResult, int overload)
    {
        var currentResult = 0;
        var result = source.Match(Result<int, int>.Ok, () => Result<int, int>.Error(value));
        switch (overload)
        {
            case 1:
                currentResult = result.Match(x => x + value, x => x);
                break;
            default:
                result.Match(x => { currentResult = x + value; }, x => { currentResult = x; });
                break;
        }
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public void MapMapperNullThrowsException()
    {
        var result = Result<int, int>.Ok(0);
        Func<int, int> mapper = null;

        result
            .Invoking(x => x.Map(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 2 })]
    [TestCase(null, new int[0])]
    public void Map(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .Map(x => x + 1)
            .ShouldBe(expectedResult);

    [Test]
    public void MapErrorMapperNullThrowsException()
    {
        var result = Result<int, int>.Error(0);
        Func<int, int> mapper = null;

        result
            .Invoking(x => x.MapError(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 2 })]
    [TestCase(null, new[] { 0 })]
    public void MapError(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int, int>.Error, Result<int, int>.Ok(0))
            .MapError(x => x + 1)
            .Match(x => Enumerable.Create(x), x => Enumerable.Create(x))
            .ShouldBe(expectedResult);

    [Test]
    public void FlatMapMapperNullThrowsException()
    {
        var result = Result<int, int>.Ok(0);
        Func<int, Result<int, int>> mapper = null;

        result
            .Invoking(x => x.FlatMap(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void FlatMap(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .FlatMap(Result<int, int>.Ok)
            .ShouldBe(expectedResult);

    [Test]
    public void OrElseOtherFactoryNullThrowsException()
    {
        var result = Result<int, int>.Ok(0);
        Func<Result<int, int>> otherFactory = null;

        result
            .Invoking(x => x.OrElse(otherFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    public void OrElse(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var result = source.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));
        var currentResult = overload switch
        {
            1 => result.OrElse(() => other.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))),
            _ => result.OrElse(other.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(null, 1, false)]
    public void Contains(int? source, int value, bool expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .Contains(value)
            .ShouldBe(expectedResult);

    [Test]
    public void ExistsPredicateNullThrowsException()
    {
        var result = Result<int, int>.Ok(0);
        Func<int, bool> predicate = null;

        result
            .Invoking(x => x.Exists(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(null, 1, false)]
    public void Exists(int? source, int value, bool expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .Exists(x => x == value)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, true)]
    [TestCase(null, false)]
    public void GetEnumerator(int? source, bool expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .GetEnumerator()
            .MoveNext()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void AsEnumerable(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))
            .AsEnumerable()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 1, 1)]
    [TestCase(1, 1, 0, 2)]
    [TestCase(1, 1, 1, 3)]
    [TestCase(1, 1, 0, 4)]
    [TestCase(1, 2, -1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(1, 2, -1, 2)]
    [TestCase(1, 2, 1, 3)]
    [TestCase(1, 2, -1, 4)]
    [TestCase(2, 1, 1, 0)]
    [TestCase(2, 1, 1, 1)]
    [TestCase(2, 1, 1, 2)]
    [TestCase(2, 1, 1, 3)]
    [TestCase(2, 1, 1, 4)]
    [TestCase(null, 1, -1, 0)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(null, 1, -1, 2)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(null, 1, -1, 4)]
    [TestCase(1, null, 1, 0)]
    [TestCase(1, null, 1, 1)]
    [TestCase(1, null, 1, 2)]
    [TestCase(1, null, 1, 3)]
    [TestCase(1, null, 1, 4)]
    [TestCase(null, null, 0, 0)]
    [TestCase(null, null, 1, 1)]
    [TestCase(null, null, 0, 2)]
    [TestCase(null, null, 1, 3)]
    [TestCase(null, null, 0, 4)]
    public void CompareTo(int? source, int? value, int expectedResult, int overload)
    {
        var result = source.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));
        var currentResult = overload switch
        {
            1 => Comparer<object>.Default.Compare(result, value),
            2 => Comparer<object>.Default.Compare(result, value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))),
            3 => StructuralComparisons.StructuralComparer.Compare(result, value),
            4 => StructuralComparisons.StructuralComparer.Compare(result, value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))),
            _ => result.CompareTo(value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, false, 1)]
    [TestCase(1, 1, true, 2)]
    [TestCase(1, 1, false, 3)]
    [TestCase(1, 1, true, 4)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, false, 2)]
    [TestCase(1, 2, false, 3)]
    [TestCase(1, 2, false, 4)]
    [TestCase(2, 1, false, 0)]
    [TestCase(2, 1, false, 1)]
    [TestCase(2, 1, false, 2)]
    [TestCase(2, 1, false, 3)]
    [TestCase(2, 1, false, 4)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(null, 1, false, 2)]
    [TestCase(null, 1, false, 3)]
    [TestCase(null, 1, false, 4)]
    [TestCase(1, null, false, 0)]
    [TestCase(1, null, false, 1)]
    [TestCase(1, null, false, 2)]
    [TestCase(1, null, false, 3)]
    [TestCase(1, null, false, 4)]
    [TestCase(null, null, true, 0)]
    [TestCase(null, null, false, 1)]
    [TestCase(null, null, true, 2)]
    [TestCase(null, null, false, 3)]
    [TestCase(null, null, true, 4)]
    public void Equals(int? source, int? value, bool expectedResult, int overload)
    {
        var result = source.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));
        var currentResult = overload switch
        {
            1 => EqualityComparer<object>.Default.Equals(result, value),
            2 => EqualityComparer<object>.Default.Equals(result, value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))),
            3 => StructuralComparisons.StructuralEqualityComparer.Equals(result, value),
            4 => StructuralComparisons.StructuralEqualityComparer.Equals(result, value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0))),
            _ => result.Equals(value.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, true, 0)]
    [TestCase(1, true, 1)]
    [TestCase(1, false, 0)]
    [TestCase(1, false, 1)]
    [TestCase(null, true, 0)]
    [TestCase(null, true, 1)]
    [TestCase(null, false, 0)]
    [TestCase(null, false, 1)]
    public void GetHashCode(object source, bool isOk, int overload)
    {
        var result = isOk
            ? Result<object, object>.Ok(source)
            : Result<object, object>.Error(source);
        var currentResult = overload switch
        {
            1 => StructuralComparisons.StructuralEqualityComparer.GetHashCode(result),
            _ => result.GetHashCode()
        };
        var expectedResult = result.Match(x => x?.GetHashCode() ?? 1, x => x?.GetHashCode() ?? -1);

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, "Ok(1)", true)]
    [TestCase(null, "Ok(null)", true)]
    [TestCase(0, "Error(0)", false)]
    [TestCase(null, "Error(null)", false)]
    public void ToString(object source, string expectedResult, bool isOk)
    {
        var result = isOk
            ? Result<object, object>.Ok(source)
            : Result<object, object>.Error(source);

        result
            .ToString()
            .ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1)]
    [TestCase(null)]
    public void OP_Implicit_Value(object source)
    {
        Result<object, int> result = source;

        result
            .Contains(source)
            .ShouldBeTrue();
    }

    [Test]
    public void OP_Implicit_Error()
    {
        Result<int, string> result = string.Empty;

        result.IsOk.ShouldBeFalse();
        result.IsError.ShouldBeTrue();
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, false)]
    public void OP_LessThan(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) < right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    public void OP_LessThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) <= right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]

    public void OP_GreaterThan(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) > right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, true)]
    public void OP_GreaterThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) >= right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, false)]
    [TestCase(null, 1, false)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    public void OP_Equality(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) == right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, true)]
    [TestCase(null, 1, true)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]
    public void OP_Inequality(int? left, int? right, bool expectedResult)
    {
        var currentResult = left.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0)) != right.Match(Result<int, int>.Ok, () => Result<int, int>.Error(0));

        currentResult.ShouldBe(expectedResult);
    }
}