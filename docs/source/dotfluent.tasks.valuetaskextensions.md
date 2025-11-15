[`< Back`](./)

---

# ValueTaskExtensions

Namespace: DotFluent.Tasks

Provides extension methods for [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask) 
 and [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1) objects.

```csharp
public static class ValueTaskExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueTaskExtensions](./dotfluent.tasks.valuetaskextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Catch(ValueTask&, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask Catch(ValueTask& source, Action action)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch(ValueTask&, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask Catch(ValueTask& source, Func<ValueTask> selector)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TException&gt;(ValueTask&, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask Catch<TException>(ValueTask& source, Action<TException> action)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TException&gt;(ValueTask&, Func&lt;TException, ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask Catch<TException>(ValueTask& source, Func<TException, ValueTask> selector)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` Func&lt;TException, ValueTask&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TSource&gt;(ValueTask`1&, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask Catch<TSource>(ValueTask`1& source, Action action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TSource&gt;(ValueTask`1&, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask Catch<TSource>(ValueTask`1& source, Func<ValueTask> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TSource&gt;(ValueTask`1&, Func&lt;TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask<TSource> Catch<TSource>(ValueTask`1& source, Func<TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TSource&gt;<br>
A function to invoke when any of the previous tasks failes.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Catch&lt;TSource&gt;(ValueTask`1&, Func&lt;ValueTask&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes.

```csharp
public static ValueTask<TSource> Catch<TSource>(ValueTask`1& source, Func<ValueTask<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;ValueTask&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Catch&lt;TSource, TException&gt;(ValueTask`1&, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask Catch<TSource, TException>(ValueTask`1& source, Action<TException> action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask Catch<TSource, TException>(ValueTask`1& source, Func<TException, ValueTask> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TException, ValueTask&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Catch&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask<TSource> Catch<TSource, TException>(ValueTask`1& source, Func<TException, TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TException, TSource&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Catch&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, ValueTask&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type.

```csharp
public static ValueTask<TSource> Catch<TSource, TException>(ValueTask`1& source, Func<TException, ValueTask<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TException, ValueTask&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **CatchWhen(ValueTask&, Func&lt;Boolean&gt;, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask CatchWhen(ValueTask& source, Func<bool> condition, Action action)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen(ValueTask&, Func&lt;Boolean&gt;, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask CatchWhen(ValueTask& source, Func<bool> condition, Func<ValueTask> selector)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TException&gt;(ValueTask&, Func&lt;TException, Boolean&gt;, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask CatchWhen<TException>(ValueTask& source, Func<TException, bool> predicate, Action<TException> action)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TException&gt;(ValueTask&, Func&lt;TException, Boolean&gt;, Func&lt;TException, ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask CatchWhen<TException>(ValueTask& source, Func<TException, bool> predicate, Func<TException, ValueTask> selector)
```

#### Type Parameters

`TException`<br>
The type of exception to catch.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, ValueTask&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TSource&gt;(ValueTask`1&, Func&lt;Boolean&gt;, Action)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask CatchWhen<TSource>(ValueTask`1& source, Func<bool> condition, Action action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TSource&gt;(ValueTask`1&, Func&lt;Boolean&gt;, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask CatchWhen<TSource>(ValueTask`1& source, Func<bool> condition, Func<ValueTask> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TSource&gt;(ValueTask`1&, Func&lt;Boolean&gt;, Func&lt;TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask<TSource> CatchWhen<TSource>(ValueTask`1& source, Func<bool> condition, Func<TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` Func&lt;TSource&gt;<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **CatchWhen&lt;TSource&gt;(ValueTask`1&, Func&lt;Boolean&gt;, Func&lt;ValueTask&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes and a specified condition is satisfied.

```csharp
public static ValueTask<TSource> CatchWhen<TSource>(ValueTask`1& source, Func<bool> condition, Func<ValueTask<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`condition` [Func&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function that evaluates to a Boolean value.

`selector` Func&lt;ValueTask&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes
 and a condition is satisfied.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **CatchWhen&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, Boolean&gt;, Action&lt;TException&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask CatchWhen<TSource, TException>(ValueTask`1& source, Func<TException, bool> predicate, Action<TException> action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`action` Action&lt;TException&gt;<br>
An action to perform when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, Boolean&gt;, Func&lt;TException, ValueTask&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask CatchWhen<TSource, TException>(ValueTask`1& source, Func<TException, bool> predicate, Func<TException, ValueTask> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, ValueTask&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **CatchWhen&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, Boolean&gt;, Func&lt;TException, TSource&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask<TSource> CatchWhen<TSource, TException>(ValueTask`1& source, Func<TException, bool> predicate, Func<TException, TSource> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, TSource&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **CatchWhen&lt;TSource, TException&gt;(ValueTask`1&, Func&lt;TException, Boolean&gt;, Func&lt;TException, ValueTask&lt;TSource&gt;&gt;)**

Creates a continuation task that executes asynchronously when any of the
 previous tasks in the chain failes due to the specified exception type
 and the exception itself satisfies a condition.

```csharp
public static ValueTask<TSource> CatchWhen<TSource, TException>(ValueTask`1& source, Func<TException, bool> predicate, Func<TException, ValueTask<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TException`<br>
The type of exception to catch.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`predicate` Func&lt;TException, Boolean&gt;<br>
A function to test the exception for a condition.

`selector` Func&lt;TException, ValueTask&lt;TSource&gt;&gt;<br>
A function to invoke when any of the previous tasks failes due to the specified exception type
 and the exception itself satifies a condition.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Finally(ValueTask&, Action)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static ValueTask Finally(ValueTask& source, Action action)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform even if any of the previous tasks failes or is canceled.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Finally(ValueTask&, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static ValueTask Finally(ValueTask& source, Func<ValueTask> selector)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke even if any of the previous tasks failes or is canceled.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Finally&lt;TSource&gt;(ValueTask`1&, Action)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static ValueTask<TSource> Finally<TSource>(ValueTask`1& source, Action action)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform even if any of the previous tasks failes or is canceled.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Finally&lt;TSource&gt;(ValueTask`1&, Func&lt;ValueTask&gt;)**

Creates a continuation task that executes asynchronously even if any of the
 previous tasks in the chain failes or is canceled.

```csharp
public static ValueTask<TSource> Finally<TSource>(ValueTask`1& source, Func<ValueTask> selector)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke even if any of the previous tasks failes or is canceled.

#### Returns

ValueTask&lt;TSource&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then(ValueTask&, Action, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask Then(ValueTask& source, Action action, CancellationToken cancellationToken)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then(ValueTask&, Func&lt;ValueTask&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask Then(ValueTask& source, Func<ValueTask> selector, CancellationToken cancellationToken)
```

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then&lt;TResult&gt;(ValueTask&, Func&lt;TResult&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask<TResult> Then<TResult>(ValueTask& source, Func<TResult> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` Func&lt;TResult&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then&lt;TResult&gt;(ValueTask&, Func&lt;ValueTask&lt;TResult&gt;&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask<TResult> Then<TResult>(ValueTask& source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` [ValueTask&](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask&)<br>
The task to create the continuation task for.

`selector` Func&lt;ValueTask&lt;TResult&gt;&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then&lt;TSource&gt;(ValueTask`1&, Action, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask Then<TSource>(ValueTask`1& source, Action action, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`action` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then&lt;TSource&gt;(ValueTask`1&, Func&lt;ValueTask&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes.

```csharp
public static ValueTask Then<TSource>(ValueTask`1& source, Func<ValueTask> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` [Func&lt;ValueTask&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then&lt;TSource&gt;(ValueTask`1&, Action&lt;TSource&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask Then<TSource>(ValueTask`1& source, Action<TSource> action, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`action` Action&lt;TSource&gt;<br>
An action to perform when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then&lt;TSource&gt;(ValueTask`1&, Func&lt;TSource, ValueTask&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask Then<TSource>(ValueTask`1& source, Func<TSource, ValueTask> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, ValueTask&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
A continuation [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask).

### **Then&lt;TSource, TResult&gt;(ValueTask`1&, Func&lt;TResult&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask<TResult> Then<TSource, TResult>(ValueTask`1& source, Func<TResult> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TResult&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then&lt;TSource, TResult&gt;(ValueTask`1&, Func&lt;ValueTask&lt;TResult&gt;&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask<TResult> Then<TSource, TResult>(ValueTask`1& source, Func<ValueTask<TResult>> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;ValueTask&lt;TResult&gt;&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then&lt;TSource, TResult&gt;(ValueTask`1&, Func&lt;TSource, TResult&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask<TResult> Then<TSource, TResult>(ValueTask`1& source, Func<TSource, TResult> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, TResult&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

### **Then&lt;TSource, TResult&gt;(ValueTask`1&, Func&lt;TSource, ValueTask&lt;TResult&gt;&gt;, CancellationToken)**

Creates a continuation task that executes asynchronously when the previous task completes and returns a value.

```csharp
public static ValueTask<TResult> Then<TSource, TResult>(ValueTask`1& source, Func<TSource, ValueTask<TResult>> selector, CancellationToken cancellationToken)
```

#### Type Parameters

`TSource`<br>
The type of the result produced by the source task.

`TResult`<br>
The type of the result produced by the continuation task.

#### Parameters

`source` ValueTask`1&<br>
The task to create the continuation task for.

`selector` Func&lt;TSource, ValueTask&lt;TResult&gt;&gt;<br>
A function to invoke when the previous task completes.

`cancellationToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
A cancellation token that will be assigned to the continuation task.

#### Returns

ValueTask&lt;TResult&gt;<br>
A continuation [ValueTask&lt;TResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).

---

[`< Back`](./)
