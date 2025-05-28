using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskFinallyTest : TaskTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        Task source = null;
        Task<int> genericSource = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.Finally(() => { }));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.Finally(() => { }, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => genericSource.Finally(() => { }));
        Assert.ThrowsAsync<ArgumentNullException>(() => genericSource.Finally(() => { }, TaskScheduler.Current));
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Task.CompletedTask;
        var genericSource = Task.FromResult(0);
        Action action = null;

        Assert.ThrowsAsync<ArgumentNullException>(() => source.Finally(action));
        Assert.ThrowsAsync<ArgumentNullException>(() => source.Finally(action, TaskScheduler.Current));
        Assert.ThrowsAsync<ArgumentNullException>(() => genericSource.Finally(action));
        Assert.ThrowsAsync<ArgumentNullException>(() => genericSource.Finally(action, TaskScheduler.Current));
    }

    [Test]
    public async Task Finally()
    {
        var result = 1;

        await Task.CompletedTask
            .Finally(() => { result++; })
                .Finally(() => { result++; }, null);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FinallyCanceled()
    {
        var result = 1;
        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.CompletedTask
                    .Then(() => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token)
                        .Finally(() => { result++; }));
        }

        using (var cts = new CancellationTokenSource())
        {
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.CompletedTask
                    .Then(() => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token)
                        .Finally(() => { result++; }, null));
        }
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FinallyFaulted()
    {
        Assert.ThrowsAsync<Exception>(() => 
            Task.CompletedTask
                .Finally(ThrowException));

        Assert.ThrowsAsync<Exception>(() =>
            Task.CompletedTask
                .Finally(ThrowException, null));

        var result = 1;
        Assert.ThrowsAsync<NotImplementedException>(() =>
            GetFaultedTask()
                .Finally(() => { result++; }));

        Assert.ThrowsAsync<NotImplementedException>(() =>
            GetFaultedTask()
                .Finally(() => { result++; }, null));

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public async Task FinallyWithGenericSource()
    {
        var result = 1;
        var taskResult = await Task.FromResult(0)
            .Finally(() => { result++; })
                .Finally(() => { result++; }, null);

        Assert.That(result, Is.EqualTo(3));
        Assert.That(taskResult, Is.EqualTo(0));
    }

    [Test]
    public void FinallyWithGenericSourceCanceled()
    {
        var result = 1;
        using (var cts = new CancellationTokenSource())
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromResult(0)
                    .Then(() =>
                    {
                        cts.Cancel();
                        return 0;
                    }, cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, cts.Token)
                        .Finally(() => { result++; }));

        using (var cts = new CancellationTokenSource())
            Assert.ThrowsAsync<TaskCanceledException>(() =>
                Task.FromResult(0)
                    .Then(() =>
                    {
                        cts.Cancel();
                        return 0;
                    }, null, cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token)
                        .Finally(() => { result++; }, null));

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FinallyWithGenericSourceFaulted()
    {
        Assert.ThrowsAsync<Exception>(() =>
            Task.FromResult(0)
                .Finally(ThrowException));

        Assert.ThrowsAsync<Exception>(() =>
            Task.FromResult(0)
                .Finally(ThrowException, null));

        var result = 1;
        Assert.ThrowsAsync<NotImplementedException>(() =>
            GetFaultedTask<int>()
                .Finally(() => { result++; }));

        Assert.ThrowsAsync<NotImplementedException>(() =>
            GetFaultedTask<int>()
                .Finally(() => { result++; }, null));

        Assert.That(result, Is.EqualTo(3));
    }

    private static void ThrowException()
        => throw new Exception("This is expected!");

    #endregion
}
