using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DotFluent.Optional;

/// <summary>
/// Provides a set of static methods for working 
/// with <see cref="Option{T}"/> instances.
/// </summary>
public static partial class Option;

/// <summary>
/// Represents an optional value.
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Option{T}"/> generic type.</typeparam>
public readonly union Option<T>(Some<T>, None) : IEnumerable<T>, IEquatable<Option<T>>, IComparable<Option<T>>, IComparable, IStructuralComparable, IStructuralEquatable
{
    /// <summary>
    /// Represents an option value that is a 'None' value.
    /// </summary>
    /// <returns>An <see cref="Option{T}"/> representing the absense of a value of type <typeparamref name="T"/>.</returns>
    public static readonly Option<T> None = default(None);

    /// <summary>
    /// Gets whether the current option is a 'Some' value.
    /// </summary>
    /// <returns><see langword="true"/> if the option is a 'Some' value; otherwise, <see langword="false"/>.</returns>
    public bool IsSome => this is Some<T>;

    /// <summary>
    /// Gets whether the current option is a 'None' value. 
    /// </summary>
    /// <returns><see langword="true"/> if the option is a 'None' value; otherwise, <see langword="false"/>.</returns>
    public bool IsNone => !IsSome;

    /// <summary>
    /// Creates an option value that is a 'Some' value.
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
    public static Option<T> Some(T value)
        => new Some<T>(value);

    /// <summary>
    /// Performs a specified action if the current option is a 'None' value.
    /// </summary>
    /// <param name="none">An action to perform if a value is missing.</param>
    public void Match(Action none)
    {
        none.ThrowIfNull();

        if (IsNone)
            none();
    }

    /// <summary>
    /// Performs a specified action if the current option is a 'Some' value.
    /// </summary>
    /// <param name="some">An action to perform if a value is present.</param>
    public void Match(Action<T> some)
    {
        some.ThrowIfNull();

        if (this is Some<T> s)
            some(s.Value);
    }

    /// <summary>
    /// Performs a specified action based on whether the current option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <param name="some">An action to perform if a value is present.</param>
    /// <param name="none">An action to perform if a value is missing.</param>
    public void Match(Action<T> some, Action none)
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        switch (this)
        {
            case Some<T> s:
                some(s.Value);
                break;
            default:
                none();
                break;
        }
    }

    /// <summary>
    /// Invokes a specified function, or returns a specified alternative value 
    /// based on whether the current option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">The value to return if a value is missing.</param>
    /// <returns>The result of the invoked function if a value is present; otherwise, the specified alternative value.</returns>
    public TResult Match<TResult>(Func<T, TResult> some, TResult none)
        => Match(some, () => none);

    /// <summary>
    /// Invokes a specified function based on whether the current option
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">A function to invoke if a value is missing.</param>
    /// <returns>The result of the invoked function.</returns>
    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        some.ThrowIfNull();
        none.ThrowIfNull();

        return this switch
        {
            Some<T> s => some(s.Value),
            _ => none()
        };
    }

    /// <summary>
    /// Projects the value of the current option into a new form using a specified function,
    /// or returns an empty option based on whether the current option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by mapper.</typeparam>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <returns>
    /// An <see cref="Option{TResult}"/> whose value is the result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public Option<TResult> Map<TResult>(Func<T, TResult> mapper)
    {
        mapper.ThrowIfNull();

        return Match(value => Option.Some(mapper(value)), Option.None<TResult>);
    }

    /// <summary>
    /// Projects the value of the current option into another option using a specified function
    /// and flattens the result, or returns an empty option based on whether the current option 
    /// is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the value of the option returned by mapper.</typeparam>
    /// <param name="mapper">A transform function to apply to the value.</param>
    /// <returns>
    /// An <see cref="Option{TResult}"/> whose value is the flattened result of invoking the transform function on the source value;
    /// otherwise, an empty <see cref="Option{TResult}"/>.
    /// </returns>
    public Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> mapper)
    {
        mapper.ThrowIfNull();

        return Match(mapper, Option.None<TResult>);
    }

    /// <summary>
    /// Returns an alternative option if the current option is a 'None' value.
    /// </summary>
    /// <param name="other">The option to return if a value is missing.</param>
    /// <returns>An <see cref="Option{T}"/> representing a value; otherwise, the specified alternative <see cref="Option{T}"/>.</returns>
    public Option<T> OrElse(Option<T> other)
        => OrElse(() => other);

    /// <summary>
    /// Returns an alternative option created by a specified function 
    /// if the current option is a 'None' value.
    /// </summary>
    /// <param name="otherFactory">A function to create an alternative option.</param>
    /// <returns>
    /// An <see cref="Option{T}"/> representing a value; otherwise, an alternative <see cref="Option{T}"/> created by
    /// the specified function.
    /// </returns>
    public Option<T> OrElse(Func<Option<T>> otherFactory)
    {
        otherFactory.ThrowIfNull();

        return IsSome ? this : otherFactory();
    }

    /// <summary>
    /// Removes the value from the current option if it does not
    /// satisfy a condition.
    /// </summary>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>
    /// An <see cref="Option{T}"/> whose value satisfies the condition in the predicate function;
    /// otherwise, an empty <see cref="Option{T}"/>.
    /// </returns>
    public Option<T> Filter(Func<T, bool> predicate)
    {
        predicate.ThrowIfNull();
        
        return this switch
        {
            Some<T> s when !predicate(s.Value) => None,
            _ => this
        };
    }

    /// <summary>
    /// Determines whether the current option contains a specified value.
    /// </summary>
    /// <param name="value">The value to locate in the option.</param>
    /// <returns><see langword="true"/> if the option contains the specified value; otherwise, <see langword="false"/>.</returns>
    public bool Contains(T value)
        => this is Some<T> s && EqualityComparer<T>.Default.Equals(s.Value, value);

    /// <summary>
    /// Determines whether the current option contains a value that
    /// satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns><see langword="true"/> if the option contains a value that satisfies the condition; otherwise, <see langword="false"/>.</returns>
    public bool Exists(Func<T, bool> predicate)
    {
        predicate.ThrowIfNull();

        return this is Some<T> s && predicate(s.Value);
    }

    /// <summary>
    /// Returns an enumerator for the current option.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> for the option.</returns>
    public IEnumerator<T> GetEnumerator()
        => AsEnumerable().GetEnumerator();

    /// <summary>
    /// Returns an enumerator for the current option.
    /// </summary>
    /// <returns>An <see cref="IEnumerator"/> for the option.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Converts the current option to a sequence with one or zero elements.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing one or zero elements.</returns>
    public IEnumerable<T> AsEnumerable()
    {
        if (this is Some<T> s)
            yield return s.Value;
    }

    /// <summary>
    /// Compares the specified option with the current option.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified option.</returns>
    public int CompareTo(Option<T> other)
        => this switch
        {
            Some<T> left => other is Some<T> right
                ? Comparer<T>.Default.Compare(left.Value, right.Value)
                : 1,
            _ => other.IsSome ? -1 : 0
        };

    /// <summary>
    /// Compares the specified object with the current option.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified object.</returns>
    int IComparable.CompareTo(object? other)
        => other is Option<T> option ? CompareTo(option) : 1;

    /// <summary>
    /// Compares the specified object with the current option by using a specified comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <param name="comparer">The comparer to compare the represented values.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified object.</returns>
    int IStructuralComparable.CompareTo(object? other, IComparer comparer)
    {
        if (other is not Option<T> option)
            return 1;

        return this switch
        {
            Some<T> left => option is Some<T> right
                ? comparer.Compare(left.Value, right.Value)
                : 1,
            _ => option.IsSome ? -1 : 0
        };
    }

    /// <summary>
    /// Determines whether the specified option is equal to the current option.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <returns><see langword="true"/> if the specified option is equal to the current option; otherwise, <see langword="false"/>.</returns>
    public bool Equals(Option<T> other)
        => this switch
        {
            Some<T> left => other is Some<T> right && EqualityComparer<T>.Default.Equals(left.Value, right.Value),
            _ => other.IsNone
        };

    /// <summary>
    /// Determines whether the specified object is equal to the current option.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <returns><see langword="true"/> if the specified object is equal to the current option; otherwise, <see langword="false"/>.</returns>
    public override bool Equals([NotNullWhen(true)]object? other)
        => other is Option<T> option && Equals(option);

    /// <summary>
    /// Determines whether the specified object is equal to the current option
    /// by using a specified equality comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <param name="comparer">The equality comparer to compare the represented values.</param>
    /// <returns><see langword="true"/> if the specified object is equal to the current option; otherwise, <see langword="false"/>.</returns>
    bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer)
        => other is Option<T> option && this switch
        {
            Some<T> left => option is Some<T> right && comparer.Equals(left.Value, right.Value),
            _ => option.IsNone
        };

    /// <summary>
    /// Returns a hash code for the current option.
    /// </summary>
    /// <returns>A hash code for the current option.</returns>
    public override int GetHashCode()
        => Match(value => value?.GetHashCode() ?? 1, 0);

    /// <summary>
    /// Returns a hash code for the current option
    /// computed by a specified equality comparer.
    /// </summary>
    /// <param name="comparer">The equality comparer that computes the hash code of the current option.</param>
    /// <returns>A hash code for the current option.</returns>
    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        => Match(value => value.IsNotNull() ? comparer.GetHashCode(value) : 1, 0);

    /// <summary>
    /// Returns a string that represents the current option.
    /// </summary>
    /// <returns>A string that represents the current option.</returns>
    public override string ToString()
        => Match(value => $"Some({value?.ToString() ?? "null"})", () => nameof(None));

    /// <summary>
    /// Implicitly converts a value into an option.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
    public static implicit operator Option<T>(T? value)
        => value.IsNotNull() ? Some(value) : None;

    /// <summary>
    /// Performs a logical AND operation on two specified options.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>An <see cref="Option{T}"/> representing the result of the logical AND operation.</returns>
    public static Option<T> operator &(Option<T> left, Option<T> right)
        => left.Filter(right.Contains);

    /// <summary>
    /// Performs a logical OR operation on two specified options.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>An <see cref="Option{T}"/> representing the result of the logical OR operation.</returns>
    public static Option<T> operator |(Option<T> left, Option<T> right)
        => left.OrElse(right);

    /// <summary>
    /// Determines whether a specified option is less than another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the left option is less than the right option; otherwise, <see langword="false"/>.</returns>
    public static bool operator <(Option<T> left, Option<T> right)
        => left.CompareTo(right) < 0;

    /// <summary>
    /// Determines whether a specified option is less than or equal to another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the left option is less than or equal to the right option; otherwise, <see langword="false"/>.</returns>
    public static bool operator <=(Option<T> left, Option<T> right)
        => left.CompareTo(right) <= 0;

    /// <summary>
    /// Determines whether a specified option is greater than another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the left option is greater than the right option; otherwise, <see langword="false"/>.</returns>
    public static bool operator >(Option<T> left, Option<T> right)
        => left.CompareTo(right) > 0;

    /// <summary>
    /// Determines whether a specified option is greater than or equal to another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the left option is greater than or equal to the right option; otherwise, <see langword="false"/>.</returns>
    public static bool operator >=(Option<T> left, Option<T> right)
        => left.CompareTo(right) >= 0;

    /// <summary>
    /// Determines whether two specified options are equal.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the specified options are equal; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Option<T> left, Option<T> right)
        => left.Equals(right);

    /// <summary>
    /// Determines whether two specified options are not equal.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns><see langword="true"/> if the specified options are not equal; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(Option<T> left, Option<T> right)
        => !left.Equals(right);

    /// <summary>
    /// Determines whether a specified option is a 'Some' value.
    /// </summary>
    /// <param name="option">The option to check.</param>
    /// <returns><see langword="true"/> if the option is a 'Some' value; otherwise, <see langword="false"/>.</returns>
    public static bool operator true(Option<T> option)
        => option.IsSome;

    /// <summary>
    /// Determines whether a specified option is a 'None' value.
    /// </summary>
    /// <param name="option">The option to check.</param>
    /// <returns><see langword="true"/> if the option is a 'None' value; otherwise, <see langword="false"/>.</returns>
    public static bool operator false(Option<T> option)
        => option.IsNone;
}

/// <summary>
/// Represents the case of <see cref="Option{T}"/> in which a value is present.
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Some{T}"/> generic type.</typeparam>
/// <param name="Value">The contained value, which may be null if <typeparamref name="T"/> allows it.</param>
public readonly record struct Some<T>(T Value);

/// <summary>
/// Represents the case of <see cref="Option{T}"/> in which no value is present.
/// </summary>
public readonly record struct None;
