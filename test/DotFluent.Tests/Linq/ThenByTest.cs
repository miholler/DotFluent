using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class ThenByTest
    {
        #region Fields

        private static readonly List<(int Order, bool IsActive)> _items = new List<(int Order, bool IsActive)>();

        #endregion

        #region Methods

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _items.Add((2, false));
            _items.Add((3, false));
            _items.Add((1, true));
            _items.Add((2, true));
            _items.Add((1, false));
        }

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<(int, bool)> items = null;

            Assert.ThrowsException<ArgumentNullException>(() => items.OrderBy(x => x.Item1).ThenBy(x => x.Item2, (x, y) => 0));
        }

        [TestMethod]
        public void ComparisonNullThrowsException()
        {
            Comparison<bool> comparison = null;

            Assert.ThrowsException<ArgumentNullException>(() => _items.OrderBy(x => x.Order).ThenBy(x => x.IsActive, comparison));
        }

        [TestMethod]
        public void ThenBy()
        {
            var isEqual = _items
                .OrderBy(x => x.Order)
                .ThenBy(x => x.IsActive, (x, y) => x == y ? 0 : x == false ? 1 : -1)
                .Select(x => x.IsActive)
                .SequenceEqual(new[] { true, false, true, false, false });

            Assert.IsTrue(isEqual);
        }

        #endregion
    }
}
