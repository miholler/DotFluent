[`< Back`](./)

---

# UnsafeResult

Namespace: DotFluent.Optional.Unsafe

Provides a set of static methods for working with
 [Result&lt;T&gt;](./dotfluent.optional.result-1) and [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2) instances.

```csharp
public static class UnsafeResult
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnsafeResult](./dotfluent.optional.unsafe.unsaferesult)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValueOrDefault&lt;TSource&gt;(Result&lt;TSource&gt;)**

Retrieves the success value of a result, or the type parameter's default value.

```csharp
public static TSource GetValueOrDefault<TSource>(Result<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to retrieve the success value of.

#### Returns

TSource<br>
The success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value for the  type.

### **GetValueOrDefault&lt;TSource&gt;(Result&lt;TSource&gt;, TSource)**

Retrieves the success value of a result, or a specified default value.

```csharp
public static TSource GetValueOrDefault<TSource>(Result<TSource> source, TSource defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to retrieve the success value of.

`defaultValue` TSource<br>
The value to return if an error value is present.

#### Returns

TSource<br>
The success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the defaultValue parameter.

### **GetValueOrDefault&lt;TSource&gt;(Result&lt;TSource&gt;, Func&lt;TSource&gt;)**

Retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static TSource GetValueOrDefault<TSource>(Result<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to retrieve the success value of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The success value of the [Result&lt;T&gt;](./dotfluent.optional.result-1); otherwise, the default value created by the specified function.

### **GetValueOrDefault&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;)**

Retrieves the success value of a result, or the type parameter's default value.

```csharp
public static TValue GetValueOrDefault<TValue, TError>(Result<TValue, TError> source)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to retrieve the success value of.

#### Returns

TValue<br>
The success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value for the  type.

### **GetValueOrDefault&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, TValue)**

Retrieves the success value of a result, or a specified default value.

```csharp
public static TValue GetValueOrDefault<TValue, TError>(Result<TValue, TError> source, TValue defaultValue)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to retrieve the success value of.

`defaultValue` TValue<br>
The value to return if an error value is present.

#### Returns

TValue<br>
The success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the defaultValue parameter.

### **GetValueOrDefault&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;, Func&lt;TValue&gt;)**

Retrieves the success value of a result, or a default value created by a
 specified function.

```csharp
public static TValue GetValueOrDefault<TValue, TError>(Result<TValue, TError> source, Func<TValue> defaultFactory)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to retrieve the success value of.

`defaultFactory` Func&lt;TValue&gt;<br>
A function to create a default value.

#### Returns

TValue<br>
The success value of the [Result&lt;TValue, TError&gt;](./dotfluent.optional.result-2); otherwise, the default value created by the specified function.

### **ToNullable&lt;TSource&gt;(Result&lt;TSource&gt;)**

Creates a nullable object from a result.

```csharp
public static Nullable<TSource> ToNullable<TSource>(Result<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result to create the nullable object from.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

### **ToNullable&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;)**

Creates a nullable object from a result.

```csharp
public static Nullable<TValue> ToNullable<TValue, TError>(Result<TValue, TError> source)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result to create the nullable object from.

#### Returns

Nullable&lt;TValue&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the success value of source.

---

[`< Back`](./)
