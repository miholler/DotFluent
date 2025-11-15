[`< Back`](./)

---

# UnsafeOption

Namespace: DotFluent.Optional.Unsafe

Provides a set of static methods for working 
 with [Option&lt;T&gt;](./dotfluent.optional.option-1) instances.

```csharp
public static class UnsafeOption
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UnsafeOption](./dotfluent.optional.unsafe.unsafeoption)<br>
Attributes [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **GetValueOrDefault&lt;TSource&gt;(Option&lt;TSource&gt;)**

Retrieves the value of an option, or the type parameter's default value.

```csharp
public static TSource GetValueOrDefault<TSource>(Option<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to retrieve the value of.

#### Returns

TSource<br>
The value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value for the  type.

### **GetValueOrDefault&lt;TSource&gt;(Option&lt;TSource&gt;, TSource)**

Retrieves the value of an option, or a specified default value.

```csharp
public static TSource GetValueOrDefault<TSource>(Option<TSource> source, TSource defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to retrieve the value of.

`defaultValue` TSource<br>
The value to return if a value is missing.

#### Returns

TSource<br>
The value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the defaultValue parameter.

### **GetValueOrDefault&lt;TSource&gt;(Option&lt;TSource&gt;, Func&lt;TSource&gt;)**

Retrieves the value of an option, or a default value created by a
 specified function.

```csharp
public static TSource GetValueOrDefault<TSource>(Option<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to retrieve the value of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The value of the [Option&lt;T&gt;](./dotfluent.optional.option-1); otherwise, the default value created by the specified function.

### **ToNullable&lt;TSource&gt;(Option&lt;TSource&gt;)**

Creates a nullable object from an option.

```csharp
public static Nullable<TSource> ToNullable<TSource>(Option<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Option&lt;TSource&gt;<br>
The option to create the nullable object from.

#### Returns

Nullable&lt;TSource&gt;<br>
A [Nullable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) representing the value of source.

---

[`< Back`](./)
