[`< Back`](./)

---

# ResultTask

Namespace: DotFluent.Optional.Tasks

Provides a set of static methods for working with 
 [Result&lt;T&gt;](./dotfluent.optional.result-1) and [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) 
 instances asynchronously.

```csharp
public static class ResultTask
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ResultTask](./dotfluent.optional.tasks.resulttask)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **ContainsAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TSource>(Result<TSource> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result in which to locate a value.

`valueFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create the value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **ContainsAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, TSource, CancellationToken)**

Asynchronously determines whether a result contains a specified value.

```csharp
public static Task<bool> ContainsAsync<TSource>(Task<Result<TSource>> source, TSource value, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result in which to locate a value.

`value` TSource<br>
The value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **ContainsAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TSource>(Task<Result<TSource>> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result in which to locate a value.

`valueFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create the value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **ContainsAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;Task&lt;TValue&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TValue, TError>(Result<TValue, TError> source, Func<Task<TValue>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result in which to locate a value.

`valueFactory` Func&lt;Task&lt;TValue&gt;&gt;<br>
A function to create the value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **ContainsAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, TValue, CancellationToken)**

Asynchronously determines whether a result contains a specified value.

```csharp
public static Task<bool> ContainsAsync<TValue, TError>(Task<Result<TValue, TError>> source, TValue value, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result in which to locate a value.

`value` TValue<br>
The value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **ContainsAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;Task&lt;TValue&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<Task<TValue>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result in which to locate a value.

`valueFactory` Func&lt;Task&lt;TValue&gt;&gt;<br>
A function to create the value to locate in the result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the result contains the specified value; otherwise, .

### **Error&lt;TResult&gt;(Exception)**

Creates a task returning a result value that is an 'Error' value.

```csharp
public static Task<Result<TResult>> Error<TResult>(Exception error)
```

#### Type Parameters

`TResult`<br>
The type of the success value.

#### Parameters

`error` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The error value.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the error value.

### **Error&lt;TValue, TError&gt;(TError)**

Creates a task returning a result value that is an 'Error' value.

```csharp
public static Task<Result<TValue, TError>> Error<TValue, TError>(TError error)
```

#### Type Parameters

`TValue`<br>
The type of the success value.

`TError`<br>
The type of the error value.

#### Parameters

`error` TError<br>
The error value.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the error value.

### **ExistsAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Result<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result in which to locate a value.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Boolean&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Task<Result<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result in which to locate a value.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Task<Result<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result in which to locate a value.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TValue, TError>(Result<TValue, TError> source, Func<TValue, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result in which to locate a value.

`predicate` Func&lt;TValue, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Boolean&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<TValue, bool> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result in which to locate a value.

`predicate` Func&lt;TValue, Boolean&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether a result contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<TValue, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result in which to locate a value.

`predicate` Func&lt;TValue, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the result contains a value that satisfies the condition; otherwise, .

### **FlatMapAsync&lt;TSource, TResult&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&lt;Result&lt;TResult&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(Result<TSource> source, Func<TSource, Task<Result<TResult>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result whose success value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;Result&lt;TResult&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **FlatMapAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Result&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, Result<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TSource, Result&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **FlatMapAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;Result&lt;TResult&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> FlatMapAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, Task<Result<TResult>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;Result&lt;TResult&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **FlatMapAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&lt;Result&lt;TResult, TError&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> FlatMapAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TValue, Task<Result<TResult, TError>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result whose success value is to be transformed.

`mapper` Func&lt;TValue, Task&lt;Result&lt;TResult, TError&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **FlatMapAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Result&lt;TResult, TError&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> FlatMapAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, Result<TResult, TError>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TValue, Result&lt;TResult, TError&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **FlatMapAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&lt;Result&lt;TResult, TError&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into another result using a specified function and
 flattens the result, or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> FlatMapAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, Task<Result<TResult, TError>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the success value of the result returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TValue, Task&lt;Result&lt;TResult, TError&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the flattened result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **FlattenAsync&lt;TSource&gt;(Result&lt;Result&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously flattens a result with a nested result into one result.

```csharp
public static Task<Result<TSource>> FlattenAsync<TSource>(Result<Result<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of the nested result.

#### Parameters

`source` Result&lt;Result&lt;TSource&gt;&gt;<br>
The result with a nested result to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the flattened result.

### **FlattenAsync&lt;TSource&gt;(Task&lt;Result&lt;Result&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously flattens a result with a nested result into one result.

```csharp
public static Task<Result<TSource>> FlattenAsync<TSource>(Task<Result<Result<TSource>>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of the nested result.

#### Parameters

`source` Task&lt;Result&lt;Result&lt;TSource&gt;&gt;&gt;<br>
The task returning the result with a nested result to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the flattened result.

### **FlattenAsync&lt;TValue, TError&gt;(Result&lt;Result&lt;TValue, TError&gt;, TError&gt;, CancellationToken)**

Asynchronously flattens a result with a nested result into one result.

```csharp
public static Task<Result<TValue, TError>> FlattenAsync<TValue, TError>(Result<Result<TValue, TError>, TError> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;Result&lt;TValue, TError&gt;, TError&gt;<br>
The result with a nested result to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the flattened result.

### **FlattenAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;Result&lt;TValue, TError&gt;, TError&gt;&gt;, CancellationToken)**

Asynchronously flattens a result with a nested result into one result.

```csharp
public static Task<Result<TValue, TError>> FlattenAsync<TValue, TError>(Task<Result<Result<TValue, TError>, TError>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;Result&lt;TValue, TError&gt;, TError&gt;&gt;<br>
The task returning the result with a nested result to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the flattened result.

### **MapAsync&lt;TSource, TResult&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> MapAsync<TSource, TResult>(Result<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result whose success value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> MapAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, TResult> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TSource, TResult&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult>> MapAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TValue, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result whose success value is to be transformed.

`mapper` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, TResult&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, TResult> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TValue, TResult&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the success value of a result into a new form using a specified function,
 or returns an 'Error' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TResult, TError>> MapAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose success value is to be transformed.

`mapper` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TResult, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose success value is the result of invoking the transform function on the success value of source;
 otherwise, an 'Error' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapErrorAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;Exception, Task&lt;Exception&gt;&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TSource>> MapErrorAsync<TSource>(Result<TSource> source, Func<Exception, Task<Exception>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result whose error value is to be transformed.

`mapper` [Func&lt;Exception, Task&lt;Exception&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapErrorAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Exception, Exception&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TSource>> MapErrorAsync<TSource>(Task<Result<TSource>> source, Func<Exception, Exception> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose error value is to be transformed.

`mapper` [Func&lt;Exception, Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapErrorAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Exception, Task&lt;Exception&gt;&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TSource>> MapErrorAsync<TSource>(Task<Result<TSource>> source, Func<Exception, Task<Exception>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result whose error value is to be transformed.

`mapper` [Func&lt;Exception, Task&lt;Exception&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **MapErrorAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TError, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result whose error value is to be transformed.

`mapper` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapErrorAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TError, TResult&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TError, TResult> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose error value is to be transformed.

`mapper` Func&lt;TError, TResult&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MapErrorAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the error value of a result into a new form using a specified function,
 or returns an 'Ok' result based on whether the result is an 'Ok' or an 'Error' value.

```csharp
public static Task<Result<TValue, TResult>> MapErrorAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TError, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result whose error value is to be transformed.

`mapper` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'map error' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) whose error value is the result of invoking the transform function on the error value of source;
 otherwise, an 'Ok' [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **MatchAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&gt;, Action&lt;Exception&gt;, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Result<TSource> source, Func<TSource, Task> ok, Action<Exception> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TSource, Task&gt;<br>
A function to invoke if a success value is present.

`error` [Action&lt;Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Action&lt;TSource&gt;, Func&lt;Exception, Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Result<TSource> source, Action<TSource> ok, Func<Exception, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Action&lt;TSource&gt;<br>
An action to perform if a success value is present.

`error` [Func&lt;Exception, Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&gt;, Func&lt;Exception, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Result<TSource> source, Func<TSource, Task> ok, Func<Exception, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TSource, Task&gt;<br>
A function to invoke if a success value is present.

`error` [Func&lt;Exception, Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource, TResult&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Exception, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Result<TSource> source, Func<TSource, Task<TResult>> ok, Func<Exception, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Result&lt;TSource&gt;, Func&lt;TSource, TResult&gt;, Func&lt;Exception, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Result<TSource> source, Func<TSource, TResult> ok, Func<Exception, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Result&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Exception, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Result<TSource> source, Func<TSource, Task<TResult>> ok, Func<Exception, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Action&lt;TSource&gt;, Action&lt;Exception&gt;, CancellationToken)**

Asynchronously performs a specified action based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Task<Result<TSource>> source, Action<TSource> ok, Action<Exception> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Action&lt;TSource&gt;<br>
An action to perform if a success value is present.

`error` [Action&lt;Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&gt;, Action&lt;Exception&gt;, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Task<Result<TSource>> source, Func<TSource, Task> ok, Action<Exception> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, Task&gt;<br>
A function to invoke if a success value is present.

`error` [Action&lt;Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Action&lt;TSource&gt;, Func&lt;Exception, Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Task<Result<TSource>> source, Action<TSource> ok, Func<Exception, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Action&lt;TSource&gt;<br>
An action to perform if a success value is present.

`error` [Func&lt;Exception, Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&gt;, Func&lt;Exception, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TSource>(Task<Result<TSource>> source, Func<TSource, Task> ok, Func<Exception, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, Task&gt;<br>
A function to invoke if a success value is present.

`error` [Func&lt;Exception, Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, Func&lt;Exception, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, TResult> ok, Func<Exception, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Exception, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, Task<TResult>> ok, Func<Exception, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, Func&lt;Exception, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, TResult> ok, Func<Exception, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Exception, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Result<TSource>> source, Func<TSource, Task<TResult>> ok, Func<Exception, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;Exception, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&gt;, Action&lt;TError&gt;, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Result<TValue, TError> source, Func<TValue, Task> ok, Action<TError> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TValue, Task&gt;<br>
A function to invoke if a success value is present.

`error` Action&lt;TError&gt;<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Action&lt;TValue&gt;, Func&lt;TError, Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Result<TValue, TError> source, Action<TValue> ok, Func<TError, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Action&lt;TValue&gt;<br>
An action to perform if a success value is present.

`error` Func&lt;TError, Task&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&gt;, Func&lt;TError, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Result<TValue, TError> source, Func<TValue, Task> ok, Func<TError, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TValue, Task&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, Func&lt;TError, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TValue, Task<TResult>> ok, Func<TError, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, TResult&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TValue, TResult> ok, Func<TError, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TValue, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Result<TValue, TError> source, Func<TValue, Task<TResult>> ok, Func<TError, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`ok` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Action&lt;TValue&gt;, Action&lt;TError&gt;, CancellationToken)**

Asynchronously performs a specified action based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Task<Result<TValue, TError>> source, Action<TValue> ok, Action<TError> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Action&lt;TValue&gt;<br>
An action to perform if a success value is present.

`error` Action&lt;TError&gt;<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&gt;, Action&lt;TError&gt;, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<TValue, Task> ok, Action<TError> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, Task&gt;<br>
A function to invoke if a success value is present.

`error` Action&lt;TError&gt;<br>
An action to perform if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Action&lt;TValue&gt;, Func&lt;TError, Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether a result is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Task<Result<TValue, TError>> source, Action<TValue> ok, Func<TError, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Action&lt;TValue&gt;<br>
An action to perform if a success value is present.

`error` Func&lt;TError, Task&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&gt;, Func&lt;TError, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task MatchAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<TValue, Task> ok, Func<TError, Task> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, Task&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, TResult&gt;, Func&lt;TError, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, TResult> ok, Func<TError, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, Func&lt;TError, TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, Task<TResult>> ok, Func<TError, TResult> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, TResult&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, TResult&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, TResult> ok, Func<TError, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, TResult&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TValue, TError, TResult&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue, Task&lt;TResult&gt;&gt;, Func&lt;TError, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether a result
 is an 'Ok' or an 'Error' value.

```csharp
public static Task<TResult> MatchAsync<TValue, TError, TResult>(Task<Result<TValue, TError>> source, Func<TValue, Task<TResult>> ok, Func<TError, Task<TResult>> error, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`ok` Func&lt;TValue, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a success value is present.

`error` Func&lt;TError, Task&lt;TResult&gt;&gt;<br>
A function to invoke if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **Ok&lt;TResult&gt;(TResult)**

Creates a task returning a result value that is an 'Ok' value.

```csharp
public static Task<Result<TResult>> Ok<TResult>(TResult value)
```

#### Type Parameters

`TResult`<br>
The type of the success value.

#### Parameters

`value` TResult<br>
The success value.

#### Returns

Task&lt;Result&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the success value.

### **Ok&lt;TValue, TError&gt;(TValue)**

Creates a task returning a result value that is an 'Ok' value.

```csharp
public static Task<Result<TValue, TError>> Ok<TValue, TError>(TValue value)
```

#### Type Parameters

`TValue`<br>
The type of the success value.

`TError`<br>
The type of the error value.

#### Parameters

`value` TValue<br>
The success value.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the success value.

### **OrElseAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;Task&lt;Result&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TSource>> OrElseAsync<TSource>(Result<TSource> source, Func<Task<Result<TSource>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to check for a success or an error value.

`otherFactory` Func&lt;Task&lt;Result&lt;TSource&gt;&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, an alternative [Result&lt;T&gt;](./dotfluent.optional.result-1) created by
 the specified function.

### **OrElseAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Result&lt;TSource&gt;, CancellationToken)**

Asynchronously returns an alternative result if a result is an 'Error' value.

```csharp
public static Task<Result<TSource>> OrElseAsync<TSource>(Task<Result<TSource>> source, Result<TSource> other, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`other` Result&lt;TSource&gt;<br>
The result to return if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, the specified alternative [Result&lt;T&gt;](./dotfluent.optional.result-1).

### **OrElseAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Result&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TSource>> OrElseAsync<TSource>(Task<Result<TSource>> source, Func<Result<TSource>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`otherFactory` Func&lt;Result&lt;TSource&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, an alternative [Result&lt;T&gt;](./dotfluent.optional.result-1) created by
 the specified function.

### **OrElseAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Task&lt;Result&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TSource>> OrElseAsync<TSource>(Task<Result<TSource>> source, Func<Task<Result<TSource>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`otherFactory` Func&lt;Task&lt;Result&lt;TSource&gt;&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;T&gt;](./dotfluent.optional.result-1) representing a success value; otherwise, an alternative [Result&lt;T&gt;](./dotfluent.optional.result-1) created by
 the specified function.

### **OrElseAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;Task&lt;Result&lt;TValue, TError&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(Result<TValue, TError> source, Func<Task<Result<TValue, TError>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to check for a success or an error value.

`otherFactory` Func&lt;Task&lt;Result&lt;TValue, TError&gt;&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value; otherwise, an alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)
 created by the specified function.

### **OrElseAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Result&lt;TValue, TError&gt;, CancellationToken)**

Asynchronously returns an alternative result if a result is an 'Error' value.

```csharp
public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(Task<Result<TValue, TError>> source, Result<TValue, TError> other, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`other` Result&lt;TValue, TError&gt;<br>
The result to return if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value; otherwise, the specified alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2).

### **OrElseAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;Result&lt;TValue, TError&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<Result<TValue, TError>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`otherFactory` Func&lt;Result&lt;TValue, TError&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value; otherwise, an alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)
 created by the specified function.

### **OrElseAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;Task&lt;Result&lt;TValue, TError&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative result created by a specified function
 if a result is an 'Error' value.

```csharp
public static Task<Result<TValue, TError>> OrElseAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<Task<Result<TValue, TError>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to check for a success or an error value.

`otherFactory` Func&lt;Task&lt;Result&lt;TValue, TError&gt;&gt;&gt;<br>
A function to create an alternative result.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 a [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing a success value; otherwise, an alternative [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)
 created by the specified function.

---

[`< Back`](./)
