[`< Back`](./)

---

# NullableExtensions

Namespace: DotFluent

Provides extension members for [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) objects.

```csharp
public static class NullableExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullableExtensions](./dotfluent.nullableextensions)<br>
Attributes [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Contains&lt;TSource&gt;(Nullable&lt;TSource&gt;, TSource)**

Determines whether a nullable object contains a specified value.

```csharp
public static bool Contains<TSource>(Nullable<TSource> source, TSource value)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object in which to locate a value.

`value` TSource<br>
The value to locate in the nullable object.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the nullable object contains the specified value; otherwise, .

### **Exists&lt;TSource&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;)**

Determines whether a nullable object contains a value that
 satisfies a condition.

```csharp
public static bool Exists<TSource>(Nullable<TSource> source, Func<TSource, bool> predicate)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object in which to locate a value.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the nullable object contains a value that satisfies the condition; otherwise, .

### **Filter&lt;TSource&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;)**

Removes the value from a nullable object if it does not
 satisfy a condition.

```csharp
public static Nullable<TSource> Filter<TSource>(Nullable<TSource> source, Func<TSource, bool> predicate)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object whose value is to be filtered.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the value for a condition.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) whose value satisfies the condition in the predicate function;
 otherwise, an empty [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1).

### **FlatMap&lt;TSource, TResult&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;TResult&gt;&gt;)**

Projects the value of a nullable object into another nullable object using a specified function
 and flattens the result, or returns an empty nullable object if the nullable object has no value.

```csharp
public static Nullable<TResult> FlatMap<TSource, TResult>(Nullable<TSource> source, Func<TSource, Nullable<TResult>> mapper)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value of the nullable returned by mapper.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object whose value is to be transformed.

`mapper` Func&lt;TSource, Nullable&lt;TResult&gt;&gt;<br>
A transform function to apply to the value.

#### Returns

Nullable&lt;TResult&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) whose value is the flattened result of invoking the transform function 
 on the value of source; otherwise, an empty [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1).

### **GetValueOrDefault&lt;TSource&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource&gt;)**

Retrieves the value of a nullable object, or a default value 
 created by a specified function.

```csharp
public static TSource GetValueOrDefault<TSource>(Nullable<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to retrieve the value of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The value of the [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1); otherwise, the default value created by the specified function.

### **get_IsNone&lt;TSource&gt;(Nullable&lt;TSource&gt;)**

```csharp
public static bool get_IsNone<TSource>(Nullable<TSource> source)
```

#### Type Parameters

`TSource`<br>

#### Parameters

`source` Nullable&lt;TSource&gt;<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **get_IsSome&lt;TSource&gt;(Nullable&lt;TSource&gt;)**

```csharp
public static bool get_IsSome<TSource>(Nullable<TSource> source)
```

#### Type Parameters

`TSource`<br>

#### Parameters

`source` Nullable&lt;TSource&gt;<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Map&lt;TSource, TResult&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, TResult&gt;)**

Projects the value of a nullable object into a new form using a specified function,
 or returns an empty nullable object if the nullable object has no value.

```csharp
public static Nullable<TResult> Map<TSource, TResult>(Nullable<TSource> source, Func<TSource, TResult> mapper)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value returned by mapper.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object whose value is to be transformed.

`mapper` Func&lt;TSource, TResult&gt;<br>
A transform function to apply to the value.

#### Returns

Nullable&lt;TResult&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) whose value is the result of invoking the transform function on the value of source; 
 otherwise, an empty [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1).

### **Match&lt;TSource&gt;(Nullable&lt;TSource&gt;, Action)**

Performs a specified action if a nullable object has no value.

```csharp
public static void Match<TSource>(Nullable<TSource> source, Action none)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

### **Match&lt;TSource&gt;(Nullable&lt;TSource&gt;, Action&lt;TSource&gt;)**

Performs a specified action if a nullable object has a value.

```csharp
public static void Match<TSource>(Nullable<TSource> source, Action<TSource> some)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

### **Match&lt;TSource&gt;(Nullable&lt;TSource&gt;, Action&lt;TSource&gt;, Action)**

Performs a specified action based on whether a nullable object has a value.

```csharp
public static void Match<TSource>(Nullable<TSource> source, Action<TSource> some, Action none)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`some` Action&lt;TSource&gt;<br>
An action to perform if a value is present.

`none` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>
An action to perform if a value is missing.

### **Match&lt;TSource, TResult&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, TResult&gt;, TResult)**

Invokes a specified function, or returns a specified alternative value 
 based on whether a nullable object has a value.

```csharp
public static TResult Match<TSource, TResult>(Nullable<TSource> source, Func<TSource, TResult> some, TResult none)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the result value.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` TResult<br>
The value to return if a value is missing.

#### Returns

TResult<br>
The result of the invoked function if a value is present; otherwise, the specified alternative value.

### **Match&lt;TSource, TResult&gt;(Nullable&lt;TSource&gt;, Func&lt;TSource, TResult&gt;, Func&lt;TResult&gt;)**

Invokes a specified function based on whether a nullable object has a value.

```csharp
public static TResult Match<TSource, TResult>(Nullable<TSource> source, Func<TSource, TResult> some, Func<TResult> none)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

`TResult`<br>
The type of the value returned by the invoked function.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`some` Func&lt;TSource, TResult&gt;<br>
A function to invoke if a value is present.

`none` Func&lt;TResult&gt;<br>
A function to invoke if a value is missing.

#### Returns

TResult<br>
The result of the invoked function.

### **OrElse&lt;TSource&gt;(Nullable&lt;TSource&gt;, Nullable&lt;TSource&gt;)**

Returns an alternative nullable object if a nullable object 
 does not have a value.

```csharp
public static Nullable<TSource> OrElse<TSource>(Nullable<TSource> source, Nullable<TSource> other)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`other` Nullable&lt;TSource&gt;<br>
The nullable object to return if a value is missing.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing a value; otherwise, the specified 
 alternative [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1).

### **OrElse&lt;TSource&gt;(Nullable&lt;TSource&gt;, Func&lt;Nullable&lt;TSource&gt;&gt;)**

Returns an alternative nullable object created by a specified function 
 if a nullable object does not have a value.

```csharp
public static Nullable<TSource> OrElse<TSource>(Nullable<TSource> source, Func<Nullable<TSource>> otherFactory)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to check for having a value.

`otherFactory` Func&lt;Nullable&lt;TSource&gt;&gt;<br>
A function to create an alternative nullable object.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing a value; otherwise, an alternative
 [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) created by the specified function.

### **ToNullable&lt;TSource&gt;(TSource)**

Creates a nullable object from an object.

```csharp
public static Nullable<TSource> ToNullable<TSource>(TSource source)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to create a nullable object from.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing source.

---

[`< Back`](./)
