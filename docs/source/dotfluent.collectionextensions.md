[`< Back`](./)

---

# CollectionExtensions

Namespace: DotFluent

Provides extension methods for generic collection objects.

```csharp
public static class CollectionExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CollectionExtensions](./dotfluent.collectionextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **AddOrUpdate&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, TValue, Func&lt;TKey, TValue, TValue&gt;)**

Adds a key/value pair to a dictionary if the key does not already exist,
 or updates a key/value pair in the dictionary by using a specified function 
 if the key already exists.

```csharp
public static TValue AddOrUpdate<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key to be added or whose value should be updated.

`addValue` TValue<br>
The value to be added for an absent key.

`updateValueFactory` Func&lt;TKey, TValue, TValue&gt;<br>
A function used to generate a new value for an existing key based on the key's existing value.

#### Returns

TValue<br>
The new value for the key. This will either be addValue (if the key was absent) 
 or the result of updateValueFactory (if the key was present).

### **AddOrUpdate&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, Func&lt;TKey, TValue&gt;, Func&lt;TKey, TValue, TValue&gt;)**

Uses specified functions to add a key/value pair to a dictionary if the key does not already exist,
 or to update a key/value pair in the dictionary if the key already exists.

```csharp
public static TValue AddOrUpdate<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key to be added or whose value should be updated.

`addValueFactory` Func&lt;TKey, TValue&gt;<br>
A function used to generate a value for an absent key.

`updateValueFactory` Func&lt;TKey, TValue, TValue&gt;<br>
A function used to generate a new value for an existing key based on the key's existing value.

#### Returns

TValue<br>
The new value for the key. This will either be the result of addValueFactory (if the key was absent)
 or the result of updateValueFactory (if the key was present).

### **GetOrAdd&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, TValue)**

Adds a key/value pair to a dictionary if the key does not already exist,
 or returns the existing value if the key exists.

```csharp
public static TValue GetOrAdd<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, TValue value)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key of the element to add.

`value` TValue<br>
The value to be added, if the key does not already exist.

#### Returns

TValue<br>
The value for the key. This will be either the existing value for the key if
 the key is already in the dictionary, or the new value if the key was not in
 the dictionary.

### **GetOrAdd&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, Func&lt;TKey, TValue&gt;)**

Adds a key/value pair to a dictionary by using a specified function if the key does not already exist, 
 or returns the existing value if the key exists.

```csharp
public static TValue GetOrAdd<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> valueFactory)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key of the element to add.

`valueFactory` Func&lt;TKey, TValue&gt;<br>
A function used to generate a value for the key.

#### Returns

TValue<br>
The value for the key. This will be either the existing value for the key if
 the key is already in the dictionary, or the new value if the key was not in
 the dictionary.

### **TryRemove&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, TValue&)**

Attempts to remove and return the value that has the specified key from a dictionary.

```csharp
public static bool TryRemove<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, TValue& value)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key of the element to remove and return.

`value` TValue&<br>
When this method returns, contains the value of the element removed from the dictionary
 or the default value of the TValue type if the key does not exist.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the element was removed successfully; otherwise, .

### **TryUpdate&lt;TKey, TValue&gt;(IDictionary&lt;TKey, TValue&gt;, TKey, TValue, TValue)**

Attempts to update an existing value for the specified key by comparing the existing
 value with a specified value, and if they are equal, updates the key with a third value.

```csharp
public static bool TryUpdate<TKey, TValue>(IDictionary<TKey, TValue> source, TKey key, TValue newValue, TValue comparisonValue)
```

#### Type Parameters

`TKey`<br>
The type of the keys in the dictionary.

`TValue`<br>
The type of the values in the dictionary.

#### Parameters

`source` IDictionary&lt;TKey, TValue&gt;<br>
The dictionary to modify.

`key` TKey<br>
The key whose value is compared with comparisonValue and possibly replaced.

`newValue` TValue<br>
The value that replaces the value of the element that has the specified key if 
 the comparison results in equality.

`comparisonValue` TValue<br>
The value that is compared to the value of the element that has the specified key.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the value with key was equal to comparisonValue and was replaced with newValue; otherwise, .

---

[`< Back`](./)
