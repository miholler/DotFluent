using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class JoinTest
    {
        #region Fields

        private static readonly List<Publisher> _publishers = new List<Publisher>();
        private static readonly List<Author> _authors = new List<Author>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
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

        [Test]
        public void OuterNullThrowsException()
        {
            IEnumerable<Publisher> publishers = null;

            Assert.Throws<ArgumentNullException>(() => publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }));
            Assert.Throws<ArgumentNullException>(() => publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, EqualityComparer<int>.Default));
            Assert.Throws<ArgumentNullException>(() => publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void InnerNullThrowsException()
        {
            IEnumerable<Publisher> publishers = null;
            IEnumerable<Author> authors = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(publishers, x => x.Id, (l, r) => new { Left = l, Right = r }));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, EqualityComparer<int>.Default));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            Func<Publisher, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, keySelector, (l, r) => new { Left = l, Right = r }));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, keySelector, (l, r) => new { Left = l, Right = r }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, keySelector, (l, r) => new { Left = l, Right = r }, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, keySelector, (l, r) => new { Left = l, Right = r }, EqualityComparer<int>.Default));
        }

        [Test]
        public void OuterKeySelectorNullThrowsException()
        {
            Func<Publisher, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, keySelector, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, keySelector, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void InnerKeySelectorNullThrowsException()
        {
            Func<Author, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, keySelector, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, keySelector, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            Func<Publisher, Publisher, object> resultSelector = null;
            Func<Publisher, Author, object> differentResultSelector = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, resultSelector));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, resultSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, resultSelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, resultSelector, EqualityComparer<int>.Default));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, differentResultSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, differentResultSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, comparer));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, comparer, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, comparer));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, comparer, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y, hashCodeProvider));
            Assert.Throws<ArgumentNullException>(() => _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, hashCodeProvider));
        }

        [Test]
        public void Join()
        {
            var results = _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }).ToArray();
            Assert.AreEqual(results.Length, 3);

            foreach (var result in results)
                Assert.AreEqual(result.Left.Id, result.Right.Id);
        }

        [Test]
        public void JoinWithComparer()
        {
            var results = _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y).ToArray();
            Assert.AreEqual(results.Length, 3);

            foreach (var result in results)
                Assert.AreEqual(result.Left.Id, result.Right.Id);
        }

        [Test]
        public void JoinWithHashCode()
        {
            var hash = GetHashCode();
            var results = _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, (x, y) => x == y, x => x.GetHashCode() ^ hash).ToArray();
            Assert.AreEqual(results.Length, 3);

            foreach (var result in results)
                Assert.AreEqual(result.Left.Id, result.Right.Id);
        }

        [Test]
        public void JoinWithEqualityComparer()
        {
            var results = _publishers.Join(_publishers, x => x.Id, (l, r) => new { Left = l, Right = r }, EqualityComparer<int>.Default).ToArray();
            Assert.AreEqual(results.Length, 3);

            foreach (var result in results)
                Assert.AreEqual(result.Left.Id, result.Right.Id);
        }

        [Test]
        public void JoinWithDifferentSourcesAndComparer()
        {
            var results = _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y).ToArray();
            Assert.AreEqual(results.Length, 2);

            foreach (var result in results)
                Assert.AreEqual(result.Publisher.Id, result.Author.PublisherId);
        }

        [Test]
        public void JoinWithDifferentSourcesAndHashCode()
        {
            var hash = GetHashCode();
            var results = _publishers.Join(_authors, x => x.Id, x => x.PublisherId, (p, a) => new { Publisher = p, Author = a }, (x, y) => x == y, x => x.GetHashCode() ^ hash).ToArray();
            Assert.AreEqual(results.Length, 2);

            foreach (var result in results)
                Assert.AreEqual(result.Publisher.Id, result.Author.PublisherId);
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
