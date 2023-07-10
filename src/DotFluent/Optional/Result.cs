using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

namespace DotFluent.Optional;

/// <summary>
/// Represents an operational result that is either a success value (Ok)
/// or an error value (Error).
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Result{T}"/> generic type.</typeparam>
public readonly struct Result<T> : IEnumerable<T>, IEquatable<Result<T>>, IComparable<Result<T>>, IComparable, IStructuralComparable, IStructuralEquatable
{
    #region Fields

    private readonly T _value;
    private readonly ExceptionDispatchInfo _error;

    #endregion

    #region Ctors

    private Result(T value)
    {
        _value = value;
        _error = default!;
    }

    private Result(ExceptionDispatchInfo error)
    {
        _value = default!;
        _error = error;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets whether the current result is an 'Ok' value.
    /// </summary>
    /// <returns>true if the result is an 'Ok' value; otherwise, false.</returns>
    public bool IsOk => _error.IsNull();

    /// <summary>
    /// Gets whether the current result is an 'Error' value.
    /// </summary>
    /// <returns>true if the result is an 'Error' value; otherwise, false.</returns>
    public bool IsError => !IsOk;

    #endregion

    #region Methods

    /// <summary>
    /// Creates a result value that is an 'Ok' value.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{T}"/> representing the success value.</returns>
    public static Result<T> Ok(T value)
        => new(value);

    /// <summary>
    /// Creates a result value that is an 'Error' value.
    /// </summary>
    /// <param name="error">The error value.</param>
    /// <returns>A <see cref="Result{T}"/> representing the error value.</returns>
    public static Result<T> Error(Exception error)
        => new(ExceptionDispatchInfo.Capture(error));

    /// <summary>
    /// Performs a specified action based on whether the current result
    /// is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <param name="ok">An action to perform if a success value is present.</param>
    /// <param name="error">An action to perform if an error value is present.</param>
    public void Match(Action<T> ok, Action<Exception> error)
    {
        ok.ThrowIfNull();
        error.ThrowIfNull();

        if (IsOk)
            ok(_value);
        else
            error(_error.SourceException);
    }

    /// <summary>
    /// Invokes a specified function based on whether the current result
    /// is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="ok">A function to invoke if a success value is present.</param>
    /// <param name="error">A function to invoke if an error value is present.</param>
    /// <returns>The result of the invoked function.</returns>
    public TResult Match<TResult>(Func<T, TResult> ok, Func<Exception, TResult> error)
    {
        ok.ThrowIfNull();
        error.ThrowIfNull();

        return IsOk ? ok(_value) : error(_error.SourceException);
    }

    /// <summary>
    /// Projects the success value of the current result into a new form using a specified function,
    /// or returns an 'Error' result based on whether the current result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult}"/> whose success value is the result of invoking the transform function on
    /// the source success value; otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public Result<TResult> Map<TResult>(Func<T, TResult> mapper)
    {
        mapper.ThrowIfNull();

        return Match(x => Result.Ok(mapper(x)), Result.Error<TResult>);
    }

    /// <summary>
    /// Projects the error value of the current result into a new form using a specified function,
    /// or returns an 'Ok' result based on whether the current result is an 'Ok' or an 'Error' value.
    /// </summary>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> whose error value is the result of invoking the transform function on
    /// the source error value; otherwise, an 'Ok' <see cref="Result{T}"/>.
    /// </returns>
    public Result<T> MapError(Func<Exception, Exception> mapper)
    {
        mapper.ThrowIfNull();

        return Match(Ok, x => Error(mapper(x)));
    }

    /// <summary>
    /// Projects the success value of the current result into another result using a specified function
    /// and flattens the result, or returns an 'Error' result based on whether the current result is an
    /// 'Ok' or an 'Error' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value of the result returned by mapper.</typeparam>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <returns>
    /// A <see cref="Result{TResult}"/> whose success value is the flattened result of invoking the transform
    /// function on the source success value; otherwise, an 'Error' <see cref="Result{TResult}"/>.
    /// </returns>
    public Result<TResult> FlatMap<TResult>(Func<T, Result<TResult>> mapper)
    {
        mapper.ThrowIfNull();

        return Match(mapper, Result.Error<TResult>);
    }

    /// <summary>
    /// Returns an alternative result if the current result is an 'Error' value.
    /// </summary>
    /// <param name="other">The result to return if an error value is present.</param>
    /// <returns>A <see cref="Result{T}"/> representing a success value; otherwise, the specified alternative <see cref="Result{T}"/>.</returns>
    public Result<T> OrElse(Result<T> other)
        => OrElse(() => other);

    /// <summary>
    /// Returns an alternative result created by a specified function
    /// if the current result is an 'Error' value.
    /// </summary>
    /// <param name="otherFactory">A function to create an alternative result.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> representing a success value; otherwise, an alternative <see cref="Result{T}"/>
    /// created by the specified function.
    /// </returns>
    public Result<T> OrElse(Func<Result<T>> otherFactory)
    {
        otherFactory.ThrowIfNull();

        return IsOk ? this : otherFactory();
    }

    /// <summary>
    /// Determines whether the current result contains a specified value.
    /// </summary>
    /// <param name="value">The value to locate in the result.</param>
    /// <returns>true if the result contains the specified value; otherwise, false.</returns>
    public bool Contains(T value)
        => IsOk && EqualityComparer<T>.Default.Equals(_value, value);

    /// <summary>
    /// Determines whether the current result contains a value that
    /// satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>true if the result contains a value that satisfies the condition; otherwise, false.</returns>
    public bool Exists(Func<T, bool> predicate)
    {
        predicate.ThrowIfNull();

        return IsOk && predicate(_value);
    }

    /// <summary>
    /// Returns an enumerator for the current result.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> for the result.</returns>
    public IEnumerator<T> GetEnumerator()
        => AsEnumerable().GetEnumerator();

    /// <summary>
    /// Returns an enumerator for the current result.
    /// </summary>
    /// <returns>An <see cref="IEnumerator"/> for the result.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Converts the current result to a sequence with one or zero elements.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing one or zero elements.</returns>
    public IEnumerable<T> AsEnumerable()
    {
        if (IsOk)
            yield return _value;
    }

    /// <summary>
    /// Compares the specified result with the current result.
    /// </summary>
    /// <param name="other">The result to compare with the current result.</param>
    /// <returns>An integer indicating the order of the current result relative to the specified result.</returns>
    public int CompareTo(Result<T> other)
    {
        if (IsError && other.IsError)
            return 0;

        if (IsOk && other.IsError)
            return 1;

        if (IsError && other.IsOk)
            return -1;

        return Comparer<T>.Default.Compare(_value, other._value);
    }

    /// <summary>
    /// Compares the specified object with the current result.
    /// </summary>
    /// <param name="other">The object to compare with the current result.</param>
    /// <returns>An integer indicating the order of the current result relative to the specified object.</returns>
    int IComparable.CompareTo(object? other)
        => other is Result<T> result ? CompareTo(result) : 1;

    /// <summary>
    /// Compares the specified object with the current result by using a specified comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current result.</param>
    /// <param name="comparer">The comparer to compare the represented values.</param>
    /// <returns>An integer indicating the order of the current result relative to the specified object.</returns>
    int IStructuralComparable.CompareTo(object? other, IComparer comparer)
    {
        if (other is not Result<T> result)
            return 1;

        if (IsError && result.IsError)
            return 0;

        if (IsOk && result.IsError)
            return 1;

        if (IsError && result.IsOk)
            return -1;

        return comparer.Compare(_value, result._value);
    }

    /// <summary>
    /// Determines whether the specified result is equal to the current result.
    /// </summary>
    /// <param name="other">The result to compare with the current result.</param>
    /// <returns>true if the specified result is equal to the current result; otherwise, false.</returns>
    public bool Equals(Result<T> other)
        => (IsError && other.IsError) || (IsOk && other.IsOk && EqualityComparer<T>.Default.Equals(_value, other._value));

    /// <summary>
    /// Determines whether the specified object is equal to the current result.
    /// </summary>
    /// <param name="other">The object to compare with the current result.</param>
    /// <returns>true if the specified object is equal to the current result; otherwise, false.</returns>
    public override bool Equals([NotNullWhen(true)]object? other)
        => other is Result<T> result && Equals(result);

    /// <summary>
    /// Determines whether the specified object is equal to the current result
    /// by using a specified equality comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current result.</param>
    /// <param name="comparer">The equality comparer to compare the represented values.</param>
    /// <returns>true if the specified object is equal to the current result; otherwise, false.</returns>
    bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer)
        => other is Result<T> result && ((IsError && result.IsError) || IsOk && result.IsOk && comparer.Equals(_value, result._value));

    /// <summary>
    /// Returns a hash code for the current result.
    /// </summary>
    /// <returns>A hash code for the current result.</returns>
    public override int GetHashCode()
        => Match(x => x?.GetHashCode() ?? 1, x => x.GetHashCode());

    /// <summary>
    /// Returns a hash code for the current result
    /// computed by a specified equality comparer.
    /// </summary>
    /// <param name="comparer">The equality comparer that computes the hash code of the current result.</param>
    /// <returns>A hash code for the current result.</returns>
    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        => Match(x => x.IsNotNull() ? comparer.GetHashCode(x) : 1, comparer.GetHashCode);

    /// <summary>
    /// Returns a string that represents the current result.
    /// </summary>
    /// <returns>A string that represents the current result.</returns>
    public override string ToString()
        => Match(x => $"Ok({x?.ToString() ?? "null"})", x => $"Error({x})");

    #endregion

    #region Operators

    /// <summary>
    /// Implicitly converts a success value into a result.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{T}"/> representing the success value.</returns>
    public static implicit operator Result<T>(T value)
        => Ok(value);

    /// <summary>
    /// Implicitly converts an error value into a result.
    /// </summary>
    /// <param name="error">The error value.</param>
    /// <returns>A <see cref="Result{T}"/> representing the error value.</returns>
    public static implicit operator Result<T>(Exception error)
        => Error(error);

    /// <summary>
    /// Determines whether a specified result is less than another specified result.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the left result is less than the right result; otherwise, false.</returns>
    public static bool operator <(Result<T> left, Result<T> right)
        => left.CompareTo(right) < 0;

    /// <summary>
    /// Determines whether a specified result is less than or equal to another specified result.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the left result is less than or equal to the right result; otherwise, false.</returns>
    public static bool operator <=(Result<T> left, Result<T> right)
        => left.CompareTo(right) <= 0;

    /// <summary>
    /// Determines whether a specified result is greater than another specified result.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the left result is greater than the right result; otherwise, false.</returns>
    public static bool operator >(Result<T> left, Result<T> right)
        => left.CompareTo(right) > 0;

    /// <summary>
    /// Determines whether a specified result is greater than or equal to another specified result.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the left result is greater than or equal to the right result; otherwise, false.</returns>
    public static bool operator >=(Result<T> left, Result<T> right)
        => left.CompareTo(right) >= 0;

    /// <summary>
    /// Determines whether two specified results are equal.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the specified results are equal; otherwise, false.</returns>
    public static bool operator ==(Result<T> left, Result<T> right)
        => left.Equals(right);

    /// <summary>
    /// Determines whether two specified results are not equal.
    /// </summary>
    /// <param name="left">The first result to compare.</param>
    /// <param name="right">The second result to compare.</param>
    /// <returns>true if the specified results are not equal; otherwise, false.</returns>
    public static bool operator !=(Result<T> left, Result<T> right)
        => !left.Equals(right);

    #endregion
}
