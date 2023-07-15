# FolkerKinzel.Strings

### List of Polyfill Extension Methods 
(Refers to the latest nuget version)
#### Polyfills for the String Class (.NET 5.0, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.5)
```csharp
string ReplaceLineEndings(this string);
string ReplaceLineEndings(this string, string);
```
.
#### Polyfills for the String Class (.NET Standard 2.0, .NET Framework 4.5)
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

System.Buffers.SpanAction<T, TArg>;
```
.
#### Polyfills for Static Methods of the String Class
```csharp
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>);
static string StaticStringMethod.Create<TState>(int, TState, SpanAction<char, TState>);
```
.

#### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
bool Contains(this ReadOnlySpan<char>, char);
int LastIndexOf(this ReadOnlySpan<char>, ReadOnlySpan<char>, StringComparison);
```
.

#### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
bool Contains(this ReadOnlySpan<char>, string?, StringComparison);
bool EndsWith(this ReadOnlySpan<char>, string?);
bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, StringComparison);
int LastIndexOf(this ReadOnlySpan<char>, string?, int, int, StringComparison);
bool StartsWith(this ReadOnlySpan<char>, string?);
bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
bool Equals(this ReadOnlySpan<char>, string?, StringComparison);
```
.

#### Polyfills for the ReadOnlyMemory&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)
```csharp
ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char>);
ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char>);
```
.
#### Polyfills for the StringBuilder Class (.NET Framework 4.5, .NET Standard 2.0)
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
```