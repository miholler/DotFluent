using System.Diagnostics.CodeAnalysis;

namespace DotFluent;

public static partial class NullableExtensions
{
    extension<TSource>([NotNullWhen(false)]TSource? source) where TSource : struct
    {
        /// <summary>
        /// Gets whether the current nullable object has no value (is a 'None' value).
        /// </summary>
        /// <returns>true if the nullable object has no value; otherwise, false.</returns>
        public bool IsNone => !source.HasValue;
    }
}
