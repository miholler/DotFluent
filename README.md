# DotFluent

DotFluent is a .NET library with fluent extensions for everyday operations like guarding against null, transforming nullable values, and chaining async tasks. Its companion package, `DotFluent.Optional`, adds `Option<T>` for values that may be absent and `Result` types for operations that can fail.

## Installation

Install the core extensions package:

```shell
dotnet add package DotFluent
```

Optionally, add `Option<T>`, `Result<T>`, and `Result<TValue, TError>` support:

```shell
dotnet add package DotFluent.Optional
```

## Packages

| Package | Version | Description |
|---------|---------|-------------|
| [DotFluent](src/DotFluent/README.md) | [![NuGet](https://img.shields.io/nuget/v/DotFluent.svg)](https://www.nuget.org/packages/DotFluent) | Core fluent extensions for objects, strings, collections, nullables, LINQ, and tasks |
| [DotFluent.Optional](src/DotFluent.Optional/README.md) | [![NuGet](https://img.shields.io/nuget/v/DotFluent.Optional.svg)](https://www.nuget.org/packages/DotFluent.Optional) | `Option<T>` and `Result<T>` / `Result<TValue, TError>` discriminated unions |

## Filing issues

If you find a bug or have a suggestion, feel free to open an issue.

## License

DotFluent is licensed under the [MIT](LICENSE) license.
