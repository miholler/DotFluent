[`< Back`](./)

---

# Result&lt;TValue, TError&gt;

Namespace: DotFluent.Optional

Represents an operational result that is either a success value (Ok)
 or an error value (Error).

```csharp
public struct Result<TValue, TError>
```

#### Type Parameters

`TValue`<br>
The type of the success value.

`TError`<br>
The type of the error value.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
Implements IEnumerable&lt;TValue&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable), IEquatable&lt;Result&lt;TValue, TError&gt;&gt;, IComparable&lt;Result&lt;TValue, TError&gt;&gt;, [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [IStructuralComparable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable), [IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)<br>
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

### **Ok(TValue)**

Creates a result value that is an 'Ok' value.

```csharp
Result<TValue, TError> Ok(TValue value)
```

#### Parameters

`value` TValue<br>
The success value.

#### Returns

[Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the success value.

### **Error(TError)**

Creates a result value that is an 'Error' value.

```csharp
Result<TValue, TError> Error(TError error)
```

#### Parameters

`error` TError<br>
The error value.

#### Returns

[Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the error value.

### **Match(Action&lt;TValue&gt;, Action&lt;TError&gt;)**

Performs a specified action based on whether the current result
 is an 'Ok' or an 'Error' value.

```csharp
void Match(Action<TValue> ok, Action<TError> error)
```

#### Parameters

`ok` Action&lt;TValue&gt;<br>
An action to perform if a success value is present.

`error` Action&lt;TError&gt;<br>
An action to perform if an error value is present.

### **Match&lt;TResult&gt;(Func&lt;TValue, TResult&gt;, Func&lt;TError, TResult&gt;)**

Invokes a specified function based on whether the current result
 is an 'Ok' or an 'Error' value.

```csharp
TResult Match<TResult>(Func<TValue, TResult> ok, Func<TError, TResult> error)
```

#### Type Parameters

`TResult`<br>
The type of the result value.

#### Parameters

`ok` Func&lt;TValue, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, TResult&gt;<br>
A function to invoke if an error value is present.

#### Returns

TResult<br>
The result of the invoked function.

### **Map&lt;TResult&gt;(Func&lt;TValue, TResult&gt;)**

Projects the success value of the current result into a new form using a specified function,
 or returns an 'Error' result based on whether the current result is an 'Ok' or an 'Error' value.

```csharp
Result<TResult, TError> Map<TResult>(Func<TValue, TResult> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`mapper` Func&lt;TValue, TResult&gt;<br>
A transform function to apply to the value.

#### Returns

Result&lt;TResult, TError&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the result of invoking the transform function on
 the source success value; otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapError&lt;TResult&gt;(Func&lt;TError, TResult&gt;)**

Projects the error value of the current result into a new form using a specified function,
 or returns an 'Ok' result based on whether the current result is an 'Ok' or an 'Error' value.

```csharp
Result<TValue, TResult> MapError<TResult>(Func<TError, TResult> mapper)
```

#### Type Parameters

`TResult`<br>

#### Parameters

`mapper` Func&lt;TError, TResult&gt;<br>
A transform function to apply to the value.

#### Returns

Result&lt;TValue, TResult&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose error value is the result of invoking the transform function on
 the source error value; otherwise, an 'Ok' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **FlatMap&lt;TResult&gt;(Func&lt;TValue, Result&lt;TResult, TError&gt;&gt;)**

Projects the success value of the current result into another result using a specified function
 and flattens the result, or returns an 'Error' result based on whether the current result is an
 'Ok' or an 'Error' value.

```csharp
Result<TResult, TError> FlatMap<TResult>(Func<TValue, Result<TResult, TError>> mapper)
```

#### Type Parameters

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`mapper` Func&lt;TValue, Result&lt;TResult, TError&gt;&gt;<br>
A transform function to apply to the value.

#### Returns

Result&lt;TResult, TError&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the flattened result of invoking the transform
 function on the source success value; otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **OrElse(Result&lt;TValue, TError&gt;)**

Returns an alternative result if the current result is an 'Error' value.

```csharp
Result<TValue, TError> OrElse(Result<TValue, TError> other)
```

#### Parameters

`other` [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
The result to return if an error value is present.

#### Returns

[Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value;
 otherwise, the specified alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **OrElse(Func&lt;Result&lt;TValue, TError&gt;&gt;)**

Returns an alternative result created by a specified function
 if the current result is an 'Error' value.

```csharp
Result<TValue, TError> OrElse(Func<Result<TValue, TError>> otherFactory)
```

#### Parameters

`otherFactory` Func&lt;Result&lt;TValue, TError&gt;&gt;<br>
A function to create an alternative result.

#### Returns

[Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value;
 otherwise, an alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) created by the specified function.

### **Contains(TValue)**

Determines whether the current result contains a specified value.

```csharp
bool Contains(TValue value)
```

#### Parameters

`value` TValue<br>
The value to locate in the result.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the result contains the specified value; otherwise, .

### **Exists(Func&lt;TValue, Boolean&gt;)**

Determines whether the current result contains a value that
 satisfies a condition.

```csharp
bool Exists(Func<TValue, bool> predicate)
```

#### Parameters

`predicate` Func&lt;TValue, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the result contains a value that satisfies the condition; otherwise, .

### **GetEnumerator()**

Returns an enumerator for the current result.

```csharp
IEnumerator<TValue> GetEnumerator()
```

#### Returns

IEnumerator&lt;TValue&gt;<br>
An [IEnumerator&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1) for the result.

### **AsEnumerable()**

Converts the current result to a sequence with one or zero elements.

```csharp
IEnumerable<TValue> AsEnumerable()
```

#### Returns

IEnumerable&lt;TValue&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing one or zero elements.

### **CompareTo(Result&lt;TValue, TError&gt;)**

Compares the specified result with the current result.

```csharp
int CompareTo(Result<TValue, TError> other)
```

#### Parameters

`other` [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
The result to compare with the current result.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
An integer indicating the order of the current result relative to the specified result.

### **Equals(Result&lt;TValue, TError&gt;)**

Determines whether the specified result is equal to the current result.

```csharp
bool Equals(Result<TValue, TError> other)
```

#### Parameters

`other` [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)<br>
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
