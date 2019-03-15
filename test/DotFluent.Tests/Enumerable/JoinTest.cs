using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class JoinTest
    {
        #region Fields

        private static readonly List<Publisher> _publishers = new List<Publisher>();
        private static readonly List<Author> _authors = new List<Author>();

        #endregion

        #region Methods

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _publishers.Add(new Publisher()
            {
                Id = 1,
                Name = "Publisher One"
            });
            _publishers.Add(new Publisher()
            {
                Id = 2,
                Name = "Publisher Two"
            });
            _publishers.Add(new Publisher()
            {
                Id = 3,
                Name = "Publisher Three"
            });
            _authors.Add(new Author()
            {
                Id = 1,
                PublisherId = 1,
                Name = "Author One"
            });
            _authors.Add(new Author()
            {
                Id = 2,
                PublisherId = 2,
                Name = "Author Two"
            });
        }

        [TestMethod]
        public void OuterNullThrowsException()
        {
            IEnumerable<Publisher> publishers = null;

            Assert.ThrowsException<ArgumentNullException>(() => publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void InnerNullThrowsException()
        {
            IEnumerable<Author> authors = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void OuterKeySelectorNullThrowsException()
        {
            Func<Publisher, int> keySelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, keySelector, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, keySelector, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void InnerKeySelectorNullThrowsException()
        {
            Func<Author, int> keySelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, keySelector, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, keySelector, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            Func<Publisher, Author, object> resultSelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, resultSelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, resultSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, comparer, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.ThrowsException<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, hashCodeProvider));
        }

        [TestMethod]
        public void Join()
        {
            var results = _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y).ToArray();
            Assert.IsTrue(results.Length == 2);

            foreach (var result in results)
                Assert.IsTrue(result.Publisher.Id == result.Author.PublisherId);
        }

        [TestMethod]
        public void JoinWithHashCode()
        {
            var hash = GetHashCode();
            var results = _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode() ^ hash).ToArray();
            Assert.IsTrue(results.Length == 2);

            foreach (var result in results)
                Assert.IsTrue(result.Publisher.Id == result.Author.PublisherId);
        }

        #endregion

        #region Nested Classes

        private sealed class Publisher
        {
            #region Properties

            public int Id { get; set; }

            public string Name { get; set; }

            #endregion
        }

        private sealed class Author
        {
            #region Properties

            public int Id { get; set; }

            public int PublisherId { get; set; }

            public string Name { get; set; }

            #endregion
        }

        #endregion
    }
}
