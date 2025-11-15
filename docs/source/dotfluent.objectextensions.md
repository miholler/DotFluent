[`< Back`](./)

---

# ObjectExtensions

Namespace: DotFluent

Provides extension methods for all objects.

```csharp
public static class ObjectExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ObjectExtensions](./dotfluent.objectextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Is&lt;TSource&gt;(TSource, Func&lt;TSource, Boolean&gt;)**

Determines whether an object satisfies a condition.

```csharp
public static bool Is<TSource>(TSource source, Func<TSource, bool> predicate)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to check for a condition.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the object for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the object satisfies the condition in the predicate function; otherwise, .

### **IsEqualTo(Object, Object, Boolean)**

Determines whether two objects are considered equal.

```csharp
public static bool IsEqualTo(object source, object value, bool reference)
```

#### Parameters

`source` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The first object to compare.

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The second object to compare.

`reference` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Specifies whether to check for reference equality.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the objects are considered equal or if both are null; otherwise, .

### **IsNot&lt;TSource&gt;(TSource, Func&lt;TSource, Boolean&gt;)**

Determines whether an object does not satisfy a condition.

```csharp
public static bool IsNot<TSource>(TSource source, Func<TSource, bool> predicate)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to check for a condition.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test the object for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the object does not satisfy the condition in the predicate function; otherwise, .

### **IsNotEqualTo(Object, Object, Boolean)**

Determines whether two objects are not considered equal.

```csharp
public static bool IsNotEqualTo(object source, object value, bool reference)
```

#### Parameters

`source` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The first object to compare.

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The second object to compare.

`reference` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Specifies whether to check for reference equality.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the objects are not null and not considered equal; otherwise, .

### **IsNotNull(Object)**

Determines wheter an object is not null.

```csharp
public static bool IsNotNull(object source)
```

#### Parameters

`source` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to check for null.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the object is not null; otherwise, .

### **IsNull(Object)**

Determines whether an object is null.

```csharp
public static bool IsNull(object source)
```

#### Parameters

`source` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to check for null.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the object is null; otherwise, .

### **ThrowIfNull&lt;TSource&gt;(TSource, String)**

Throws an [ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) if an object is null; otherwise, returns the object.

```csharp
public static TSource ThrowIfNull<TSource>(TSource source, string paramName)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to check for null.

`paramName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The parameter name to use when throwing the [ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception).

#### Returns

TSource<br>
The  if not null.

### **ThrowIfNull&lt;TSource&gt;(TSource, Func&lt;Exception&gt;)**

Throws an [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) created by a specified function if an object is null; otherwise, returns the object.

```csharp
public static TSource ThrowIfNull<TSource>(TSource source, Func<Exception> factory)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to check for null.

`factory` [Func&lt;Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create the [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception).

#### Returns

TSource<br>
The  if not null.

---

[`< Back`](./)
