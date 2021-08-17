# FolkerKinzel.Strings

## List of Polyfill Extension Methods

### Polyfills for the String Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
public static bool Contains(this string, char, StringComparison );
public static bool Contains(this string, char);
public static bool Contains(this string, string, StringComparison);
public static int IndexOf(this string, char, StringComparison );
public static string[] Split(this string, char, StringSplitOptions);
public static string[] Split(this string, char, int, StringSplitOptions);
public static string[] Split(this string, string?, int count, StringSplitOptions);
public static string[] Split(this string, string?, StringSplitOptions options);
public static string Replace(this string, string, string?, StringComparison);
public static bool StartsWith(this string, char);
public static bool EndsWith(this string, char);
```
.

### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
public static bool Contains(this ReadOnlySpan<char>, char);
```
.

### Polyfills for the ReadOnlySpan&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
public static bool StartsWith(this ReadOnlySpan<char>, string?);
public static bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
public static bool EndsWith(this ReadOnlySpan<char>, string?);
public static bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
```
.

### Polyfills for the ReadOnlyMemory&lt;Char&gt; Struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)
```csharp
public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char>);
public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char>);
public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char>);
```
.
### Polyfills for the StringBuilder Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
public static StringBuilder Append(this StringBuilder, ReadOnlySpan<char>);
public static StringBuilder Append(this StringBuilder, StringBuilder?, int, int);
```