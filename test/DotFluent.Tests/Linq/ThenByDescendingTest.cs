using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ThenByDescendingTest
    {
        #region Fields

        private static readonly List<(int Order, bool IsActive)> _items = new List<(int Order, bool IsActive)>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
        {
            _items.Add((2, false));
            _items.Add((3, false));
            _items.Add((1, true));
            _items.Add((2, true));
            _items.Add((1, false));
        }

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<(int, bool)> items = null;

            Assert.Throws<ArgumentNullException>(() => items.OrderBy(x => x.Item1).ThenByDescending(x => x.Item2, (x, y) => 0));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var source = Enumerable.Empty<(int, bool)>();
            Func<(int, bool), bool> keySelector = null;

            source
                .Invoking(x => x
                    .OrderBy(x => x.Item1)
                    .ThenByDescending(keySelector, (x, y) => 0))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            Comparison<bool> comparison = null;

            Assert.Throws<ArgumentNullException>(() => _items.OrderBy(x => x.Order).ThenByDescending(x => x.IsActive, comparison));
        }

        [Test]
        public void ThenByDescending()
        {
            var isEqual = _items
                .OrderBy(x => x.Order)
                .ThenByDescending(x => x.IsActive, Comparer<bool>.Default.Compare)
                .Select(x => x.IsActive)
                .SequenceEqual(new[] { true, false, true, false, false });

            Assert.IsTrue(isEqual);
        }

        #endregion
    }
}
