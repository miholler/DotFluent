using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class ToDictionaryTest
    {
        #region Fields

        private static readonly List<(int Id, string Name)> _items = new List<(int Id, string Name)>();

        #endregion

        #region Methods

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _items.Add((1, "Item One"));
            _items.Add((2, "Item Two"));
            _items.Add((3, "Item Three"));
        }

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<(int, string)> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, x => x.Item2, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, x => x.Item2, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void KeySelectorNullThrowsException()
        {
            Func<(int Id, string Name), int> keySelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(keySelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(keySelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(keySelector, x => x.Name, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(keySelector, x => x.Name, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ElementSelectorNullThrowsException()
        {
            Func<(int Id, string Name), string> elementSelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, elementSelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, elementSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, comparer, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, comparer, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, (x, y) => x == y, hashCodeProvider));
            Assert.ThrowsException<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y, hashCodeProvider));
        }

        [TestMethod]
        public void ToDictionary()
        {
            var keys = _items.Select(x => x.Id).ToArray();
            var dict = _items.ToDictionary(x => x.Id, (x, y) => x == y);

            Assert.IsTrue(dict.IsNotNullOrEmpty() && dict.Keys.SequenceEqual(keys));
        }

        [TestMethod]
        public void ToDictionaryWithHasCode()
        {
            var hash = GetHashCode();
            var keys = _items.Select(x => x.Id).ToArray();
            var dict = _items.ToDictionary(x => x.Id, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(dict.IsNotNullOrEmpty() && dict.Keys.SequenceEqual(keys));
        }

        [TestMethod]
        public void ToDictionaryWithElementSelector()
        {
            var keys = _items.Select(x => x.Id).ToArray();
            var names = _items.Select(x => x.Name).ToArray();
            var dict = _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y);

            Assert.IsTrue(dict.IsNotNullOrEmpty() && dict.Keys.SequenceEqual(keys) && dict.Values.SequenceEqual(names));
        }

        [TestMethod]
        public void ToDictionaryWithElementSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var keys = _items.Select(x => x.Id).ToArray();
            var names = _items.Select(x => x.Name).ToArray();
            var dict = _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(dict.IsNotNullOrEmpty() && dict.Keys.SequenceEqual(keys) && dict.Values.SequenceEqual(names));
        }

        #endregion
    }
}
