[`< Back`](./)

---

# UnsafeResultTask

Namespace: DotFluent.Optional.Unsafe.Tasks

Provides a set of static methods for working with 
 [Result&lt;T&gt;](./dotfluent.optional.result-1) and [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2)
 instances asynchronously.

```csharp
public static class UnsafeResultTask
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnsafeResultTask](./dotfluent.optional.unsafe.tasks.unsaferesulttask)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValueOrDefaultAsync&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Result<TSource> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to retrieve the success value of.

`defaultFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or the type parameter's default value.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Result<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value for the  type.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, TSource, CancellationToken)**

Asynchronously retrieves the success value of a result, or a specified default value.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Result<TSource>> source, TSource defaultValue, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultValue` TSource<br>
The value to return if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the defaultValue parameter.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;TSource&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Result<TSource>> source, Func<TSource> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Result<TSource>> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;Task&lt;TValue&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(Result<TValue, TError> source, Func<Task<TValue>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to retrieve the success value of.

`defaultFactory` Func&lt;Task&lt;TValue&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TValue&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or the type parameter's default value.

```csharp
public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(Task<Result<TValue, TError>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TValue&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value for the  type.

### **GetValueOrDefaultAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, TValue, CancellationToken)**

Asynchronously retrieves the success value of a result, or a specified default value.

```csharp
public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(Task<Result<TValue, TError>> source, TValue defaultValue, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultValue` TValue<br>
The value to return if an error value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TValue&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the defaultValue parameter.

### **GetValueOrDefaultAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;TValue&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<TValue> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultFactory` Func&lt;TValue&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TValue&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, Func&lt;Task&lt;TValue&gt;&gt;, CancellationToken)**

Asynchronously retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static Task<TValue> GetValueOrDefaultAsync<TValue, TError>(Task<Result<TValue, TError>> source, Func<Task<TValue>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to retrieve the success value of.

`defaultFactory` Func&lt;Task&lt;TValue&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TValue&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value created by the specified function.

### **ToNullableAsync&lt;TSource&gt;(Result&lt;TSource&gt;, CancellationToken)**

Asynchronously creates a nullable object from a result.

```csharp
public static Task<Nullable<TSource>> ToNullableAsync<TSource>(Result<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

### **ToNullableAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously creates a nullable object from a result.

```csharp
public static Task<Nullable<TSource>> ToNullableAsync<TSource>(Task<Result<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

### **ToNullableAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, CancellationToken)**

Asynchronously creates a nullable object from a result.

```csharp
public static Task<Nullable<TValue>> ToNullableAsync<TValue, TError>(Result<TValue, TError> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TValue&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

### **ToNullableAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, CancellationToken)**

Asynchronously creates a nullable object from a result.

```csharp
public static Task<Nullable<TValue>> ToNullableAsync<TValue, TError>(Task<Result<TValue, TError>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TValue&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

---

[`< Back`](./)
