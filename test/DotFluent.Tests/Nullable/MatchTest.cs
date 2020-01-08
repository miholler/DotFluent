using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullable
{
    [TestClass]
    public sealed class MatchTest
    {
        #region Methods

        [TestMethod]
        public void NoneNullThrowsException()
        {
            var nullable = new int?();
            Action none = null;
            Func<int?> noneFunc = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(none));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(x => { x++; }, none));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(x => x++, noneFunc));
        }

        [TestMethod]
        public void SomeNullThrowsException()
        {
            var nullable = new int?();
            Action<int> some = null;
            Func<int, int> someFunc = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(some));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(some, () => { }));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(someFunc, 5));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.Match(someFunc, () => 5));
        }

        [TestMethod]
        public void MatchNone()
        {
            var invoked = false;
            var nullable = new int?();

            nullable.Match(() => invoked = true);

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void MatchSome()
        {
            var invoked = false;
            var nullable = new int?(1);

            nullable.Match(x => invoked = x == 1);

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void MatchWithActions()
        {
            var someInvoked = false;
            var noneInvoked = false;
            var nullable = new int?();

            nullable.Match(x => { noneInvoked = false; }, () => { noneInvoked = true; });
            Assert.IsTrue(noneInvoked);

            nullable = 1;
            nullable.Match(x => { someInvoked = x == 1; }, () => { someInvoked = false; });
            Assert.IsTrue(someInvoked);
        }

        [TestMethod]
        public void MatchWithFuncAndValue()
        {
            var nullable = new int?();
            var result = nullable.Match(x => x, -1);
            Assert.AreEqual(result, -1);

            nullable = 1;
            result = nullable.Match(x => x, -1);
            Assert.AreEqual(result, nullable.Value);            
        }

        [TestMethod]
        public void MatchWithFuncs()
        {
            var nullable = new int?();
            var result = nullable.Match(x => x, () => -1);
            Assert.AreEqual(result, -1);

            nullable = 1;
            result = nullable.Match(x => x, () => -1);
            Assert.AreEqual(result, nullable.Value);            
        }

        #endregion
    }
}
