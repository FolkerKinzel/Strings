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
public static int ParseHexDigit(this char);
public static int ParseDecimalDigit(this char);
public static bool IsDecimalDigit(this char);
public static bool IsHexDigit(this char);
public static bool IsBinaryDigit(this char);
public static bool IsControl(this char);
public static bool IsDigit(this char c);
public static bool IsHighSurrogate(this char c);
public static bool IsLowSurrogate(this char c);
public static bool IsSurrogate(this char c);

public static bool IsLetter(this char);
public static bool IsLetterOrDigit(this char);
public static bool IsLower(this char);
public static bool IsUpper(this char);
public static bool IsNumber(this char);
public static bool IsPunctuation(this char);
public static bool IsSeparator(this char);
public static bool IsSymbol(this char);
public static bool IsWhiteSpace(this char);
public static char ToLowerInvariant(this char);
public static char ToUpperInvariant(this char);




```
.

- New extension methods for the `ReadOnlySpan<Char>` structure:
```csharp
public static bool StartsWith(this ReadOnlySpan<char>, char);
public static bool EndsWith(this ReadOnlySpan<char>, char);
public static int LastIndexOfAny(this ReadOnlySpan<char>, ReadOnlySpan<char>, int, int);

```
.

- New extension methods for the `StringBuilder` class:
```csharp
public static bool StartsWith(this StringBuilder, char)
public static bool EndsWith(this StringBuilder, char)
```


- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
