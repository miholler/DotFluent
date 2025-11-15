[`< Back`](./)

---

# UnsafeOptionTask

Namespace: DotFluent.Optional.Unsafe.Tasks

Provides a set of static methods for working with 
 [Option&lt;T&gt;](./dotfluent.optional.option-1) instances asynchronously.

```csharp
public static class UnsafeOptionTask
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnsafeOptionTask](./dotfluent.optional.unsafe.tasks.unsafeoptiontask)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValueOrDefaultAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the value of an option, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Option<TSource> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to retrieve the value of.

`defaultFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the value of an option, or the type parameter's default value.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Option<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to retrieve the value of.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value for the  type.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, TSource, CancellationToken)**

Asynchronously retrieves the value of an option, or a specified default value.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Option<TSource>> source, TSource defaultValue, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to retrieve the value of.

`defaultValue` TSource<br>
The value to return if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the defaultValue parameter.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource&gt;, CancellationToken)**

Asynchronously retrieves the value of an option, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Option<TSource>> source, Func<TSource> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to retrieve the value of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value created by the specified function.

### **GetValueOrDefaultAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously retrieves the value of an option, or a default value created by a
 specified function.

```csharp
public static Task<TSource> GetValueOrDefaultAsync<TSource>(Task<Option<TSource>> source, Func<Task<TSource>> defaultFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to retrieve the value of.

`defaultFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create a default value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TSource&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous get operation. The value of the TResult parameter contains
 the value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value created by the specified function.

### **ToNullableAsync&lt;TSource&gt;(Option&lt;TSource&gt;, CancellationToken)**

Asynchronously creates a nullable object from an option.

```csharp
public static Task<Nullable<TSource>> ToNullableAsync<TSource>(Option<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the value of source.

### **ToNullableAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously creates a nullable object from an option.

```csharp
public static Task<Nullable<TSource>> ToNullableAsync<TSource>(Task<Option<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to create the nullable object from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Nullable&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to nullable' operation. The value of the TResult parameter contains
 a [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the value of source.

---

[`< Back`](./)
