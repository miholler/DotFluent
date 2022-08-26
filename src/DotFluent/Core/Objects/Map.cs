using System;

namespace DotFluent;

public static partial class ObjectExtensions
{
    #region Methods

    /// <summary>
    /// Projects an object into a new form using a specified function,
    /// or returns the default value of the TResult type if the object is null.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="source">The object which is to be transformed.</param>
    /// <param name="mapper">A transform function to apply to the object.</param>
    /// <returns>
    /// An object of type <typeparamref name="TResult"/> which is the result of invoking the transform function on source;
    /// otherwise, the default value of the <typeparamref name="TResult"/> type.
    /// </returns>
    public static TResult Map<TSource, TResult>(this TSource? source, Func<TSource, TResult> mapper) where TSource : class?
    {
        mapper.ThrowIfNull();

        return source.Match(mapper, () => default!);
    }

    #endregion
}
