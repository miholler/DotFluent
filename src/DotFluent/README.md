# DotFluent

[![NuGet](https://img.shields.io/nuget/v/DotFluent.svg)](https://www.nuget.org/packages/DotFluent)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![.NET](https://img.shields.io/badge/.NET-Standard%202.0%20%7C%208%20%7C%2010-blueviolet)

A .NET library that provides fluent extension members for commonly used types, making everyday guard checks, string tests, collection operations, LINQ queries, and async task composition more expressive and readable.

## Why DotFluent?

If you prefer a fluent, pipeline-oriented style, DotFluent extends the types you already use to support it — guard checks return the guarded value, and string and collection tests read as natural predicates.

**Before**
```csharp
public void Process(Order? order, string? description)
{
    if (order == null)
        throw new ArgumentNullException(nameof(order));

    if (string.IsNullOrWhiteSpace(description))
        description = "No description";

    if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Processing)
        throw new InvalidOperationException("Order is not active.");
}
```

**After**
```csharp
public void Process(Order? order, string? description)
{
    order.ThrowIfNull();
    description = description.DefaultIfEmpty("No description");

    if (order.IsNot(o => o.Status is OrderStatus.Pending or OrderStatus.Processing))
        throw new InvalidOperationException("Order is not active.");
}
```

## Installation

**.NET CLI**
```shell
dotnet add package DotFluent
```

**Package Manager Console**
```powershell
Install-Package DotFluent
```

## Namespaces

| Namespace | Contents |
|-----------|----------|
| [`DotFluent`](#dotfluent-core) | Object, string, collection, and nullable extensions |
| [`DotFluent.Linq`](#dotfluent-linq) | Additional LINQ operators for `IEnumerable<T>` and `IAsyncEnumerable<T>` |
| [`DotFluent.Tasks`](#dotfluent-tasks) | Promise-style continuations for `Task` and `ValueTask` |

---

<a id="dotfluent-core"></a>

## `DotFluent`

```csharp
using DotFluent;
```

### Objects — `ObjectExtensions`

| Member | Description |
|--------|-------------|
| `Is` | `true` if the object satisfies a predicate; `false` when null |
| `IsEqualTo` | Value or reference equality check |
| `IsNot` | `true` if the object does not satisfy a predicate; `true` when null |
| `IsNotEqualTo` | Value or reference inequality check |
| `IsNotNull` | `true` if the object is not null |
| `IsNull` | `true` if the object is null |
| `ThrowIfNull` | Throws `ArgumentNullException` (or a custom exception) if the object is null; otherwise returns the object |

### Strings — `StringExtensions`

| Member | Description |
|--------|-------------|
| `DefaultIfEmpty` | Returns a default value if the string is null, empty, or whitespace |
| `IsEqualTo` | Case-sensitive string equality check |
| `IsLike` | Case-insensitive equality (`OrdinalIgnoreCase`) |
| `IsNotEqualTo` | Case-sensitive string inequality check |
| `IsNotLike` | Case-insensitive inequality (`OrdinalIgnoreCase`) |
| `IsNotNullNorEmpty` | `true` if the string is not null and not `""` |
| `IsNotNullNorWhiteSpace` | `true` if the string is not null, not empty, and not whitespace-only |
| `IsNullOrEmpty` | `true` if the string is null or `""` |
| `IsNullOrWhiteSpace` | `true` if the string is null, empty, or whitespace-only |
| `Replace` | Replaces multiple characters or substrings in a single pass |
| `ThrowIfNullOrEmpty` | Throws if null or empty; returns the string otherwise |
| `ThrowIfNullOrWhiteSpace` | Throws if null, empty, or whitespace; returns the string otherwise |

### Collections — `CollectionExtensions`

Extensions on `IDictionary<TKey, TValue>` that mirror the thread-safe API of `ConcurrentDictionary`.

| Member | Description |
|--------|-------------|
| `AddOrUpdate` | Inserts a new entry or updates an existing one using a factory |
| `GetOrAdd` | Returns the existing value or inserts and returns a new one |
| `TryAdd` | Adds a key/value pair if the key does not exist; returns `false` if it does |
| `TryRemove` | Removes a key and returns its value via `out`; returns `false` if not found |
| `TryUpdate` | Updates a value only if the current value equals a comparison value |

### Nullables — `NullableExtensions`

Functional-style extensions for `Nullable<T>` (value types).

| Member | Description |
|--------|-------------|
| `Contains` | `true` if the nullable contains a specific value |
| `Exists` | `true` if the nullable contains a value satisfying a predicate |
| `Filter` | Removes the value if it does not satisfy a predicate |
| `FlatMap` | Transforms the inner value into another nullable; flattens the result |
| `GetValueOrDefault` | Returns the value or a specified/computed default |
| `IsNone` | `true` if the nullable has no value |
| `IsSome` | `true` if the nullable has a value (`HasValue`) |
| `Map` | Transforms the inner value; propagates `null` if none |
| `Match` | Executes an action or projects a value based on `Some`/`None` state |
| `OrElse` | Returns a fallback nullable if none |
| `ToNullable` | Wraps a value type in a `Nullable<T>` |

---

### Code Examples

#### `ThrowIfNull`

Throws an `ArgumentNullException` (or a custom exception) when the value is `null`; otherwise returns the value. The parameter name is captured automatically via `CallerArgumentExpression`.

```csharp
// Guard at the top of a method — parameter name is inferred automatically
public void Process(Order? order)
{
    order.ThrowIfNull(); // throws ArgumentNullException: "order"
}

// Custom exception
public void Process(Order? order)
{
    order.ThrowIfNull(() => new InvalidOperationException("Order must not be null."));
}

// Inline guard — combines the null check and assignment on one line
var name = GetName().ThrowIfNull();
```

#### `IsNull` / `IsNotNull`

Null-checks that flow into the C# nullable analysis (annotated with `[NotNullWhen]`).

```csharp
string? name = GetName();

if (name.IsNull())
    Console.WriteLine("No name provided.");

if (name.IsNotNull())
    Console.WriteLine($"Hello, {name}!"); // name is non-null here
```

#### `Is` / `IsNot`

Test an object against an arbitrary predicate without first checking for `null`. Both methods return `false`/`true` respectively when the source is `null`.

```csharp
int? age = GetAge();

if (age.Is(x => x >= 18))
    Console.WriteLine("Adult");

if (order.IsNot(x => x.IsShipped))
    Console.WriteLine("Order is still pending.");
```

#### String guards

```csharp
string? input = Console.ReadLine();

if (input.IsNullOrEmpty())
    return;

if (email.IsNullOrWhiteSpace())
    throw new ValidationException("E-mail is required.");

// Guard that also returns the value for inline chaining
var slug = input
    .ThrowIfNullOrEmpty()
    .ToLowerInvariant()
    .Replace(' ', '-');

// Case-insensitive comparison
if (command.IsLike("quit"))
    Environment.Exit(0);

// Fallback
string title = GetTitle().DefaultIfEmpty("Untitled");
```

#### `GetOrAdd` / `AddOrUpdate`

```csharp
var cache = new Dictionary<string, User>();

// Returns the existing value or lazily inserts a new one
var user = cache.GetOrAdd("alice", key => LoadUserFromDb(key));

// Increments a counter, starting at 1 if the key is new
var hits = new Dictionary<string, int>();
hits.AddOrUpdate("home", addValue: 1, updateValueFactory: (key, current) => current + 1);
```

#### Nullable extensions

```csharp
DateTime? date = GetExpiryDate();

// Map
int? daysLeft = date.Map(d => (d - DateTime.Today).Days);

// Match
string label = date.Match(
    some: d => d.ToString("d"),
    none: "N/A"
);

// Filter — None if the date is in the past
DateTime? validDate = date.Filter(d => d > DateTime.Today);

// OrElse
int? primary = GetPrimary();
int? result  = primary.OrElse(GetFallback());
```

---

<a id="dotfluent-linq"></a>

## `DotFluent.Linq`

```csharp
using DotFluent.Linq;
```

All members below either extend `IEnumerable<T>` or `IAsyncEnumerable<T>` unless marked *(static)*.

| Member | Description |
|--------|-------------|
| `AggregateBy` | Aggregates a sequence grouped by a key |
| `AverageOrDefault` | Computes the average, or a default value if the sequence is empty |
| `Contains` | Determines whether a sequence contains an element using a custom comparison |
| `CountBy` | Returns the occurrence count of each distinct key |
| `Create` | *(static)* Creates a sequence or async sequence from a set of elements |
| `CrossJoin` | Returns the Cartesian product of two sequences |
| `DefaultIfEmpty` | Returns a singleton sequence with a default value if the source is empty |
| `Distinct` | Returns distinct elements using a custom comparison |
| `DistinctBy` | Returns distinct elements by a key selector |
| `ElementAtOrDefault` | Returns the element at an index or a default value |
| `Empty` | *(static)* Returns an empty async sequence |
| `Except` | Removes elements present in a second sequence using a custom comparison |
| `ExceptBy` | Removes elements whose key is present in a second sequence |
| `FirstOrDefault` | Returns the first element or a default value |
| `Flatten` | Flattens nested sequences, or a tree structure via a child selector |
| `ForEach` | Performs an action on each element (immediate, no return value) |
| `ForEachAsync` | Performs a synchronous or asynchronous action on each async element |
| `FullJoin` | Returns all elements from both sequences, matched where possible |
| `GroupBy` | Groups elements by a key using a custom comparison |
| `GroupJoin` | Correlates elements of the left sequence with a group of matching right elements |
| `Index` | Returns each element paired with its zero-based index |
| `IndexOf` | Returns the zero-based index of an element in the sequence, or `-1` |
| `Insert` | Inserts an element at a specified index |
| `InsertRange` | Inserts a range of elements at a specified index |
| `Intersect` | Returns elements present in both sequences using a custom comparison |
| `IntersectBy` | Returns elements from the first sequence whose key is in the second |
| `IsNotNullNorEmpty` | `true` if the sequence is not null and contains at least one element |
| `IsNullOrEmpty` | `true` if the sequence is null or contains no elements |
| `Join` | Correlates elements of two sequences by matching keys using a custom comparison |
| `LastOrDefault` | Returns the last element or a default value |
| `LeftJoin` | Returns all left elements with matching right elements (or null for non-matches) |
| `Max` | Returns the maximum value using a custom comparison |
| `MaxBy` | Returns the element with the maximum projected key |
| `MaxOrDefault` | Returns the maximum value or a default value if the sequence is empty |
| `Min` | Returns the minimum value using a custom comparison |
| `MinBy` | Returns the element with the minimum projected key |
| `MinOrDefault` | Returns the minimum value or a default value if the sequence is empty |
| `None` | `true` if the sequence is empty, or no element satisfies a predicate |
| `Order` | Sorts elements in ascending order |
| `OrderBy` | Sorts elements in ascending order by a key using a custom comparison |
| `OrderByDescending` | Sorts elements in descending order by a key using a custom comparison |
| `OrderDescending` | Sorts elements in descending order |
| `Pipe` | Performs an action on each element while passing elements through (lazy, chainable), including async sequences |
| `RightJoin` | Returns all right elements with matching left elements (or null for non-matches) |
| `SequenceEqual` | Determines whether two sequences are equal using a custom comparison |
| `SingleOrDefault` | Returns the only matching element or a default value |
| `SumOrDefault` | Computes the sum or a default value if the sequence is empty |
| `ThenBy` | Performs a secondary ascending sort using a custom comparison |
| `ThenByDescending` | Performs a secondary descending sort using a custom comparison |
| `ToArrayAsync` | Creates an array from an async sequence |
| `ToAsyncEnumerable` | Converts an `IEnumerable<T>` to an `IAsyncEnumerable<T>` |
| `ToDictionary` | Creates a dictionary using a custom key comparison |
| `ToDictionaryAsync` | Creates a dictionary from an async sequence using a custom key comparison |
| `ToHashSet` | Creates a hash set using a custom comparison |
| `ToListAsync` | Creates a list from an async sequence |
| `ToLookup` | Creates a lookup using a custom comparison |
| `Union` | Returns distinct elements from both sequences using a custom comparison |
| `UnionBy` | Returns distinct elements from both sequences by a key selector |

### Code Examples

#### Static methods

```csharp
var numbers = Enumerable.Create(1, 2, 3);
var asyncNumbers = AsyncEnumerable.Create(1, 2, 3);
var empty = AsyncEnumerable.Empty<int>();
```

#### `IsNullOrEmpty` / `None`

```csharp
IEnumerable<Order>? orders = GetOrders();

if (orders.IsNullOrEmpty())
    return;

if (orders.None(o => o.IsShipped))
    Console.WriteLine("No shipped orders yet.");
```

#### `ForEach` / `Pipe`

```csharp
// ForEach — immediate side effects, no return value
users.ForEach(u => Console.WriteLine(u.Name));
users.ForEach((u, i) => Console.WriteLine($"{i}: {u.Name}"));

// Pipe — side effects while keeping the sequence flowing
var result = users
    .Pipe(u => logger.Log(u.Name))   // side effect
    .Where(u => u.IsActive)
    .ToList();
```

#### `ForEachAsync` / `Pipe`

```csharp
// ForEachAsync — immediate async side effects, no return value
await users
    .ToAsyncEnumerable()
    .ForEachAsync(user => Console.WriteLine(user.Name));
await users
    .ToAsyncEnumerable()
    .ForEachAsync((user, i) => Console.WriteLine($"{i}: {user.Name}"));

// Pipe — async side effects while keeping the sequence flowing
var result = users
    .ToAsyncEnumerable()
    .Pipe(user => logger.Log(user.Name))
    .Where(u => u.IsActive)
    .ToListAsync();
```

#### Join variants

```csharp
// Left join — all customers, with or without orders
var result = customers.LeftJoin(
    orders,
    customer => customer.Id,
    order    => order.CustomerId,
    (customer, order) => new { customer.Name, OrderId = order?.Id });

// Right join — all orders, with or without a matching customer
var result = orders.RightJoin(
    customers,
    order    => order.CustomerId,
    customer => customer.Id,
    (order, customer) => new { customer?.Name, OrderId = order.Id });

// Full join — all rows from both sides
var full = left.FullJoin(
    right,
    l => l.Key,
    r => r.Key,
    (l, r) => new { Left = l?.Value, Right = r?.Value });

// Cross join — Cartesian product of both sequences
var pairs = sizes.CrossJoin(
    colors,
    (size, color) => new { Size = size, Color = color });
```

#### `Flatten`

```csharp
// Flatten nested sequences
IEnumerable<IEnumerable<int>> nested = [[1, 2], [3, 4]];
IEnumerable<int> flat = nested.Flatten(); // [1, 2, 3, 4]

// Flatten a tree
var allNodes = rootNodes.Flatten(node => node.Children);
```

#### `AverageOrDefault` / `MaxOrDefault` / `MinOrDefault` / `SumOrDefault`

```csharp
double avg = emptyList.AverageOrDefault(0.0);
int    max = scores.MaxOrDefault();
int    min = scores.MinOrDefault();
int    sum = scores.SumOrDefault(() => -1);
```

---

<a id="dotfluent-tasks"></a>

## `DotFluent.Tasks`

```csharp
using DotFluent.Tasks;
```

Promise-style continuations for `Task`, `Task<T>`, `ValueTask`, and `ValueTask<T>`.

| Member | Description |
|--------|-------------|
| `AsValueTask` | Converts a `Task` / `Task<T>` to `ValueTask` / `ValueTask<T>` |
| `Catch` | Handles a failure in the task chain, like a `catch` block |
| `CatchWhen` | Handles a failure only when a specified condition is met |
| `Finally` | Always-execute continuation after a task, regardless of success or failure |
| `Then` | Chains a synchronous or asynchronous continuation after a task completes successfully |
| `Unwrap` | Flattens a `ValueTask<ValueTask>` or `ValueTask<ValueTask<T>>` |

### Code Examples

#### `Then`

```csharp
await FetchUserAsync(id)
    .Then(user => Console.WriteLine($"Fetched {user.Name}"));

// Async continuation
await FetchUserAsync(id)
    .Then(user => SaveToDbAsync(user));
```

#### `Catch` / `CatchWhen`

```csharp
await FetchUserAsync(id)
    .Catch<TimeoutException>(ex => logger.LogWarning(ex, "The request timed out"))
    .Catch<InvalidOperationException>(ex => logger.LogError(ex, "The operation failed"));

// CatchWhen handlers can target different exception types and conditions
await FetchUserAsync(id)
    .CatchWhen<TimeoutException>(ex => !isRetrying, ex => logger.LogWarning(ex, "The request timed out"))
    .CatchWhen<InvalidOperationException>(ex => isRetrying, ex => logger.LogError(ex, "The operation failed while retrying"));
```

#### `Finally`

```csharp
await FetchUserAsync(id)
    .Then(user => ProcessAsync(user))
    .Catch<InvalidOperationException>(ex => logger.LogError(ex, "Processing failed"))
    .Finally(() => connection.Close());
```
