using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    [TestFixture]
    public sealed class CatchTest : TaskTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            Task<int> source = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => { }));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => { }, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<Exception>(x => { }));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<Exception>(x => { }, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => 0));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => 0, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => Task.FromResult(0)));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(() => Task.FromResult(0), TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => 0));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => 0, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => Task.FromResult(0)));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => Task.FromResult(0), TaskScheduler.Current));
        }

        [Test]
        public void ActionNullThrowsException()
        {
            var source = Task.FromResult(0);
            Action action = null;
            Action<Exception> exceptionAction = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(action));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(action, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(exceptionAction));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(exceptionAction, TaskScheduler.Current));
        }

        [Test]
        public void SelectorNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<int> selector = null;
            Func<Task<int>> taskSelector = null;
            Func<Exception, int> exceptionSelector = null;
            Func<Exception, Task<int>> taskExceptionSelector = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(selector));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(selector, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(taskSelector));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(taskSelector, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(exceptionSelector));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(exceptionSelector, TaskScheduler.Current));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(taskExceptionSelector));
            Assert.ThrowsAsync<ArgumentNullException>(() => source.Catch(taskExceptionSelector, TaskScheduler.Current));
        }

        [Test]
        public async Task Catch()
        {
            var firstResult = 1;
            await GetFaultedTask()
                .Catch(() => { firstResult += 2; });

            var secondResult = 2;
            await GetFaultedTask()
                .Catch(() => { secondResult++; }, null);

            Assert.That(firstResult, Is.EqualTo(secondResult));
        }

        [Test]
        public void CatchCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch(() => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, cts.Token)
                        .Catch(ShouldNotBeCalled, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch(() => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, null, cts.Token)
                        .Catch(ShouldNotBeCalled, null, cts.Token));
            }
        }

        [Test]
        public void CatchFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch(ThrowException));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch(ThrowException, null));
        }

        [Test]
        public async Task CatchCompleted()
        {
            try
            {
                await Task.CompletedTask
                    .Catch(ShouldNotBeCalled)
                    .Catch(ShouldNotBeCalled, null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task CatchWithExceptionAction()
        {
            var result = 1;

            await GetFaultedTask()
                .Catch<ArgumentNullException>(x => ShouldNotBeCalled())
                .Catch<NotImplementedException>(x => { result++; });

            await GetFaultedTask()
                .Catch<ArgumentNullException>(x => ShouldNotBeCalled(), null)
                .Catch<NotImplementedException>(x => { result++; }, null);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void CatchWithExceptionActionCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch<NotImplementedException>(x => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, cts.Token)
                        .Catch<NotImplementedException>(x => ShouldNotBeCalled(), cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch<NotImplementedException>(x => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, null, cts.Token)
                        .Catch<NotImplementedException>(x => ShouldNotBeCalled(), null, cts.Token));
            }
        }

        [Test]
        public void CatchWithExceptionActionFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch<NotImplementedException>(ThrowException));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch<NotImplementedException>(ThrowException, null));
        }

        [Test]
        public async Task CatchWithExceptionActionCompleted()
        {
            try
            {
                await Task.CompletedTask
                    .Catch<NotImplementedException>(x => ShouldNotBeCalled())
                    .Catch<NotImplementedException>(x => ShouldNotBeCalled(), null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task CatchWithSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch(() => 1);

            var secondResult = await GetFaultedTask<int>()
                .Catch(() => 1, null);

            Assert.That(firstResult, Is.EqualTo(secondResult));
        }

        [Test]
        public void CatchWithSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [Test]
        public void CatchWithSelectorFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionSelector));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionSelector, null));
        }

        [Test]
        public async Task CatchWithSelectorCompleted()
        {
            try
            {
                await Task.FromResult(0)
                    .Catch(() =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    })
                    .Catch(() =>
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
        public async Task CatchWithExceptionSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch<int, ArgumentNullException>(x =>
                {
                    ShouldNotBeCalled();
                    return 0;
                })
                .Catch<int, NotImplementedException>(x => 1);

            var secondResult = await GetFaultedTask<int>()
                .Catch<int, ArgumentNullException>(x =>
                {
                    ShouldNotBeCalled();
                    return 0;
                }, null)
                .Catch<int, NotImplementedException>(x => 1, null);

            Assert.That(firstResult, Is.EqualTo(secondResult));
        }

        [Test]
        public void CatchWithExceptionSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [Test]
        public void CatchWithExceptionSelectorFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionSelector));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionSelector, null));
        }

        [Test]
        public async Task CatchWithExceptionSelectorCompleted()
        {
            try
            {
                await Task.FromResult(0)
                    .Catch<int, NotImplementedException>(x =>
                    {
                        ShouldNotBeCalled();
                        return 0;
                    })
                    .Catch<int, NotImplementedException>(x =>
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
        public async Task CatchWithTaskSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch(() => Task.FromResult(1));

            var secondResult = await GetFaultedTask<int>()
                .Catch(() => Task.FromResult(1), null);

            Assert.That(firstResult, Is.EqualTo(secondResult));
        }

        [Test]
        public void CatchWithTaskSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [Test]
        public void CatchWithTaskSelectorFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionTaskSelector));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionTaskSelector, null));
        }

        [Test]
        public async Task CatchWithTaskSelectorCompleted()
        {
            try
            {
                await Task.FromResult(0)
                    .Catch(() =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    })
                    .Catch(() =>
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

        [Test]
        public async Task CatchWithTaskExceptionSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch<int, ArgumentNullException>(x =>
                {
                    ShouldNotBeCalled();
                    return Task.FromResult(0);
                })
                .Catch<int, NotImplementedException>(x => Task.FromResult(1));

            var secondResult = await GetFaultedTask<int>()
                .Catch<int, ArgumentNullException>(x =>
                {
                    ShouldNotBeCalled();
                    return Task.FromResult(0);
                }, null)
                .Catch<int, NotImplementedException>(x => Task.FromResult(1), null);

            Assert.That(firstResult, Is.EqualTo(secondResult));
        }

        [Test]
        public void CatchWithTaskExceptionSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                Assert.ThrowsAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [Test]
        public void CatchWithTaskExceptionSelectorFaulted()
        {
            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionTaskSelector));

            Assert.ThrowsAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionTaskSelector, null));
        }

        [Test]
        public async Task CatchWithTaskExceptionSelectorCompleted()
        {
            try
            {
                await Task.FromResult(0)
                    .Catch<int, NotImplementedException>(x =>
                    {
                        ShouldNotBeCalled();
                        return Task.FromResult(0);
                    })
                    .Catch<int, NotImplementedException>(x =>
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

        private static void ThrowException()
            => throw new AggregateException();

        private static void ThrowException<T>(T ex) where T : Exception
            => throw new AggregateException(ex);

        private static int ThrowExceptionSelector()
        {
            ThrowException();
            return 0;
        }

        private static int ThrowExceptionSelector<T>(T ex) where T : Exception
        {
            ThrowException(ex);
            return 0;
        }

        private static Task<int> ThrowExceptionTaskSelector()
        {
            ThrowException();
            return Task.FromResult(0);
        }

        private static Task<int> ThrowExceptionTaskSelector<T>(T ex) where T : Exception
        {
            ThrowException(ex);
            return Task.FromResult(0);
        }

        #endregion
    }
}
