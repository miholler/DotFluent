using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerablePipeTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Pipe(y => y++))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe((y, i) => y += i))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;

        source
            .Invoking(x => x.Pipe(action))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe(indexAction))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void Pipe(int overload)
    {
        var a = new StringBuilder("A");
        var b = new StringBuilder("B");
        var c = new StringBuilder("C");
        var source = Sequence.Create(a, b, c);

        var result = overload switch
        {
            1 => source.Pipe((x, i) => x.Insert(i - i, '#')),
            _ => source.Pipe(x => x.Insert(0, '#'))
        };
        result
            .Select(x => x.ToString())
            .ShouldBe(["#A", "#B", "#C"]);
    }

    #endregion
}
