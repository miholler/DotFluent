[`< Back`](./)

---

# Sequence

Namespace: DotFluent.Linq

Provides a set of static methods for querying objects
 that implement [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1).

```csharp
public static class Sequence
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Sequence](./dotfluent.linq.sequence)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, TAccumulate, Func&lt;TAccumulate, TSource, TAccumulate&gt;, EqualityComparison&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seed` TAccumulate<br>
The initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, TAccumulate, Func&lt;TAccumulate, TSource, TAccumulate&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seed` TAccumulate<br>
The initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, TAccumulate&gt;, Func&lt;TAccumulate, TSource, TAccumulate&gt;, EqualityComparison&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seedSelector` Func&lt;TKey, TAccumulate&gt;<br>
A function to create the initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, TAccumulate&gt;, Func&lt;TAccumulate, TSource, TAccumulate&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seedSelector` Func&lt;TKey, TAccumulate&gt;<br>
A function to create the initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, TAccumulate, Func&lt;TAccumulate, TSource, TAccumulate&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seed` TAccumulate<br>
The initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, TAccumulate, Func&lt;TAccumulate, TSource, TAccumulate&gt;, IEqualityComparer&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seed` TAccumulate<br>
The initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, TAccumulate&gt;, Func&lt;TAccumulate, TSource, TAccumulate&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seedSelector` Func&lt;TKey, TAccumulate&gt;<br>
A function to create the initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AggregateBy&lt;TSource, TKey, TAccumulate&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, TAccumulate&gt;, Func&lt;TAccumulate, TSource, TAccumulate&gt;, IEqualityComparer&lt;TKey&gt;)**

Applies an accumulator function over a sequence, grouping results by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TAccumulate`<br>
The type of the accumulator value.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to aggregate over.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`seedSelector` Func&lt;TKey, TAccumulate&gt;<br>
A function to create the initial accumulator value.

`func` Func&lt;TAccumulate, TSource, TAccumulate&gt;<br>
An accumulator function to be invoked on each element.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, TAccumulate&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the aggregates corresponding to each key deriving from source.

### **AverageOrDefault(IEnumerable&lt;Int32&gt;)**

Computes the average of a sequence of int values,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<int> source)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the average of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Int32&gt;, Double)**

Computes the average of a sequence of int values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<int> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the average of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Int32&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of int values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<int> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the average of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;)**

Computes the average of a sequence of nullable int values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<int>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the average of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable int values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<int>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the average of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable int values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<int>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the average of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Int64&gt;)**

Computes the average of a sequence of long values,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<long> source)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the average of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Int64&gt;, Double)**

Computes the average of a sequence of long values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<long> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the average of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Int64&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of long values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<long> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the average of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;)**

Computes the average of a sequence of nullable long values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<long>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the average of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable long values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<long>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the average of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable long values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<long>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the average of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Single&gt;)**

Computes the average of a sequence of float values,
 or returns a default value if the sequence contains no elements.

```csharp
public static float AverageOrDefault(IEnumerable<float> source)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the average of.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Single&gt;, Single)**

Computes the average of a sequence of float values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static float AverageOrDefault(IEnumerable<float> source, float defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the average of.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Single&gt;, Func&lt;Single&gt;)**

Computes the average of a sequence of float values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static float AverageOrDefault(IEnumerable<float> source, Func<float> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the average of.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;)**

Computes the average of a sequence of nullable float values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault(IEnumerable<Nullable<float>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the average of.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Computes the average of a sequence of nullable float values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault(IEnumerable<Nullable<float>> source, Nullable<float> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the average of.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Computes the average of a sequence of nullable float values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault(IEnumerable<Nullable<float>> source, Func<Nullable<float>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the average of.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Double&gt;)**

Computes the average of a sequence of double values,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<double> source)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the average of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Double&gt;, Double)**

Computes the average of a sequence of double values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<double> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the average of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Double&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of double values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault(IEnumerable<double> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the average of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable double values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<double>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the average of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable double values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<double>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the average of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable double values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault(IEnumerable<Nullable<double>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the average of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Decimal&gt;)**

Computes the average of a sequence of decimal values,
 or returns a default value if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault(IEnumerable<decimal> source)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the average of.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Decimal&gt;, Decimal)**

Computes the average of a sequence of decimal values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault(IEnumerable<decimal> source, decimal defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the average of.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Decimal&gt;, Func&lt;Decimal&gt;)**

Computes the average of a sequence of decimal values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault(IEnumerable<decimal> source, Func<decimal> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the average of.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the average of a sequence of nullable decimal values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault(IEnumerable<Nullable<decimal>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the average of.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Computes the average of a sequence of nullable decimal values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault(IEnumerable<Nullable<decimal>> source, Nullable<decimal> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the average of.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the average of a sequence of nullable decimal values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault(IEnumerable<Nullable<decimal>> source, Func<Nullable<decimal>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the average of.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;)**

Computes the average of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Double)**

Computes the average of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;)**

Computes the average of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;)**

Computes the average of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Double)**

Computes the average of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;)**

Computes the average of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;)**

Computes the average of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static float AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Single)**

Computes the average of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static float AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Func&lt;Single&gt;)**

Computes the average of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static float AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;)**

Computes the average of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Computes the average of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Nullable<float> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Computes the average of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Func<Nullable<float>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;)**

Computes the average of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Double)**

Computes the average of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Func&lt;Double&gt;)**

Computes the average of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the average of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the average of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;)**

Computes the average of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Decimal)**

Computes the average of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Func&lt;Decimal&gt;)**

Computes the average of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;)**

Computes the average of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Computes the average of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Nullable<decimal> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **AverageOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the average of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> AverageOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Func<Nullable<decimal>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the average of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the average of the sequence of values.

### **Contains&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, TSource, EqualityComparison&lt;TSource&gt;)**

Determines whether a sequence contains a specified element by using a specified compare function.

```csharp
public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence in which to locate a value.

`value` TSource<br>
The value to locate in the sequence.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the source sequence contains an element that has the specified value; otherwise, .

### **CountBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Returns the number of elements in a sequence grouped by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to be counted.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, Int32&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the frequencies of each key occurrence in source.

### **CountBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Returns the number of elements in a sequence grouped by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to be counted.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, Int32&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the frequencies of each key occurrence in source.

### **CountBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;)**

Returns the number of elements in a sequence grouped by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to be counted.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, Int32&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the frequencies of each key occurrence in source.

### **CountBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, IEqualityComparer&lt;TKey&gt;)**

Returns the number of elements in a sequence grouped by key.

```csharp
public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to be counted.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;KeyValuePair&lt;TKey, Int32&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the frequencies of each key occurrence in source.

### **Create&lt;TResult&gt;(IEnumerable&lt;TResult&gt;)**

Returns a sequence containing all specified elements.

```csharp
public static IEnumerable<TResult> Create<TResult>(IEnumerable<TResult> elements)
```

#### Type Parameters

`TResult`<br>
The type of the elements.

#### Parameters

`elements` IEnumerable&lt;TResult&gt;<br>
The elements to create the sequence with.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing all specified elements.

### **DefaultIfEmpty&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource&gt;)**

Returns the elements of a sequence or a singleton collection containing
 a default value created by a specified function.

```csharp
public static IEnumerable<TSource> DefaultIfEmpty<TSource>(IEnumerable<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return a default value for if it is empty.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the default value created by the specified function if the source sequence
 is empty; otherwise, the source sequence.

### **Distinct&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Returns distinct elements from a sequence by using a specified compare function to compare values.

```csharp
public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to remove duplicate elements from.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains distinct elements from the source sequence.

