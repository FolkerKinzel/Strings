﻿# FolkerKinzel.Strings

## Roadmap
### 9.4.0
- [x] Implement as polyfill for NET461 and NETSTANDARD2_0:
```csharp
    static void TextWriterPolyfillExtension.Write(this TextWriter, ReadOnlySpan<char>);
    static void TextWriterPolyfillExtension.WriteLine(this TextWriter, ReadOnlySpan<char>);
```
AND use it in `FolkerKinzel.CsvTools`
### 9.2.1

- [x] Make a .NET 9.0 version of the package
- [x] Change `ReadOnlySpanPolyfillExtension.EndsWith(this ReadOnlySpan<char>, char)` to not conflict with .NET 9.0
- [x] Change `ReadOnlySpanPolyfillExtension.StartsWith(this ReadOnlySpan<char>, char)` to not conflict with .NET 9.0


### 9.2.0
- [x] Replace .NET Framework 4.6.1 support with .NET Framework 4.6.2 support
- [x] Dependency updates

### 9.1.0
- [x] Implement `string UrlEncoding.Encode(ReadOnlySpan<byte>)`
- [x] Implement `string UrlEncoding.Encode(ReadOnlySpan<char>)`
- [x] Implement `string UrlEncoding.Encode(string)`
- [x] Implement polyfills for .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
     SpanLineEnumeratorPolyfill EnumerateLines(this ReadOnlySpan<char>);
```
- [x] Implement polyfills for .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
    int CommonPrefixLength(this ReadOnlySpan<char>, ReadOnlySpan<char>);
    int CommonPrefixLength(this ReadOnlySpan<char>, ReadOnlySpan<char>, IEqualityComparer<char>?);
    int CommonPrefixLength(this Span<char>, ReadOnlySpan<char>);
    int CommonPrefixLength(this Span<char>, ReadOnlySpan<char>, IEqualityComparer<char>?);
```
- [x] Implement polyfills for .NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
    int IndexOfAnyInRange(this ReadOnlySpan<char>, char, char);
    int IndexOfAnyInRange(this Span<char>, char, char);
    int IndexOfAnyExceptInRange(this ReadOnlySpan<char>, char, char);
    int IndexOfAnyExceptInRange(this Span<char>, char, char);
    int LastIndexOfAnyInRange(this ReadOnlySpan<char>, char, char);
    int LastIndexOfAnyInRange(this Span<char>, char, char);
    int LastIndexOfAnyExceptInRange(this ReadOnlySpan<char>, char, char);
    int LastIndexOfAnyExceptInRange(this Span<char>, char, char);
    bool ContainsAnyInRange(this ReadOnlySpan<char>, char, char);
    bool ContainsAnyInRange(this Span<char>, char, char);
```

- [x] Implement polyfills for .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
    int CommonPrefixLength(this ReadOnlySpan<char>, string?);
    int CommonPrefixLength(this ReadOnlySpan<char>, string?, IEqualityComparer<char>?);
    int CommonPrefixLength(this Span<char>, string?);
    int CommonPrefixLength(this Span<char>, string?, IEqualityComparer<char>?);
```

### 9.0.0
-[x] Fix an issue

### 8.1.0
- [x] Refactor ReadOnlySpanExtension.ContainsNewLine to use ReadOnlySpan.ContainsAny or SearchValues
- [x] Refactor SpanExtension.ContainsNewLine to use ReadOnlySpan.ContainsAny or SearchValues
- [x] Refactor StringBuilderExtension.ContainsNewLine to use ReadOnlySpan.ContainsNewLine
- [x] Refactor StringBuilderExtension.IndexOf
- [x] Refactor StringBuilderExtension.LastIndexOf
- [x] Refactor StringBuilderExtension.GetPersistentHashCode to use the `PersistentStringHash` struct
- [x] Refactor StringBuilderExtension.ContainsWhiteSpace to use the ReadOnlySpan method
- [x] Refactor StringBuilderExtension.ContainsNonAscii to use the ReadOnlySpan.IsAscii method
- [x] Refactor StringBuilderExtension.ReplaceLineEndings
- [x] Refactor StringBuilderExtension.ReplaceWhiteSpaceWith
- [x] Refactor StringBuilderExtension.ToLowerInvariant
- [x] Refactor StringBuilderExtension.ToUpperInvariant
- [x] Refactor StringBuilderExtension.Trim
- [x] Refactor StringBuilderExtension.TrimStart
- [x] Refactor StringBuilderExtension.TrimEnd
- [x] Refactor StringPolyfillExtension.ReplaceLineEndings
- [x] Refactor.StringExtension.ReplaceWhiteSpaceWith
- [x] Implement `PersistentStringHash` struct

