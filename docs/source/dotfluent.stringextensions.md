[`< Back`](./)

---

# StringExtensions

Namespace: DotFluent

Provides extension methods for [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) objects.

```csharp
public static class StringExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [StringExtensions](./dotfluent.stringextensions)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **DefaultIfEmpty(String, String)**

Returns a specified default value if a string is null, empty, or consists only of 
 white-space characters; otherwise, returns the string.

```csharp
public static string DefaultIfEmpty(string source, string defaultValue)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

`defaultValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to return if the string is null, empty or consists exclusively of white-space characters.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The specified default value if the string is null, empty, or consists exclusively of white-space characters;
 otherwise, the string.

### **DefaultIfEmpty(String, Func&lt;String&gt;)**

Returns a default value created by a specified function if a string is null, empty, or consists only of
 white-space characters; otherwise, returns the string.

```csharp
public static string DefaultIfEmpty(string source, Func<string> defaultFactory)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

`defaultFactory` [Func&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)<br>
A function to create a default value.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The default value created by the specified function if the string is null, empty, or consists exclusively of 
 white-space characters; otherwise, the string.

### **IsEqualTo(String, String)**

Determines whether two strings are considered equal.

```csharp
public static bool IsEqualTo(string source, string value)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are considered equal; otherwise, .

### **IsEqualTo(String, String, StringComparison)**

Determines whether two strings are considered equal based on a specified comparison type.

```csharp
public static bool IsEqualTo(string source, string value, StringComparison comparison)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

`comparison` [StringComparison](https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison)<br>
The comparison type to use.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are considered equal; otherwise, .

### **IsLike(String, String)**

Determines whether two strings are considered equal regardless of their case.

```csharp
public static bool IsLike(string source, string value)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are considered equal regardless of their case; otherwise, .

### **IsNotEqualTo(String, String)**

Determines whether two strings are not considered equal.

```csharp
public static bool IsNotEqualTo(string source, string value)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are not considered equal; otherwise, .

### **IsNotEqualTo(String, String, StringComparison)**

Determines whether two strings are not considered equal based on a specified comparison type.

```csharp
public static bool IsNotEqualTo(string source, string value, StringComparison comparison)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

`comparison` [StringComparison](https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison)<br>
The comparison type to use.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are not considered equal; otherwise, .

### **IsNotLike(String, String)**

Determines whether two strings are not considered equal regardless of their case.

```csharp
public static bool IsNotLike(string source, string value)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The first string to compare.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The second string to compare.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the strings are not considered equal regardless of their case; otherwise, .

### **IsNotNullNorEmpty(String)**

Determines whether a string is not null nor an empty string.

```csharp
public static bool IsNotNullNorEmpty(string source)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the string is not null nor an empty string (""); otherwise, .

### **IsNotNullNorWhiteSpace(String)**

Determines whether a string is not null, nor empty and does not
 consist only of white-space characters.

```csharp
public static bool IsNotNullNorWhiteSpace(string source)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the string is not null, nor empty and does not consist exclusively of white-space characters; otherwise, .

### **IsNullOrEmpty(String)**

Determines whether a string is null or an empty string.

```csharp
public static bool IsNullOrEmpty(string source)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the string is null or an empty string (""); otherwise, .

### **IsNullOrWhiteSpace(String)**

Determines whether a string is null, empty, or consists only of 
 white-space characters.

```csharp
public static bool IsNullOrWhiteSpace(string source)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if the string is null, empty, or consists exclusively of white-space characters; otherwise, .

### **Replace(String, Char[], Char)**

Returns a new string in which all occurrences of each specified character
 in a string are replaced with another specified character.

```csharp
public static string Replace(string source, Char[] oldChars, char newChar)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string in which characters are to be replaced.

`oldChars` [Char[]](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The characters to be replaced.

`newChar` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The character to replace all occurrences of each character in oldChars.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) that is equivalent to the source string except that all instances 
 of each character in oldChars are replaced with newChar.

### **Replace(String, String[], String)**

Returns a new string in which all occurrences of each specified string
 in a string are replaced with another specified string.

```csharp
public static string Replace(string source, String[] oldValues, string newValue)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string in which strings are to be replaced.

`oldValues` [String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The strings to be replaced.

`newValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to replace all occurrences of each string in oldValues.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) that is equivalent to the source string except that all instances 
 of each string in oldValues are replaced with newValue.

### **ThrowIfNullOrEmpty(String, String)**

Throws an exception if a string is null or an empty string; otherwise, returns the string.

```csharp
public static string ThrowIfNullOrEmpty(string source, string paramName)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

`paramName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The parameter name to use when throwing the exception.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) if not null nor an empty [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) ("").

### **ThrowIfNullOrWhiteSpace(String, String)**

Throws an exception if a string is null, empty, or consists only of
 white-space characters.

```csharp
public static string ThrowIfNullOrWhiteSpace(string source, string paramName)
```

#### Parameters

`source` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to test.

`paramName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The parameter name to use when throwing the exception.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The [String](https://docs.microsoft.com/en-us/dotnet/api/system.string) if not null, nor empty and if it does not consist exclusively of white-space characters.

---

[`< Back`](./)
