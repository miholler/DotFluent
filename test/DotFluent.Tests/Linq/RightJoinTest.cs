using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestClass]
    public sealed class RightJoinTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(new int[0], null)]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int, bool> comparer = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparer)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, comparer, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparer)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, comparer, x => x.GetHashCode())).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            var outer = Enumerable.Empty<int>();
            var inner = Enumerable.Empty<int>();
            Func<int, int> hashCodeProvider = null;

            outer.Invoking(x => x.RightJoin(inner, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeProvider)).ShouldThrow<ArgumentNullException>();
            outer.Invoking(x => x.RightJoin(inner, x => x, x => x, (o, i) => new { Outer = o, Inner = i }, (x, y) => x == y, hashCodeProvider)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
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

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void RightJoinWithComparer(int overload)
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

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
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

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
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
