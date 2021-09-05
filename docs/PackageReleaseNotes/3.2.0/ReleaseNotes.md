# FolkerKinzel.Strings 3.2.0-beta.1
## Package Release Notes

- New method for TextEncodingConverter:
```csharp
static int GetCodePage(ReadOnlySpan<byte> data, out int bomLength);
```
.
- New polyfills for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
static bool StartsWith(this ReadOnlySpan<char>, string?);
static bool StartsWith(this ReadOnlySpan<char>, string?, StringComparison);
static bool EndsWith(this ReadOnlySpan<char>, string?);
static bool EndsWith(this ReadOnlySpan<char>, string?, StringComparison);
static string[] Split(this string, string?, int count, StringSplitOptions);
static string[] Split(this string, string?, StringSplitOptions options);
static bool Contains(this string, string, StringComparison);
static string Replace(this string, string, string?, StringComparison);
static StringBuilder Insert(this StringBuilder, int, ReadOnlySpan<char>);
static string ReplaceWhiteSpaceWith(this string, string?, bool);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, bool);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, bool);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, string?, int, int, bool);
static string NormalizeNewLinesTo(this string, string?);
static StringBuilder NormalizeNewLinesTo(this StringBuilder, string?);



```
.

- New extension methods for the `Char` structure:
```csharp
static int ParseHexDigit(this char);
static int ParseDecimalDigit(this char);
static int ParseBinaryDigit(this char digit);
static bool TryParseHexDigit(this char, [NotNullWhen(true)] out int?);
static bool TryParseDecimalDigit(this char, [NotNullWhen(true)] out int?);
static bool TryParseBinaryDigit(this char, [NotNullWhen(true)] out int?);
static bool IsDecimalDigit(this char);
static bool IsHexDigit(this char);
static bool IsBinaryDigit(this char);
static bool IsControl(this char);
static bool IsDigit(this char c);
static bool IsHighSurrogate(this char c);
static bool IsLowSurrogate(this char c);
static bool IsSurrogate(this char c);
static bool IsLetter(this char);
static bool IsLetterOrDigit(this char);
static bool IsLower(this char);
static bool IsUpper(this char);
static bool IsNumber(this char);
static bool IsPunctuation(this char);
static bool IsSeparator(this char);
static bool IsSymbol(this char);
static bool IsWhiteSpace(this char);
static char ToLowerInvariant(this char);
static char ToUpperInvariant(this char);
```
.

- New extension methods for the `ReadOnlySpan<Char>` structure:
```csharp
static bool StartsWith(this ReadOnlySpan<char>, char);
static bool EndsWith(this ReadOnlySpan<char>, char);
static int LastIndexOfAny(this ReadOnlySpan<char>, ReadOnlySpan<char>, int, int);
static bool ContainsNewLine(this ReadOnlySpan<char> span)
```
.

- New extension methods for the `StringBuilder` class:
```csharp
static bool StartsWith(this StringBuilder, char);
static bool EndsWith(this StringBuilder, char);
static bool ContainsWhiteSpace(this StringBuilder);
static bool ContainsWhiteSpace(this StringBuilder, int);
static bool ContainsWhiteSpace(this StringBuilder, int, int);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, ReadOnlySpan<char>, bool);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, ReadOnlySpan<char>, int, bool);
static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder, ReadOnlySpan<char>, int, int, bool);
static bool ContainsNewLine(this StringBuilder);
static bool ContainsNewLine(this StringBuilder, int);
static bool ContainsNewLine(this StringBuilder, int, int);
static StringBuilder NormalizeNewLinesTo(this StringBuilder, ReadOnlySpan<char>);
```

.

- New extension methods for the `String` class:
```csharp
static bool ContainsNewLine(this string s);
public static string NormalizeNewLinesTo(this string, ReadOnlySpan<char>);
static string ReplaceWhiteSpaceWith(this string, ReadOnlySpan<char>, bool);
```


- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
