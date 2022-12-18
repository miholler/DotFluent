using DotFluent.Internal;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace DotFluent.Optional;

/// <summary>
/// Represents an optional value.
/// </summary>
/// <typeparam name="T">The underlying type of the <see cref="Option{T}"/> generic type.</typeparam>
[Serializable]
public readonly struct Option<T> : IEnumerable<T>, IEquatable<Option<T>>, IComparable<Option<T>>, IComparable, IStructuralComparable, IStructuralEquatable, ISerializable
{
    #region Fields

    private readonly T _value;

    #endregion

    #region Ctors

    private Option(T value)
    {
        _value = value;
        IsSome = true;
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    private Option(SerializationInfo info, StreamingContext context)
    {
        IsSome = (bool)info.GetValue(nameof(IsSome), typeof(bool));
        _value = IsSome ? (T)info.GetValue(nameof(Value), typeof(T)) : default!;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets an option value that is a 'None' value.
    /// </summary>
    /// <returns>An <see cref="Option{T}"/> representing the absense of a value of type <typeparamref name="T"/>.</returns>
    public static Option<T> None => default;

    /// <summary>
    /// Get the value of the current option if it is a 'Some' option.
    /// An <see cref="InvalidOperationException"/> is thrown if the option is 'None'.
    /// </summary>
    /// <returns>The value of the option if it is a 'Some' option.</returns>
    public T Value => IsSome ? _value : throw new InvalidOperationException("Option has no value.");

    /// <summary>
    /// Gets whether the current option is a 'Some' value.
    /// </summary>
    /// <returns>true if the option is a 'Some' value; otherwise, false.</returns>
    public bool IsSome { get; }

    /// <summary>
    /// Gets whether the current option is a 'None' value. 
    /// </summary>
    /// <returns>true if the option is a 'None' value; otherwise, false.</returns>
    public bool IsNone => !IsSome;

    #endregion

    #region Methods

    /// <summary>
    /// Creates an option value that is a 'Some' value.
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <returns>An <see cref="Option{T}"/> representing the value.</returns>
    public static Option<T> Some(T value)
        => new(value);

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

        if (IsSome)
            some(_value);
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

        if (IsSome)
            some(_value);
        else
            none();
    }

    /// <summary>
    /// Invokes a specified function, or returns a specified alternative value 
    /// based on whether the current option is a 'Some' or a 'None' value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    /// <param name="some">A function to invoke if a value is present.</param>
    /// <param name="none">The value to return if a value is missing.</param>
    /// <returns>The result of the invoked function if a value is present; otherwise the specified alternative value.</returns>
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

        return IsSome ? some(_value) : none();
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

        return Match(x => Option.Some(mapper(x)), Option.None<TResult>);
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
        
        return IsSome && predicate(_value) ? this : None;
    }

    /// <summary>
    /// Removes the value from the current option if it is a null value.
    /// </summary>
    /// <returns>
    /// An <see cref="Option{T}"/> whose value is not null; 
    /// otherwise, an empty <see cref="Option{T}"/>.
    /// </returns>
    public Option<T> Secure()
        => Filter(x => x.IsNotNull());

    /// <summary>
    /// Returns the number of values contained in the current option.
    /// </summary>
    /// <returns>
    /// An integer indicating the number of values contained in the option.
    /// <para>
    ///     'Some' value: 1
    /// </para>
    /// <para>
    ///     'None' value: 0
    /// </para>
    /// </returns>
    public int Count()
        => IsSome ? 1 : 0;

    /// <summary>
    /// Determines whether the current option contains a specified value.
    /// </summary>
    /// <param name="value">The value to locate in the option.</param>
    /// <returns>true if the option contains the specified value; otherwise, false.</returns>
    public bool Contains(T value)
        => IsSome && EqualityComparer<T>.Default.Equals(_value, value);

    /// <summary>
    /// Determines whether the current option contains a value that
    /// satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <returns>true if the option contains a value that satisfies the condition; otherwise, false.</returns>
    public bool Exists(Func<T, bool> predicate)
    {
        predicate.ThrowIfNull();

        return IsSome && predicate(_value);
    }

    /// <summary>
    /// Populates a storage object with the data needed to serialize the current option.
    /// </summary>
    /// <param name="info">The storage object to populate with data.</param>
    /// <param name="context">The destination for this serialization.</param>
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(IsSome), IsSome);
        if (IsSome)
            info.AddValue(nameof(Value), _value);
    }

    /// <summary>
    /// Returns an enumerator for the current option.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> for the option.</returns>
    public IEnumerator<T> GetEnumerator()
        => AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Converts the current option to a sequence with one or zero elements.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing one or zero elements.</returns>
    public IEnumerable<T> AsEnumerable()
    {
        if (IsSome)
            yield return _value;
    }

    /// <summary>
    /// Compares the specified option with the current option.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified option.</returns>
    public int CompareTo(Option<T> other)
        => CompareTo(other, Comparer<T>.Default);

    /// <summary>
    /// Compares the specified option with the current option by using a specified comparer.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <param name="comparer">The comparer to compare the represented values.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified option.</returns>
    public int CompareTo(Option<T> other, IComparer<T>? comparer)
        => IsNone && other.IsNone ? 0 : IsSome && other.IsNone ? 1 : IsNone && other.IsSome ? -1 : (comparer ?? Comparer<T>.Default).Compare(_value, other._value);

    /// <summary>
    /// Compares the specified object with the current option.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified object.</returns>
    public int CompareTo(object other)
        => other is Option<T> option ? CompareTo(option) : 1;

    /// <summary>
    /// Compares the specified object with the current option by using a specified comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <param name="comparer">The comparer to compare the represented values.</param>
    /// <returns>An integer indicating the order of the current option relative to the specified object.</returns>
    public int CompareTo(object other, IComparer? comparer)
    {
        if (other is Option<T> option)
        {
            comparer ??= StructuralComparisons.StructuralComparer;
            return CompareTo(option, Comparer<T>.Create((x, y) => comparer.Compare(x, y)));
        }
        return 1;
    }

    /// <summary>
    /// Determines whether the specified option is equal to the current option.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <returns>true if the specified option is equal to the current option; otherwise, false.</returns>
    public bool Equals(Option<T> other)
        => Equals(other, EqualityComparer<T>.Default);

    /// <summary>
    /// Determines whether the specified option is equal to the current option
    /// by using a specified equality comparer.
    /// </summary>
    /// <param name="other">The option to compare with the current option.</param>
    /// <param name="comparer">The equality comparer to compare the represented values.</param>
    /// <returns>true if the specified option is equal to the current option; otherwise, false.</returns>
    public bool Equals(Option<T> other, IEqualityComparer<T>? comparer)
        => (IsNone && other.IsNone) || (IsSome && other.IsSome && (comparer ?? EqualityComparer<T>.Default).Equals(_value, other._value));

    /// <summary>
    /// Determines whether the specified object is equal to the current option.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <returns>true if the specified object is equal to the current option; otherwise, false.</returns>
    public override bool Equals(object other)
        => other is Option<T> option && Equals(option);

    /// <summary>
    /// Determines whether the specified object is equal to the current option
    /// by using a specified equality comparer.
    /// </summary>
    /// <param name="other">The object to compare with the current option.</param>
    /// <param name="comparer">The equality comparer to compare the represented values.</param>
    /// <returns>true if the specified object is equal to the current option; otherwise, false.</returns>
    public bool Equals(object other, IEqualityComparer? comparer)
    {
        if (other is Option<T> option)
        {
            comparer ??= StructuralComparisons.StructuralEqualityComparer;
            return Equals(option, ComparisonEqualityComparer<T>.Create((x, y) => comparer.Equals(x, y)));
        }
        return false;
    }

    /// <summary>
    /// Returns a hash code for the current option.
    /// </summary>
    /// <returns>A hash code for the current option.</returns>
    public override int GetHashCode()
        => IsSome ? _value?.GetHashCode() ?? 1 : 0;

    /// <summary>
    /// Returns a hash code for the current option
    /// computed by a specified equality comparer.
    /// </summary>
    /// <param name="comparer">The equality comparer that computes the hash code of the current option.</param>
    /// <returns>A hash code for the current option.</returns>
    public int GetHashCode(IEqualityComparer? comparer)
        => IsSome ? (comparer ?? StructuralComparisons.StructuralEqualityComparer).GetHashCode(_value) : 0;

    /// <summary>
    /// Returns a string that represents the current option.
    /// </summary>
    /// <returns>A string that represents the current option.</returns>
    public override string ToString()
        => IsSome ? $"Some({_value?.ToString() ?? "null"})" : "None";

    #endregion

    #region Operators

    /// <summary>
    /// Implicitly converts a value into an option.
    /// </summary>
    /// <param name="value">The input value.</param>
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
        => left.Equals(right) ? left : None;

    /// <summary>
    /// Performs a logical OR operation on two specified options.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>An <see cref="Option{T}"/> representing the result of the logical OR operation.</returns>
    public static Option<T> operator |(Option<T> left, Option<T> right)
        => left.IsSome ? left : right;

    /// <summary>
    /// Determines whether a specified option is less than another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the left option is less than the right option; otherwise false.</returns>
    public static bool operator <(Option<T> left, Option<T> right)
        => left.CompareTo(right) < 0;

    /// <summary>
    /// Determines whether a specified option is less than or equal to another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the left option is less than or equal to the right option; otherwise false.</returns>
    public static bool operator <=(Option<T> left, Option<T> right)
        => left.CompareTo(right) <= 0;

    /// <summary>
    /// Determines whether a specified option is greater than another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the left option is greater than the right option; otherwise false.</returns>
    public static bool operator >(Option<T> left, Option<T> right)
        => left.CompareTo(right) > 0;

    /// <summary>
    /// Determines whether a specified option is greater than or equal to another specified option.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the left option is greater than or equal to the right option; otherwise false.</returns>
    public static bool operator >=(Option<T> left, Option<T> right)
        => left.CompareTo(right) >= 0;

    /// <summary>
    /// Determines whether two specified options are equal.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the specified options are equal; otherwise false.</returns>
    public static bool operator ==(Option<T> left, Option<T> right)
        => left.Equals(right);

    /// <summary>
    /// Determines whether two specified options are not equal.
    /// </summary>
    /// <param name="left">The first option to compare.</param>
    /// <param name="right">The second option to compare.</param>
    /// <returns>true if the specified options are not equal; otherwise false.</returns>
    public static bool operator !=(Option<T> left, Option<T> right)
        => !left.Equals(right);

    /// <summary>
    /// Determines whether a specified option is a 'Some' value.
    /// </summary>
    /// <param name="option">The option to check.</param>
    /// <returns>true if the option is a 'Some' value; otherwise, false.</returns>
    public static bool operator true(Option<T> option)
        => option.IsSome;

    /// <summary>
    /// Determines whether a specified option is a 'None' value.
    /// </summary>
    /// <param name="option">The option to check.</param>
    /// <returns>true if the option is a 'None' value; otherwise, false.</returns>
    public static bool operator false(Option<T> option)
        => option.IsNone;

    #endregion
}
