# FolkerKinzel.Strings

## List of Polyfill Extension Methods 
(Refers to the latest nuget version)

### Polyfills for the String class (.NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
string ReplaceLineEndings(this string);
string ReplaceLineEndings(this string, string);
```
&nbsp;
### Polyfills for the String class (.NET Standard 2.0, .NET Framework 4.6.1)
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
bool ContainsAny(this string, string?);
string Trim(this string, string?);
string TrimEnd(this string, string?);
string TrimStart(this string, string?);
```
&nbsp;
### Polyfills for Static Methods of the String class
```csharp
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Create<TState>(int, TState, SpanAction<char, TState>);
```
&nbsp;
### Polyfills for the static System.Buffers.SearchValues class and the System.Buffers.SearchValues<char> class (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
static class FolkerKinzel.Strings.SearchValues;
class FolkerKinzel.Strings.SearchValues<T>;
```
&nbsp;
### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
bool ContainsAny(this ReadOnlySpan<char>, ReadOnlySpan<char>);
bool ContainsAny(this ReadOnlySpan<char>, char, char);
bool ContainsAny(this ReadOnlySpan<char>, char, char, char);
int IndexOfAny(this ReadOnlySpan<char>, SearchValues<char>);
bool ContainsAny(this ReadOnlySpan<char>, SearchValues<char>);
```
&nbsp;
### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
int IndexOfAnyExcept(this ReadOnlySpan<char>, char);
int IndexOfAnyExcept(this ReadOnlySpan<char>, char, char);
int IndexOfAnyExcept(this ReadOnlySpan<char>, char, char, char);
int IndexOfAnyExcept(this ReadOnlySpan<char>, ReadOnlySpan<char>);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, char);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, char, char);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, char, char, char);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, ReadOnlySpan<char>);
```
&nbsp;
### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
bool Contains(this ReadOnlySpan<char>, char);
```
&nbsp;
### Polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Standard 2.0, .NET Framework 4.6.1)
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
int IndexOfAnyExcept(this ReadOnlySpan<char>, string?);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, string?);
```
&nbsp;
### Polyfills for the Span&lt;Char&gt; struct (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
bool ContainsAny(this Span<char>, ReadOnlySpan<char>);
bool ContainsAny(this Span<char>, char, char);
bool ContainsAny(this Span<char>, char, char, char);
int IndexOfAny(this Span<char>, SearchValues<char>);
bool ContainsAny(this Span<char>, SearchValues<char>);
```
&nbsp;
### Polyfills for the Span&lt;Char&gt; struct (.NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
int IndexOfAnyExcept(this Span<char>, char);
int IndexOfAnyExcept(this Span<char>, char, char);
int IndexOfAnyExcept(this Span<char>, char, char, char);
int IndexOfAnyExcept(this Span<char>, ReadOnlySpan<char>);
int LastIndexOfAnyExcept(this Span<char>, char);
int LastIndexOfAnyExcept(this Span<char>, char, char);
int LastIndexOfAnyExcept(this Span<char>, char, char, char);
int LastIndexOfAnyExcept(this Span<char>, ReadOnlySpan<char>);
```
&nbsp;
### Polyfills for the Span&lt;Char&gt; struct (.NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
bool Contains(this ReadOnlySpan<char>, char);
Span<char> Trim(this Span<char>);
Span<char> TrimStart(this Span<char>);
Span<char> TrimEnd(this Span<char>);
Span<char> Trim(this Span<char>, char);
Span<char> TrimStart(this Span<char>, char);
Span<char> TrimEnd(this Span<char>, char);
```
&nbsp;
### Polyfills for the Span&lt;Char&gt; struct (.NET Standard 2.0, .NET Framework 4.6.1)
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
int IndexOfAnyExcept(this Span<char>, string?);
int LastIndexOfAnyExcept(this Span<char>, string?);
```
&nbsp;
### Polyfills for the ReadOnlyMemory&lt;Char&gt; struct (.NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char>);
```
&nbsp;
### Polyfills for the Memory&lt;Char&gt; struct (.NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1)
```csharp
Memory<char> Trim(this Memory<char>);
Memory<char> TrimEnd(this Memory<char>);
Memory<char> TrimStart(this Memory<char>);
```
&nbsp;
### Polyfills for the StringBuilder class (.NET Standard 2.0, .NET Framework 4.6.1)
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
StringBuilder Trim(this StringBuilder, string?);
StringBuilder TrimEnd(this StringBuilder, string?);
StringBuilder TrimStart(this StringBuilder, string?);
```
&nbsp;
### Polyfills for the Encoding class (.NET Standard 2.0, .NET Framework 4.6.1)
```csharp
string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes);
```