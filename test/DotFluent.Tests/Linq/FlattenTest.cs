using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class FlattenTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<IEnumerable<int>> source = null;
            IEnumerable<TreeItem> treeSource = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Flatten());
            Assert.ThrowsException<ArgumentNullException>(() => treeSource.Flatten(x => x.Children));
        }

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var source = new List<TreeItem>();
            Func<TreeItem, IEnumerable<TreeItem>> selector = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Flatten(selector));
        }

        [TestMethod]
        public void Flatten()
        {
            var source = new List<int[]>();

            Assert.IsTrue(source.Flatten().SequenceEqual(new int[0]));

            source.AddRange(Sequence.Create(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 }));

            Assert.IsTrue(source.Flatten().SequenceEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }

        [TestMethod]
        public void FlattenWithSelector()
        {
            var source = new List<TreeItem>();

            Assert.IsTrue(source.Flatten(x => x.Children).SequenceEqual(Sequence.Create<TreeItem>()));

            source.AddRange(Sequence.Create(
                new TreeItem()
                {
                    Id = 1,
                    Children = new List<TreeItem>(Sequence.Create(
                        new TreeItem()
                        {
                            Id = 2,
                            Children = new List<TreeItem>(Sequence.Create(
                                new TreeItem()
                                {
                                    Id = 3
                                }))
                        }))
                },
                new TreeItem()
                {
                    Id = 4,
                    Children = new List<TreeItem>(Sequence.Create(
                        new TreeItem()
                        {
                            Id = 5
                        },
                        new TreeItem()
                        {
                            Id = 6
                        }))
                }));

            Assert.IsTrue(source.Flatten(x => x.Children).Select(x => x.Id).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
        }

        #endregion

        #region Nested Classes

        private sealed class TreeItem
        {
            #region Properties

            public int Id { get; set; }

            public IEnumerable<TreeItem> Children { get; set; }

            #endregion
        }

        #endregion
    }
}
