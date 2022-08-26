using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ToLookupTest
    {
        #region Fields

        private static readonly List<Person> _persons = new List<Person>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
        {
            _persons.Add(new Person()
            {
                Id = 1,
                CountryId = 1,
                Name = "Person One"
            });
            _persons.Add(new Person()
            {
                Id = 2,
                CountryId = 1,
                Name = "Person Two"
            });
            _persons.Add(new Person()
            {
                Id = 3,
                CountryId = 2,
                Name = "Person Three"
            });
        }

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<Person> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ToLookup(x => x.CountryId, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.ToLookup(x => x.CountryId, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => source.ToLookup(x => x.CountryId, x => x.Name, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.ToLookup(x => x.CountryId, x => x.Name, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            Func<Person, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(keySelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(keySelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(keySelector, x => x.Name, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(keySelector, x => x.Name, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ElementSelectorNullThrowsException()
        {
            Func<Person, string> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, elementSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, elementSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, comparer));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, comparer, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, x => x.Name, comparer));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, x => x.Name, comparer, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, (x, y) => x == y, hashCodeProvider));
            Assert.Throws<ArgumentNullException>(() => _persons.ToLookup(x => x.CountryId, x => x.Name, (x, y) => x == y, hashCodeProvider));
        }

        [Test]
        public void ToLookup()
        {
            var lookup = _persons.ToLookup(x => x.CountryId, (x, y) => x == y);

            Assert.IsTrue(lookup.IsNotNullNorEmpty() && lookup.Count == 2 && _persons.All(x => lookup[x.CountryId].Any(y => y.Name == x.Name)));
        }

        [Test]
        public void ToLookupWithHashCode()
        {
            var hash = GetHashCode();
            var lookup = _persons.ToLookup(x => x.CountryId, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(lookup.IsNotNullNorEmpty() && lookup.Count == 2 && _persons.All(x => lookup[x.CountryId].Any(y => y.Name == x.Name)));
        }

        [Test]
        public void ToLookupWithElementSelector()
        {
            var lookup = _persons.ToLookup(x => x.CountryId, x => x.Name, (x, y) => x == y);

            Assert.IsTrue(lookup.IsNotNullNorEmpty() && lookup.Count == 2 && _persons.All(x => lookup[x.CountryId].Contains(x.Name)));
        }

        [Test]
        public void ToLookupWithElementSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var lookup = _persons.ToLookup(x => x.CountryId, x => x.Name, (x, y) => x == y, x => x.GetHashCode() ^ hash);

            Assert.IsTrue(lookup.IsNotNullNorEmpty() && lookup.Count == 2 && _persons.All(x => lookup[x.CountryId].Contains(x.Name)));
        }

        #endregion

        #region Nested Classes

        private sealed class Person
        {
            #region Properties

            public int Id { get; set; }

            public int CountryId { get; set; }

            public string Name { get; set; }

            #endregion
        }

        #endregion
    }
}
