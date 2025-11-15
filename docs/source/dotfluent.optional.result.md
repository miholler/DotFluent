[`< Back`](./)

---

# Result

Namespace: DotFluent.Optional

Provides a set of static methods for working with
 [Result&lt;T&gt;](./dotfluent.optional.result-1) and [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) instances.

```csharp
public static class Result
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Result](./dotfluent.optional.result)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Error&lt;TResult&gt;(Exception)**

Creates a result value that is an 'Error' value.

```csharp
public static Result<TResult> Error<TResult>(Exception error)
```

#### Type Parameters

`TResult`<br>
The type of the success value.

#### Parameters

`error` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The error value.

#### Returns

Result&lt;TResult&gt;<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the error value.

### **Error&lt;TValue, TError&gt;(TError)**

Creates a result value that is an 'Error' value.

```csharp
public static Result<TValue, TError> Error<TValue, TError>(TError error)
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

Result&lt;TValue, TError&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the error value.

### **Flatten&lt;TSource&gt;(Result&lt;Result&lt;TSource&gt;&gt;)**

Flattens a result with a nested result into one result.

```csharp
public static Result<TSource> Flatten<TSource>(Result<Result<TSource>> source)
```

#### Type Parameters

`TSource`<br>
The type of the success value of the nested result.

#### Parameters

`source` Result&lt;Result&lt;TSource&gt;&gt;<br>
The result with a nested result to flatten.

#### Returns

Result&lt;TSource&gt;<br>
An [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the flattened result.

### **Flatten&lt;TValue, TError&gt;(Result&lt;Result&lt;TValue, TError&gt;, TError&gt;)**

Flattens a result with a nested result into one result.

```csharp
public static Result<TValue, TError> Flatten<TValue, TError>(Result<Result<TValue, TError>, TError> source)
```

#### Type Parameters

`TValue`<br>
The type of the success value of the nested result.

`TError`<br>
The type of the error value of the nested result.

#### Parameters

`source` Result&lt;Result&lt;TValue, TError&gt;, TError&gt;<br>
The result with a nested result to flatten.

#### Returns

Result&lt;TValue, TError&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the flattened result.

### **GetUnderlyingType(Type)**

Returns the underlying type argument of the specified result type.

```csharp
public static Type GetUnderlyingType(Type resultType)
```

#### Parameters

`resultType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
The type that describes a closed generic result type.

#### Returns

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
The type argument of the resultType parameter, if the resultType parameter
 is a closed generic result type; otherwise, null.

### **GetUnderlyingTypes(Type)**

Returns the underlying type arguments of the specified result type.

```csharp
public static Type[] GetUnderlyingTypes(Type resultType)
```

#### Parameters

`resultType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
The type that describes a closed generic result type.

#### Returns

[Type[]](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
An array of [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) objects that represent the type arguments of the resultType parameter,
 if the resultType parameter is a closed generic result type; otherwise, an empty array.

### **Ok&lt;TResult&gt;(TResult)**

Creates a result value that is an 'Ok' value.

```csharp
public static Result<TResult> Ok<TResult>(TResult value)
```

#### Type Parameters

`TResult`<br>
The type of the success value.

#### Parameters

`value` TResult<br>
The success value.

#### Returns

Result&lt;TResult&gt;<br>
A [Result&lt;T&gt;](./dotfluent.optional.result-1) representing the success value.

### **Ok&lt;TValue, TError&gt;(TValue)**

Creates a result value that is an 'Ok' value.

```csharp
public static Result<TValue, TError> Ok<TValue, TError>(TValue value)
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

Result&lt;TValue, TError&gt;<br>
A [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) representing the success value.

---

[`< Back`](./)
