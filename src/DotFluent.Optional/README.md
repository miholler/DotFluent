# DotFluent.Optional

[![NuGet](https://img.shields.io/nuget/v/DotFluent.Optional.svg)](https://www.nuget.org/packages/DotFluent.Optional)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![.NET](https://img.shields.io/badge/.NET-Standard%202.0-blueviolet)

A companion package to [DotFluent](https://www.nuget.org/packages/DotFluent) that adds `Option<T>` and `Result<T>` / `Result<TValue, TError>` discriminated unions — functional patterns for expressing optional values and operation outcomes without using `null` or exceptions for control flow.

## Why DotFluent.Optional?

Returning `null` to signal "not found" and throwing exceptions for expected failures work — but they hide intent. Null slips silently across method boundaries until a `NullReferenceException` surfaces far from its origin. Exceptions used for control flow are expensive and obscure which operations can fail. `Option<T>` and `Result<T>` make absence and failure **first-class values**: explicit in the method signature, impossible to ignore at the call site, and composable into readable pipelines.

**Before**
```csharp
User? user = _db.Find(id);
if (user == null)
    return null;

Address? address = _db.FindAddress(user.AddressId);
return address?.City ?? "Unknown";
```

**After**
```csharp
return FindUser(id)
    .FlatMap(u => FindAddress(u.AddressId))
    .Match(
        some: addr => addr.City,
        none: "Unknown"
    );
```

The `Option<T>` version is self-documenting: `FindUser` may return nothing, the address lookup depends on it, and both missing cases are handled in one place.

## Installation

**.NET CLI**
```shell
dotnet add package DotFluent.Optional
```

**Package Manager Console**
```powershell
Install-Package DotFluent.Optional
```

## `Option<T>` vs `Result<T>` — when to use which

| | `Option<T>` | `Result<T>` / `Result<TValue, TError>` |
|---|---|---|
| **Models** | The presence or absence of a value | The success or failure of an operation |
| **"Failure" carries** | No information | An `Exception` or a typed error value |
| **Use when** | A value may simply not exist (e.g. a record not found, an optional field) | An operation can fail for a reason the caller should handle |
| **States** | `Some(value)` / `None` | `Ok(value)` / `Error(exception\|error)` |

**Rule of thumb:** reach for `Option<T>` to replace nullable references and `?` value types; reach for `Result<T>` when an operation can fail and the caller needs to know why.

---

## `Option<T>`

```csharp
using DotFluent.Optional;
```

An immutable value type that is either `Some(value)` — holding a non-null value — or `None` — representing the absence of a value.

### Member Reference

| Member | Description |
|--------|-------------|
| `Option.Some<T>(value)` | *(static)* Creates a `Some` option |
| `Option.None<T>()` | *(static)* Creates a `None` option |
| `ToOption` | Creates an `Option<T>` from a reference type, value type, or `Result<T>` |
| `IsSome` | `true` if the option holds a value |
| `IsNone` | `true` if the option holds no value |
| `Value` | Gets the inner value; throws `InvalidOperationException` if `None` |
| `Match` | Branches on `Some`/`None` — performs actions or returns a projected value |
| `Map` | Transforms the inner value; propagates `None` |
| `FlatMap` | Chains an option-returning function; flattens the result |
| `Filter` | Discards the value if it does not satisfy a predicate |
| `OrElse` | Returns a fallback option if `None` |
| `Contains` | `true` if the option holds a specific value |
| `Exists` | `true` if the value satisfies a predicate |
| `GetValueOrDefault` | Returns the value or a specified/computed default |
| `AsEnumerable` | Converts the option to a sequence with zero or one element |
| `Flatten` | Flattens `Option<Option<T>>` to `Option<T>` |
| `Secure` | Strips null inner values from `Option<T?>` → `Option<T>` |
| `ToNullable` | Converts `Option<T>` to `T?` |

Async variants of all operations are available via `using DotFluent.Optional.Tasks;`.

### Code Examples

#### Creating an option

```csharp
// Explicit factory methods
Option<int>    some = Option.Some(42);
Option<string> none = Option.None<string>();

// Implicit conversion from a value (null → None, non-null → Some)
Option<string> opt = GetName();

// From a nullable value type
int?           nullable = 7;
Option<int>    opt      = nullable.ToOption();
```

#### `Match` — branch on Some / None

`Match` is the primary way to consume an option. It forces both cases to be handled.

```csharp
// Perform side effects
opt.Match(
    some: value => Console.WriteLine($"Found: {value}"),
    none: ()    => Console.WriteLine("Not found")
);

// Return a value
string display = opt.Match(
    some: value => value.ToUpper(),
    none: "N/A"
);
```

#### `Map` — transform the inner value

```csharp
Option<string> name   = GetName();
Option<int>    length = name.Map(n => n.Length);
```

#### `FlatMap` — chain options

Use `FlatMap` when the transform itself returns an `Option<T>`, avoiding a nested `Option<Option<T>>`.

```csharp
Option<User>    user    = FindUser(id);
Option<Address> address = user.FlatMap(u => FindAddress(u.AddressId));
```

#### `Filter` / `OrElse` / `GetValueOrDefault`

```csharp
// Discard the value if it doesn't meet a condition
Option<int> positiveScore = GetScore().Filter(s => s > 0);

// Provide a fallback
Option<string> name = GetPreferredName().OrElse(() => ComputeFallback());

// Extract safely
string name = opt.GetValueOrDefault("Anonymous");
```

#### Async pipeline

```csharp
using DotFluent.Optional.Tasks;

string display = await repository
    .FindAsync(id)                               // Task<Option<User>>
    .MapAsync(user => LoadAvatarAsync(user.Id))  // Task<Option<Avatar>>
    .MatchAsync(
        some: avatar => avatar.Url,
        none: "https://example.com/default.png"
    );
```

---

## `Result<T>`

An immutable value type that is either `Ok(value)` — holding a success value — or `Error(exception)` — carrying an `Exception`.

> `Result<T>` preserves the original exception stack trace via `ExceptionDispatchInfo`, so rethrowing the captured exception shows the correct call site.

### Member Reference

| Member | Description |
|--------|-------------|
| `Result.Ok<T>(value)` | *(static)* Creates an `Ok` result |
| `Result.Error<T>(exception)` | *(static)* Creates an `Error` result from an `Exception` |
| `IsOk` | `true` if the result holds a success value |
| `IsError` | `true` if the result holds an error |
| `Match` | Branches on `Ok`/`Error` — performs actions or returns a projected value |
| `Map` | Transforms the success value; propagates the error |
| `MapError` | Transforms the error; propagates the success value |
| `FlatMap` | Chains a result-returning function; flattens the result |
| `OrElse` | Returns a fallback result if `Error` |
| `Contains` | `true` if the result holds a specific success value |
| `Exists` | `true` if the success value satisfies a predicate |
| `GetValueOrDefault` | Returns the success value or a specified/computed default |
| `AsEnumerable` | Converts to a sequence with zero or one element |
| `Flatten` | Flattens `Result<Result<T>>` to `Result<T>` |
| `ToOption` | Converts to `Option<T>`, discarding the error |
| `ToNullable` | Converts `Result<T>` to `T?` |

Async variants of all operations are available via `using DotFluent.Optional.Tasks;`.

### Code Examples

#### Creating and returning a result

```csharp
public Result<User> FindUser(int id)
{
    var user = _db.Find(id);
    return user is not null
        ? Result.Ok(user)
        : Result.Error<User>(new KeyNotFoundException($"User {id} not found."));
}

// Implicit conversions
Result<string> ok    = "hello";                       // from value
Result<string> error = new ArgumentException("Bad");  // from Exception
```

#### `Match` — branch on Ok / Error

```csharp
result.Match(
    ok:    user => Console.WriteLine($"Welcome, {user.Name}"),
    error: ex   => logger.LogError(ex, "Failed to find user")
);

string display = result.Match(
    ok:    user => user.Name,
    error: ex   => $"Error: {ex.Message}"
);
```

#### `Map` / `MapError` / `FlatMap`

```csharp
// Transform the success value
Result<string> name = result.Map(user => user.Name);

// Add context to the error
Result<User> enriched = result.MapError(
    ex => new ApplicationException("User lookup failed", ex));

// Chain dependent operations
Result<Order> order = FindUser(userId)
    .FlatMap(user => FindLatestOrder(user.Id));
```

#### Async pipeline

```csharp
using DotFluent.Optional.Tasks;

Result<Invoice> invoice = await orderService
    .CreateAsync(cart)                           // Task<Result<Order>>
    .MapAsync(order => BuildInvoiceAsync(order))
    .OrElseAsync(() => Result.Error<Invoice>(new TimeoutException()));
```

---

## `Result<TValue, TError>`

The two-parameter variant for when you prefer a domain-specific error type over `Exception`.

### Member Reference

| Member | Description |
|--------|-------------|
| `Result.Ok<TValue, TError>(value)` | *(static)* Creates an `Ok` result |
| `Result.Error<TValue, TError>(error)` | *(static)* Creates an `Error` result from a typed value |
| `IsOk` | `true` if the result holds a success value |
| `IsError` | `true` if the result holds an error |
| `Match` | Branches on `Ok`/`Error` — performs actions or returns a projected value |
| `Map` | Transforms the success value; propagates the error |
| `MapError` | Transforms the error value; propagates the success value |
| `FlatMap` | Chains a result-returning function; flattens the result |
| `OrElse` | Returns a fallback result if `Error` |
| `Contains` | `true` if the result holds a specific success value |
| `Exists` | `true` if the success value satisfies a predicate |
| `GetValueOrDefault` | Returns the success value or a specified/computed default |
| `AsEnumerable` | Converts to a sequence with zero or one element |
| `Flatten` | Flattens `Result<Result<TValue, TError>, TError>` |
| `ToOption` | Converts to `Option<TValue>`, discarding the error |
| `ToNullable` | Converts `Result<TValue, TError>` to `TValue?` |

Async variants of all operations are available via `using DotFluent.Optional.Tasks;`.

### Code Examples

#### Domain-specific errors

```csharp
public enum UserError { NotFound, Unauthorized }

public Result<User, UserError> Find(int id)
{
    if (!_db.TryFind(id, out var user))
        return Result.Error<User, UserError>(UserError.NotFound);

    if (!_context.CanAccess(user))
        return Result.Error<User, UserError>(UserError.Unauthorized);

    return Result.Ok<User, UserError>(user);
}

Find(42).Match(
    ok:    user  => Console.WriteLine($"Hello, {user.Name}"),
    error: error => Console.WriteLine(error switch
    {
        UserError.NotFound     => "User does not exist.",
        UserError.Unauthorized => "Access denied.",
        _                      => "Unknown error."
    })
);
```

#### Mapping values and errors

```csharp
// Transform only the success value
Result<string, UserError> name = Find(id).Map(u => u.Name);

// Change the error type
Result<User, string> result = Find(id).MapError(e => e.ToString());
```

---

## Converting between types

```csharp
// Result → Option (drops the error)
Option<User> opt = result.ToOption();

// Option → Result (compose manually)
Result<User> r = option.Match(
    some: user => Result.Ok(user),
    none: ()   => Result.Error<User>(new KeyNotFoundException())
);

// Option or Result → Nullable
int? nullable = Option.Some(42).ToNullable();
```
