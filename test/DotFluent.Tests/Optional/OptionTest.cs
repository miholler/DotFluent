using NUnit.Framework;
using Shouldly;
using System.Collections;
using System.Runtime.Serialization;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionTest
{
    #region Methods

    [Test]
    public void SomeValueReturnsValue()
        => Option<int>
            .Some(1)
            .Value
            .ShouldBe(1);

    [Test]
    public void NoneValueThrowsException()
        => Option<int>
            .None
            .Invoking(x => x.Value)
            .ShouldThrow<InvalidOperationException>();

    [Test]
    public void IsSome()
    {
        var option = Option<int>.Some(1);

        option.IsSome.ShouldBeTrue();
        option.IsNone.ShouldBeFalse();
    }

    [Test]
    public void IsNone()
    {
        var option = Option<int>.None;

        option.IsSome.ShouldBeFalse();
        option.IsNone.ShouldBeTrue();
    }

    [Test]
    public void MatchNoneNullThrowsException()
    {
        var option = Option<int>.None;
        Action none = null;
        Func<int> noneFunc = null;

        option
            .Invoking(x => x.Match(none))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.Match(x => { x++; }, none))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.Match(x => x++, noneFunc))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void MatchSomeNullThrowsException()
    {
        var option = Option<int>.Some(0);
        Action<int> some = null;
        Func<int, int> someFunc = null;

        option
            .Invoking(x => x.Match(some))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.Match(some, () => { }))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.Match(someFunc, 0))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.Match(someFunc, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 0, 0, 0)]
    [TestCase(null, 0, 0, 1)]
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
        var option = source.ToOption();

        switch (overload)
        {
            case 1:
                option.Match(x => result = x + value);
                break;
            case 2:
                option.Match(x => { result = x + value; }, () => { result = value; });
                break;
            case 3:
                result = option.Match(x => x + value, value);
                break;
            case 4:
                result = option.Match(x => x + value, () => value);
                break;
            default:
                option.Match(() => result = value);
                break;
        }
        result.ShouldBe(expectedResult);
    }

    [Test]
    public void MapMapperNullThrowsException()
    {
        var option = Option<int>.None;
        Func<int, int> mapper = null;

        option
            .Invoking(x => x.Map(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 2 })]
    public void Map(int? source, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .Map(x => ++x)
            .ShouldBe(expectedResult);

    [Test]
    public void FlatMapMapperNullThrowsException()
    {
        var option = Option<int>.None;
        Func<int, Option<int>> mapper = null;

        option
            .Invoking(x => x.FlatMap(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void FlatMap(int? source, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .FlatMap(Option<int>.Some)
            .ShouldBe(expectedResult);

    [Test]
    public void OrElseOtherFactoryNullThrowsException()
    {
        var option = Option<int>.None;
        Func<Option<int>> otherFactory = null;

        option
            .Invoking(x => x.OrElse(otherFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    public void OrElse(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var option = source.ToOption();
        var result = overload switch
        {
            1 => option.OrElse(() => other.ToOption()),
            _ => option.OrElse(other.ToOption())
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public void FilterPredicateNullThrowsException()
    {
        var option = Option<int>.None;
        Func<int, bool> predicate = null;

        option
            .Invoking(x => x.Filter(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, new int[0])]
    [TestCase(1, 2, new int[0])]
    [TestCase(1, 1, new[] { 1 })]
    public void Filter(int? source, int value, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .Filter(x => x == value)
            .ShouldBe(expectedResult);

    [Test]
    public void Secure()
    {
        var option = Option<object>.Some(null);

        option
            .Secure()
            .ShouldBe(Option<object>.None);
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public void Contains(int? source, int value, bool expectedResult)
        => source
            .ToOption()
            .Contains(value)
            .ShouldBe(expectedResult);

    [Test]
    public void ExistsPredicateNullThrowsException()
    {
        var option = Option<int>.None;
        Func<int, bool> predicate = null;

        option
            .Invoking(x => x.Exists(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public void Exists(int? source, int value, bool expectedResult)
        => source
            .ToOption()
            .Exists(x => x == value)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null)]
    [TestCase(1)]
    public void GetObjectData(int? source)
    {
        var option = source.ToOption();
        var serializer = new DataContractSerializer(typeof(Option<int>));
        using var stream = new MemoryStream();

        serializer.WriteObject(stream, option);
        stream.Seek(0, SeekOrigin.Begin);

        var result = (Option<int>)serializer.ReadObject(stream);
        option.ShouldBe(result);
    }

    [Test]
    [TestCase(null, false)]
    [TestCase(1, true)]
    public void GetEnumerator(int? source, bool expectedResult)
        => source
            .ToOption()
            .GetEnumerator()
            .MoveNext()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void AsEnumerable(int? source, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .AsEnumerable()
            .ShouldBe(expectedResult);

    [Test]
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
    public void CompareTo(int? source, int? value, int expectedResult, int overload)
    {
        var option = source.ToOption();
        var result = overload switch
        {
            1 => Comparer<object>.Default.Compare(option, value),
            2 => Comparer<object>.Default.Compare(option, value.ToOption()),
            3 => StructuralComparisons.StructuralComparer.Compare(option, value),
            4 => StructuralComparisons.StructuralComparer.Compare(option, value.ToOption()),
            _ => option.CompareTo(value.ToOption())
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
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
    public void Equals(int? source, int? value, bool expectedResult, int overload)
    {
        var option = source.ToOption();
        var result = overload switch
        {
            1 => EqualityComparer<object>.Default.Equals(option, value),
            2 => EqualityComparer<object>.Default.Equals(option, value.ToOption()),
            3 => StructuralComparisons.StructuralEqualityComparer.Equals(option, value),
            4 => StructuralComparisons.StructuralEqualityComparer.Equals(option, value.ToOption()),
            _ => option.Equals(value.ToOption())
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, true, 0)]
    [TestCase(1, true, 1)]
    [TestCase(null, true, 0)]
    [TestCase(null, true, 1)]
    [TestCase(null, false, 0)]
    [TestCase(null, false, 1)]
    public void GetHashCode(object source, bool isSome, int overload)
    {
        var option = isSome
            ? Option<object>.Some(source)
            : Option<object>.None;
        var result = overload switch
        {
            1 => StructuralComparisons.StructuralEqualityComparer.GetHashCode(option),
            _ => option.GetHashCode()
        };
        var expectedResult = option.Match(x => x?.GetHashCode() ?? 1, 0);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, "Some(1)", true)]
    [TestCase(null, "Some(null)", true)]
    [TestCase(null, "None", false)]
    public void ToString(object source, string expectedResult, bool isSome)
    {
        var option = isSome
            ? Option<object>.Some(source)
            : Option<object>.None;

        option
            .ToString()
            .ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null)]
    [TestCase(1)]
    public void OP_Implicit(object source)
    {
        Option<object> option = source;

        option
            .Match(x => x.Equals(source), source.IsNull)
            .ShouldBeTrue();
    }

    [Test]
    [TestCase(null, 1, new int[0])]
    [TestCase(1, null, new int[0])]
    [TestCase(null, null, new int[0])]
    [TestCase(1, 1, new[] { 1 })]
    [TestCase(1, 2, new int[0])]
    [TestCase(2, 1, new int[0])]
    public void OP_BitwiseAnd(int? left, int? right, IEnumerable<int> expectedResult)
    {
        var option = left.ToOption() & right.ToOption();

        option.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, new[] { 1 })]
    [TestCase(1, null, new[] { 1 })]
    [TestCase(null, null, new int[0])]
    [TestCase(1, 1, new[] { 1 })]
    [TestCase(1, 2, new[] { 1 })]
    [TestCase(2, 1, new[] { 2 })]
    public void OP_BitwiseOr(int? left, int? right, IEnumerable<int> expectedResult)
    {
        var option = left.ToOption() | right.ToOption();

        option.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, false)]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    public void OP_LessThan(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() < right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, true)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, false)]
    public void OP_LessThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() <= right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    public void OP_GreaterThan(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() > right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, null, true)]
    [TestCase(null, null, true)]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, true)]
    public void OP_GreaterThanOrEqual(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() >= right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, null, false)]
    [TestCase(null, null, true)]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, false)]
    public void OP_Equality(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() == right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, true)]
    [TestCase(1, null, true)]
    [TestCase(null, null, false)]
    [TestCase(1, 1, false)]
    [TestCase(1, 2, true)]
    [TestCase(2, 1, true)]
    public void OP_Inequality(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() != right.ToOption();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, false)]
    [TestCase(1, true)]
    public void OP_True(int? source, bool expectedResult)
    {
        var result = source.ToOption()
            ? true
            : false;

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, null, false)]
    [TestCase(null, null, false)]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(2, 1, false)]
    public void OP_False(int? left, int? right, bool expectedResult)
    {
        var result = left.ToOption() && right.ToOption()
            ? true
            : false;

        result.ShouldBe(expectedResult);
    }

    #endregion
}
