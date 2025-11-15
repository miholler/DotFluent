[`< Back`](./)

---

# Result&lt;T&gt;

Namespace: DotFluent.Optional

Represents an operational result that is either a success value (Ok)
 or an error value (Error).

```csharp
public struct Result<T>
```

#### Type Parameters

`T`<br>
The underlying type of the [Result&lt;T&gt;](./dotfluent.optional.result-1) generic type.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
Implements IEnumerable&lt;T&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable), IEquatable&lt;Result&lt;T&gt;&gt;, IComparable&lt;Result&lt;T&gt;&gt;, [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [IStructuralComparable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable), [IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [IsReadOnlyAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.isreadonlyattribute)

## Properties

### **IsOk**

Gets whether the current result is an 'Ok' value.

```csharp
public bool IsOk { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsError**

Gets whether the current result is an 'Error' value.

```csharp
public bool IsError { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **Ok(T)**

Creates a result value that is an 'Ok' value.

```csharp
Result<T> Ok(T value)
```

#### Parameters

`value` T<br>
The success value.

#### Returns

[Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the success value.

### **Error(Exception)**

Creates a result value that is an 'Error' value.

```csharp
Result<T> Error(Exception error)
```

#### Parameters

`error` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The error value.

#### Returns

[Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the error value.

### **Match(Action&lt;T&gt;, Action&lt;Exception&gt;)**

Performs a specified action based on whether the current result
 is an 'Ok' or an 'Error' value.

```csharp
void Match(Action<T> ok, Action<Exception> error)
```

#### Parameters

`ok` Action&lt;T&gt;<br>
An action to perform if a success value is present.

`error` [Action&lt;Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An action to perform if an error value is present.

### **Match&lt;TResult&gt;(Func&lt;T, TResult&gt;, Func&lt;Exception, TResult&gt;)**

Invokes a specified function based on whether the current result
 is an 'Ok' or an 'Error' value.

```csharp
TResult Match<TResult>(Func<T, TResult> ok, Func<Exception, TResult> error)
```

#### Type Parameters

`TResult`<br>
The type of the result value.

#### Parameters

`ok` Func&lt;T, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, TResult&gt;<br>
A function to invoke if an error value is present.

#### Returns

TResult<br>
The result of the invoked function.

### **Map&lt;TResult&gt;(Func&lt;T, TResult&gt;)**

Projects the success value of the current result into a new form using a specified function,
 or returns an 'Error' result based on whether the current result is an 'Ok' or an 'Error' value.

```csharp
Result<TResult> Map<TResult>(Func<T, TResult> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`mapper` Func&lt;T, TResult&gt;<br>
A transform function to apply to the value.

#### Returns

Result&lt;TResult&gt;<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the result of invoking the transform function on
 the source success value; otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapError(Func&lt;Exception, Exception&gt;)**

Projects the error value of the current result into a new form using a specified function,
 or returns an 'Ok' result based on whether the current result is an 'Ok' or an 'Error' value.

```csharp
Result<T> MapError(Func<Exception, Exception> mapper)
```

#### Parameters

`mapper` [Func&lt;Exception, Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A transform function to apply to the value.

#### Returns

[Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) whose error value is the result of invoking the transform function on
 the source error value; otherwise, an 'Ok' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **FlatMap&lt;TResult&gt;(Func&lt;T, Result&lt;TResult&gt;&gt;)**

Projects the success value of the current result into another result using a specified function
 and flattens the result, or returns an 'Error' result based on whether the current result is an
 'Ok' or an 'Error' value.

```csharp
Result<TResult> FlatMap<TResult>(Func<T, Result<TResult>> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`mapper` Func&lt;T, Result&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

#### Returns

Result&lt;TResult&gt;<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the flattened result of invoking the transform
 function on the source success value; otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **OrElse(Result&lt;T&gt;)**

Returns an alternative result if the current result is an 'Error' value.

```csharp
Result<T> OrElse(Result<T> other)
```

#### Parameters

`other` [Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
The result to return if an error value is present.

#### Returns

[Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, the specified alternative [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **OrElse(Func&lt;Result&lt;T&gt;&gt;)**

Returns an alternative result created by a specified function
 if the current result is an 'Error' value.

```csharp
Result<T> OrElse(Func<Result<T>> otherFactory)
```

#### Parameters

`otherFactory` Func&lt;Result&lt;T&gt;&gt;<br>
A function to create an alternative result.

#### Returns

[Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, an alternative [Result&lt;T&gt;](./dotfluent.optional.result-1)
 created by the specified function.

### **Contains(T)**

Determines whether the current result contains a specified value.

```csharp
bool Contains(T value)
```

#### Parameters

`value` T<br>
The value to locate in the result.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the result contains the specified value; otherwise, .

### **Exists(Func&lt;T, Boolean&gt;)**

Determines whether the current result contains a value that
 satisfies a condition.

```csharp
bool Exists(Func<T, bool> predicate)
```

#### Parameters

`predicate` Func&lt;T, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the result contains a value that satisfies the condition; otherwise, .

### **GetEnumerator()**

Returns an enumerator for the current result.

```csharp
IEnumerator<T> GetEnumerator()
```

#### Returns

IEnumerator&lt;T&gt;<br>
An [IEnumerator&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1) for the result.

### **AsEnumerable()**

Converts the current result to a sequence with one or zero elements.

```csharp
IEnumerable<T> AsEnumerable()
```

#### Returns

IEnumerable&lt;T&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing one or zero elements.

### **CompareTo(Result&lt;T&gt;)**

Compares the specified result with the current result.

```csharp
int CompareTo(Result<T> other)
```

#### Parameters

`other` [Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
The result to compare with the current result.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
An integer indicating the order of the current result relative to the specified result.

### **Equals(Result&lt;T&gt;)**

Determines whether the specified result is equal to the current result.

```csharp
bool Equals(Result<T> other)
```

#### Parameters

`other` [Result&lt;T&gt;](./dotfluent.optional.result-1)<br>
The result to compare with the current result.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the specified result is equal to the current result; otherwise, .

### **Equals(Object)**

Determines whether the specified object is equal to the current result.

```csharp
bool Equals(object other)
```

#### Parameters

`other` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to compare with the current result.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the specified object is equal to the current result; otherwise, .

### **GetHashCode()**

Returns a hash code for the current result.

```csharp
int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
A hash code for the current result.

### **ToString()**

Returns a string that represents the current result.

```csharp
string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current result.

---

[`< Back`](./)
