using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    [TestClass]
    public sealed class FinallyTest : TaskTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task source = null;
            Task<int> genericSource = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Finally(() => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Finally(() => { }, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => genericSource.Finally(() => { }));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => genericSource.Finally(() => { }, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task ActionNullThrowsException()
        {
            var source = Task.CompletedTask;
            var genericSource = Task.FromResult(0);
            Action action = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Finally(action));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Finally(action, TaskScheduler.Current));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => genericSource.Finally(action));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => genericSource.Finally(action, TaskScheduler.Current));
        }

        [TestMethod]
        public async Task Finally()
        {
            var result = 1;

            await Task.CompletedTask
                .Finally(() => { result++; })
                    .Finally(() => { result++; }, null);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task FinallyCanceled()
        {
            var result = 1;
            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() => cts.Cancel(), cts.Token)
                            .Then(ShouldNotBeCalled, cts.Token)
                            .Finally(() => { result++; }));
            }

            using (var cts = new CancellationTokenSource())
            {
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
                    Task.CompletedTask
                        .Then(() => cts.Cancel(), null, cts.Token)
                            .Then(ShouldNotBeCalled, null, cts.Token)
                            .Finally(() => { result++; }, null));
            }
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task FinallyFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() => 
                Task.CompletedTask
                    .Finally(ThrowException));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.CompletedTask
                    .Finally(ThrowException, null));

            var result = 1;
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() =>
                GetFaultedTask()
                    .Finally(() => { result++; }));

            await Assert.ThrowsExceptionAsync<NotImplementedException>(() =>
                GetFaultedTask()
                    .Finally(() => { result++; }, null));

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task FinallyWithGenericSource()
        {
            var result = 1;
            var taskResult = await Task.FromResult(0)
                .Finally(() => { result++; })
                    .Finally(() => { result++; }, null);

            Assert.AreEqual(result, 3);
            Assert.AreEqual(taskResult, 0);
        }

        [TestMethod]
        public async Task FinallyWithGenericSourceCanceled()
        {
            var result = 1;
            using (var cts = new CancellationTokenSource())
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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
                await Assert.ThrowsExceptionAsync<TaskCanceledException>(() =>
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

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public async Task FinallyWithGenericSourceFaulted()
        {
            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Finally(ThrowException));

            await Assert.ThrowsExceptionAsync<Exception>(() =>
                Task.FromResult(0)
                    .Finally(ThrowException, null));

            var result = 1;
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() =>
                GetFaultedTask<int>()
                    .Finally(() => { result++; }));

            await Assert.ThrowsExceptionAsync<NotImplementedException>(() =>
                GetFaultedTask<int>()
                    .Finally(() => { result++; }, null));

            Assert.AreEqual(result, 3);
        }

        private static void ThrowException()
            => throw new Exception("This is expected!");

        #endregion
    }
}
