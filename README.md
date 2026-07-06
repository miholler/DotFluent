# DotFluent

Null guards, async flows, and optional values — the patterns that show up everywhere tend to be the noisiest. DotFluent is a collection of extension members and types that keep them readable.

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
