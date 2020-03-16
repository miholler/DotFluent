using DotFluent.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tests.Tasks
{
    [TestClass]
    public sealed class ThenTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => 0));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => 0, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => Task.FromResult(0)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(() => Task.FromResult(0), TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => { x++; }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => { x++; }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => x++));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => x++, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => Task.FromResult(++x)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(x => Task.FromResult(++x), TaskScheduler.Current));
        }

        [TestMethod]
        public async Task ActionNullThrowsException()
        {
            var source = Task.FromResult(0);
            Action action = null;
            Action<int> sourceAction = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(action));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(action, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(sourceAction));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(sourceAction, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<int> selector = null;
            Func<int, int> resultSelector = null;
            Func<Task<int>> taskSelector = null;
            Func<int, Task<int>> taskResultSelector = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(selector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(selector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(resultSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(resultSelector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(taskSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(taskSelector, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(taskResultSelector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Then(taskResultSelector, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task Then()
        {
            var result = 1;

            await Task.CompletedTask
                .Then(() => { result++; })
                    .Then(() => { result++; }, null);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task ThenCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() => cts.Cancel(), cts.Token)
                            .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() => cts.Cancel(), null, cts.Token)
                            .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Then(ThrowException)
                        .Then(ShouldNotBeCalled));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Then(ThrowException, null)
                        .Then(ShouldNotBeCalled, null));
        }

        [TestMethod]
        public async Task ThenWithGenericAction()
        {
            var result = 1;

            await Task.FromResult(1)
                .Then(x => { result += x; });

            await Task.FromResult(1)
                .Then(x => { result += x; }, null);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task ThenWithGenericActionCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x => { cts.Cancel(); }, cts.Token)
                            .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x => { ShouldNotBeCalled(); }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x => { cts.Cancel(); }, null, cts.Token)
                            .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x => { ShouldNotBeCalled(); }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenWithGenericActionFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowException)
                        .Then(() => 0)
                            .Then(x => ShouldNotBeCalled()));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowException, null)
                        .Then(() => 0)
                            .Then(x => ShouldNotBeCalled(), null));
        }

        [TestMethod]
        public async Task ThenWithSelector()
        {
            var firstResult = await Task.CompletedTask
                .Then(() => 1);

            var secondResult = await Task.CompletedTask
                .Then(() => 1, null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task ThenWithSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() =>
                        {
                            cts.Cancel();
                            return 0;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenWithSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() => 
                Task.CompletedTask
                    .Then(ThrowExceptionSelector)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Then(ThrowExceptionSelector, null)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null));
        }

        [TestMethod]
        public async Task ThenWithResultSelector()
        {
            var firstResult = await Task.FromResult(1)
                .Then(x => x + 2);

            var secondResult = await Task.FromResult(2)
                .Then(x => ++x, null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task ThenWithResultSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x =>
                        {
                            cts.Cancel();
                            return x;
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x =>
                        {
                            cts.Cancel();
                            return x;
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return 0;
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenWithResultSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowExceptionSelector)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return x;
                        }));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowExceptionSelector, null)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return x;
                        }, null));
        }

        [TestMethod]
        public async Task ThenWithTaskSelector()
        {
            var firstResult = await Task.CompletedTask
                .Then(() => Task.FromResult(1));

            var secondResult = await Task.CompletedTask
                .Then(() => Task.FromResult(1), null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task ThenWithTaskSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() =>
                        {
                            cts.Cancel();
                            return Task.FromResult(0);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled(cts.Token)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenWithTaskSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Then(ThrowExceptionTaskSelector)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Then(ThrowExceptionTaskSelector, null)
                        .Then(() =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(0);
                        }, null));
        }

        [TestMethod]
        public async Task ThenWithTaskResultSelector()
        {
            var firstResult = await Task.FromResult(1)
                .Then(x => Task.FromResult(x + 2));

            var secondResult = await Task.FromResult(2)
                .Then(x => Task.FromResult(++x), null);

            Assert.AreEqual(firstResult, secondResult);
        }

        [TestMethod]
        public async Task ThenWithTaskResultSelectorCanceled()
        {
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(x);
                        }, cts.Token)
                        .Then(ShouldNotBeCalled, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(x);
                        }, cts.Token));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromResult(0)
                        .Then(x =>
                        {
                            cts.Cancel();
                            return Task.FromResult(x);
                        }, null, cts.Token)
                        .Then(ShouldNotBeCalled, null, cts.Token));

                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.FromCanceled<int>(cts.Token)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(x);
                        }, null, cts.Token));
            }
        }

        [TestMethod]
        public async Task ThenWithTaskResultSelectorFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowExceptionTaskSelector)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(x);
                        }));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Then(ThrowExceptionTaskSelector, null)
                        .Then(x =>
                        {
                            ShouldNotBeCalled();
                            return Task.FromResult(x);
                        }, null));
        }

        private static void ThrowException()
            => throw new Exception("This is expected!");

        private static void ThrowException<T>(T _)
            => ThrowException();

        private static int ThrowExceptionSelector()
        {
            ThrowException();
            return 0;
        }

        private static T ThrowExceptionSelector<T>(T arg)
        {
            ThrowException();
            return arg;
        }

        private static Task<int> ThrowExceptionTaskSelector()
        {
            ThrowException();
            return Task.FromResult(0);
        }

        private static Task<T> ThrowExceptionTaskSelector<T>(T arg)
        {
            ThrowException();
            return Task.FromResult(arg);
        }

        private static void ShouldNotBeCalled()
            => throw new InvalidOperationException("This action should not be called!");

        #endregion
    }
}
