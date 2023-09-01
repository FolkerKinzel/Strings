- New static class `Base64`
- New enum `Base64ParserOptions`
- New extension methods:
```csharp
byte[] GetBytes(this Encoding, ReadOnlySpan<char>);

StringBuilder AppendBase64(this StringBuilder,
                           IEnumerable<byte>,
                           Base64FormattingOptions);

StringBuilder AppendBase64(this StringBuilder,
                           byte[],
                           Base64FormattingOptions);

StringBuilder AppendBase64(this StringBuilder,
                           ReadOnlySpan<byte>,
                           Base64FormattingOptions);

bool Contains(this Span<char>, ReadOnlySpan<char>, StringComparison comparisonType);
bool ContainsAny(this Span<char>, ReadOnlySpan<char>);
bool ContainsAny(this Span<char>, char, char);
bool ContainsAny(this Span<char>, char, char, char);
bool ContainsNewLine(this Span<char>);
bool ContainsWhiteSpace(this Span<char>);
bool EndsWith(this Span<char>, char);
bool EndsWith(this Span<char>, ReadOnlySpan<char>, StringComparison);
bool Equals(this Span<char>, ReadOnlySpan<char>, StringComparison);
int GetPersistentHashCode(this Span<char>, HashType);
int GetTrimmedLength(this Span<char>);
int GetTrimmedStart(this Span<char>);
int IndexOfAny(this Span<char>, ReadOnlySpan<char>);
bool IsAscii(this Span<char>);
bool IsWhiteSpace(this Span<char>);
int LastIndexOf(this Span<char>, ReadOnlySpan<char>, StringComparison);
int LastIndexOf(this Span<char>, ReadOnlySpan<char>, int, int, StringComparison);
int LastIndexOfAny(this Span<char>, ReadOnlySpan<char>);
int LastIndexOfAny(this Span<char>, ReadOnlySpan<char>, int, int);
bool StartsWith(this Span<char>, char);
bool StartsWith(this Span<char>, ReadOnlySpan<char>, StringComparison);
void ToLowerInvariant(this Span<char>);
void ToLower(this Span<char> span, CultureInfo?);
void ToUpperInvariant(this Span<char>);
void ToUpper(this Span<char>, CultureInfo?);
```
.
- New polyfill for the Encoding class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes);
```
.
- New polyfills for the ReadOnlySpan&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
bool ContainsAny(this ReadOnlySpan<char>, string?);
int IndexOfAny(this ReadOnlySpan<char>, string?);
int LastIndexOfAny(this ReadOnlySpan<char>, string?);
int LastIndexOfAny(this ReadOnlySpan<char>, string?, int, int);
```
.
- New polyfills for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0, .NET Standard 2.1)

```csharp
bool Contains(this ReadOnlySpan<char>, char);
public static Span<char> Trim(this Span<char>);
public static Span<char> TrimStart(this Span<char>);
public static Span<char> TrimEnd(this Span<char>);
```
.
- New polyfills for the Span&lt;Char&gt; struct (.NET Framework 4.5, .NET Standard 2.0)

```csharp
    public static bool Equals(this Span<char>, string?, StringComparison);
    public static bool Contains(this Span<char>, string?, StringComparison);
    public static int LastIndexOf(this Span<char>, string?, StringComparison);
    public static bool StartsWith(this Span<char>, string?);
    public static bool StartsWith(this Span<char>, string?, StringComparison);
    public static bool EndsWith(this Span<char>, string?);
    public static bool EndsWith(this Span<char>, string?, StringComparison);
    public static int LastIndexOf(this Span<char>, string?, int, int, StringComparison);
    public static bool ContainsAny(this Span<char>, string?);
    public static int IndexOfAny(this Span<char>, string?);
    public static int LastIndexOfAny(this Span<char>, string?);
    public static int LastIndexOfAny(this Span<char>, string?, int, int);
```
.

.
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.