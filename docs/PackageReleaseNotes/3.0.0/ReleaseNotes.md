# FolkerKinzel.Strings 3.0.0
## Package Release Notes
- The polyfill extension methods have moved to the namespace `FolkerKinzel.Strings.Polyfills`.
The namespace was needed, because some of the polyfill extension methods cause conflicts with
 existing extension methods from `System.MemoryExtensions` when used in a .NET Core 3.1 app. The 
new namespace will help to resolve such conflicts.
This is a breaking change that requires a new Major version, because the new namespace has to be
published in existing code to make use of the polyfills.


- New extension method for the Char structure:
```csharp
public static bool IsAscii(this char c);
```

.
- Additional extension method for the ReadOnlySpan&lt;Char&gt; structure:
```csharp
public static bool IsAscii(this ReadOnlySpan<char> span);
public static bool ContainsAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> chars);
public static int GetTrimmedStart(this ReadOnlySpan<char> span);
public static int GetTrimmedLength(this ReadOnlySpan<char> span);
```
.

- New static class `TextEncodingConverter`, which helps to overcome the the weaknesses of
.NET Standard and .NET 5.0 in parsing ANSI charset names.



- New Polyfills for .NET Framework 4.5, .NET Standard 2.0 and .NET Standard 2.1:
```csharp
public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory);
public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory);
public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory);
```
.

- New Polyfills for .NET Framework 4.5, .NET Standard 2.0:
```csharp
public static bool Contains(this string s, char value);
public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value);
```
.
- Additional extension methods for the StringBuilder class:
```csharp
public static StringBuilder Trim(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimStart(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static bool ContainsNonAscii(this StringBuilder builder);
public static bool ContainsNonAscii(this StringBuilder builder, int startIndex);
public static bool ContainsNonAscii(this StringBuilder builder, int startIndex, int length);
public static StringBuilder ToLowerInvariant(this StringBuilder builder);
public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex);
public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex, int length);
public static StringBuilder ToUpperInvariant(this StringBuilder builder);
public static StringBuilder ToUpperInvariant(this StringBuilder builder, int startIndex);
public static StringBuilder ToUpperInvariant(this StringBuilder builder, int startIndex, int length);
```
.

- Additional extension methods for the System.String class:
```csharp
public static string Trim(this string s, ReadOnlySpan<char> trimChars);
public static string TrimStart(this string s, ReadOnlySpan<char> trimChars);
public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars);
public static bool IsAscii(this string? s);
```

.

- The Polyfill for ReadOnlySpan&lt;T&gt; is now specalized for ReadOnlySpan&lt;Char&gt;
in order to solve a conflict in .NET Core 3.1:
```csharp
public static bool Contains(this ReadOnlySpan<char> span, char value);
```
.

- The CLSCompliantAttribute has been added.



- The extension method classes have been made partial.

.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
