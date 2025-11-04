namespace DotFluent;

#if NETFRAMEWORK

public static class ValueTaskExtensions
{
    extension(ValueTask)
    {
        public static ValueTask CompletedTask => default;

        public static ValueTask FromCanceled(CancellationToken cancellationToken)
            => new(Task.FromCanceled(cancellationToken));

        public static ValueTask<TResult> FromCanceled<TResult>(CancellationToken cancellationToken)
            => new(Task.FromCanceled<TResult>(cancellationToken));

        public static ValueTask FromException(Exception exception)
            => new(Task.FromException(exception));

        public static ValueTask<TResult> FromException<TResult>(Exception exception)
            => new(Task.FromException<TResult>(exception));

        public static ValueTask<TResult> FromResult<TResult>(TResult result)
            => new(result);
    }
}

#endif