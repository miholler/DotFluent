using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class GroupByTest
    {
        #region Fields

        private static readonly List<Message> _messages = new List<Message>();

        #endregion

        #region Methods

        [ClassInitialize]
        public static void Initialize(TestContext context)
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

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<Message> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void KeySelectorNullThrowsException()
        {
            Func<Message, int> keySelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ElementSelectorNullThrowsException()
        {
            Func<Message, string> elementSelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (Func<int, IEnumerable<Message>, Message>)null, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (Func<int, IEnumerable<Message>, Message>)null, (x, y) => x == y, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (Func<int, IEnumerable<string>, string>)null, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (Func<int, IEnumerable<string>, string>)null, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, comparer, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, comparer, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), comparer, x => x.GetHashCode()));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), comparer));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), comparer, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (x, y) => x == y, hashCodeProvider));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y, hashCodeProvider));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, hashCodeProvider));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y, hashCodeProvider));
        }

        [TestMethod]
        public void GroupBy()
        {
            bool comparer(string x, string y) => x.IsEqualTo(y);
            var results = _messages.GroupBy(x => x.Subject, comparer).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementSelector()
        {
            bool comparer(string x, string y) => x.IsEqualTo(y);
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, comparer).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Aggregate((x, y) => $"{x} {y}"), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, (k, ie) => ie.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y)).ToArray();
            var body = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsTrue(body.IsNotNullOrEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [TestMethod]
        public void GroupByWithResultSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, (k, ie) => ie.Select(x => x.Body).Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var body = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsTrue(body.IsNotNullOrEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementAndResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (k, ie) => ie.Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y)).ToArray();
            var body = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsTrue(body.IsNotNullOrEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementAndResultSelectorAndHashCode()
        {
            var hash = GetHashCode();
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (k, ie) => ie.Aggregate((x, y) => $"{x} {y}"), (x, y) => x.IsEqualTo(y), x => x.GetHashCode() ^ hash).ToArray();
            var body = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsTrue(body.IsNotNullOrEmpty());
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
