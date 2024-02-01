using System.Diagnostics.CodeAnalysis;

namespace System.Threading.Tasks;

#if NETSTANDARD

[ExcludeFromCodeCoverage]
internal class TaskCompletionSource : TaskCompletionSource<VoidResult>
{
    #region Methods

    public void SetResult()
        => SetResult(default);

    public bool TrySetResult()
        => TrySetResult(default);

    #endregion
}

#endif
