[`< Back`](./)

---

# Success&lt;T&gt;

Namespace: DotFluent.Optional.Primitives

Represents a success value.

```csharp
public struct Success<T>
```

#### Type Parameters

`T`<br>
The underlying type of the [Success&lt;T&gt;](./dotfluent.optional.primitives.success-1) generic type.

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Success&lt;T&gt;](./dotfluent.optional.primitives.success-1)<br>
Implements IEquatable&lt;Success&lt;T&gt;&gt;<br>
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

### **Success(T)**

Represents a success value.

```csharp
Success(T Value)
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

### **Equals(Success&lt;T&gt;)**

```csharp
bool Equals(Success<T> other)
```

#### Parameters

`other` [Success&lt;T&gt;](./dotfluent.optional.primitives.success-1)<br>

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
