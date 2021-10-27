# FolkerKinzel.Strings

## List of Polyfill Extension Methods

### Polyfills for the String Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
bool Contains(this string, char, StringComparison );
bool Contains(this string, char);
bool Contains(this string, string, StringComparison);
int IndexOf(this string, char, StringComparison );
string[] Split(this string, char, StringSplitOptions);
string[] Split(this string, char, int, StringSplitOptions);
string[] Split(this string, string?, int count, StringSplitOptions);
string[] Split(this string, string?, StringSplitOptions options);
string Replace(this string, string, string?, StringComparison);
bool StartsWith(this string, char);
bool EndsWith(this string, char);
string ReplaceWhiteSpaceWith(this string, string?, bool);
string NormalizeNewLinesTo(this string, string?);

System.Buffers.SpanAction<T, TArg>;
```
.

### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
bool Contains(this ReadOnlySpan<char>, char);
int LastIndexOf(this ReadOnlySpan<char>, ReadOnlySpan<char>, StringComparison);
```
.

### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
bool StartsWith(this ReadOnlySpan<char>, string?);
bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
bool EndsWith(this ReadOnlySpan<char>, string?);
bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, int, int, StringComparison);
```
.

### Polyfills for the ReadOnlyMemory&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)
```csharp
ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char>);
```
.
### Polyfills for the StringBuilder Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
StringBuilder Append(this StringBuilder, ReadOnlySpan<char>);
StringBuilder Append(this StringBuilder, StringBuilder?, int, int);
StringBuilder Insert(this StringBuilder, int, ReadOnlySpan<char>);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, bool);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, bool);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, int, bool);
StringBuilder NormalizeNewLinesTo(this StringBuilder, string?);
```