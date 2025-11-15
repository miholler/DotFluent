[`< Back`](./)

---

# OptionTask

Namespace: DotFluent.Optional.Tasks

Provides a set of static methods for working with 
 [Option&lt;T&gt;](./dotfluent.optional.option-1) instances asynchronously.

```csharp
public static class OptionTask
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [OptionTask](./dotfluent.optional.tasks.optiontask)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **ContainsAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously determines whether an option contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TSource>(Option<TSource> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option in which to locate a value.

`valueFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create the value to locate in the option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the option contains the specified value; otherwise, .

### **ContainsAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, TSource, CancellationToken)**

Asynchronously determines whether an option contains a specified value.

```csharp
public static Task<bool> ContainsAsync<TSource>(Task<Option<TSource>> source, TSource value, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option in which to locate a value.

`value` TSource<br>
The value to locate in the option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the option contains the specified value; otherwise, .

### **ContainsAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;Task&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously determines whether an option contains a value created by a specified function.

```csharp
public static Task<bool> ContainsAsync<TSource>(Task<Option<TSource>> source, Func<Task<TSource>> valueFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option in which to locate a value.

`valueFactory` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to create the value to locate in the option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous contains operation. The value of the TResult parameter contains
  if the option contains the specified value; otherwise, .

### **ExistsAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether an option contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Option<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option in which to locate a value.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the option contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Boolean&gt;, CancellationToken)**

Asynchronously determines whether an option contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Task<Option<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option in which to locate a value.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the option contains a value that satisfies the condition; otherwise, .

### **ExistsAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously determines whether an option contains a value that satisfies a condition.

```csharp
public static Task<bool> ExistsAsync<TSource>(Task<Option<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option in which to locate a value.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous exists operation. The value of the TResult parameter contains
  if the option contains a value that satisfies the condition; otherwise, .

### **FilterAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously removes the value from an option if it does not satisfy a condition.

```csharp
public static Task<Option<TSource>> FilterAsync<TSource>(Option<TSource> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option whose value is to be filtered.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous filter operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value satisfies the condition in the predicate function; 
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FilterAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Boolean&gt;, CancellationToken)**

Asynchronously removes the value from an option if it does not satisfy a condition.

```csharp
public static Task<Option<TSource>> FilterAsync<TSource>(Task<Option<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be filtered.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous filter operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value satisfies the condition in the predicate function; 
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FilterAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;Boolean&gt;&gt;, CancellationToken)**

Asynchronously removes the value from an option if it does not satisfy a condition.

```csharp
public static Task<Option<TSource>> FilterAsync<TSource>(Task<Option<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be filtered.

`predicate` Func&lt;TSource, Task&lt;Boolean&gt;&gt;<br>
A function to test the value for a condition.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous filter operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value satisfies the condition in the predicate function; 
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FlatMapAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;Option&lt;TResult&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the value of an option into another option using a specified function and
 flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(Option<TSource> source, Func<TSource, Task<Option<TResult>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value of the option returned by mapper.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option whose value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;Option&lt;TResult&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the flattened result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FlatMapAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Option&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the value of an option into another option using a specified function and
 flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Option<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value of the option returned by mapper.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be transformed.

`mapper` Func&lt;TSource, Option&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the flattened result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FlatMapAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;Option&lt;TResult&gt;&gt;&gt;, CancellationToken)**

Asynchronously projects the value of an option into another option using a specified function and
 flattens the result, or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> FlatMapAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Task<Option<TResult>>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value of the option returned by mapper.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;Option&lt;TResult&gt;&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'flat map' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the flattened result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **FlattenAsync&lt;TSource&gt;(Option&lt;Option&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously flattens an option with a nested option into one option.

```csharp
public static Task<Option<TSource>> FlattenAsync<TSource>(Option<Option<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of the nested option.

#### Parameters

`source` Option&lt;Option&lt;TSource&gt;&gt;<br>
The option with a nested option to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the flattened result.

### **FlattenAsync&lt;TSource&gt;(Task&lt;Option&lt;Option&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously flattens an option with a nested option into one option.

```csharp
public static Task<Option<TSource>> FlattenAsync<TSource>(Task<Option<Option<TSource>>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of the nested option.

#### Parameters

`source` Task&lt;Option&lt;Option&lt;TSource&gt;&gt;&gt;<br>
The task returning the option with a nested option to flatten.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous flatten operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the flattened result.

### **MapAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the value of an option into a new form using a specified function,
 or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> MapAsync<TSource, TResult>(Option<TSource> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option whose value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **MapAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, CancellationToken)**

Asynchronously projects the value of an option into a new form using a specified function,
 or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> MapAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, TResult> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be transformed.

`mapper` Func&lt;TSource, TResult&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **MapAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously projects the value of an option into a new form using a specified function,
 or returns an empty option based on whether the option is a 'Some' or a 'None' value.

```csharp
public static Task<Option<TResult>> MapAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Task<TResult>> mapper, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be transformed.

`mapper` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous map operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is the result of invoking the transform function on the source value;
 otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **MatchAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously invokes a specified function if an option is a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Option<TSource> source, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function if an option is a 'Some' value.

```csharp
public static Task MatchAsync<TSource>(Option<TSource> source, Func<TSource, Task> some, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&gt;, Action, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Option<TSource> source, Func<TSource, Task> some, Action none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Action&lt;TSource&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Option<TSource> source, Action<TSource> some, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Option<TSource> source, Func<TSource, Task> some, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, TResult, CancellationToken)**

Asynchronously invokes a specified function, or returns a specified alternative value
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Option<TSource> source, Func<TSource, Task<TResult>> some, TResult none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` TResult<br>
The value to return if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function if a value is present; otherwise, the specified alternative value.

### **MatchAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Option<TSource> source, Func<TSource, Task<TResult>> some, Func<TResult> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;TResult&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, TResult&gt;, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Option<TSource> source, Func<TSource, TResult> some, Func<Task<TResult>> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Option&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Option<TSource> source, Func<TSource, Task<TResult>> some, Func<Task<TResult>> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Action, CancellationToken)**

Asynchronously performs a specified action if an option is a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Action none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously invokes a specified function if an option is a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Action&lt;TSource&gt;, CancellationToken)**

Asynchronously performs a specified action if an option is a 'Some' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Action<TSource> some, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&gt;, CancellationToken)**

Asynchronously invokes a specified function if an option is a 'Some' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Func<TSource, Task> some, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Action&lt;TSource&gt;, Action, CancellationToken)**

Asynchronously performs a specified action based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Action<TSource> some, Action none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&gt;, Action, CancellationToken)**

Asynchronously invokes a specified function or performs a specified action
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Func<TSource, Task> some, Action none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Action&lt;TSource&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously performs a specified action or invokes a specified function
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Action<TSource> some, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&gt;, Func&lt;Task&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task MatchAsync<TSource>(Task<Option<TSource>> source, Func<TSource, Task> some, Func<Task> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&gt;<br>
A function to invoke if a value is present.

`none` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) representing the asynchronous match operation.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, TResult, CancellationToken)**

Asynchronously invokes a specified function, or returns a specified alternative value
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, TResult> some, TResult none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` TResult<br>
The value to return if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function if a value is present; otherwise, the specified alternative value.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, TResult, CancellationToken)**

Asynchronously invokes a specified function, or returns a specified alternative value
 based on whether an option is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Task<TResult>> some, TResult none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` TResult<br>
The value to return if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function if a value is present; otherwise, the specified alternative value.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, Func&lt;TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, TResult> some, Func<TResult> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;TResult&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;TResult&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Task<TResult>> some, Func<TResult> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;TResult&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, TResult&gt;, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, TResult> some, Func<Task<TResult>> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **MatchAsync&lt;TSource, TResult&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)**

Asynchronously invokes a specified function based on whether an option
 is a 'Some' or a 'None' value.

```csharp
public static Task<TResult> MatchAsync<TSource, TResult>(Task<Option<TSource>> source, Func<TSource, Task<TResult>> some, Func<Task<TResult>> none, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`some` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;Task&lt;TResult&gt;&gt;<br>
A function to invoke if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;TResult&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous match operation. The value of the TResult parameter contains
 the result of the invoked function.

### **None&lt;TResult&gt;()**

Creates a task returning an option value that is a 'None' value.

```csharp
public static Task<Option<TResult>> None<TResult>()
```

#### Type Parameters

`TResult`<br>
The type of the value.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains 
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the absense of a value of type .

### **OrElseAsync&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;Task&lt;Option&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative option created by a specified function
 if an option is a 'None' value.

```csharp
public static Task<Option<TSource>> OrElseAsync<TSource>(Option<TSource> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to check for having a value.

`otherFactory` Func&lt;Task&lt;Option&lt;TSource&gt;&gt;&gt;<br>
A function to create an alternative option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, an alternative [Option&lt;T&gt;](./dotfluent.optional.option-1) created by
 the specified function.

### **OrElseAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Option&lt;TSource&gt;, CancellationToken)**

Asynchronously returns an alternative option if an option is a 'None' value.

```csharp
public static Task<Option<TSource>> OrElseAsync<TSource>(Task<Option<TSource>> source, Option<TSource> other, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`other` Option&lt;TSource&gt;<br>
The option to return if a value is missing.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, the specified alternative [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **OrElseAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;Option&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative option created by a specified function
 if an option is a 'None' value.

```csharp
public static Task<Option<TSource>> OrElseAsync<TSource>(Task<Option<TSource>> source, Func<Option<TSource>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`otherFactory` Func&lt;Option&lt;TSource&gt;&gt;<br>
A function to create an alternative option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, an alternative [Option&lt;T&gt;](./dotfluent.optional.option-1) created by
 the specified function.

### **OrElseAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, Func&lt;Task&lt;Option&lt;TSource&gt;&gt;&gt;, CancellationToken)**

Asynchronously returns an alternative option created by a specified function
 if an option is a 'None' value.

```csharp
public static Task<Option<TSource>> OrElseAsync<TSource>(Task<Option<TSource>> source, Func<Task<Option<TSource>>> otherFactory, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option to check for having a value.

`otherFactory` Func&lt;Task&lt;Option&lt;TSource&gt;&gt;&gt;<br>
A function to create an alternative option.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'or else' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing a value; otherwise, an alternative [Option&lt;T&gt;](./dotfluent.optional.option-1) created by
 the specified function.

### **SecureAsync&lt;TSource&gt;(Option&lt;TSource&gt;, CancellationToken)**

Asynchronously removes the value from an option if it is a null value.

```csharp
public static Task<Option<TSource>> SecureAsync<TSource>(Option<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option whose value is to be checked for null.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous secure operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is not null; otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **SecureAsync&lt;TSource&gt;(Task&lt;Option&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously removes the value from an option if it is a null value.

```csharp
public static Task<Option<TSource>> SecureAsync<TSource>(Task<Option<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Option&lt;TSource&gt;&gt;<br>
The task returning the option whose value is to be checked for null.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous secure operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) whose value is not null; otherwise, an empty [Option&lt;T&gt;](./dotfluent.optional.option-1).

### **Some&lt;TResult&gt;(TResult)**

Creates a task returning an option value that is a 'Some' value.

```csharp
public static Task<Option<TResult>> Some<TResult>(TResult value)
```

#### Type Parameters

`TResult`<br>
The type of the value.

#### Parameters

`value` TResult<br>
The input value.

#### Returns

Task&lt;Option&lt;TResult&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) whose TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value.

### **ToOptionAsync&lt;TSource&gt;(TSource, CancellationToken)**

Asynchronously creates an option from an object.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(TSource source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` TSource<br>
The object to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing source.

### **ToOptionAsync&lt;TSource&gt;(Nullable&lt;TSource&gt;, CancellationToken)**

Asynchronously creates an option from a nullable object.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(Nullable<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value of source.

### **ToOptionAsync&lt;TSource&gt;(Result&lt;TSource&gt;, CancellationToken)**

Asynchronously creates an option from a result value.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(Result<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result value to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

### **ToOptionAsync&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, CancellationToken)**

Asynchronously creates an option from a result value.

```csharp
public static Task<Option<TValue>> ToOptionAsync<TValue, TError>(Result<TValue, TError> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result value to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TValue&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

### **ToOptionAsync&lt;TSource&gt;(Task&lt;TSource&gt;, CancellationToken)**

Asynchronously creates an option from an object.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(Task<TSource> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task returning the object to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value of source.

### **ToOptionAsync&lt;TSource&gt;(Task&lt;Nullable&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously creates an option from a nullable object.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(Task<Nullable<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Task&lt;Nullable&lt;TSource&gt;&gt;<br>
The task returning the nullable object to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value of source.

### **ToOptionAsync&lt;TSource&gt;(Task&lt;Result&lt;TSource&gt;&gt;, CancellationToken)**

Asynchronously creates an option from a result value.

```csharp
public static Task<Option<TSource>> ToOptionAsync<TSource>(Task<Result<TSource>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Task&lt;Result&lt;TSource&gt;&gt;<br>
The task returning the result value to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TSource&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

### **ToOptionAsync&lt;TValue, TError&gt;(Task&lt;Result&lt;TValue, TError&gt;&gt;, CancellationToken)**

Asynchronously creates an option from a result value.

```csharp
public static Task<Option<TValue>> ToOptionAsync<TValue, TError>(Task<Result<TValue, TError>> source, CancellationToken cancellationToken)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Task&lt;Result&lt;TValue, TError&gt;&gt;<br>
The task returning the result value to create an option from.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A token to monitor for cancellation requests.

#### Returns

Task&lt;Option&lt;TValue&gt;&gt;<br>
A [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) representing the asynchronous 'to option' operation. The value of the TResult parameter contains
 an [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

---

[`< Back`](./)
