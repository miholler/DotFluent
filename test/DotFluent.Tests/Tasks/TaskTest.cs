using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks
{
    public abstract class TaskTest
    {
        #region Methods

        protected static Task GetFaultedTask()
            => Task.FromException(new NotImplementedException());

        protected static Task<TResult> GetFaultedTask<TResult>()
            => Task.FromException<TResult>(new NotImplementedException());

        protected static void ShouldNotBeCalled()
            => throw new InvalidOperationException("This action should not be called!");

        #endregion
    }
}