### 7.0.1
- [x] Remove `IsAsciiLowerCaseLetter(this char)`
- [x] Remove `IsAsciiUpperCaseLetter(this char)`
- [x] Remove `IsDecimalDigit(this char)`
- [x] Remove `IsHexDigit(this char)`
- [x] Remove German resource files

### 7.0.0
- [x] Mark `IsAsciiLowerCaseLetter(this char)` as obsolete error
- [x] Mark `IsAsciiUpperCaseLetter(this char)` as obsolete error
- [x] Mark `IsDecimalDigit(this char)` as obsolete error
- [x] Mark `IsHexDigit(this char)` as obsolete error

### 5.4.0
- [ ] `StringBuilder.EscapeUri(int start, int length)`
- [ ] `StringBuilder.UnEscapeUri(int start, int length, string? charSet = null)`
- [ ] `int FileInfo.GetCodePage()`
- [ ] `ReadOnlySpan<byte>.GetCodePage()`
 
### 5.3.0
- [x] `StringBuilder.Contains(char, int)`
- [x] `StringBuilder.Contains(char, int, int)`

### 5.2.0
- [x] `Stream.IsUtf8(int, bool);`
- [x] `Stream.IsValidUtf8(int, bool);`
- [x] `FileInfo.IsUtf8(int);`
- [x] `FileInfo.IsValidUtf8(int);`
- [x] `DecoderValidationFallback`

### 5.1.0
- [x] Polyfill for the `ReadOnlySpan<Char>` Struct (.NET Framework 4.5, .NET Standard 2.0):
```csharp
bool Equals(this ReadOnlySpan<char>, string?, StringComparison);
```

### 5.0.0
- [x] Add .NET 7 support.
- [x] Dependency update.
- [x] Change the behavior of the methods `TextEncodingConverter.GetEncoding(int)` and `TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback)` to treat the argument `0` as an invalid value.
- [x] The methods `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` should accept encoding names that contain `SPACE` characters.
- [x] Give the `TextEncodingConverter.GetEncoding(...)` methods an optional parameter that allows to choose whether in case of a failed conversion the fallback value is returned or an exception is thrown.
- [x] Rename the parameter `name` in `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` to `encodingWebName`.
- [x] Rename the parameter `codepage` in `TextEncodingConverter.GetEncoding(int)` and `TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback)` to `codePage`.
- [x] Implement:
```csharp
static bool TextEncodingConverter.TryGetEncoding(string?, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(string?, EncoderFallback, DecoderFallback, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(int, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(int, EncoderFallback, DecoderFallback, out Encoding?);
```

### 4.4.0
- [x] `StringBuilder.AppendJoin()` - Polyfills

### 4.3.0
- [x] `StringBuilder.AppendLine(ReadOnlyMemory<Char>)`
- [x] `StringBuilder.AppendLine(ReadOnlySpan<Char>)`

### 4.2.0
- [x] Polyfill `bool Contains(this ReadOnlySpan<char>, string?, StringComparison)`

### 4.1.0
- [x] Dependency update.
- [x] Remove `StringCreator`

 ### 4.0.0
