

- Polyfills for the static System.Buffers.SearchValues class and the System.Buffers.SearchValues<char> class (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1):
```csharp
static class FolkerKinzel.Strings.SearchValues;
class FolkerKinzel.Strings.SearchValues<T>;
```
&nbsp;
- New extension methods:
```csharp
int LastIndexOfAny(this ReadOnlySpan<char>, SearchValues<char>, int, int);
int LastIndexOfAny(this Span<char>, SearchValues<char>, int, int);
```
&nbsp;
- New polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1):
```csharp
int IndexOfAny(this ReadOnlySpan<char>, SearchValues<char>);
bool ContainsAny(this ReadOnlySpan<char>, SearchValues<char>);
int LastIndexOfAny(this ReadOnlySpan<char>, SearchValues<char>);
int IndexOfAnyExcept(this ReadOnlySpan<char>, SearchValues<char>);
int LastIndexOfAnyExcept(this ReadOnlySpan<char>, SearchValues<char>);
bool ContainsAnyExcept(this ReadOnlySpan<char>, SearchValues<char>);
bool ContainsAnyExcept(this ReadOnlySpan<char>, ReadOnlySpan<char>);
bool ContainsAnyExcept(this ReadOnlySpan<char>, char);
bool ContainsAnyExcept(this ReadOnlySpan<char>, char, char);
bool ContainsAnyExcept(this ReadOnlySpan<char>, char, char, char);
```
&nbsp;
- New polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Standard 2.0, .NET Framework 4.6.1):
```csharp
bool ContainsAnyExcept(this ReadOnlySpan<char>, string?);
```
&nbsp;
- New polyfills for the Span&lt;Char&gt; struct (.NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1):
```csharp
int IndexOfAny(this Span<char>, SearchValues<char>);
bool ContainsAny(this Span<char>, SearchValues<char>);
int LastIndexOfAny(this Span<char>, SearchValues<char>);
int IndexOfAnyExcept(this Span<char>, SearchValues<char>);
int LastIndexOfAnyExcept(this Span<char>, SearchValues<char>);
bool ContainsAnyExcept(this Span<char>, SearchValues<char>);
bool ContainsAnyExcept(this Span<char>, ReadOnlySpan<char>);
bool ContainsAnyExcept(this Span<char>, char);
bool ContainsAnyExcept(this Span<char>, char, char);
bool ContainsAnyExcept(this Span<char>, char, char, char);
```
&nbsp;
- New polyfills for the Span&lt;Char&gt; struct (.NET Standard 2.0, .NET Framework 4.6.1):
```csharp
bool ContainsAnyExcept(this Span<char>, string?);
```
&nbsp;
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.