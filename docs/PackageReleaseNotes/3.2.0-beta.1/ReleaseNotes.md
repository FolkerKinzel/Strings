# FolkerKinzel.Strings 3.2.0-beta.1
## Package Release Notes

- New method for TextEncodingConverter:
```csharp
public static int GetCodePage(ReadOnlySpan<byte> data, out int bomLength);
```
.
- New polyfills for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
public static bool StartsWith(this ReadOnlySpan<char>, string?);
public static bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
public static bool EndsWith(this ReadOnlySpan<char>, string?);
public static bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
public static string[] Split(this string, string?, int count, StringSplitOptions);
public static string[] Split(this string, string?, StringSplitOptions options);
public static bool Contains(this string, string, StringComparison);
public static string Replace(this string, string, string?, StringComparison);
```
.

- New extension methods for the `Char` structure:
```csharp
public static bool IsDecimalDigit(this char);
public static bool IsBinaryDigit(this char);
```
.

- New extension methods for the `ReadOnlySpan<Char>` structure:
```csharp
public static bool StartsWith(this ReadOnlySpan<char>, char);
public static bool EndsWith(this ReadOnlySpan<char>, char);
```
.

- New extension methods for the `StringBuilder` class:
```csharp
public static bool StartsWith(this StringBuilder, char)
public static bool EndsWith(this StringBuilder, char)
```


- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
