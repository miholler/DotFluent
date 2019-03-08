using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
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
                Body = new MessageBody()
                {
                    Text = "Hello world!"
                }
            });
            _messages.Add(new Message()
            {
                Id = 2,
                Subject = "Message 2",
                Body = new MessageBody()
                {
                    Text = "Hello from world!"
                }
            });
            _messages.Add(new Message()
            {
                Id = 3,
                Subject = "Message 3",
                Body = new MessageBody()
                {
                    Text = "Hello"
                }
            });
            _messages.Add(new Message()
            {
                Id = 4,
                Subject = "Message 3",
                Body = new MessageBody()
                {
                    Text = "World!"
                }
            });
        }

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<Message> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.GroupBy(x => x.Id, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
        }

        [TestMethod]
        public void KeySelectorNullThrowsException()
        {
            Func<Message, int> keySelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(keySelector, x => x.Body, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
        }

        [TestMethod]
        public void ElementSelectorNullThrowsException()
        {
            Func<Message, MessageBody> elementSelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, elementSelector, (k, ie) => ie.FirstOrDefault(), (x, y) => x == y));
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, (Func<int, IEnumerable<Message>, Message>)null, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => _messages.GroupBy(x => x.Id, x => x.Body, (Func<int, IEnumerable<MessageBody>, MessageBody>)null, (x, y) => x == y));
        }

        [TestMethod]
        public void GroupBy()
        {
            var results = _messages.GroupBy(x => x.Subject, (x, y) => x.IsEqualTo(y)).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(string.Join(' ', group.Select(x => x.Body.Text).ToArray()), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (x, y) => x.IsEqualTo(y)).ToArray();
            var group = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsNotNull(group);
            Assert.AreEqual(string.Join(' ', group.Select(x => x.Text).ToArray()), "Hello World!");
        }

        [TestMethod]
        public void GroupByWithResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, (k, ie) => string.Join(' ', ie.Select(x => x.Body.Text).ToArray()), (x, y) => x.IsEqualTo(y)).ToArray();
            var body = results.LastOrDefault();

            Assert.IsTrue(results.Length == 3);
            Assert.IsTrue(body.IsNotNullOrEmpty());
            Assert.AreEqual(body, "Hello World!");
        }

        [TestMethod]
        public void GroupByWithElementAndResultSelector()
        {
            var results = _messages.GroupBy(x => x.Subject, x => x.Body, (k, ie) => string.Join(' ', ie.Select(x => x.Text).ToArray()), (x, y) => x.IsEqualTo(y)).ToArray();
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

            public MessageBody Body { get; set; }

            #endregion
        }

        private sealed class MessageBody
        {
            #region Properties

            public string Text { get; set; }

            #endregion
        }

        #endregion
    }
}