- [x] .NET 6.0 support.
- [x] Replace the `StringCreator` class with a `StaticStringMethod` class.
- [x] Make the usage of the `StringCreator` class an Obsolete error.
- [x] Implement `StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>)`
- [x] Implement `StaticStringMethod.Concat(ReadOnlySpan<char>, ReadOnlySpan<char>, ReadOnlySpan<char>)`
- [x] Implement `String.ReplaceLineEndings()` poyfill.
- [x] Implement `String.ReplaceLineEndings(string)` poyfill.
- [x] Implement `StringBuilder.ReplaceLineEndings()`.
- [x] Implement `StringBuilder.ReplaceLineEndings(string)`.
- [x] Let `StringBuilder.NormalizeNewLinesTo(ReadOnlySpan<char> newLine)` give an obsolete warning.
- [x] Let `StringBuilder.NormalizeNewLinesTo(string? newLine)` give an obsolete warning.
- [x] Let `String.NormalizeNewLinesTo(ReadOnlySpan<char> newLine)` give an  obsolete warning.
- [x] Let `String.NormalizeNewLinesTo(string? newLine)` give an obsolete warning.

### 3.3.0
- [x] Implement `ReadOnlySpan<Char>.LastIndexOf(ReadOnlySpan<Char>, Int32, Int32, StringComparison)`.
- [x] Polyfill `string StringCreator.Create<TState> (int, TState, System.Buffers.SpanAction<char,TState>)`
- [x] Implement bool `IsAsciiLowerCaseLetter(this char)`.
- [x] Implement bool `IsAsciiUpperCaseLetter(this char)`.
- [x] Implement bool `IsAsciiLetter(this char)`.

### 3.2.0
- [x] Remove obsolete stuff.
- [x] Wrap Uri.IsHexDigit(char), Uri.IsHexUpperChar(char), Uri.IsHexLowerChar(char) and the
 Char.IsXxx(char) methods with extension methods.
- [x] Implement char.IsDecimalDigit()
- [x] Implement char.IsBinaryDigit()
- [x] Implement char.IsNewLine()
- [x] Implement `TextEncodingConverter.GetCodePage(ReadOnlySpan<byte>, out int)`
- [x] Implement `ReadOnlySpan<Char>.LastIndexOfAny(ReadOnlySpan<Char>, int, int)` to avoid error 
prone calculating with the result when slicing the span before.
- [x] Implement `ReadOnlySpan<char>.StartsWith(char)` and `ReadOnlySpan<char>.EndsWith(char)`.
- [x] Implement `StringBuilder.StartsWith(char)` and `StringBuilder.EndsWith(char)`.
- [x] Implement `StringBuilder.ReplaceWhiteSpaceWith(ReadOnlySpan<Char>)`.
- [x] Implement `StringBuilder.ReplaceWhiteSpaceWith(ReadOnlySpan<Char>, int)`.
- [x] Implement `StringBuilder.ReplaceWhiteSpaceWith(ReadOnlySpan<Char>, int, int)`.
- [x] Implement `String.ContainsNewLine()`.
- [x] Implement `ReadOnlySpan<Char>.ContainsNewLine()`.
- [x] Implement `StringBuilder.ContainsNewLine()`.
- [x] Implement `String.NormalizeNewLinesWith(ReadOnlySpan<Char>)`.
- [x] Implement `StringBuilder.NormalizeNewLinesWith(ReadOnlySpan<Char>)`.

### 3.1.0
- [x] New overloads for TextEncodingConverter.GetEncoding
- [x] Additional extension methods and polyfills.

### 3.0.0
- [x] Move the Polyfills to the namespace FolkerKinzel.Strings.Polyfills.
- [x] Add new extension methods and polyfills.
- [x] Make the extension method classes partial.

### 2.1.0
- [x] Add IndexOf- and Contains-Polyfills. 

### 2.0.1
- [x] Cleanup: Remove obsolete symbols.

### 2.0.0
- [x] Add support for .NET 5.0.
- [x] End .NET Framework 4.0 support.
- [x] Rename the GetStableHashCode extension methods to GetPersistentHashCode.
- [x] Rename the StringBuilderExtensions class to StringBuilderExtension.
- [x] Rename the ReadOnlySpanExtensions class to ReadOnlySpanExtension.
- [x] Rename the StringExtensions class to StringExtension.
- [x] Remove redundant code.
- [x] Let GetPersistentHashCode throw an ArgumentException instead of an ArgumentOutOfRangeException 
when an undefined enum value is passed as argument.
- [x] Add a Trim extension method for StringBuilder.


.

