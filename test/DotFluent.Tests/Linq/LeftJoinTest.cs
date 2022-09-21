using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class LeftJoinTest
    {
        #region Methods

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(new int[0], null)]
        public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
        {
            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.LeftJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void OuterKeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.LeftJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, keySelector, x => x, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void InnerKeySelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            outer.Invoking(x => x.LeftJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i })).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int, int> resultSelector = null;

            outer.Invoking(x => x.LeftJoin(inner, x => x, resultSelector)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, resultSelector, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, resultSelector, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, resultSelector, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, resultSelector)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, resultSelector, (x, y) => x == y)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, resultSelector, (x, y) => x == y, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, resultSelector, EqualityComparer<int>.Default)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int, bool> comparer = null;

            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparer)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparer, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparer)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparer, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> hashCodeProvider = null;

            outer.Invoking(x => x.LeftJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeProvider)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.LeftJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeProvider)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void LeftJoin(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(a, b, c);
            var inner = Sequence.Create(b, b, d);

            var result = overload switch
            {
                1 => outer.LeftJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i)),
                _ => outer.LeftJoin(inner, x => x.Id, (o, i) => (o, i))
            };
            result.ShouldBe(
                (a, default),
                (b, b),
                (b, b),
                (c, default));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void LeftJoinWithComparer(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(a, b, c);
            var inner = Sequence.Create(b, b, d);

            var result = overload switch
            {
                1 => outer.LeftJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y),
                _ => outer.LeftJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y)
            };
            result.ShouldBe(
                (a, default),
                (b, b),
                (b, b),
                (c, default));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void LeftJoinWithHashCode(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(a, b, c);
            var inner = Sequence.Create(b, b, d);
            var hash = GetHashCode();

            var result = overload switch
            {
                1 => outer.LeftJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode() ^ hash),
                _ => outer.LeftJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode() ^ hash)
            };
            result.ShouldBe(
                (a, default),
                (b, b),
                (b, b),
                (c, default));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void LeftJoinWithEqualityComparer(int overload)
        {
            var a = (Id: 1, Name: "A");
            var b = (Id: 2, Name: "B");
            var c = (Id: 3, Name: "C");
            var d = (Id: 4, Name: "D");
            var outer = Sequence.Create(a, b, c);
            var inner = Sequence.Create(b, b, d);

            var result = overload switch
            {
                1 => outer.LeftJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default),
                _ => outer.LeftJoin(inner, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default)
            };
            result.ShouldBe(
                (a, default),
                (b, b),
                (b, b),
                (c, default));
        }

        #endregion
    }
}
