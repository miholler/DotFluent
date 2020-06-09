using DotFluent.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tests.Tasks
{
    [TestClass]
    public sealed class CatchTest : TaskTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<Exception>(x => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<Exception>(x => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => 0));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => 0, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => Task.FromResult(0)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(() => Task.FromResult(0), TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => 0));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => 0, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => Task.FromResult(0)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch<int, Exception>(x => Task.FromResult(0), TaskScheduler.Current));
        }

        [TestMethod]
        public async Task ActionNullThrowsException()
        {
            var source = Task.FromResult(0);
            Action action = null;
            Action<Exception> exceptionAction = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(action));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(action, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(exceptionAction));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(exceptionAction, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<int> selector = null;
            Func<Task<int>> taskSelector = null;
            Func<Exception, int> exceptionSelector = null;
            Func<Exception, Task<int>> taskExceptionSelector = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(selector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(selector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(taskSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(taskSelector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(exceptionSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(exceptionSelector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(taskExceptionSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Catch(taskExceptionSelector, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task Catch()
        {
            var firstResult = 1;
            await GetFaultedTask()
                .Catch(() => { firstResult += 2; });

            var secondResult = 2;
            await GetFaultedTask()
                .Catch(() => { secondResult++; }, null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch(() => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, cts.Token)
                        .Catch(ShouldNotBeCalled, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch(() => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, null, cts.Token)
                        .Catch(ShouldNotBeCalled, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch(ThrowException));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch(ThrowException, null));
        }

        [TestMethod]
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

        [TestMethod]
        public async Task CatchWithExceptionAction()
        {
            var result = 1;

            await GetFaultedTask()
                .Catch<ArgumentNullException>(x => ShouldNotBeCalled())
                .Catch<NotImplementedException>(x => { result++; });

            await GetFaultedTask()
                .Catch<ArgumentNullException>(x => ShouldNotBeCalled(), null)
                .Catch<NotImplementedException>(x => { result++; }, null);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task CatchWithExceptionActionCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch<NotImplementedException>(x => cts.Cancel(), cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, cts.Token)
                        .Catch<NotImplementedException>(x => ShouldNotBeCalled(), cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .Catch<NotImplementedException>(x => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, null, cts.Token)
                        .Catch<NotImplementedException>(x => ShouldNotBeCalled(), null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWithExceptionActionFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch<NotImplementedException>(ThrowException));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .Catch<NotImplementedException>(ThrowException, null));
        }

        [TestMethod]
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

        [TestMethod]
        public async Task CatchWithSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch(() => 1);

            var secondResult = await GetFaultedTask<int>()
                .Catch(() => 1, null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWithSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWithSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionSelector, null));
        }

        [TestMethod]
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

        [TestMethod]
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

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWithExceptionSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWithExceptionSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionSelector, null));
        }

        [TestMethod]
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

        [TestMethod]
        public async Task CatchWithTaskSelector()
        {
            var firstResult = await GetFaultedTask<int>()
                .Catch(() => Task.FromResult(1));

            var secondResult = await GetFaultedTask<int>()
                .Catch(() => Task.FromResult(1), null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWithTaskSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWithTaskSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionTaskSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch(ThrowExceptionTaskSelector, null));
        }

        [TestMethod]
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

        [TestMethod]
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

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWithTaskExceptionSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .Catch<int, NotImplementedException>(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .Catch<int, NotImplementedException>(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWithTaskExceptionSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionTaskSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .Catch<int, NotImplementedException>(ThrowExceptionTaskSelector, null));
        }

        [TestMethod]
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