### **Distinct&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;, HashFunc&lt;TSource&gt;)**

Returns distinct elements from a sequence by using specified compare functions to compare values.

```csharp
public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, EqualityComparison<TSource> comparison, HashFunc<TSource> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to remove duplicate elements from.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

`hashCodeSelector` HashFunc&lt;TSource&gt;<br>
A function to resolve a hash code for a value.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains distinct elements from the source sequence.

### **DistinctBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Returns distinct elements from a sequence according to a specified key selector function
 and using a specified compare function to compare keys.

```csharp
public static IEnumerable<TSource> DistinctBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of key to distinguish elements by.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to remove duplicate elements from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains distinct elements from the source sequence.

### **DistinctBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Returns distinct elements from a sequence according to a specified key selector function
 and using specified compare functions to compare keys.

```csharp
public static IEnumerable<TSource> DistinctBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of key to distinguish elements by.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to remove duplicate elements from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains distinct elements from the source sequence.

### **ElementAtOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Int32, TSource)**

Returns the element at a specified index in a sequence or a specified default value 
 if the index is out of range.

```csharp
public static TSource ElementAtOrDefault<TSource>(IEnumerable<TSource> source, int index, TSource defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the element to retrieve.

`defaultValue` TSource<br>
The value to return if the index is out of range.

#### Returns

TSource<br>
The specified default value if the index is outside the bounds of the source sequence; otherwise,
 the element at the specified position in the source sequence.

### **ElementAtOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Index, TSource)**

Returns the element at a specified index in a sequence or a specified default value 
 if the index is out of range.

```csharp
public static TSource ElementAtOrDefault<TSource>(IEnumerable<TSource> source, Index index, TSource defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`index` [Index](https://docs.microsoft.com/en-us/dotnet/api/system.index)<br>
The index of the element to retrieve, which is either from the start or the end.

`defaultValue` TSource<br>
The value to return if the index is out of range.

#### Returns

TSource<br>
The specified default value if the index is outside the bounds of the source sequence; otherwise,
 the element at the specified position in the source sequence.

### **ElementAtOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Int32, Func&lt;TSource&gt;)**

Returns the element at a specified index in a sequence or a default value
 created by a specified function if the index is out of range.

```csharp
public static TSource ElementAtOrDefault<TSource>(IEnumerable<TSource> source, int index, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the element to retrieve.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the index is outside the bounds of the source sequence; otherwise,
 the element at the specified position in the source sequence.

### **ElementAtOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Index, Func&lt;TSource&gt;)**

Returns the element at a specified index in a sequence or a default value
 created by a specified function if the index is out of range.

```csharp
public static TSource ElementAtOrDefault<TSource>(IEnumerable<TSource> source, Index index, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`index` [Index](https://docs.microsoft.com/en-us/dotnet/api/system.index)<br>
The index of the element to retrieve, which is either from the start or the end.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the index is outside the bounds of the source sequence; otherwise,
 the element at the specified position in the source sequence.

### **Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Produces the set difference of two sequences by using a specified compare function to compare values.

```csharp
public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements that are not also in second will be returned.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the set difference of the elements of two sequences.

### **Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;, HashFunc&lt;TSource&gt;)**

Produces the set difference of two sequences by using specified compare functions to compare values.

```csharp
public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison, HashFunc<TSource> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements that are not also in second will be returned.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

`hashCodeSelector` HashFunc&lt;TSource&gt;<br>
A function to resolve a hash code for a value.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the set difference of the elements of two sequences.

### **ExceptBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TKey&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Produces the set difference of two sequences according to a specified key selector function
 and using a specified compare function to compare keys.

```csharp
public static IEnumerable<TSource> ExceptBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose keys that are not also in second will be returned.

`second` IEnumerable&lt;TKey&gt;<br>
The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the set difference of the elements of two sequences.

### **ExceptBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TKey&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Produces the set difference of two sequences according to a specified key selector function
 and using specified compare functions to compare keys.

```csharp
public static IEnumerable<TSource> ExceptBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose keys that are not also in second will be returned.

`second` IEnumerable&lt;TKey&gt;<br>
The sequence whose keys that also occur in the first sequence will cause those elements to be removed from the returned sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the set difference of the elements of two sequences.

### **FirstOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource&gt;)**

Returns the first element of a sequence, or a default value created by a specified function if
 the sequence contains no elements.

```csharp
public static TSource FirstOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return the first element of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the source sequence is empty; otherwise, the first element in the source sequence.

### **FirstOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;, Func&lt;TSource&gt;)**

Returns the first element of the sequence that satisfies a condition, or a default value created by
 a specified function if no such element is found.

```csharp
public static TSource FirstOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test each element for a condition.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the source sequence is empty or if no element passes the test in the predicate function;
 otherwise, the first element that passes the test in the predicate function.

### **Flatten&lt;TSource&gt;(IEnumerable&lt;IEnumerable&lt;TSource&gt;&gt;)**

Flattens a sequence of nested sequences into one sequence.

```csharp
public static IEnumerable<TSource> Flatten<TSource>(IEnumerable<IEnumerable<TSource>> source)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;IEnumerable&lt;TSource&gt;&gt;<br>
The sequence of nested sequences to flatten.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the elements of all nested sequences of source.

### **Flatten&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, IEnumerable&lt;TSource&gt;&gt;)**

Flattens a sequence of one-to-many linked elements by using a specified function
 to project the nested sequence of each element.

```csharp
public static IEnumerable<TSource> Flatten<TSource>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to flatten.

`selector` Func&lt;TSource, IEnumerable&lt;TSource&gt;&gt;<br>
A function to extract the nested sequence of each element.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) containing the elements of source and all nested sequences.

### **ForEach&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Action&lt;TSource&gt;)**

Performs a specified action on each element of a sequence.

```csharp
public static void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> action)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to perform an action on each of its elements on.

`action` Action&lt;TSource&gt;<br>
An action to perform on each element of the sequence.

### **ForEach&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Action&lt;TSource, Int32&gt;)**

Performs a specified action on each element of a sequence and incorporates the element's index.

```csharp
public static void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource, int> action)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to perform an action on each of its elements on.

`action` Action&lt;TSource, Int32&gt;<br>
An action to perform on each element of the sequence.

### **FullJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **FullJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a full outer join on two sequences.

### **GroupBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and compares the keys by using a specified function.

```csharp
public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) of  where each object contains a collection of objects and a key.

### **GroupBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and compares the keys by using specified functions.

```csharp
public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) of  where each object contains a collection of objects and a key.

### **GroupBy&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;)**

Groups the elements of a sequence according to a key selector function. The keys
 are compared by using a specified function and each group's elements are
 projected by using a specified function.

```csharp
public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the elements in each .

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A function to map each source element to an element in an .

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) of  where each object contains a collection of objects of type TElement and a key.

### **GroupBy&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Groups the elements of a sequence according to a key selector function. The keys
 are compared by using specified functions and each group's elements are
 projected by using a specified function.

