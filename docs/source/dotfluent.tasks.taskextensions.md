[`< Back`](./)

---

# TaskExtensions

Namespace: DotFluent.Tasks

Provides extension methods for [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)
 and [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) objects.

```csharp
public static class TaskExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TaskExtensions](./dotfluent.tasks.taskextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **AsValueTask(Task)**

Converts a specified task to a value task.

```csharp
public static ValueTask AsValueTask(Task source)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to convert.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask) that represents the input [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **AsValueTask&lt;TSource&gt;(Task&lt;TSource&gt;)**

Converts a specified task to a value task.

```csharp
public static ValueTask<TSource> AsValueTask<TSource>(Task<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to convert.

#### Returns

ValueTask&lt;TSource&gt;<br>
A [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1) that represents the input [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Catch(Task, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static Task Catch(Task source, Action action)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Catch(Task, Func&lt;Task&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static Task Catch(Task source, Func<Task> selector)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Catch&lt;TException&gt;(Task, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static Task Catch<TException>(Task source, Action<TException> action)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Catch&lt;TException&gt;(Task, Func&lt;TException, Task&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static Task Catch<TException>(Task source, Func<TException, Task> selector)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` Func&lt;TException, Task&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Catch&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static Task<TSource> Catch<TSource>(Task<TSource> source, Func<TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TSource&gt;<br>
A function to invoke when any of the previous tasks failes.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Catch&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;Task&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static Task<TSource> Catch<TSource>(Task<TSource> source, Func<Task<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Catch&lt;TSource, TException&gt;(Task&lt;TSource&gt;, Func&lt;TException, TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static Task<TSource> Catch<TSource, TException>(Task<TSource> source, Func<TException, TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TException, TSource&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Catch&lt;TSource, TException&gt;(Task&lt;TSource&gt;, Func&lt;TException, Task&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static Task<TSource> Catch<TSource, TException>(Task<TSource> source, Func<TException, Task<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TException, Task&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **CatchWhen(Task, Func&lt;Boolean&gt;, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static Task CatchWhen(Task source, Func<bool> condition, Action action)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **CatchWhen(Task, Func&lt;Boolean&gt;, Func&lt;Task&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static Task CatchWhen(Task source, Func<bool> condition, Func<Task> selector)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **CatchWhen&lt;TException&gt;(Task, Func&lt;TException, Boolean&gt;, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static Task CatchWhen<TException>(Task source, Func<TException, bool> predicate, Action<TException> action)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **CatchWhen&lt;TException&gt;(Task, Func&lt;TException, Boolean&gt;, Func&lt;TException, Task&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static Task CatchWhen<TException>(Task source, Func<TException, bool> predicate, Func<TException, Task> selector)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, Task&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **CatchWhen&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;Boolean&gt;, Func&lt;TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static Task<TSource> CatchWhen<TSource>(Task<TSource> source, Func<bool> condition, Func<TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` Func&lt;TSource&gt;<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **CatchWhen&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;Boolean&gt;, Func&lt;Task&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static Task<TSource> CatchWhen<TSource>(Task<TSource> source, Func<bool> condition, Func<Task<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` Func&lt;Task&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **CatchWhen&lt;TSource, TException&gt;(Task&lt;TSource&gt;, Func&lt;TException, Boolean&gt;, Func&lt;TException, TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static Task<TSource> CatchWhen<TSource, TException>(Task<TSource> source, Func<TException, bool> predicate, Func<TException, TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, TSource&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **CatchWhen&lt;TSource, TException&gt;(Task&lt;TSource&gt;, Func&lt;TException, Boolean&gt;, Func&lt;TException, Task&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static Task<TSource> CatchWhen<TSource, TException>(Task<TSource> source, Func<TException, bool> predicate, Func<TException, Task<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, Task&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Finally(Task, Action)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static Task Finally(Task source, Action action)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform even if any of the previous tasks failes or is canceled.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Finally(Task, Func&lt;Task&gt;)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static Task Finally(Task source, Func<Task> selector)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke even if any of the previous tasks failes or is canceled.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Finally&lt;TSource&gt;(Task&lt;TSource&gt;, Action)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static Task<TSource> Finally<TSource>(Task<TSource> source, Action action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform even if any of the previous tasks failes or is canceled.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Finally&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;Task&gt;)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static Task<TSource> Finally<TSource>(Task<TSource> source, Func<Task> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke even if any of the previous tasks failes or is canceled.

#### Returns

Task&lt;TSource&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Then(Task, Action, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static Task Then(Task source, Action action, CancellationToken cancellationToken)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Then(Task, Func&lt;Task&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static Task Then(Task source, Func<Task> selector, CancellationToken cancellationToken)
```

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` [Func&lt;Task&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Then&lt;TResult&gt;(Task, Func&lt;TResult&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static Task<TResult> Then<TResult>(Task source, Func<TResult> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` Func&lt;TResult&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

Task&lt;TResult&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Then&lt;TResult&gt;(Task, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static Task<TResult> Then<TResult>(Task source, Func<Task<TResult>> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
The task to create the continuation task for.

`selector` Func&lt;Task&lt;TResult&gt;&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

Task&lt;TResult&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Then&lt;TSource&gt;(Task&lt;TSource&gt;, Action&lt;TSource&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static Task Then<TSource>(Task<TSource> source, Action<TSource> action, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`action` Action&lt;TSource&gt;<br>
An action to perform when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Then&lt;TSource&gt;(Task&lt;TSource&gt;, Func&lt;TSource, Task&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static Task Then<TSource>(Task<TSource> source, Func<TSource, Task> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, Task&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A continuation [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### **Then&lt;TSource, TResult&gt;(Task&lt;TSource&gt;, Func&lt;TSource, TResult&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static Task<TResult> Then<TSource, TResult>(Task<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, TResult&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

Task&lt;TResult&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

### **Then&lt;TSource, TResult&gt;(Task&lt;TSource&gt;, Func&lt;TSource, Task&lt;TResult&gt;&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static Task<TResult> Then<TSource, TResult>(Task<TSource> source, Func<TSource, Task<TResult>> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` Task&lt;TSource&gt;<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, Task&lt;TResult&gt;&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

Task&lt;TResult&gt;<br>
A continuation [Task&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1).

---

[`< Back`](./)
