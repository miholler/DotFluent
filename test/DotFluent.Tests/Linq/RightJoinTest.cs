using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class RightJoinTest
    {
        #region Methods

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(new int[0], null)]
        public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
        {
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.RightJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void OuterKeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.RightJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void InnerKeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int, int> resultSelector = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, resultSelector)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, resultSelector, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, resultSelector, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, resultSelector, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, resultSelector)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, resultSelector, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, resultSelector, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, resultSelector, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            EqualityComparison<int> comparison = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparison)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparison, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparison)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparison, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HashCodeSelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> hashCodeSelector = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeSelector)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeSelector)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void RightJoin(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(b, b, d);
            var inner = Sequence.Create(a, b, c);

            var result = overload switch
            {
                1 => outer.RightJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i)),
                _ => outer.RightJoin(inner, x => x.Id, (o, i) => (o, i))
            };
            result.ShouldBe(
                (default, a),
                (b, b),
                (b, b),
                (default, c));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void RightJoinWithComparison(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(b, b, d);
            var inner = Sequence.Create(a, b, c);

            var result = overload switch
            {
                1 => outer.RightJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y),
                _ => outer.RightJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y)
            };
            result.ShouldBe(
                (default, a),
                (b, b),
                (b, b),
                (default, c));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void RightJoinWithHashCode(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(b, b, d);
            var inner = Sequence.Create(a, b, c);
            var hash = GetHashCode();

            var result = overload switch
            {
                1 => outer.RightJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode() ^ hash),
                _ => outer.RightJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode() ^ hash)
            };
            result.ShouldBe(
                (default, a),
                (b, b),
                (b, b),
                (default, c));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void RightJoinWithEqualityComparer(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(b, b, d);
            var inner = Sequence.Create(a, b, c);

            var result = overload switch
            {
                1 => outer.RightJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default),
                _ => outer.RightJoin(inner, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default)
            };
            result.ShouldBe(
                (default, a),
                (b, b),
                (b, b),
                (default, c));
        }

        #endregion
    }
}
