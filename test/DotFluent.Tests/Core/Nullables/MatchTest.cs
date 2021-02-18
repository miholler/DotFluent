using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableMatchTest
    {
        #region Methods

        [TestMethod]
        public void NoneNullThrowsException()
        {
            var source = new int?();
            Action none = null;
            Func<int?> noneFunc = null;

            source.Invoking(x => x.Match(none)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.Match(x => { x++; }, none)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.Match(x => x++, noneFunc)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void SomeNullThrowsException()
        {
            var source = new int?();
            Action<int> some = null;
            Func<int, int> someFunc = null;

            source.Invoking(x => x.Match(some)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.Match(some, () => { })).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.Match(someFunc, 0)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.Match(someFunc, () => 0)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void MatchNone()
        {
            var invoked = false;
            var source = new int?();

            source.Match(() => invoked = true);

            invoked.ShouldBeTrue();
        }

        [TestMethod]
        public void MatchSome()
        {
            var invoked = false;
            var source = new int?(1);

            source.Match(x => invoked = x == 1);

            invoked.ShouldBeTrue();
        }

        [TestMethod]
        [DataRow(null, 1, -1, -1)]
        [DataRow(1, 1, -1, 2)]
        public void MatchWithActions(int? source, int some, int none, int expectedResult)
        {
            var result = 0;
            source.Match(x => { result = x + some; }, () => { result = none; });

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, 1, -1, -1)]
        [DataRow(1, 1, -1, 2)]
        public void MatchWithFuncAndValue(int? source, int some, int none, int expectedResult)
            => source.Match(x => x + some, none).ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, 1, -1, -1)]
        [DataRow(1, 1, -1, 2)]
        public void MatchWithFuncs(int? source, int some, int none, int expectedResult)
            => source.Match(x => x + some, () => none).ShouldBe(expectedResult);

        #endregion
    }
}
