# FolkerKinzel.Strings 3.3.0
## Package Release Notes

- Simulation of String.Create<TState>(int, TState, SpanAction<char, TState>) that works also for 
older .NET Versions:
```csharp
string StringCreator.Create<TState>(int, TState, SpanAction<char, TState>);
```

.
- New extension methods for the `Char` structure:
```csharp
bool IsAsciiLowerCaseLetter(this char);
bool IsAsciiUpperCaseLetter(this char);
bool IsAsciiLetter(this char);
```
.

- New extension method for the `ReadOnlySpan<Char>` structure:
```csharp
int LastIndexOf(this ReadOnlySpan<char>, ReadOnlySpan<char>, int, int, StringComparison);
```
.

- New polyfills for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
int LastIndexOf(this ReadOnlySpan<char>, string, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string, int, int, StringComparison);

System.Buffers.SpanAction<T, TArg>;
```
.

- New polyfill for .NET Framework 4.5, .NET Standard 2.0 and .NET Standard 2.1:
```csharp
int LastIndexOf(this ReadOnlySpan<char>, ReadOnlySpan<char>, StringComparison);
```
.

- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
