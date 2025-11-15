[`< Back`](./)

---

# Option&lt;T&gt;

Namespace: DotFluent.Optional

Represents an optional value.

```csharp
public struct Option<T>
```

#### Type Parameters

`T`<br>
The underlying type of the [Option&lt;T&gt;](./dotfluent.optional.option-1) generic type.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
Implements IEnumerable&lt;T&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable), IEquatable&lt;Option&lt;T&gt;&gt;, IComparable&lt;Option&lt;T&gt;&gt;, [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [IStructuralComparable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable), [IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [IsReadOnlyAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.isreadonlyattribute)

## Properties

### **None**

Gets an option value that is a 'None' value.

```csharp
public static Option<T> None { get; }
```

#### Property Value

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>

### **Value**

Get the value of the current option if it is a 'Some' option.
 An [InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) is thrown if the option is 'None'.

```csharp
public T Value { get; }
```

#### Property Value

T<br>

### **IsSome**

Gets whether the current option is a 'Some' value.

```csharp
public bool IsSome { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsNone**

Gets whether the current option is a 'None' value.

```csharp
public bool IsNone { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **Some(T)**

Creates an option value that is a 'Some' value.

```csharp
Option<T> Some(T value)
```

#### Parameters

`value` T<br>
The input value.

#### Returns

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value.

### **Match(Action)**

Performs a specified action if the current option is a 'None' value.

```csharp
void Match(Action none)
```

#### Parameters

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

### **Match(Action&lt;T&gt;)**

Performs a specified action if the current option is a 'Some' value.

```csharp
void Match(Action<T> some)
```

#### Parameters

`some` Action&lt;T&gt;<br>
An action to perform if a value is present.

### **Match(Action&lt;T&gt;, Action)**

Performs a specified action based on whether the current option
 is a 'Some' or a 'None' value.

```csharp
void Match(Action<T> some, Action none)
```

#### Parameters

`some` Action&lt;T&gt;<br>
An action to perform if a value is present.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

### **Match&lt;TResult&gt;(Func&lt;T, TResult&gt;, TResult)**

Invokes a specified function, or returns a specified alternative value 
 based on whether the current option is a 'Some' or a 'None' value.

```csharp
TResult Match<TResult>(Func<T, TResult> some, TResult none)
```

#### Type Parameters

`TResult`<br>
The type of the result value.

#### Parameters

`some` Func&lt;T, TResult&gt;<br>
A function to invoke if a value is present.

`none` TResult<br>
The value to return if a value is missing.

#### Returns

TResult<br>
The result of the invoked function if a value is present; otherwise, the specified alternative value.

### **Match&lt;TResult&gt;(Func&lt;T, TResult&gt;, Func&lt;TResult&gt;)**

Invokes a specified function based on whether the current option
 is a 'Some' or a 'None' value.

```csharp
TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
```

#### Type Parameters

`TResult`<br>
The type of the result value.

#### Parameters

`some` Func&lt;T, TResult&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;TResult&gt;<br>
A function to invoke if a value is missing.

#### Returns

TResult<br>
The result of the invoked function.

### **Map&lt;TResult&gt;(Func&lt;T, TResult&gt;)**

Projects the value of the current option into a new form using a specified function,
 or returns an empty option based on whether the current option is a 'Some' or a 'None' value.

```csharp
Option<TResult> Map<TResult>(Func<T, TResult> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`mapper` Func&lt;T, TResult&gt;<br>
A transform function to apply to the value.

#### Returns

Option&lt;TResult&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FlatMap&lt;TResult&gt;(Func&lt;T, Option&lt;TResult&gt;&gt;)**

Projects the value of the current option into another option using a specified function
 and flattens the result, or returns an empty option based on whether the current option 
 is a 'Some' or a 'None' value.

```csharp
Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the value of the option returned by mapper.

#### Parameters

`mapper` Func&lt;T, Option&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

#### Returns

Option&lt;TResult&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the flattened result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **OrElse(Option&lt;T&gt;)**

Returns an alternative option if the current option is a 'None' value.

```csharp
Option<T> OrElse(Option<T> other)
```

#### Parameters

`other` [Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
The option to return if a value is missing.

#### Returns

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, the specified alternative [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **OrElse(Func&lt;Option&lt;T&gt;&gt;)**

Returns an alternative option created by a specified function 
 if the current option is a 'None' value.

```csharp
Option<T> OrElse(Func<Option<T>> otherFactory)
```

#### Parameters

`otherFactory` Func&lt;Option&lt;T&gt;&gt;<br>
A function to create an alternative option.

#### Returns

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, an alternative [Option&lt;T&gt;](./dotfluent.optional.option-1) created by
 the specified function.

### **Filter(Func&lt;T, Boolean&gt;)**

Removes the value from the current option if it does not
 satisfy a condition.

```csharp
Option<T> Filter(Func<T, bool> predicate)
```

#### Parameters

`predicate` Func&lt;T, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value satisfies the condition in the predicate function;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **Secure()**

Removes the value from the current option if it is a null value.

```csharp
Option<T> Secure()
```

#### Returns

[Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is not null; 
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **Contains(T)**

Determines whether the current option contains a specified value.

```csharp
bool Contains(T value)
```

#### Parameters

`value` T<br>
The value to locate in the option.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the option contains the specified value; otherwise, .

### **Exists(Func&lt;T, Boolean&gt;)**

Determines whether the current option contains a value that
 satisfies a condition.

```csharp
bool Exists(Func<T, bool> predicate)
```

#### Parameters

`predicate` Func&lt;T, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the option contains a value that satisfies the condition; otherwise, .

### **GetEnumerator()**

Returns an enumerator for the current option.

```csharp
IEnumerator<T> GetEnumerator()
```

#### Returns

IEnumerator&lt;T&gt;<br>
An [IEnumerator&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1) for the option.

### **AsEnumerable()**

Converts the current option to a sequence with one or zero elements.

```csharp
IEnumerable<T> AsEnumerable()
```

#### Returns

IEnumerable&lt;T&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing one or zero elements.

### **CompareTo(Option&lt;T&gt;)**

Compares the specified option with the current option.

```csharp
int CompareTo(Option<T> other)
```

#### Parameters

`other` [Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
The option to compare with the current option.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
An integer indicating the order of the current option relative to the specified option.

### **Equals(Option&lt;T&gt;)**

Determines whether the specified option is equal to the current option.

```csharp
bool Equals(Option<T> other)
```

#### Parameters

`other` [Option&lt;T&gt;](./dotfluent.optional.option-1)<br>
The option to compare with the current option.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the specified option is equal to the current option; otherwise, .

### **Equals(Object)**

Determines whether the specified object is equal to the current option.

```csharp
bool Equals(object other)
```

#### Parameters

`other` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to compare with the current option.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the specified object is equal to the current option; otherwise, .

### **GetHashCode()**

Returns a hash code for the current option.

```csharp
int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
A hash code for the current option.

### **ToString()**

Returns a string that represents the current option.

```csharp
string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current option.

---

[`< Back`](./)
