using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskThenTest : TaskTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        Task<int> source = null;

        source.Awaiting(x => x.Then(() => { })).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => { }, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => Task.CompletedTask)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => Task.CompletedTask, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => 0)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => 0, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => Task.FromResult(0))).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(() => Task.FromResult(0), TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => { x++; })).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => { x++; }, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => Task.CompletedTask)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => Task.CompletedTask, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => x++)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => x++, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => Task.FromResult(++x))).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(x => Task.FromResult(++x), TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Action action = null;
        Action<int> genericAction = null;

        source.Awaiting(x => x.Then(action)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(action, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericAction)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericAction, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Task> taskSelector = null;
        Func<int> selector = null;
        Func<Task<int>> genericTaskSelector = null;
        Func<int, Task> taskResultSelector = null;
        Func<int, int> resultSelector = null;
        Func<int, Task<int>> genericTaskResultSelector = null;

        source.Awaiting(x => x.Then(taskSelector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(taskSelector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(selector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(selector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericTaskSelector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericTaskSelector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(taskResultSelector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(taskResultSelector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(resultSelector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(resultSelector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericTaskResultSelector)).ShouldThrow<ArgumentNullException>();
        source.Awaiting(x => x.Then(genericTaskResultSelector, TaskScheduler.Current)).ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public async Task Then()
    {
        var result = 1;

        await Task.CompletedTask
            .Then(() => { result++; })
                .Then(() => { result++; }, null);

        result.ShouldBe(3);
    }

    [Test]
    public void ThenCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(ShouldNotBeCalled, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(ShouldNotBeCalled, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenFaulted()
    {
        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentException)
                    .Then(ShouldNotBeCalled))
            .ShouldThrow<ArgumentException>();

        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentException, null)
                    .Then(ShouldNotBeCalled, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithTaskSelector()
    {
        var result = 1;

        await Task.CompletedTask
            .Then(() => 
            { 
                result++;
                return Task.CompletedTask;
            })
            .Then(() => 
            { 
                result++;
                return Task.CompletedTask;
            }, null);

        result.ShouldBe(3);
    }

    [Test]
    public void ThenWithTaskSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    { 
                        cts.Cancel();
                        return Task.CompletedTask;
                    }, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    {
                        cts.Cancel();
                        return Task.CompletedTask;
                    }, null, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithTaskSelectorFaulted()
    {
        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionTaskSelector)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }))
            .ShouldThrow<ArgumentException>();

        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionTaskSelector, null)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithSelector()
    {
        var firstResult = await Task.CompletedTask
            .Then(() => 1);

        var secondResult = await Task.CompletedTask
            .Then(() => 1, null);

        firstResult.ShouldBe(secondResult);
    }

    [Test]
    public void ThenWithSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    {
                        cts.Cancel();
                        return 0;
                    }, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    {
                        cts.Cancel();
                        return 0;
                    }, null, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithSelectorFaulted()
    {
        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionSelector)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }))
            .ShouldThrow<ArgumentException>();

        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionSelector, null)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    }, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithGenericTaskSelector()
    {
        var firstResult = await Task.CompletedTask
            .Then(() => Task.FromResult(1));

        var secondResult = await Task.CompletedTask
            .Then(() => Task.FromResult(1), null);

        firstResult.ShouldBe(secondResult);
    }

    [Test]
    public void ThenWithGenericTaskSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    {
                        cts.Cancel();
                        return Task.FromResult(0);
                    }, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.CompletedTask
                .Awaiting(x => x
                    .Then(() =>
                    {
                        cts.Cancel();
                        return Task.FromResult(0);
                    }, null, cts.Token)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled(cts.Token)
                .Awaiting(x => x
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithGenericTaskSelectorFaulted()
    {
        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionGenericTaskSelector)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }))
            .ShouldThrow<ArgumentException>();

        Task.CompletedTask
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionGenericTaskSelector, null)
                    .Then(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    }, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithGenericAction()
    {
        var result = 1;

        await Task.FromResult(1)
            .Then(x => { result += x; });

        await Task.FromResult(1)
            .Then(x => { result += x; }, null);

        result.ShouldBe(3);
    }

    [Test]
    public void ThenWithGenericActionCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y => cts.Cancel(), cts.Token)
                        .Then(() => 0)
                            .Then(y => ShouldNotBeCalled(), cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y => ShouldNotBeCalled(), cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y => cts.Cancel(), null, cts.Token)
                        .Then(() => 0, null)
                            .Then(y => ShouldNotBeCalled(), null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y => ShouldNotBeCalled(), null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithGenericActionFaulted()
    {
        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentException)
                    .Then(() => 0)
                        .Then(y => ShouldNotBeCalled()))
            .ShouldThrow<ArgumentException>();

        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentException, null)
                    .Then(() => 0, null)
                        .Then(y => ShouldNotBeCalled(), null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithTaskResultSelector()
    {
        var result = 1;

        await Task.FromResult(1)
            .Then(x =>
            {
                result += x;
                return Task.CompletedTask;
            });

        await Task.FromResult(1)
            .Then(x =>
            {
                result += x;
                return Task.CompletedTask;
            }, null);

        result.ShouldBe(3);
    }

    [Test]
    public void ThenWithTaskResultSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return Task.CompletedTask;
                    }, cts.Token)
                        .Then(() => 0)
                            .Then(y =>
                            {
                                ShouldNotBeCalled();
                                return Task.CompletedTask;
                            }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return Task.CompletedTask;
                    }, null, cts.Token)
                        .Then(() => 0, null)
                            .Then(y =>
                            {
                                ShouldNotBeCalled();
                                return Task.CompletedTask;
                            }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.CompletedTask;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithTaskResultSelectorFaulted()
    {
        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionTaskSelector)
                    .Then(() => 0)
                        .Then(y =>
                        {
                            ShouldNotBeCalled();
                            return Task.CompletedTask;
                        }))
            .ShouldThrow<ArgumentException>();

        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionTaskSelector, null)
                    .Then(() => 0, null)
                        .Then(y =>
                        {
                            ShouldNotBeCalled();
                            return Task.CompletedTask;
                        }, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithResultSelector()
    {
        var firstResult = await Task.FromResult(1)
            .Then(x => x + 2);

        var secondResult = await Task.FromResult(2)
            .Then(x => ++x, null);

        firstResult.ShouldBe(secondResult);
    }

    [Test]
    public void ThenWithResultSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return y;
                    }, cts.Token)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return y;
                    }, null, cts.Token)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithResultSelectorFaulted()
    {
        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionSelector)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }))
            .ShouldThrow<ArgumentException>();

        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionSelector, null)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return y;
                    }, null))
            .ShouldThrow<ArgumentException>();
    }

    [Test]
    public async Task ThenWithGenericTaskResultSelector()
    {
        var firstResult = await Task.FromResult(1)
            .Then(x => Task.FromResult(x + 2));

        var secondResult = await Task.FromResult(2)
            .Then(x => Task.FromResult(++x), null);

        firstResult.ShouldBe(secondResult);
    }

    [Test]
    public void ThenWithGenericTaskResultSelectorCanceled()
    {
        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return Task.FromResult(y);
                    }, cts.Token)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }

        using (var cts = new CancellationTokenSource())
        {
            Task.FromResult(0)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        cts.Cancel();
                        return Task.FromResult(y);
                    }, null, cts.Token)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();

            Task.FromCanceled<int>(cts.Token)
                .Awaiting(x => x
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }, null, cts.Token))
                .ShouldThrow<TaskCanceledException>();
        }
    }

    [Test]
    public void ThenWithGenericTaskResultSelectorFaulted()
    {
        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionGenericTaskSelector)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }))
            .ShouldThrow<ArgumentException>();

        Task.FromResult(0)
            .Awaiting(x => x
                .Then(ThrowArgumentExceptionGenericTaskSelector, null)
                    .Then(y =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(y);
                    }, null))
            .ShouldThrow<ArgumentException>();
    }

    private static void ThrowArgumentException()
        => throw new ArgumentException("This is expected!");

    private static void ThrowArgumentException<T>(T _)
        => ThrowArgumentException();

    private static int ThrowArgumentExceptionSelector()
    {
        ThrowArgumentException();
        return 0;
    }

    private static T ThrowArgumentExceptionSelector<T>(T arg)
    {
        ThrowArgumentException();
        return arg;
    }

    private static Task ThrowArgumentExceptionTaskSelector()
    {
        ThrowArgumentException();
        return Task.CompletedTask;
    }

    private static Task ThrowArgumentExceptionTaskSelector<T>(T _)
    {
        ThrowArgumentException();
        return Task.CompletedTask;
    }

    private static Task<int> ThrowArgumentExceptionGenericTaskSelector()
    {
        ThrowArgumentException();
        return Task.FromResult(0);
    }

    private static Task<T> ThrowArgumentExceptionGenericTaskSelector<T>(T arg)
    {
        ThrowArgumentException();
        return Task.FromResult(arg);
    }

    #endregion
}
