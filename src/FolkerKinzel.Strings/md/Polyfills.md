# FolkerKinzel.Strings

## List of Polyfill Extension Methods 
(Refers to the latest nuget version)
### Polyfills for the String class (.NET 5.0, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.5)
```csharp
string ReplaceLineEndings(this string);
string ReplaceLineEndings(this string, string);
```
.
### Polyfills for the String class (.NET Standard 2.0, .NET Framework 4.5)
```csharp
bool Contains(this string, char);
bool Contains(this string, char, StringComparison );
bool Contains(this string, string, StringComparison);
bool EndsWith(this string, char);
int IndexOf(this string, char, StringComparison );
string Replace(this string, string, string?, StringComparison);
string ReplaceWhiteSpaceWith(this string, string?, bool);
string[] Split(this string, char, StringSplitOptions);
string[] Split(this string, char, int, StringSplitOptions);
string[] Split(this string, string?, int count, StringSplitOptions);
string[] Split(this string, string?, StringSplitOptions options);
bool StartsWith(this string, char);
int IndexOfAny(this string, string?, int);
int IndexOfAny(this string, string?);
int LastIndexOfAny(this string, string?, int);
int LastIndexOfAny(this string, string?);
bool ContainsAny(this s, string?);

```
.
### Polyfills for Static Methods of the String class
```csharp
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Create<TState>(int, TState, SpanAction<char, TState>);
```
.

### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
bool Contains(this ReadOnlySpan<char>, char);
```

.

### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
bool Contains(this ReadOnlySpan<char>, string?, StringComparison);
bool EndsWith(this ReadOnlySpan<char>, string?);
bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, int, int, StringComparison);
bool StartsWith(this ReadOnlySpan<char>, string?);
bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
bool Equals(this ReadOnlySpan<char>, string?, StringComparison);
bool ContainsAny(this ReadOnlySpan<char>, string?);
int IndexOfAny(this ReadOnlySpan<char>, string?);
int LastIndexOfAny(this ReadOnlySpan<char>, string?);
int LastIndexOfAny(this ReadOnlySpan<char>, string?, int, int);
int IndexOf(this ReadOnlySpan<char>, string?, StringComparison);
ReadOnlySpan<char> Trim(this ReadOnlySpan<char>, string?);
ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char>, string?);
ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char>, string?);
```
.
### Polyfills for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
bool Contains(this ReadOnlySpan<char>, char);
public static Span<char> Trim(this Span<char>);
public static Span<char> TrimStart(this Span<char>);
public static Span<char> TrimEnd(this Span<char>);
```
.
### Polyfills for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
bool Equals(this Span<char>, string?, StringComparison);
bool Contains(this Span<char>, string?, StringComparison);
int LastIndexOf(this Span<char>, string?, StringComparison);
bool StartsWith(this Span<char>, string?);
bool StartsWith(this Span<char>, string?, StringComparison);
bool EndsWith(this Span<char>, string?);
bool EndsWith(this Span<char>, string?, StringComparison);
int LastIndexOf(this Span<char>, string?, int, int, StringComparison);
bool ContainsAny(this Span<char>, string?);
int IndexOfAny(this Span<char>, string?);
int LastIndexOfAny(this Span<char>, string?);
int LastIndexOfAny(this Span<char>, string?, int, int);
int IndexOf(this Span<char>, string?, StringComparison);
```
.

### Polyfills for the ReadOnlyMemory&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)
```csharp
ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char>);
```
.
### Polyfills for the StringBuilder class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
StringBuilder Append(this StringBuilder, ReadOnlySpan<char>);
StringBuilder Append(this StringBuilder, StringBuilder?, int, int);
StringBuilder AppendJoin(this StringBuilder, char, params string?[]);
StringBuilder AppendJoin(this StringBuilder, char, params object?[]);
StringBuilder AppendJoin<T>(this StringBuilder, char, IEnumerable<T>);
StringBuilder AppendJoin(this StringBuilder, string?, params string?[]);
StringBuilder AppendJoin(this StringBuilder, string?, params object?[]);
StringBuilder AppendJoin<T>(this StringBuilder, string?, IEnumerable<T>);
StringBuilder Insert(this StringBuilder, int, ReadOnlySpan<char>);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, bool);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, bool);
StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, int, bool);
StringBuilder AppendUrlEncoded(this StringBuilder, string?);
```
.
### Polyfills for the Encoding class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes);
```