```csharp
public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the elements in each .

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A function to map each source element to an element in an .

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) of  where each object contains a collection of objects of type TElement and a key.

### **GroupBy&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and creates a result value from each group and its key. The keys are compared
 by using a specified function.

```csharp
public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TResult`<br>
The type of the result value returned by resultSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`resultSelector` Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result value from each group.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) where each element represents a projection over a group and its key.

### **GroupBy&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and creates a result value from each group and its key. The keys are compared
 by using specified functions.

```csharp
public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TResult`<br>
The type of the result value returned by resultSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`resultSelector` Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result value from each group.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) where each element represents a projection over a group and its key.

### **GroupBy&lt;TSource, TKey, TElement, TResult&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and creates a result value from each group and its key. Key values are compared
 by using a specified function, and the elements of each group are projected
 by using a specified function.

```csharp
public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the elements in each .

`TResult`<br>
The type of the result value returned by resultSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A function to map each source element to an element in an .

`resultSelector` Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;<br>
A function to create a result value from each group.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) where each element represents a projection over a group and its key.

### **GroupBy&lt;TSource, TKey, TElement, TResult&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Groups the elements of a sequence according to a specified key selector function
 and creates a result value from each group and its key. Key values are compared
 by using specified functions, and the elements of each group are projected
 by using a specified function.

```csharp
public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the elements in each .

`TResult`<br>
The type of the result value returned by resultSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to group.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A function to map each source element to an element in an .

`resultSelector` Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;<br>
A function to create a result value from each group.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) where each element represents a projection over a group and its key.

### **GroupJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. The default equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **GroupJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. A specified function is used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **GroupJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. Specified functions are used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **GroupJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. A specified equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, IEnumerable&lt;TSource&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. A specified function is used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on key equality and groups the
 results. Specified functions are used to compare keys.

```csharp
public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;<br>
A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains elements of type TResult that are obtained by performing a grouped join on two sequences.

### **Index&lt;TSource&gt;(IEnumerable&lt;TSource&gt;)**

Returns a sequence that incorporates the element's index into a tuple.

```csharp
public static IEnumerable<ValueTuple<int, TSource>> Index<TSource>(IEnumerable<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The source sequence providing the elements.

#### Returns

IEnumerable&lt;ValueTuple&lt;Int32, TSource&gt;&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that incorporates each element index into a tuple.

### **IndexOf&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, TSource)**

Returns the zero-based index of a specified element in a sequence by
 using the default equality comparer.

```csharp
public static int IndexOf<TSource>(IEnumerable<TSource> source, TSource value)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence in which to locate a value.

`value` TSource<br>
The value to locate in the sequence.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the specified element if the source sequence contains 
 an element that has the specified value; otherwise, minus 1.

### **IndexOf&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, TSource, EqualityComparison&lt;TSource&gt;)**

Returns the zero-based index of a specified element in a sequence by
 using a specified compare function.

```csharp
public static int IndexOf<TSource>(IEnumerable<TSource> source, TSource value, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence in which to locate a value.

`value` TSource<br>
The value to locate in the sequence.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the specified element if the source sequence contains 
 an element that has the specified value; otherwise, minus 1.

### **IndexOf&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, TSource, IEqualityComparer&lt;TSource&gt;)**

Returns the zero-based index of a specified element in a sequence by
 using a specified equality comparer.

```csharp
public static int IndexOf<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence in which to locate a value.

`value` TSource<br>
The value to locate in the sequence.

`comparer` IEqualityComparer&lt;TSource&gt;<br>
The equality comparer to compare values.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index of the specified element if the source sequence contains 
 an element that has the specified value; otherwise, minus 1.

### **Insert&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Int32, TSource)**

Inserts an element into a sequence at a specified index.

```csharp
public static IEnumerable<TSource> Insert<TSource>(IEnumerable<TSource> source, int index, TSource item)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence in which the element is to be inserted.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index at which to insert the element.

`item` TSource<br>
The element to be inserted into the source sequence.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the element inserted into
 the input sequence at the specified index.

### **InsertRange&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Int32, IEnumerable&lt;TSource&gt;)**

Inserts the elements of a sequence into another sequence at a specified index.

```csharp
public static IEnumerable<TSource> InsertRange<TSource>(IEnumerable<TSource> first, int index, IEnumerable<TSource> second)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence in which the elements of the second sequence are to be inserted.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The zero-based index at which to insert the elements.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements are to be inserted into the first sequence.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements of the second input sequence inserted
 into the first input sequence at the specified index.

### **Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Produces the set intersection of two sequences by using
 a specified function to compare values.

```csharp
public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the second sequence will be returned.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the first sequence will be returned.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements that form the set intersection of two sequences.

### **Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;, HashFunc&lt;TSource&gt;)**

Produces the set intersection of two sequences by using
 specified functions to compare values.

```csharp
public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison, HashFunc<TSource> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the second sequence will be returned.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the first sequence will be returned.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

`hashCodeSelector` HashFunc&lt;TSource&gt;<br>
A function to resolve a hash code for a value.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements that form the set intersection of two sequences.

### **IntersectBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TKey&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Produces the set intersection of two sequences according to a specified key selector function
 and using a specified compare function to compare keys.

```csharp
public static IEnumerable<TSource> IntersectBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the second sequence will be returned.

`second` IEnumerable&lt;TKey&gt;<br>
The sequence whose distinct elements that also appear in the first sequence will be returned.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements that form the set intersection of two sequences.

### **IntersectBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TKey&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Produces the set intersection of two sequences according to a specified key selector function
 and using specified compare functions to compare keys.

```csharp
public static IEnumerable<TSource> IntersectBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements that also appear in the second sequence will be returned.

`second` IEnumerable&lt;TKey&gt;<br>
The sequence whose distinct elements that also appear in the first sequence will be returned.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements that form the set intersection of two sequences.

### **IsNotNullNorEmpty&lt;TSource&gt;(IEnumerable&lt;TSource&gt;)**

Determines whether a sequence is not null and contains any elements.

```csharp
public static bool IsNotNullNorEmpty<TSource>(IEnumerable<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to check for not null and any elements.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the source sequence is not null and contains any elements; otherwise, .

### **IsNullOrEmpty&lt;TSource&gt;(IEnumerable&lt;TSource&gt;)**

Determines whether a sequence is null or contains no elements.

```csharp
public static bool IsNullOrEmpty<TSource>(IEnumerable<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to check for null or emptiness.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the source sequence is null or contains no elements; otherwise, .

### **Join&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **Join&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **Join&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified 
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **Join&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing an inner join on two sequences.

### **LastOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource&gt;)**

Returns the last element of a sequence, or a default value created by a specified function if 
 the sequence contains no elements.

```csharp
public static TSource LastOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return the last element of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the source sequence is empty; otherwise, the last element in the source sequence.

### **LastOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;, Func&lt;TSource&gt;)**

Returns the last element of the sequence that satisfies a condition or a default value created by
 a specified function if no such element is found.

```csharp
public static TSource LastOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return an element from.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test each element for a condition.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The default value created by the specified function if the source sequence is empty or if no element passes the test in the predicate function;
 otherwise, the last element that passes the test in the predicate function.

### **LeftJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **LeftJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a left outer join on two sequences.

### **Max&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Comparison&lt;TSource&gt;)**

Returns the maximum value in a generic sequence
 by using a specified function to compare values.

```csharp
public static TSource Max<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`comparison` Comparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

TSource<br>
The maximum value in the sequence.

### **MaxBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Returns the maximum value in a generic sequence according to a specified key selector function
 and using a specified function to compare keys.

```csharp
public static TSource MaxBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of key to compare elements by.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

TSource<br>
The value with the maximum key in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int32&gt;)**

