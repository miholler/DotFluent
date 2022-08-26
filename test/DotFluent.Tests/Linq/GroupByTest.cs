using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class GroupByTest
    {
        #region Fields

        private static readonly List<Message> _messages = new List<Message>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
        {
            _messages.Add(new Message()
            {
                Id = 1,
                Subject = "Message 1",
                Body = "Hello world!"
            });
            _messages.Add(new Message()
            {
                Id = 2,
                Subject = "Message 2",
                Body = "Hello from world!"
            });
            _messages.Add(new Message()
            {
                Id = 3,
                Subject = "Message 3",
                Body = "Hello"
            });
            _messages.Add(new Message()
            {
                Id = 4,
                Subject = "Message 3",
                Body = "World!"
            });
        }

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<Message> source = null;

            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            Func<Message, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ElementSelectorNullThrowsException()
        {
            Func<Message, string> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (Func<int, IEnumerable<Message>, Message>)null, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (Func<int, IEnumerable<Message>, Message>)null, (x, y) => x == y, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (Func<int, IEnumerable<string>, string>)null, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (Func<int, IEnumerable<string>, string>)null, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, comparer));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, comparer, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, comparer));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, comparer, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), comparer));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), comparer, x => x.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), comparer));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), comparer, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (x, y) => x == y, hashCodeProvider));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y, hashCodeProvider));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, hashCodeProvider));
            Assert.Throws<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, hashCodeProvider));
        }

        [Test]
        public void GroupBy()
        {
            static bool comparer(string x, string y) => x.IsEqualTo(y);
            var results = _messages.GroupBy(x => x.Subject, comparer).ToArray();
            var group = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [Test]
        public void GroupByWithHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var group = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [Test]
        public void GroupByWithElementSelector()
        {
            static bool comparer(string x, string y) => x.IsEqualTo(y);
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, comparer).ToArray();
            var group = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [Test]
        public void GroupByWithElementSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var group = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [Test]
        public void GroupByWithResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, (k, ie) => ie.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y)).ToArray();
            var body = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsTrue(body.IsNotNullNorEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [Test]
        public void GroupByWithResultSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, (k, ie) => ie.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var body = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsTrue(body.IsNotNullNorEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [Test]
        public void GroupByWithElementAndResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (k, ie) => ie.Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y)).ToArray();
            var body = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsTrue(body.IsNotNullNorEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [Test]
        public void GroupByWithElementAndResultSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (k, ie) => ie.Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var body = results.LastOrDefault();

            Assert.AreEqual(results.Length, 3);
            Assert.IsTrue(body.IsNotNullNorEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        #endregion

        #region Nested Classes

        private sealed class Message
        {
            #region Properties

            public int Id { get; set; }

            public string Subject { get; set; }

            public string Body { get; set; }

            #endregion
        }

        #endregion
    }
}
