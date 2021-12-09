# FolkerKinzel.Strings 4.0.0
## Package Release Notes

- New class `StaticStringMethod`, which offers polyfills for static methods of the `String` class:
```csharp
    static string StaticStringMethod.Create<TState>(int, TState, SpanAction<char, TState>);
    static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
    static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>);
```
- The class `StringCreator` has been replaced by `StaticStringMethod`.
- Polyfills for the .NET 6.0 methods `String.ReplaceLineEndings()` and `String.ReplaceLineEndings(String)`.
- The following methods are marked as obsolete and have a replacement in `ReplaceLineEndings` methods now,
which exactly simulate the behavior of the .NET 6.0 method `String.ReplaceLineEndings(String)`:
```csharp
    NormalizeNewLinesTo(this StringBuilder, ReadOnlySpan<char>);
    NormalizeNewLinesTo(this StringBuilder, string?);
    NormalizeNewLinesTo(this string, ReadOnlySpan<char>);
    NormalizeNewLinesTo(this string, string?);
```
.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)


