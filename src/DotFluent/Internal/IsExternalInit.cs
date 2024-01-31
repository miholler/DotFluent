using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

#if NETSTANDARD

/// <summary>
/// Reserved to be used by the compiler for tracking metadata.
/// This class should not be used by developers in source code.
/// </summary>
[ExcludeFromCodeCoverage]
[EditorBrowsable(EditorBrowsableState.Never)]
internal sealed record IsExternalInit;

#endif