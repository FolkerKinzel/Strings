# FolkerKinzel.Strings 3.1.0-beta.1
## Package Release Notes

- Additional overloads for TextEncodingConverter.GetEncoding:
```csharp
public static Encoding GetEncoding(string?, EncoderFallback, DecoderFallback);
public static Encoding GetEncoding(int)
public static Encoding GetEncoding(int, EncoderFallback, DecoderFallback);
```
.
- New extension methods for the `String` class:
```csharp
public static bool ContainsWhiteSpace(this string? s);
public static bool ContainsAny(this string, char, char);
public static bool ContainsAny(this string, char, char, char);
public static bool ContainsAny(this string, ReadOnlySpan<char>);
public static bool ContainsAny(this string, char[]);
public static int IndexOfAny(this string, ReadOnlySpan<char>, int, int);
public static int LastIndexOfAny(this string, ReadOnlySpan<char>, int, int)
```
.
- New extension methods for the `StringBuilder` Class:
```csharp
public static bool Contains(this StringBuilder, char);
public static int IndexOf(this StringBuilder, char);
public static int IndexOf(this StringBuilder, char, int);
public static int IndexOf(this StringBuilder, char, int, int);
public static int LastIndexOf(this StringBuilder, char)
public static int LastIndexOf(this StringBuilder, char, int)
public static int LastIndexOf(this StringBuilder, char, int, int)
```
.

- New extension methods for the `ReadOnlySpan<Char>` structure:
```csharp
public static bool ContainsAny(this ReadOnlySpan<char>, char, char );
public static bool ContainsAny(this ReadOnlySpan<char>, char, char, char );
public static int IndexOfAny (this ReadOnlySpan<char>, ReadOnlySpan<char>);
public static int LastIndexOfAny (this ReadOnlySpan<char>, ReadOnlySpan<char>);
public static bool ContainsWhiteSpace(this ReadOnlySpan<char> span)
```

.
- New polyfill for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
public static StringBuilder Append(this StringBuilder, StringBuilder?, int, int);
```

.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
