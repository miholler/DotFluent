using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class NullableExtensions
{
    extension<TSource>([NotNullWhen(true)]TSource? source) where TSource : struct
    {
        /// <summary>
        /// Gets whether the current nullable object has a value (is a 'Some' value).
        /// </summary>
        /// <returns><see langword="true"/> if the nullable object has a value; otherwise, <see langword="false"/>.</returns>
        public bool IsSome => source.HasValue;
    }
}
