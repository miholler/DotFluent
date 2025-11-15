using DotFluent;
using DotFluent.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

#if !NET8_0_OR_GREATER

[ExcludeFromCodeCoverage]
internal static class ExceptionPolyfills
{
    extension(ArgumentException)
    {
        public static void ThrowIfNullOrEmpty([NotNull]string? argument, [CallerArgumentExpression(nameof(argument))]string? paramName = null)
        {
            if (argument.IsNullOrEmpty())
            {
                argument.ThrowIfNull(paramName);
                throw new ArgumentException(Errors.ArgumentEmptyString, paramName);
            }
        }

        public static void ThrowIfNullOrWhiteSpace([NotNull]string? argument, [CallerArgumentExpression(nameof(argument))]string? paramName = null)
        {
            if (argument.IsNullOrWhiteSpace())
            {
                argument.ThrowIfNull(paramName);
                throw new ArgumentException(Errors.ArgumentEmptyOrWhiteSpaceString, paramName);
            }
        }
    }

    extension(ArgumentOutOfRangeException)
    {
        public static void ThrowIfGreaterThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))]string? paramName = null) where T : IComparable<T>
        {
            if (value.CompareTo(other) > 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(Errors.ArgumentOutOfRangeMustBeLessOrEqual, paramName, value, other));
        }

        public static void ThrowIfNegative(int value, [CallerArgumentExpression(nameof(value))]string? paramName = null)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(Errors.ArgumentOutOfRangeMustBeNonNegative, paramName, value));
        }
    }
}

#endif