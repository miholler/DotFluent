using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent
{
    [TestClass]
    public sealed class DictionaryGetOrAddTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IDictionary<int, int> source = null;

            source.Invoking(x => x.GetOrAdd(1, 1)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.GetOrAdd(1, k => 1)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void KeyNullThrowsException()
        {
            var source = new Dictionary<object, int>();

            source.Invoking(x => x.GetOrAdd(null, 1)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.GetOrAdd(null, k => 1)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ValueFactoryNullThrowsException()
        {
            var source = new Dictionary<int, int>();
            Func<int, int> valueFactory = null;

            source.Invoking(x => x.GetOrAdd(1, valueFactory)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(0, 1, 2, false)]
        [DataRow(1, 1, 2, false)]
        [DataRow(0, 1, 2, true)]
        [DataRow(1, 1, 2, true)]
        public void GetOrAdd(int overload, int key, int value, bool isExisting)
        {
            var source = isExisting ? new Dictionary<int, int>() { { key, value } } : new Dictionary<int, int>();
            var result = overload switch
            {
                1 => source.GetOrAdd(key, k => value),
                _ => source.GetOrAdd(key, value)
            };
            result.ShouldBe(value);
        }

        #endregion
    }
}
