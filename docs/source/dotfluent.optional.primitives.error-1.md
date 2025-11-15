[`< Back`](./)

---

# Error&lt;T&gt;

Namespace: DotFluent.Optional.Primitives

Represents an error value.

```csharp
public struct Error<T>
```

#### Type Parameters

`T`<br>
The underlying type of the [Error&lt;T&gt;](./dotfluent.optional.primitives.error-1) generic type.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Error&lt;T&gt;](./dotfluent.optional.primitives.error-1)<br>
Implements IEquatable&lt;Error&lt;T&gt;&gt;<br>
Attributes [IsReadOnlyAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.isreadonlyattribute)

## Properties

### **Value**

The input value.

```csharp
public T Value { get; set; }
```

#### Property Value

T<br>

## Constructors

### **Error(T)**

Represents an error value.

```csharp
Error(T Value)
```

#### Parameters

`Value` T<br>
The input value.

## Methods

### **ToString()**

```csharp
string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetHashCode()**

```csharp
int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Equals(Object)**

```csharp
bool Equals(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Equals(Error&lt;T&gt;)**

```csharp
bool Equals(Error<T> other)
```

#### Parameters

`other` [Error&lt;T&gt;](./dotfluent.optional.primitives.error-1)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Deconstruct(T&)**

```csharp
void Deconstruct(T& Value)
```

#### Parameters

`Value` T&<br>

---

[`< Back`](./)
