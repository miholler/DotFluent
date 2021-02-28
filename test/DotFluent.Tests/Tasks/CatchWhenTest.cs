using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    [TestClass]
    public sealed class CatchWhenTest : TaskTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<Exception>(x => true, x => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<Exception>(x => true, x => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => 0));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => 0, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => Task.FromResult(0)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen<int, Exception>(x => true, x => Task.FromResult(0), TaskScheduler.Current));
        }

        [TestMethod]
        public async Task PredicateNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<Exception, bool> predicate = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => 0));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => 0, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => Task.FromResult(0)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(predicate, x => Task.FromResult(0), TaskScheduler.Current));
        }

        [TestMethod]
        public async Task ActionNullThrowsException()
        {
            var source = Task.FromResult(0);
            Action<Exception> action = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, action));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, action, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<Exception, int> selector = null; ;
            Func<Exception, Task<int>> taskSelector = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, selector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, selector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, taskSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.CatchWhen(x => true, taskSelector, TaskScheduler.Current));
        }

        [TestMethod]
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

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task CatchWhenCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .CatchWhen<NotImplementedException>(x => true, x => cts.Cancel(), cts.Token)
                            .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, cts.Token)
                        .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled(), cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask()
                        .CatchWhen<NotImplementedException>(x => true, x => cts.Cancel(), null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask, null, cts.Token)
                        .CatchWhen<NotImplementedException>(x => true, x => ShouldNotBeCalled(), null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWhenFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .CatchWhen<NotImplementedException>(x => true, ThrowException));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask()
                    .CatchWhen<NotImplementedException>(x => true, ThrowException, null));
        }

        [TestMethod]
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

        [TestMethod]
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

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWhenWithSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWhenWithSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionSelector, null));
        }

        [TestMethod]
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

        [TestMethod]
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

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task CatchWhenWithTaskSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    GetFaultedTask<int>()
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(GetFaultedTask<int>, null, cts.Token)
                        .CatchWhen<int, NotImplementedException>(x => true, x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task CatchWhenWithTaskSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionTaskSelector));

            await Assert.ThrowsExceptionAsync<AggregateException>(() =>
                GetFaultedTask<int>()
                    .CatchWhen<int, NotImplementedException>(x => true, ThrowExceptionTaskSelector, null));
        }

        [TestMethod]
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
}