Returns the maximum value in a sequence of int values,
 or a default value if the sequence contains no elements.

```csharp
public static int MaxOrDefault(IEnumerable<int> source)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the maximum value of.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int32&gt;, Int32)**

Returns the maximum value in a sequence of int values,
 or a specified default value if the sequence contains no elements.

```csharp
public static int MaxOrDefault(IEnumerable<int> source, int defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the maximum value of.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int32&gt;, Func&lt;Int32&gt;)**

Returns the maximum value in a sequence of int values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static int MaxOrDefault(IEnumerable<int> source, Func<int> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the maximum value of.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;)**

Returns the maximum value in a sequence of nullable int values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault(IEnumerable<Nullable<int>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the maximum value of.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Returns the maximum value in a sequence of nullable int values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault(IEnumerable<Nullable<int>> source, Nullable<int> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the maximum value of.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Returns the maximum value in a sequence of nullable int values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault(IEnumerable<Nullable<int>> source, Func<Nullable<int>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the maximum value of.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int64&gt;)**

Returns the maximum value in a sequence of long values,
 or a default value if the sequence contains no elements.

```csharp
public static long MaxOrDefault(IEnumerable<long> source)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the maximum value of.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int64&gt;, Int64)**

Returns the maximum value in a sequence of long values,
 or a specified default value if the sequence contains no elements.

```csharp
public static long MaxOrDefault(IEnumerable<long> source, long defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the maximum value of.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Int64&gt;, Func&lt;Int64&gt;)**

Returns the maximum value in a sequence of long values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static long MaxOrDefault(IEnumerable<long> source, Func<long> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the maximum value of.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;)**

Returns the maximum value in a sequence of nullable long values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault(IEnumerable<Nullable<long>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the maximum value of.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Returns the maximum value in a sequence of nullable long values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault(IEnumerable<Nullable<long>> source, Nullable<long> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the maximum value of.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Returns the maximum value in a sequence of nullable long values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault(IEnumerable<Nullable<long>> source, Func<Nullable<long>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the maximum value of.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Single&gt;)**

Returns the maximum value in a sequence of float values,
 or a default value if the sequence contains no elements.

```csharp
public static float MaxOrDefault(IEnumerable<float> source)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the maximum value of.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Single&gt;, Single)**

Returns the maximum value in a sequence of float values,
 or a specified default value if the sequence contains no elements.

```csharp
public static float MaxOrDefault(IEnumerable<float> source, float defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the maximum value of.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Single&gt;, Func&lt;Single&gt;)**

Returns the maximum value in a sequence of float values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static float MaxOrDefault(IEnumerable<float> source, Func<float> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the maximum value of.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;)**

Returns the maximum value in a sequence of nullable float values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault(IEnumerable<Nullable<float>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the maximum value of.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Returns the maximum value in a sequence of nullable float values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault(IEnumerable<Nullable<float>> source, Nullable<float> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the maximum value of.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Returns the maximum value in a sequence of nullable float values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault(IEnumerable<Nullable<float>> source, Func<Nullable<float>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the maximum value of.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Double&gt;)**

Returns the maximum value in a sequence of double values,
 or a default value if the sequence contains no elements.

```csharp
public static double MaxOrDefault(IEnumerable<double> source)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the maximum value of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Double&gt;, Double)**

Returns the maximum value in a sequence of double values,
 or a specified default value if the sequence contains no elements.

```csharp
public static double MaxOrDefault(IEnumerable<double> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the maximum value of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Double&gt;, Func&lt;Double&gt;)**

Returns the maximum value in a sequence of double values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static double MaxOrDefault(IEnumerable<double> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the maximum value of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;)**

Returns the maximum value in a sequence of nullable double values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault(IEnumerable<Nullable<double>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the maximum value of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Returns the maximum value in a sequence of nullable double values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault(IEnumerable<Nullable<double>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the maximum value of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Returns the maximum value in a sequence of nullable double values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault(IEnumerable<Nullable<double>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the maximum value of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Decimal&gt;)**

Returns the maximum value in a sequence of decimal values,
 or a default value if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault(IEnumerable<decimal> source)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the maximum value of.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Decimal&gt;, Decimal)**

Returns the maximum value in a sequence of decimal values,
 or a specified default value if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault(IEnumerable<decimal> source, decimal defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the maximum value of.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Decimal&gt;, Func&lt;Decimal&gt;)**

Returns the maximum value in a sequence of decimal values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault(IEnumerable<decimal> source, Func<decimal> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the maximum value of.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;)**

Returns the maximum value in a sequence of nullable decimal values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault(IEnumerable<Nullable<decimal>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the maximum value of.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Returns the maximum value in a sequence of nullable decimal values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault(IEnumerable<Nullable<decimal>> source, Nullable<decimal> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the maximum value of.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Returns the maximum value in a sequence of nullable decimal values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault(IEnumerable<Nullable<decimal>> source, Func<Nullable<decimal>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the maximum value of.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum int value,
 or a default value if the sequence contains no elements.

```csharp
public static int MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Int32)**

Invokes a transform function on each element of a sequence and returns the maximum int value,
 or a specified default value if the sequence contains no elements.

```csharp
public static int MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Func&lt;Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum int value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static int MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, Func<int> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Nullable<int> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable int value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Func<Nullable<int>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum long value,
 or a default value if the sequence contains no elements.

```csharp
public static long MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Int64)**

Invokes a transform function on each element of a sequence and returns the maximum long value,
 or a specified default value if the sequence contains no elements.

```csharp
public static long MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Func&lt;Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum long value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static long MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, Func<long> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Nullable<long> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable long value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Func<Nullable<long>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum float value,
 or a default value if the sequence contains no elements.

```csharp
public static float MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Single)**

Invokes a transform function on each element of a sequence and returns the maximum float value,
 or a specified default value if the sequence contains no elements.

```csharp
public static float MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Func&lt;Single&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum float value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static float MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Nullable<float> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable float value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Func<Nullable<float>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum double value,
 or a default value if the sequence contains no elements.

```csharp
public static double MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Double)**

Invokes a transform function on each element of a sequence and returns the maximum double value,
 or a specified default value if the sequence contains no elements.

```csharp
public static double MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Func&lt;Double&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum double value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static double MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable double value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum decimal value,
 or a default value if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Decimal)**

Invokes a transform function on each element of a sequence and returns the maximum decimal value,
 or a specified default value if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Func&lt;Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum decimal value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Nullable<decimal> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **MaxOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the maximum nullable decimal value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MaxOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Func<Nullable<decimal>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the maximum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the maximum value in the sequence.

### **Min&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Comparison&lt;TSource&gt;)**

Returns the minimum value in a generic sequence
 by using a specified function to compare values.

```csharp
public static TSource Min<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`comparison` Comparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

TSource<br>
The minimum value in the sequence.

### **MinBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Returns the minimum value in a generic sequence according to a specified key selector function
 and using a specified function to compare keys.

```csharp
public static TSource MinBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of key to compare elements by.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

TSource<br>
The value with the minimum key in the sequence.

### **MinOrDefault(IEnumerable&lt;Int32&gt;)**

Returns the minimum value in a sequence of int values,
 or a default value if the sequence contains no elements.

```csharp
public static int MinOrDefault(IEnumerable<int> source)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the minimum value of.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Int32&gt;, Int32)**

Returns the minimum value in a sequence of int values,
 or a specified default value if the sequence contains no elements.

```csharp
public static int MinOrDefault(IEnumerable<int> source, int defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the minimum value of.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Int32&gt;, Func&lt;Int32&gt;)**

Returns the minimum value in a sequence of int values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static int MinOrDefault(IEnumerable<int> source, Func<int> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to determine the minimum value of.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;)**

Returns the minimum value in a sequence of nullable int values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MinOrDefault(IEnumerable<Nullable<int>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the minimum value of.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Returns the minimum value in a sequence of nullable int values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MinOrDefault(IEnumerable<Nullable<int>> source, Nullable<int> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the minimum value of.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Returns the minimum value in a sequence of nullable int values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MinOrDefault(IEnumerable<Nullable<int>> source, Func<Nullable<int>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to determine the minimum value of.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Int64&gt;)**

Returns the minimum value in a sequence of long values,
 or a default value if the sequence contains no elements.

```csharp
public static long MinOrDefault(IEnumerable<long> source)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the minimum value of.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Int64&gt;, Int64)**

Returns the minimum value in a sequence of long values,
 or a specified default value if the sequence contains no elements.

```csharp
public static long MinOrDefault(IEnumerable<long> source, long defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the minimum value of.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Int64&gt;, Func&lt;Int64&gt;)**

Returns the minimum value in a sequence of long values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static long MinOrDefault(IEnumerable<long> source, Func<long> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to determine the minimum value of.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;)**

Returns the minimum value in a sequence of nullable long values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MinOrDefault(IEnumerable<Nullable<long>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the minimum value of.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Returns the minimum value in a sequence of nullable long values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MinOrDefault(IEnumerable<Nullable<long>> source, Nullable<long> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the minimum value of.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Returns the minimum value in a sequence of nullable long values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MinOrDefault(IEnumerable<Nullable<long>> source, Func<Nullable<long>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to determine the minimum value of.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Single&gt;)**

Returns the minimum value in a sequence of float values,
 or a default value if the sequence contains no elements.

```csharp
public static float MinOrDefault(IEnumerable<float> source)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the minimum value of.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Single&gt;, Single)**

Returns the minimum value in a sequence of float values,
 or a specified default value if the sequence contains no elements.

```csharp
public static float MinOrDefault(IEnumerable<float> source, float defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the minimum value of.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Single&gt;, Func&lt;Single&gt;)**

Returns the minimum value in a sequence of float values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static float MinOrDefault(IEnumerable<float> source, Func<float> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to determine the minimum value of.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;)**

Returns the minimum value in a sequence of nullable float values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MinOrDefault(IEnumerable<Nullable<float>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the minimum value of.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Returns the minimum value in a sequence of nullable float values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MinOrDefault(IEnumerable<Nullable<float>> source, Nullable<float> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the minimum value of.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Returns the minimum value in a sequence of nullable float values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MinOrDefault(IEnumerable<Nullable<float>> source, Func<Nullable<float>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to determine the minimum value of.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Double&gt;)**

Returns the minimum value in a sequence of double values,
 or a default value if the sequence contains no elements.

```csharp
public static double MinOrDefault(IEnumerable<double> source)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the minimum value of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Double&gt;, Double)**

Returns the minimum value in a sequence of double values,
 or a specified default value if the sequence contains no elements.

```csharp
public static double MinOrDefault(IEnumerable<double> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the minimum value of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Double&gt;, Func&lt;Double&gt;)**

Returns the minimum value in a sequence of double values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static double MinOrDefault(IEnumerable<double> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to determine the minimum value of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;)**

Returns the minimum value in a sequence of nullable double values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MinOrDefault(IEnumerable<Nullable<double>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the minimum value of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Returns the minimum value in a sequence of nullable double values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MinOrDefault(IEnumerable<Nullable<double>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the minimum value of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Returns the minimum value in a sequence of nullable double values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MinOrDefault(IEnumerable<Nullable<double>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to determine the minimum value of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Decimal&gt;)**

Returns the minimum value in a sequence of decimal values,
 or a default value if the sequence contains no elements.

```csharp
public static decimal MinOrDefault(IEnumerable<decimal> source)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the minimum value of.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Decimal&gt;, Decimal)**

Returns the minimum value in a sequence of decimal values,
 or a specified default value if the sequence contains no elements.

```csharp
public static decimal MinOrDefault(IEnumerable<decimal> source, decimal defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the minimum value of.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Decimal&gt;, Func&lt;Decimal&gt;)**

Returns the minimum value in a sequence of decimal values,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal MinOrDefault(IEnumerable<decimal> source, Func<decimal> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to determine the minimum value of.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;)**

Returns the minimum value in a sequence of nullable decimal values,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault(IEnumerable<Nullable<decimal>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the minimum value of.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Returns the minimum value in a sequence of nullable decimal values,
 or a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault(IEnumerable<Nullable<decimal>> source, Nullable<decimal> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the minimum value of.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Returns the minimum value in a sequence of nullable decimal values,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault(IEnumerable<Nullable<decimal>> source, Func<Nullable<decimal>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to determine the minimum value of.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum int value,
 or a default value if the sequence contains no elements.

```csharp
public static int MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Int32)**

Invokes a transform function on each element of a sequence and returns the minimum int value,
 or a specified default value if the sequence contains no elements.

```csharp
public static int MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Func&lt;Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum int value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static int MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, Func<int> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable int value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable int value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Nullable<int> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable int value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Func<Nullable<int>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum long value,
 or a default value if the sequence contains no elements.

```csharp
public static long MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Int64)**

Invokes a transform function on each element of a sequence and returns the minimum long value,
 or a specified default value if the sequence contains no elements.

```csharp
public static long MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Func&lt;Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum long value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static long MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, Func<long> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable long value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable long value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Nullable<long> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable long value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Func<Nullable<long>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum float value,
 or a default value if the sequence contains no elements.

```csharp
public static float MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Single)**

Invokes a transform function on each element of a sequence and returns the minimum float value,
 or a specified default value if the sequence contains no elements.

```csharp
public static float MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Func&lt;Single&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum float value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static float MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable float value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable float value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Nullable<float> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable float value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Func<Nullable<float>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum double value,
 or a default value if the sequence contains no elements.

```csharp
public static double MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Double)**

Invokes a transform function on each element of a sequence and returns the minimum double value,
 or a specified default value if the sequence contains no elements.

```csharp
public static double MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Func&lt;Double&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum double value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static double MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable double value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable double value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable double value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum decimal value,
 or a default value if the sequence contains no elements.

```csharp
public static decimal MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Decimal)**

Invokes a transform function on each element of a sequence and returns the minimum decimal value,
 or a specified default value if the sequence contains no elements.

```csharp
public static decimal MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Func&lt;Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum decimal value,
 or a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable decimal value,
 or a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable decimal value,
 or a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Nullable<decimal> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **MinOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Invokes a transform function on each element of a sequence and returns the minimum nullable decimal value,
 or a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> MinOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Func<Nullable<decimal>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to determine the minimum value of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the minimum value in the sequence.

### **None&lt;TSource&gt;(IEnumerable&lt;TSource&gt;)**

Determines whether a sequence contains no elements.

```csharp
public static bool None<TSource>(IEnumerable<TSource> source)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to check for emptiness.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the source sequence contains no elements; otherwise, .

### **None&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;)**

Determines whether no element of a sequence satisfies a condition.

```csharp
public static bool None<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence whose elements to apply the predicate to.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test each element for a condition.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if no element in the source sequence passes the test in the specified predicate; otherwise, .

### **Order&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Comparison&lt;TSource&gt;)**

Sorts the elements of a sequence in ascending order 
 by using a specified function to compare values.

```csharp
public static IOrderedEnumerable<TSource> Order<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to order.

`comparison` Comparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted.

### **OrderBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Sorts the elements of a sequence in ascending order 
 by using a specified function to compare keys.

```csharp
public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to order.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from an element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted according to a key.

### **OrderByDescending&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Sorts the elements of a sequence in descending order
 by using a specified function to compare keys.

```csharp
public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to order.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from an element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted in descending order according to a key.

### **OrderDescending&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Comparison&lt;TSource&gt;)**

Sorts the elements of a sequence in descending order 
 by using a specified function to compare values.

```csharp
public static IOrderedEnumerable<TSource> OrderDescending<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to order.

`comparison` Comparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted in descending order.

### **Pipe&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Action&lt;TSource&gt;)**

Performs a specified action on each element of a sequence.

```csharp
public static IEnumerable<TSource> Pipe<TSource>(IEnumerable<TSource> source, Action<TSource> action)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to perform an action on each of its elements on.

`action` Action&lt;TSource&gt;<br>
An action to perform on each element of the sequence.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) whose elements are the result of
 performing the action on each element of source.

### **Pipe&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Action&lt;TSource, Int32&gt;)**

Performs a specified action on each element of a sequence and incorporates the element's index.

```csharp
public static IEnumerable<TSource> Pipe<TSource>(IEnumerable<TSource> source, Action<TSource, int> action)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to perform an action on each of its elements on.

`action` Action&lt;TSource, Int32&gt;<br>
An action to perform on each element of the sequence.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) whose elements are the result of
 performing the action on each element of source.

### **RightJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TSource, TKey, TResult&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TSource, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(IEnumerable<TSource> outer, IEnumerable<TSource> inner, Func<TSource, TKey> keySelector, Func<TSource, TSource, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the sequences.

`TKey`<br>
The type of the keys returned by the key selector function.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TSource&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TSource&gt;<br>
The sequence to join to the first sequence.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the join key from each element of the sequences.

`resultSelector` Func&lt;TSource, TSource, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 function is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. Specified
 functions are used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;)**

Correlates the elements of two sequences based on matching keys. The default
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **RightJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TOuter&gt;, IEnumerable&lt;TInner&gt;, Func&lt;TOuter, TKey&gt;, Func&lt;TInner, TKey&gt;, Func&lt;TOuter, TInner, TResult&gt;, IEqualityComparer&lt;TKey&gt;)**

Correlates the elements of two sequences based on matching keys. A specified
 equality comparer is used to compare keys.

```csharp
public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
```

#### Type Parameters

`TOuter`<br>
The type of the elements of the first sequence.

`TInner`<br>
The type of the elements of the second sequence.

`TKey`<br>
The type of the keys returned by the key selector functions.

`TResult`<br>
The type of the result elements.

#### Parameters

`outer` IEnumerable&lt;TOuter&gt;<br>
The first sequence to join.

`inner` IEnumerable&lt;TInner&gt;<br>
The sequence to join to the first sequence.

`outerKeySelector` Func&lt;TOuter, TKey&gt;<br>
A function to extract the join key from each element of the first sequence.

`innerKeySelector` Func&lt;TInner, TKey&gt;<br>
A function to extract the join key from each element of the second sequence.

`resultSelector` Func&lt;TOuter, TInner, TResult&gt;<br>
A function to create a result element from two matching elements or from one element having no match.

`comparer` IEqualityComparer&lt;TKey&gt;<br>
The equality comparer to hash and compare keys.

#### Returns

IEnumerable&lt;TResult&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that has elements of type TResult that are obtained by performing a right outer join on two sequences.

### **SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Determines whether two sequences are equal by comparing their elements 
 by using a specified function.

```csharp
public static bool SequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence to compare to the second sequence.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence to compare to the first sequence.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, .

### **SingleOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource&gt;)**

Returns the only element of a sequence, or a default value created by a specified function
 if the sequence is empty; this method throws an exception if there is more than one element 
 in the sequence.

```csharp
public static TSource SingleOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return the single element of.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The single element of the input sequence; otherwise, the default value created by the specified function if the source sequence is empty.

### **SingleOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Boolean&gt;, Func&lt;TSource&gt;)**

Returns the only element of a sequence that satisfies a specified condition, or
 a default value created by a specified function if no such element exists; this method 
 throws an exception if more than one element satisfies the condition.

```csharp
public static TSource SingleOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to return a single element from.

`predicate` Func&lt;TSource, Boolean&gt;<br>
A function to test an element for a condition.

`defaultFactory` Func&lt;TSource&gt;<br>
A function to create a default value.

#### Returns

TSource<br>
The single element of the source sequence that satisfies the condition; otherwise, the default value created by the specified function 
 if no such element is found.

### **SumOrDefault(IEnumerable&lt;Int32&gt;)**

Computes the sum of a sequence of int values,
 or returns a default value if the sequence contains no elements.

```csharp
public static int SumOrDefault(IEnumerable<int> source)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the sum of.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Int32&gt;, Int32)**

Computes the sum of a sequence of int values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static int SumOrDefault(IEnumerable<int> source, int defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the sum of.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Int32&gt;, Func&lt;Int32&gt;)**

Computes the sum of a sequence of int values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static int SumOrDefault(IEnumerable<int> source, Func<int> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of int values to calculate the sum of.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;)**

Computes the sum of a sequence of nullable int values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<int> SumOrDefault(IEnumerable<Nullable<int>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the sum of.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Computes the sum of a sequence of nullable int values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> SumOrDefault(IEnumerable<Nullable<int>> source, Nullable<int> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the sum of.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Computes the sum of a sequence of nullable int values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> SumOrDefault(IEnumerable<Nullable<int>> source, Func<Nullable<int>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable int values to calculate the sum of.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Int64&gt;)**

Computes the sum of a sequence of long values,
 or returns a default value if the sequence contains no elements.

```csharp
public static long SumOrDefault(IEnumerable<long> source)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the sum of.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Int64&gt;, Int64)**

Computes the sum of a sequence of long values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static long SumOrDefault(IEnumerable<long> source, long defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the sum of.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Int64&gt;, Func&lt;Int64&gt;)**

Computes the sum of a sequence of long values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static long SumOrDefault(IEnumerable<long> source, Func<long> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of long values to calculate the sum of.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;)**

Computes the sum of a sequence of nullable long values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<long> SumOrDefault(IEnumerable<Nullable<long>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the sum of.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Computes the sum of a sequence of nullable long values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> SumOrDefault(IEnumerable<Nullable<long>> source, Nullable<long> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the sum of.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Computes the sum of a sequence of nullable long values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> SumOrDefault(IEnumerable<Nullable<long>> source, Func<Nullable<long>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable long values to calculate the sum of.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Single&gt;)**

Computes the sum of a sequence of float values,
 or returns a default value if the sequence contains no elements.

```csharp
public static float SumOrDefault(IEnumerable<float> source)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the sum of.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Single&gt;, Single)**

Computes the sum of a sequence of float values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static float SumOrDefault(IEnumerable<float> source, float defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the sum of.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Single&gt;, Func&lt;Single&gt;)**

Computes the sum of a sequence of float values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static float SumOrDefault(IEnumerable<float> source, Func<float> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of float values to calculate the sum of.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;)**

Computes the sum of a sequence of nullable float values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<float> SumOrDefault(IEnumerable<Nullable<float>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the sum of.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Computes the sum of a sequence of nullable float values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> SumOrDefault(IEnumerable<Nullable<float>> source, Nullable<float> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the sum of.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Computes the sum of a sequence of nullable float values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> SumOrDefault(IEnumerable<Nullable<float>> source, Func<Nullable<float>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable float values to calculate the sum of.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Double&gt;)**

Computes the sum of a sequence of double values,
 or returns a default value if the sequence contains no elements.

```csharp
public static double SumOrDefault(IEnumerable<double> source)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the sum of.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Double&gt;, Double)**

Computes the sum of a sequence of double values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static double SumOrDefault(IEnumerable<double> source, double defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the sum of.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Double&gt;, Func&lt;Double&gt;)**

Computes the sum of a sequence of double values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double SumOrDefault(IEnumerable<double> source, Func<double> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of double values to calculate the sum of.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;)**

Computes the sum of a sequence of nullable double values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<double> SumOrDefault(IEnumerable<Nullable<double>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the sum of.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the sum of a sequence of nullable double values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> SumOrDefault(IEnumerable<Nullable<double>> source, Nullable<double> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the sum of.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the sum of a sequence of nullable double values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> SumOrDefault(IEnumerable<Nullable<double>> source, Func<Nullable<double>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable double values to calculate the sum of.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Decimal&gt;)**

Computes the sum of a sequence of decimal values,
 or returns a default value if the sequence contains no elements.

```csharp
public static decimal SumOrDefault(IEnumerable<decimal> source)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the sum of.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Decimal&gt;, Decimal)**

Computes the sum of a sequence of decimal values, or returns
 a specified default value if the sequence contains no elements.

```csharp
public static decimal SumOrDefault(IEnumerable<decimal> source, decimal defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the sum of.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Decimal&gt;, Func&lt;Decimal&gt;)**

Computes the sum of a sequence of decimal values, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal SumOrDefault(IEnumerable<decimal> source, Func<decimal> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of decimal values to calculate the sum of.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the sum of a sequence of nullable decimal values,
 or returns a default value if the sequence contains no elements 
 or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault(IEnumerable<Nullable<decimal>> source)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the sum of.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Computes the sum of a sequence of nullable decimal values, or returns
 a specified default value if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault(IEnumerable<Nullable<decimal>> source, Nullable<decimal> defaultValue)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the sum of.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault(IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the sum of a sequence of nullable decimal values, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault(IEnumerable<Nullable<decimal>> source, Func<Nullable<decimal>> defaultFactory)
```

#### Parameters

`source` [IEnumerable&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>
The sequence of nullable decimal values to calculate the sum of.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;)**

Computes the sum of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static int SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Int32)**

Computes the sum of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static int SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value to return if the source sequence is empty.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int32&gt;, Func&lt;Int32&gt;)**

Computes the sum of a sequence of int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static int SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector, Func<int> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int32&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;)**

Computes the sum of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Nullable&lt;Int32&gt;)**

Computes the sum of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<int> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Nullable<int> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int32&gt;&gt;, Func&lt;Nullable&lt;Int32&gt;&gt;)**

Computes the sum of a sequence of nullable int values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<int> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector, Func<Nullable<int>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int32&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;)**

Computes the sum of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static long SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Int64)**

Computes the sum of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static long SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The value to return if the source sequence is empty.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Int64&gt;, Func&lt;Int64&gt;)**

Computes the sum of a sequence of long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static long SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector, Func<long> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Int64&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;)**

Computes the sum of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Nullable&lt;Int64&gt;)**

Computes the sum of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<long> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Nullable<long> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Int64&gt;&gt;, Func&lt;Nullable&lt;Int64&gt;&gt;)**

Computes the sum of a sequence of nullable long values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<long> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector, Func<Nullable<long>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Int64&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Int64&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;)**

Computes the sum of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static float SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Single)**

Computes the sum of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static float SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultValue` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value to return if the source sequence is empty.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Single&gt;, Func&lt;Single&gt;)**

Computes the sum of a sequence of float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static float SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector, Func<float> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Single&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;)**

Computes the sum of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Nullable&lt;Single&gt;)**

Computes the sum of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<float> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Nullable<float> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Single&gt;&gt;, Func&lt;Nullable&lt;Single&gt;&gt;)**

Computes the sum of a sequence of nullable float values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<float> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector, Func<Nullable<float>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Single&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Single&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;)**

Computes the sum of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static double SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Double)**

Computes the sum of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static double SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value to return if the source sequence is empty.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Double&gt;, Func&lt;Double&gt;)**

Computes the sum of a sequence of double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static double SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector, Func<double> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Double&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;)**

Computes the sum of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Nullable&lt;Double&gt;)**

Computes the sum of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<double> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Nullable<double> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Double&gt;&gt;, Func&lt;Nullable&lt;Double&gt;&gt;)**

Computes the sum of a sequence of nullable double values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<double> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector, Func<Nullable<double>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Double&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Double&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;)**

Computes the sum of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a default value if the sequence contains no elements.

```csharp
public static decimal SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Decimal)**

Computes the sum of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence,
 or returns a specified default value if the sequence contains no elements.

```csharp
public static decimal SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultValue` [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The value to return if the source sequence is empty.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The specified default value if the source sequence is empty; otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Decimal&gt;, Func&lt;Decimal&gt;)**

Computes the sum of a sequence of decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements.

```csharp
public static decimal SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector, Func<decimal> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Decimal&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
The default value created by the specified function if the source sequence is empty;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;)**

Computes the sum of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value of [Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)? if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Nullable&lt;Decimal&gt;)**

Computes the sum of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a specified default value if the sequence contains no elements or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Nullable<decimal> defaultValue)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultValue` [Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The value to return if the source sequence is empty or contains only values that are null.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The specified default value if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **SumOrDefault&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;, Func&lt;Nullable&lt;Decimal&gt;&gt;)**

Computes the sum of a sequence of nullable decimal values that are obtained by
 invoking a transform function on each element of the input sequence, or returns
 a default value created by a specified function if the sequence contains no elements
 or only values that are null.

```csharp
public static Nullable<decimal> SumOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector, Func<Nullable<decimal>> defaultFactory)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence of values to calculate the sum of.

`selector` Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;<br>
A transform function to apply to each element.

`defaultFactory` [Func&lt;Nullable&lt;Decimal&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The default value created by the specified function if the source sequence is empty or contains only values that are null;
 otherwise, the sum of the sequence of values.

### **ThenBy&lt;TSource, TKey&gt;(IOrderedEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Performs a subsequent ordering of the elements in a sequence in ascending order
 by using a specified function to compare keys.

```csharp
public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IOrderedEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to sort.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted according to a key.

### **ThenByDescending&lt;TSource, TKey&gt;(IOrderedEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Comparison&lt;TKey&gt;)**

Performs a subsequent ordering of the elements in a sequence in descending order
 by using a specified function to compare keys.

```csharp
public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IOrderedEnumerable&lt;TSource&gt;<br>
The sequence that contains elements to sort.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` Comparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IOrderedEnumerable&lt;TSource&gt;<br>
An  whose elements are sorted in descending order according to a key.

### **ToDictionary&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key selector function and a key compare function.

```csharp
public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the keys returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a dictionary from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

Dictionary&lt;TKey, TSource&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values. The
 values within each group are in the same order as in source.

### **ToDictionary&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key selector function and key compare functions.

```csharp
public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the keys returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a dictionary from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

Dictionary&lt;TKey, TSource&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values. The
 values within each group are in the same order as in source.

### **ToDictionary&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key selector function, an element selector function and a
 key compare function.

```csharp
public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the value returned by elementSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a dictionary from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A transform function to produce a result element value from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

Dictionary&lt;TKey, TElement&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains values of type TElement selected from the input sequence.

### **ToDictionary&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key selector function, an element selector function and key
 compare functions.

```csharp
public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the value returned by elementSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a dictionary from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A transform function to produce a result element value from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

Dictionary&lt;TKey, TElement&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains values of type TElement selected from the input sequence.

### **ToDictionary&lt;TKey, TValue&gt;(IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key compare function.

```csharp
public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TKey`<br>
The type of the keys from elements of source.

`TValue`<br>
The type of the values from elements of source.

#### Parameters

`source` IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;<br>
The sequence to create a dictionary from.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

Dictionary&lt;TKey, TValue&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values from source.

### **ToDictionary&lt;TKey, TValue&gt;(IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a dictionary from a sequence according to specified
 key compare functions.

```csharp
public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TKey`<br>
The type of the keys from elements of source.

`TValue`<br>
The type of the values from elements of source.

#### Parameters

`source` IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;<br>
The sequence to create a dictionary from.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

Dictionary&lt;TKey, TValue&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values from source.

### **ToDictionary&lt;TKey, TValue&gt;(IEnumerable&lt;ValueTuple&lt;TKey, TValue&gt;&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a dictionary from a sequence according to a specified
 key compare function.

```csharp
public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<ValueTuple<TKey, TValue>> source, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TKey`<br>
The type of the keys from elements of source.

`TValue`<br>
The type of the values from elements of source.

#### Parameters

`source` IEnumerable&lt;ValueTuple&lt;TKey, TValue&gt;&gt;<br>
The sequence to create a dictionary from.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

Dictionary&lt;TKey, TValue&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values from source.

### **ToDictionary&lt;TKey, TValue&gt;(IEnumerable&lt;ValueTuple&lt;TKey, TValue&gt;&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a dictionary from a sequence according to specified
 key compare functions.

```csharp
public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<ValueTuple<TKey, TValue>> source, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TKey`<br>
The type of the keys from elements of source.

`TValue`<br>
The type of the values from elements of source.

#### Parameters

`source` IEnumerable&lt;ValueTuple&lt;TKey, TValue&gt;&gt;<br>
The sequence to create a dictionary from.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

Dictionary&lt;TKey, TValue&gt;<br>
A [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) that contains keys and values from source.

### **ToHashSet&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Creates a hashset from a sequence using a specified
 compare function to compare values.

```csharp
public static HashSet<TSource> ToHashSet<TSource>(IEnumerable<TSource> source, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a hashset from.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

HashSet&lt;TSource&gt;<br>
A [HashSet&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1) that contains values of type TSource selected
 from the input sequence.

### **ToHashSet&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;, HashFunc&lt;TSource&gt;)**

Creates a hashset from a sequence using specified
 compare functions to compare values.

```csharp
public static HashSet<TSource> ToHashSet<TSource>(IEnumerable<TSource> source, EqualityComparison<TSource> comparison, HashFunc<TSource> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a hashset from.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

`hashCodeSelector` HashFunc&lt;TSource&gt;<br>
A function to resolve a hash code for a value.

#### Returns

HashSet&lt;TSource&gt;<br>
A [HashSet&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1) that contains values of type TSource selected
 from the input sequence.

### **ToLookup&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a lookup from a sequence according to a specified 
 key selector function and a key compare function.

```csharp
public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a lookup from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

ILookup&lt;TKey, TSource&gt;<br>
An  that contains keys and values.

### **ToLookup&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a lookup from a sequence according to a specified
 key selector function and key compare functions.

```csharp
public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a lookup from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

ILookup&lt;TKey, TSource&gt;<br>
An  that contains keys and values.

### **ToLookup&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;)**

Creates a lookup from a sequence according to a specified 
 key selector function, an element selector function and a 
 key compare function.

```csharp
public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the value returned by elementSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a lookup from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A transform function to produce a result element value from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

ILookup&lt;TKey, TElement&gt;<br>
An  that contains values of type TElement selected from the input sequence.

### **ToLookup&lt;TSource, TKey, TElement&gt;(IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, Func&lt;TSource, TElement&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Creates a lookup from a sequence according to a specified 
 key selector function, an element selector function and 
 key compare functions.

```csharp
public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of source.

`TKey`<br>
The type of the key returned by keySelector.

`TElement`<br>
The type of the value returned by elementSelector.

#### Parameters

`source` IEnumerable&lt;TSource&gt;<br>
The sequence to create a lookup from.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract a key from each element.

`elementSelector` Func&lt;TSource, TElement&gt;<br>
A transform function to produce a result element value from each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

ILookup&lt;TKey, TElement&gt;<br>
An  that contains values of type TElement selected from the input sequence.

### **Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;)**

Produces the set union of two sequences by using a specified compare function.

```csharp
public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the first set for the union.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the second set for the union.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements from both input sequences, excluding duplicates.

### **Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, EqualityComparison&lt;TSource&gt;, HashFunc&lt;TSource&gt;)**

Produces the set union of two sequences by using specified compare functions.

```csharp
public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, EqualityComparison<TSource> comparison, HashFunc<TSource> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the first set for the union.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the second set for the union.

`comparison` EqualityComparison&lt;TSource&gt;<br>
A function to compare values.

`hashCodeSelector` HashFunc&lt;TSource&gt;<br>
A function to resolve a hash code for a value.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements from both input sequences, excluding duplicates.

### **UnionBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;)**

Produces the set union of two sequences according to a specified key selector function
 and using a specified compare function to compare keys.

```csharp
public static IEnumerable<TSource> UnionBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the first set for the union.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the second set for the union.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements from both input sequences, excluding duplicates.

### **UnionBy&lt;TSource, TKey&gt;(IEnumerable&lt;TSource&gt;, IEnumerable&lt;TSource&gt;, Func&lt;TSource, TKey&gt;, EqualityComparison&lt;TKey&gt;, HashFunc&lt;TKey&gt;)**

Produces the set union of two sequences according to a specified key selector function
 and using specified compare functions to compare keys.

```csharp
public static IEnumerable<TSource> UnionBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, EqualityComparison<TKey> comparison, HashFunc<TKey> hashCodeSelector)
```

#### Type Parameters

`TSource`<br>
The type of the elements of the input sequences.

`TKey`<br>
The type of key to identify elements by.

#### Parameters

`first` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the first set for the union.

`second` IEnumerable&lt;TSource&gt;<br>
The sequence whose distinct elements form the second set for the union.

`keySelector` Func&lt;TSource, TKey&gt;<br>
A function to extract the key for each element.

`comparison` EqualityComparison&lt;TKey&gt;<br>
A function to compare keys.

`hashCodeSelector` HashFunc&lt;TKey&gt;<br>
A function to resolve a hash code for a key.

#### Returns

IEnumerable&lt;TSource&gt;<br>
An [IEnumerable&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) that contains the elements from both input sequences, excluding duplicates.

---

[`< Back`](./)
