using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Collections.Dictionaries
{
    [TestClass]
    public sealed class TryAddTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IDictionary<int, int> source = null;

            source.Invoking(x => x.TryAdd(1, 1)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void KeyNullThrowsException()
        {
            var source = new Dictionary<object, int>();

            source.Invoking(x => x.TryAdd(null, 1)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(1, 2, false, true)]
        [DataRow(1, 2, true, false)]
        public void TryAdd(int key, int value, bool isExisting, bool expectedResult)
        {
            var source = isExisting ? new Dictionary<int, int>() { { key, value } } : new Dictionary<int, int>();

            source.TryAdd(key, value).ShouldBe(expectedResult);
        }

        #endregion
    }
}
