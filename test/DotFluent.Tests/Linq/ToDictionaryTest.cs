using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ToDictionaryTest
    {
        #region Fields

        private static readonly List<(int Id, string Name)> _items = new List<(int Id, string Name)>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
        {
            _items.Add((1, "Item One"));
            _items.Add((2, "Item Two"));
            _items.Add((3, "Item Three"));
        }

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<(int, string)> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, x => x.Item2, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(x => x.Item1, x => x.Item2, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            Func<(int Id, string Name), int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(keySelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(keySelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(keySelector, x => x.Name, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(keySelector, x => x.Name, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ElementSelectorNullThrowsException()
        {
            Func<(int Id, string Name), string> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, elementSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, elementSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            EqualityComparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, comparison));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, comparison, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, comparison));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, comparison, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeSelectorNullThrowsException()
        {
            Func<int, int> hashCodeSelector = null;

            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, (x, y) => x == y, hashCodeSelector));
            Assert.Throws<ArgumentNullException>(() => _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y, hashCodeSelector));
        }

        [Test]
        public void ToDictionary()
        {
            var keys = _items.Select(x => x.Id).ToArray();
            var dict = _items.ToDictionary(x => x.Id, (x, y) => x == y);

            Assert.IsTrue(dict.IsNotNullNorEmpty() && dict.Keys.SequenceEqual(keys));
        }

        [Test]
        public void ToDictionaryWithHasCode()
        {
            var hash = GetHashCode();
            var keys = _items.Select(x => x.Id).ToArray();
            var dict = _items.ToDictionary(x => x.Id, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(dict.IsNotNullNorEmpty() && dict.Keys.SequenceEqual(keys));
        }

        [Test]
        public void ToDictionaryWithElementSelector()
        {
            var keys = _items.Select(x => x.Id).ToArray();
            var names = _items.Select(x => x.Name).ToArray();
            var dict = _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y);

            Assert.IsTrue(dict.IsNotNullNorEmpty() && dict.Keys.SequenceEqual(keys) && dict.Values.SequenceEqual(names));
        }

        [Test]
        public void ToDictionaryWithElementSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var keys = _items.Select(x => x.Id).ToArray();
            var names = _items.Select(x => x.Name).ToArray();
            var dict = _items.ToDictionary(x => x.Id, x => x.Name, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(dict.IsNotNullNorEmpty() && dict.Keys.SequenceEqual(keys) && dict.Values.SequenceEqual(names));
        }

        #endregion
    }
}
