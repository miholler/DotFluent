using DotFluent.Tasks;

namespace DotFluent.Optional.Tasks;

public static partial class OptionTaskExtensions
{
    #region Methods

    /// <summary>
    /// Asynchronously projects the value of an option into another option using a specified function and
    /// flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value of the option returned by mapper.</typeparam>
    /// <param name="source">The task returning the option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flat map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Option<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(x => x.FlatMap(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the value of an option into another option using a specified function and
    /// flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value of the option returned by mapper.</typeparam>
    /// <param name="source">The task returning the option whose value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flat map operation. The value of the TResult parameter contains
    /// an <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(this Task<Option<TSource>> source, Func<TSource, Task<Option<TResult>>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(x => x.FlatMapAsync(mapper, cancellationToken), cancellationToken);
    }

    #endregion
}

public static partial class ResultTaskExtensions
{
    #region Methods

    /// <summary>
    /// Asynchronously projects the success value of a result into another result using a specified function and
    /// flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flat map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the flattened result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(this Task<Result<TSource>> source, Func<TSource, Result<TResult>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(x => x.FlatMap(mapper), cancellationToken);
    }

    /// <summary>
    /// Asynchronously projects the success value of a result into another result using a specified function and
    /// flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TSource">The type of the success value of source.</typeparam>
    /// <typeparam name="TResult">The type of the success value of the result returned by mapper.</typeparam>
    /// <param name="source">The task returning the result whose success value is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous flat map operation. The value of the TResult parameter contains
    /// a <see cref="Result{TResult}"/> whose success value is the flattened result of invoking the transform function on the success value of source;
    /// otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(this Task<Result<TSource>> source, Func<TSource, Task<Result<TResult>>> mapper, CancellationToken cancellationToken = default)
    {
        source.ThrowIfNull();
        mapper.ThrowIfNull();

        return source.Then(x => x.FlatMapAsync(mapper, cancellationToken), cancellationToken);
    }

    #endregion
}
