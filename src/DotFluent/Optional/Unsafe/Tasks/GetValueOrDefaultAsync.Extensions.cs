using DotFluent.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

/// <summary>
/// Provides extension methods for specific kinds of <see cref="Task{TResult}"/> objects.
/// </summary>
public static partial class UnsafeOptionTaskExtensions
{
    #region Methods

    /// <summary>
    /// Asynchronously retrieves the value of an option, or the type parameter's default value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to retrieve the value of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the value of the <see cref="Option{TSource}"/>; otherwise, the default value for the <typeparamref name="TSource"/> type.
    /// </returns>
    public static Task<TSource?> GetValueOrDefaultAsync<TSource>(this Task<Option<TSource>> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the value of an option, or a specified default value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to retrieve the value of.</param>
    /// <param name="defaultValue">The value to return if a value is missing.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the value of the <see cref="Option{TSource}"/>; otherwise, the defaultValue parameter.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Option<TSource>> source, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultValue), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the value of an option, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to retrieve the value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the value of the <see cref="Option{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Option<TSource>> source, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the value of an option, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The task returning the option to retrieve the value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the value of the <see cref="Option{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Option<TSource>> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefaultAsync(defaultFactory, cancellationToken), cancellationToken);
    }

    #endregion
}

/// <summary>
/// Provides extension methods for specific kinds of <see cref="Task{TResult}"/> objects.
/// </summary>
public static partial class UnsafeResultTaskExtensions
{
    #region Methods

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or the type parameter's default value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TSource}"/>; otherwise, the default value for the <typeparamref name="TSource"/> type.
    /// </returns>
    public static Task<TSource?> GetValueOrDefaultAsync<TSource>(this Task<Result<TSource>> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a specified default value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultValue">The value to return if an error value is present.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TSource}"/>; otherwise, the defaultValue parameter.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Result<TSource>> source, TSource defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultValue), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Result<TSource>> source, Func<TSource> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TSource}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TSource> GetValueOrDefaultAsync<TSource>(this Task<Result<TSource>> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefaultAsync(defaultFactory, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or the type parameter's default value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TValue, TError}"/>; otherwise, the default value for the <typeparamref name="TValue"/> type.
    /// </returns>
    public static Task<TValue?> GetValueOrDefaultAsync<TValue, TError>(this Task<Result<TValue, TError>> source, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a specified default value.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultValue">The value to return if an error value is present.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TValue, TError}"/>; otherwise, the defaultValue parameter.
    /// </returns>
    public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(this Task<Result<TValue, TError>> source, TValue defaultValue, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultValue), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TValue, TError}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Func<TValue> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefault(defaultFactory), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the success value of a result, or a default value created by a
    /// specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the success value of source.</typeparam>
    /// <typeparam name="TError">The type of the error value of source.</typeparam>
    /// <param name="source">The task returning the result to retrieve the success value of.</param>
    /// <param name="defaultFactory">A function to create a default value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous get operation. The value of the TResult parameter contains
    /// the success value of the <see cref="Result{TValue, TError}"/>; otherwise, the default value created by the specified function.
    /// </returns>
    public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(this Task<Result<TValue, TError>> source, Func<Task<TValue>> defaultFactory, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        defaultFactory.ThrowIfNull();

        return source.Then(x => x.GetValueOrDefaultAsync(defaultFactory, cancellationToken), cancellationToken);
    }

    #endregion
}
