namespace DotFluent;

public static partial class NullableExtensions
{
    #region Methods

    /// <summary>
    /// Determines whether a nullable object contains a specified value.
    /// </summary>
    /// <typeparam name="TSource">The type of the value of source.</typeparam>
    /// <param name="source">The nullable object in which to locate a value.</param>
    /// <param name="value">The value to locate in the nullable object.</param>
    /// <returns>true if the nullable object contains the specified value; otherwise, false.</returns>
    public static bool Contains<TSource>(this TSource? source, TSource value) where TSource : struct
        => source.IsSome() && EqualityComparer<TSource>.Default.Equals(source.Value, value);

    #endregion
}
