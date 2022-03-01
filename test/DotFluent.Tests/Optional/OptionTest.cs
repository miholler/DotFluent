using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class OptionTest
    {
        #region Methods

        [TestMethod]
        public void SomeValueReturnsValue()
            => Option<int>.Some(1).Value.ShouldBe(1);

        [TestMethod]
        public void NoneValueThrowsException()
            => Option<int>.None.Invoking(x => x.Value).ShouldThrow<InvalidOperationException>();

        [TestMethod]
        public void IsSome()
        {
            var option = Option<int>.Some(1);

            option.IsSome.ShouldBeTrue();
            option.IsNone.ShouldBeFalse();
        }

        [TestMethod]
        public void IsNone()
        {
            var option = Option<int>.None;

            option.IsSome.ShouldBeFalse();
            option.IsNone.ShouldBeTrue();
        }

        [TestMethod]
        public void MatchNoneNullThrowsException()
        {
            var option = Option<int>.None;
            Action none = null;
            Func<int> noneFunc = null;

            option.Invoking(x => x.Match(none)).ShouldThrow<ArgumentNullException>();
            option.Invoking(x => x.Match(x => { x++; }, none)).ShouldThrow<ArgumentNullException>();
            option.Invoking(x => x.Match(x => x++, noneFunc)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void MatchSomeNullThrowsException()
        {
            var option = Option<int>.Some(0);
            Action<int> some = null;
            Func<int, int> someFunc = null;

            option.Invoking(x => x.Match(some)).ShouldThrow<ArgumentNullException>();
            option.Invoking(x => x.Match(some, () => { })).ShouldThrow<ArgumentNullException>();
            option.Invoking(x => x.Match(someFunc, 0)).ShouldThrow<ArgumentNullException>();
            option.Invoking(x => x.Match(someFunc, () => 0)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, 1, 0)]
        [DataRow(1, 0, 0, 0)]
        [DataRow(null, 0, 0, 1)]
        [DataRow(1, 1, 2, 1)]
        [DataRow(1, 1, 2, 2)]
        [DataRow(null, 1, 1, 2)]
        [DataRow(1, 1, 2, 3)]
        [DataRow(null, 1, 1, 3)]
        [DataRow(1, 1, 2, 4)]
        [DataRow(null, 1, 1, 4)]
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

        [TestMethod]
        public void MapMapperNullThrowsException()
        {
            var option = Option<int>.None;
            Func<int, int> mapper = null;

            option.Invoking(x => x.Map(mapper)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 2 })]
        public void Map(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .Map(x => ++x)
                .ShouldBe(expectedResult);

        [TestMethod]
        public void FlatMapMapperNullThrowsException()
        {
            var option = Option<int>.None;
            Func<int, Option<int>> mapper = null;

            option.Invoking(x => x.FlatMap(mapper)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void FlatMap(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .FlatMap(x => Option<int>.Some(x))
                .ShouldBe(expectedResult);

        [TestMethod]
        public void OrElseOtherFactoryNullThrowsException()
        {
            var option = Option<int>.None;
            Func<Option<int>> otherFactory = null;

            option.Invoking(x => x.OrElse(otherFactory)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null, new int[0], 0)]
        [DataRow(null, null, new int[0], 1)]
        [DataRow(1, null, new[] { 1 }, 0)]
        [DataRow(1, null, new[] { 1 }, 1)]
        [DataRow(null, 1, new[] { 1 }, 0)]
        [DataRow(null, 1, new[] { 1 }, 1)]
        [DataRow(1, 2, new[] { 1 }, 0)]
        [DataRow(1, 2, new[] { 1 }, 1)]
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

        [TestMethod]
        public void FilterPredicateNullThrowsException()
        {
            var option = Option<int>.None;
            Func<int, bool> predicate = null;

            option.Invoking(x => x.Filter(predicate)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, new int[0])]
        [DataRow(1, 2, new int[0])]
        [DataRow(1, 1, new[] { 1 })]
        public void Filter(int? source, int value, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .Filter(x => x == value)
                .ShouldBe(expectedResult);

        [TestMethod]
        public void Secure()
        {
            var option = Option<object>.Some(null);

            option.Secure().ShouldBe(Option<object>.None);
        }

        [TestMethod]
        [DataRow(null, 0)]
        [DataRow(1, 1)]
        public void Count(int? source, int expectedResult)
            => source
                .ToOption()
                .Count()
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public void Contains(int? source, int value, bool expectedResult)
            => source
                .ToOption()
                .Contains(value)
                .ShouldBe(expectedResult);

        [TestMethod]
        public void ExistsPredicateNullThrowsException()
        {
            var option = Option<int>.None;
            Func<int, bool> predicate = null;

            option.Invoking(x => x.Exists(predicate)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public void Exists(int? source, int value, bool expectedResult)
            => source
                .ToOption()
                .Exists(x => x == value)
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
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

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(1, true)]
        public void GetEnumerator(int? source, bool expectedResult)
            => source
                .ToOption()
                .GetEnumerator()
                .MoveNext()
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void AsEnumerable(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .AsEnumerable()
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, 1, -1, 0)]
        [DataRow(null, 1, -1, 1)]
        [DataRow(1, null, 1, 0)]
        [DataRow(1, null, 1, 1)]
        [DataRow(null, null, 0, 0)]
        [DataRow(null, null, 0, 1)]
        [DataRow(1, 1, 0, 0)]
        [DataRow(1, 1, 0, 1)]
        [DataRow(1, 2, -1, 0)]
        [DataRow(1, 2, -1, 1)]
        [DataRow(2, 1, 1, 0)]
        [DataRow(2, 1, 1, 1)]
        public void CompareTo(int? source, int? value, int expectedResult, int overload)
        {
            var option = source.ToOption();
            var result = overload switch
            {
                1 => option.CompareTo(value.ToOption(), null),
                _ => option.CompareTo(value.ToOption())
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, true, -1, 0)]
        [DataRow(null, 1, true, -1, 1)]
        [DataRow(1, null, true, 1, 0)]
        [DataRow(1, null, true, 1, 1)]
        [DataRow(null, null, true, 0, 0)]
        [DataRow(null, null, true, 0, 1)]
        [DataRow(1, 1, true, 0, 0)]
        [DataRow(1, 1, true, 0, 1)]
        [DataRow(1, 2, true, -1, 0)]
        [DataRow(1, 2, true, -1, 1)]
        [DataRow(2, 1, true, 1, 0)]
        [DataRow(2, 1, true, 1, 1)]
        [DataRow(1, 1, false, 1, 0)]
        [DataRow(1, 1, false, 1, 1)]
        public void CompareToObject(int? source, int? value, bool isOption, int expectedResult, int overload)
        {
            var option = source.ToOption();
            var result = overload switch
            {
                1 => option.CompareTo(isOption ? value.ToOption() : value, null),
                _ => option.CompareTo(isOption ? value.ToOption() : value)
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, false, 0)]
        [DataRow(null, 1, false, 1)]
        [DataRow(1, null, false, 0)]
        [DataRow(1, null, false, 1)]
        [DataRow(null, null, true, 0)]
        [DataRow(null, null, true, 1)]
        [DataRow(1, 1, true, 0)]
        [DataRow(1, 1, true, 1)]
        [DataRow(1, 2, false, 0)]
        [DataRow(1, 2, false, 1)]
        [DataRow(2, 1, false, 0)]
        [DataRow(2, 1, false, 1)]
        public void Equals(int? source, int? value, bool expectedResult, int overload)
        {
            var option = source.ToOption();
            var result = overload switch
            {
                1 => option.Equals(value.ToOption(), null),
                _ => option.Equals(value.ToOption())
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, true, false, 0)]
        [DataRow(null, 1, true, false, 1)]
        [DataRow(1, null, true, false, 0)]
        [DataRow(1, null, true, false, 1)]
        [DataRow(null, null, true, true, 0)]
        [DataRow(null, null, true, true, 1)]
        [DataRow(1, 1, true, true, 0)]
        [DataRow(1, 1, true, true, 1)]
        [DataRow(1, 2, true, false, 0)]
        [DataRow(1, 2, true, false, 1)]
        [DataRow(2, 1, true, false, 0)]
        [DataRow(2, 1, true, false, 1)]
        [DataRow(1, 1, false, false, 0)]
        [DataRow(1, 1, false, false, 1)]
        public void EqualsObject(int? source, int? value, bool isOption, bool expectedResult, int overload)
        {
            var option = source.ToOption();
            var result = overload switch
            {
                1 => option.Equals(isOption ? value.ToOption() : value, null),
                _ => option.Equals(isOption ? value.ToOption() : value)
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(1, true, 0)]
        [DataRow(1, true, 1)]
        [DataRow(null, true, 0)]
        [DataRow(null, true, 1)]
        [DataRow(null, false, 0)]
        [DataRow(null, false, 1)]
        public void GetHashCode(object source, bool isSome, int overload)
        {
            var option = isSome ? Option<object>.Some(source) : Option<object>.None;
            var expectedResult = -1;
            var result = -2;

            switch (overload)
            {
                case 1:
                    expectedResult = option.Match(x => StructuralComparisons.StructuralEqualityComparer.GetHashCode(x), 0);
                    result = option.GetHashCode(null);
                    break;
                default:
                    expectedResult = option.Match(x => x?.GetHashCode() ?? 1, 0);
                    result = option.GetHashCode();
                    break;
            }

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(null, true)]
        [DataRow(null, false)]
        public void ToString(object source, bool isSome)
        {
            var option = isSome ? Option<object>.Some(source) : Option<object>.None;
            var result = option.Match(x => $"Some({x?.ToString() ?? "null"})", () => "None");
            option
                .ToString()
                .ShouldBe(result);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
        public void OP_Implicit(object source)
        {
            Option<object> option = source;
            option
                .Match(x => x.Equals(source), () => source.IsNull())
                .ShouldBeTrue();
        }

        [TestMethod]
        [DataRow(null, 1, new int[0])]
        [DataRow(1, null, new int[0])]
        [DataRow(null, null, new int[0])]
        [DataRow(1, 1, new[] { 1 })]
        [DataRow(1, 2, new int[0])]
        [DataRow(2, 1, new int[0])]
        public void OP_BitwiseAnd(int? left, int? right, IEnumerable<int> expectedResult)
        {
            var option = left.ToOption() & right.ToOption();
            option.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, new[] { 1 })]
        [DataRow(1, null, new[] { 1 })]
        [DataRow(null, null, new int[0])]
        [DataRow(1, 1, new[] { 1 })]
        [DataRow(1, 2, new[] { 1 })]
        [DataRow(2, 1, new[] { 2 })]
        public void OP_BitwiseOr(int? left, int? right, IEnumerable<int> expectedResult)
        {
            var option = left.ToOption() | right.ToOption();
            option.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, true)]
        [DataRow(1, null, false)]
        [DataRow(null, null, false)]
        [DataRow(1, 1, false)]
        [DataRow(1, 2, true)]
        [DataRow(2, 1, false)]
        public void OP_LessThan(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() < right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, true)]
        [DataRow(1, null, false)]
        [DataRow(null, null, true)]
        [DataRow(1, 1, true)]
        [DataRow(1, 2, true)]
        [DataRow(2, 1, false)]
        public void OP_LessThanOrEqual(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() <= right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, null, true)]
        [DataRow(null, null, false)]
        [DataRow(1, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(2, 1, true)]
        public void OP_GreaterThan(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() > right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, null, true)]
        [DataRow(null, null, true)]
        [DataRow(1, 1, true)]
        [DataRow(1, 2, false)]
        [DataRow(2, 1, true)]
        public void OP_GreaterThanOrEqual(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() >= right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, null, false)]
        [DataRow(null, null, true)]
        [DataRow(1, 1, true)]
        [DataRow(1, 2, false)]
        [DataRow(2, 1, false)]
        public void OP_Equality(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() == right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, true)]
        [DataRow(1, null, true)]
        [DataRow(null, null, false)]
        [DataRow(1, 1, false)]
        [DataRow(1, 2, true)]
        [DataRow(2, 1, true)]
        public void OP_Inequality(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() != right.ToOption();
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(1, true)]
        public void OP_True(int? source, bool expectedResult)
        {
            var result = source.ToOption() ? true : false;
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, null, false)]
        [DataRow(null, null, false)]
        [DataRow(1, 1, true)]
        [DataRow(1, 2, false)]
        [DataRow(2, 1, false)]
        public void OP_False(int? left, int? right, bool expectedResult)
        {
            var result = left.ToOption() && right.ToOption() ? true : false;
            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
