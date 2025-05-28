using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableFlattenTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<IEnumerable<int>> source = null;
        IEnumerable<TreeItem> treeSource = null;

        source
            .Invoking(x => x.Flatten())
            .ShouldThrow<ArgumentNullException>();
        treeSource
            .Invoking(x => x.Flatten(y => y.Children))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var source = Enumerable.Empty<TreeItem>();
        Func<TreeItem, IEnumerable<TreeItem>> selector = null;

        source
            .Invoking(x => x.Flatten(selector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void Flatten()
        => Sequence
            .Create(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })
            .Flatten()
            .ShouldBe(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

    [Test]
    public void FlattenWithSelector()
        => Sequence
            .Create(new TreeItem(1)
            {
                Children = Sequence.Create(new TreeItem(2)
                {
                    Children = Sequence.Create(new TreeItem(3))
                })
            },
            new TreeItem(4)
            {
                Children = Sequence.Create(new TreeItem(5), new TreeItem(6))
            })
            .Flatten(x => x.Children)
            .Select(x => x.Id)
            .ShouldBe(new[] { 1, 2, 3, 4, 5, 6 });

    #endregion
}

file sealed record TreeItem(int Id)
{
    #region Properties

    public IEnumerable<TreeItem> Children { get; set; }

    #endregion
}
