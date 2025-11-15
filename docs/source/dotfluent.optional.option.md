[`< Back`](./)

---

# Option

Namespace: DotFluent.Optional

Provides a set of static methods for working 
 with [Option&lt;T&gt;](./dotfluent.optional.option-1) instances.

```csharp
public static class Option
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Option](./dotfluent.optional.option)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **Flatten&lt;TSource&gt;(Option&lt;Option&lt;TSource&gt;&gt;)**

Flattens an option with a nested option into one option.

```csharp
public static Option<TSource> Flatten<TSource>(Option<Option<TSource>> source)
```

#### Type Parameters

`TSource`<br>
The type of the value of the nested option.

#### Parameters

`source` Option&lt;Option&lt;TSource&gt;&gt;<br>
The option with a nested option to flatten.

#### Returns

Option&lt;TSource&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the flattened result.

### **GetUnderlyingType(Type)**

Returns the underlying type argument of the specified option type.

```csharp
public static Type GetUnderlyingType(Type optionType)
```

#### Parameters

`optionType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
The type that describes a closed generic option type.

#### Returns

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>
The type argument of the optionType parameter, if the optionType parameter
 is a closed generic option type; otherwise, null.

### **None&lt;TResult&gt;()**

Creates an option value that is a 'None' value.

```csharp
public static Option<TResult> None<TResult>()
```

#### Type Parameters

`TResult`<br>
The type of the value.

#### Returns

Option&lt;TResult&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the absense of a value of type .

### **Some&lt;TResult&gt;(TResult)**

Creates an option value that is a 'Some' value.

```csharp
public static Option<TResult> Some<TResult>(TResult value)
```

#### Type Parameters

`TResult`<br>
The type of the value.

#### Parameters

`value` TResult<br>
The input value.

#### Returns

Option&lt;TResult&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value.

### **ToOption&lt;TSource&gt;(TSource)**

Creates an option from an object.

```csharp
public static Option<TSource> ToOption<TSource>(TSource source)
```

#### Type Parameters

`TSource`<br>
The type of the object.

#### Parameters

`source` TSource<br>
The object to create an option from.

#### Returns

Option&lt;TSource&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing source.

### **ToOption&lt;TSource&gt;(Nullable&lt;TSource&gt;)**

Creates an option from a nullable object.

```csharp
public static Option<TSource> ToOption<TSource>(Nullable<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the value of source.

#### Parameters

`source` Nullable&lt;TSource&gt;<br>
The nullable object to create an option from.

#### Returns

Option&lt;TSource&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the value of source.

### **ToOption&lt;TSource&gt;(Result&lt;TSource&gt;)**

Creates an option from a result value.

```csharp
public static Option<TSource> ToOption<TSource>(Result<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the success value of source.

#### Parameters

`source` Result&lt;TSource&gt;<br>
The result value to create an option from.

#### Returns

Option&lt;TSource&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

### **ToOption&lt;TValue, TError&gt;(Result&lt;TValue, TError&gt;)**

Creates an option from a result value.

```csharp
public static Option<TValue> ToOption<TValue, TError>(Result<TValue, TError> source)
```

#### Type Parameters

`TValue`<br>
The type of the success value of source.

`TError`<br>
The type of the error value of source.

#### Parameters

`source` Result&lt;TValue, TError&gt;<br>
The result value to create an option from.

#### Returns

Option&lt;TValue&gt;<br>
An [Option&lt;T&gt;](./dotfluent.optional.option-1) representing the success value of source.

---

[`< Back`](./)
