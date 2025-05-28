using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskCatchWhenTest : TaskTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        Task<int> source = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<Exception>(x => true, x => { }));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<Exception>(x => true, x => { }, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => 0));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => 0, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => Task.FromResult(0)));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => Task.FromResult(0), TaskScheduler.Current));
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Exception, bool> predicate = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => { }));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => { }, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => 0));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => 0, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => Task.FromResult(0)));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => Task.FromResult(0), TaskScheduler.Current));
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Action<Exception> action = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, action));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, action, TaskScheduler.Current));
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Exception, int> selector = null; ;
        Func<Exception, Task<int>> taskSelector = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, selector));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, selector, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, taskSelector));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.CatchWhen(x => true, taskSelector, TaskScheduler.Current));
    }

    [Test]
    public async Task CatchWhen()
    {
        var result = 1;

        await GetFaultedTask()
            .CatchWhen<ArgumentNullException>(x => true, x => ShouldNotBeCalled())
            .CatchWhen<NotImplementedException>(x => false, x => ShouldNotBeCalled())
            .CatchWhen<NotImplementedException>(x => true, x => { result++; });

        await GetFaultedTask()
            .CatchWhen<ArgumentNullException>(x => true, x => ShouldNotBeCalled(), null)
            .CatchWhen<NotImplementedException>(x => false, x => ShouldNotBeCalled(), null)
            .CatchWhen<NotImplementedException>(x => true, x => { result++; }, null);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void CatchWhenCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask()
                    .CatchWhen<NotImplementedException>(x => true, x => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask, cts.Token)
                    .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled(), cts.Token));
        }

        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask()
                    .CatchWhen<NotImplementedException>(x => true, x => cts.Cancel(), null, cts.Token)
                    .Then(ShouldNotBeCalled, null, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask, null, cts.Token)
                    .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled(), null, cts.Token));
        }
    }

    [Test]
    public void CatchWhenFaulted()
    {
        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask()
                .CatchWhen<NotImplementedException>(x => true, ThrowException));

        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask()
                .CatchWhen<NotImplementedException>(x => true, ThrowException, null));
    }

    [Test]
    public async Task CatchWhenCompleted()
    {
        try
        {
            await Task.CompletedTask
                .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled())
                .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled(), null);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Test]
    public async Task CatchWhenWithSelector()
    {
        var firstResult = await GetFaultedTask<int>()
            .CatchWhen<int, ArgumentNullException>(x => true, x =>
            {
                ShouldNotBeCalled();
                return 0;
            })
            .CatchWhen<int, NotImplementedException>(x => false, x =>
            {
                ShouldNotBeCalled();
                return 0;
            })
            .CatchWhen<int, NotImplementedException>(x => true, x => 1);

        var secondResult = await GetFaultedTask<int>()
            .CatchWhen<int, ArgumentNullException>(x => true, x =>
            {
                ShouldNotBeCalled();
                return 0;
            }, null)
            .CatchWhen<int, NotImplementedException>(x => false, x =>
            {
                ShouldNotBeCalled();
                return 0;
            }, null)
            .CatchWhen<int, NotImplementedException>(x => true, x => 1, null);

        Assert.That(firstResult, Is.EqualTo(secondResult));
    }

    [Test]
    public void CatchWhenWithSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        cts.Cancel();
                        return 0;
                    }, cts.Token)
                    .Then(ShouldNotBeCalled, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask<int>, cts.Token)
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, cts.Token));
        }

        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        cts.Cancel();
                        return 0;
                    }, null, cts.Token)
                    .Then(ShouldNotBeCalled, null, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask<int>, null, cts.Token)
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, null, cts.Token));
        }
    }

    [Test]
    public void CatchWhenWithSelectorFaulted()
    {
        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask<int>()
                .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionSelector));

        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask<int>()
                .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionSelector, null));
    }

    [Test]
    public async Task CatchWhenWithSelectorCompleted()
    {
        try
        {
            await Task.FromResult(0)
                .CatchWhen<int, NotImplementedException>(x => true, x =>
                {
                    ShouldNotBeCalled();
                    return 0;
                })
                .CatchWhen<int, NotImplementedException>(x => true, x =>
                {
                    ShouldNotBeCalled();
                    return 0;
                }, null);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Test]
    public async Task CatchWhenWithTaskSelector()
    {
        var firstResult = await GetFaultedTask<int>()
            .CatchWhen<int, ArgumentNullException>(x => true, x =>
            {
                ShouldNotBeCalled();
                return Task.FromResult(0);
            })
            .CatchWhen<int, NotImplementedException>(x => false, x =>
            {
                ShouldNotBeCalled();
                return Task.FromResult(0);
            })
            .CatchWhen<int, NotImplementedException>(x => true, x => Task.FromResult(1));

        var secondResult = await GetFaultedTask<int>()
            .CatchWhen<int, ArgumentNullException>(x => true, x =>
            {
                ShouldNotBeCalled();
                return Task.FromResult(0);
            }, null)
            .CatchWhen<int, NotImplementedException>(x => false, x =>
            {
                ShouldNotBeCalled();
                return Task.FromResult(0);
            }, null)
            .CatchWhen<int, NotImplementedException>(x => true, x => Task.FromResult(1), null);

        Assert.That(firstResult, Is.EqualTo(secondResult));
    }

    [Test]
    public void CatchWhenWithTaskSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        cts.Cancel();
                        return Task.FromResult(0);
                    }, cts.Token)
                    .Then(ShouldNotBeCalled, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask<int>, cts.Token)
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, cts.Token));
        }

        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        cts.Cancel();
                        return Task.FromResult(0);
                    }, null, cts.Token)
                    .Then(ShouldNotBeCalled, null, cts.Token));

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromCanceled(cts.Token)
                    .Then(GetFaultedTask<int>, null, cts.Token)
                    .CatchWhen<int, NotImplementedException>(x => true, x =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, null, cts.Token));
        }
    }

    [Test]
    public void CatchWhenWithTaskSelectorFaulted()
    {
        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask<int>()
                .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionTaskSelector));

        Assert.ThrowsAsync<AggregateException>(() =>
            GetFaultedTask<int>()
                .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionTaskSelector, null));
    }

    [Test]
    public async Task CatchWhenWithTaskSelectorCompleted()
    {
        try
        {
            await Task.FromResult(0)
                .CatchWhen<int, NotImplementedException>(x => true, x =>
                {
                    ShouldNotBeCalled();
                    return Task.FromResult(0);
                })
                .CatchWhen<int, NotImplementedException>(x => true, x =>
                {
                    ShouldNotBeCalled();
                    return Task.FromResult(0);
                }, null);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    private static void ThrowException<T>(T ex) where T : Exception
        => throw new AggregateException(ex);

    private static int ThrowExceptionSelector<T>(T ex) where T : Exception
    {
        ThrowException(ex);
        return 0;
    }

    private static Task<int> ThrowExceptionTaskSelector<T>(T ex) where T : Exception
    {
        ThrowException(ex);
        return Task.FromResult(0);
    }

    #endregion
}
