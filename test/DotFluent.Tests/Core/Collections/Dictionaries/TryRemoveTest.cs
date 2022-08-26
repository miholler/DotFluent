using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent
{
    [TestFixture]
    public sealed class DictionaryTryRemoveTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IDictionary<int, int> source = null;

            source.Invoking(x => x.TryRemove(1, out var value)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void KeyNullThrowsException()
        {
            var source = new Dictionary<object, int>();

            source.Invoking(x => x.TryRemove(null, out var value)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(1, 2, false, false, 0)]
        [TestCase(1, 2, true, true, 2)]
        public void TryRemove(int key, int value, bool isExisting, bool expectedResult, int expectedValue)
        {
            var source = isExisting ? new Dictionary<int, int>() { { key, value } } : new Dictionary<int, int>();
            var result = source.TryRemove(key, out var removedValue);

            (result, removedValue).ShouldBe((expectedResult, expectedValue));
        }

        #endregion
    }
}
