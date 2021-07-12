# FolkerKinzel.Strings 2.1.0
## Package Release Notes
- The polyfill extension methods have moved to the namespace `FolkerKinzel.Strings.Polyfills`.
The namespace was needed, because some of the polyfill extension methods cause conflicts with
 existing extension methods from `System.MemoryExtensions` when used in a .NET Core 3.1 app. The 
new namespace will help to resolve such conflicts.
This is a breaking change that requires a new Major version, because the new namespace has to be
published in existing code to make use of the polyfills.

.

- New Polyfills for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
public static bool Contains(this string s, char value);
public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory);
public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory);
public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory);
public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value);
```
.
- Additional overloads of the StringBuilder.Trim extension methods:
```csharp
public static StringBuilder Trim(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimStart(this StringBuilder builder, ReadOnlySpan<char> trimChars);
public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars);
```
.

- Additional extension methods for the System.String class:
```csharp
public static string Trim(this string s, ReadOnlySpan<char> trimChars);
public static string TrimStart(this string s, ReadOnlySpan<char> trimChars);
public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars);
```

.

- The Polyfill for ReadOnlySpan&lt;T&gt; is now specalized for ReadOnlySpan&lt;Char&gt;
in order to solve a conflict in .NET Core 3.1:
```csharp
public static bool Contains(this ReadOnlySpan<char> span, char value);
```
.

- The CLSCompliantAttribute has been added.
