# FolkerKinzel.Strings

## Roadmap

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

### 2.0.1
- [x] Cleanup: Remove obsolete symbols.

### 2.1.0
- [x] Add IndexOf- and Contains-Polyfills. 

### 3.0.0
- [x] Move the Polyfills to the namespace FolkerKinzel.Strings.Polyfills.
- [x] Add new extension methods and polyfills.
- [x] Make the extension method classes partial.

### 3.1.0
- [x] New overloads for TextEncodingConverter.GetEncoding
- [x] Additional extension methods and polyfills.

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

### 3.3.0
- [x] Implement `ReadOnlySpan<Char>.LastIndexOf(ReadOnlySpan<Char>, Int32, Int32, StringComparison)`.
- [ ] Implement `String.LastIndexOf(ReadOnlySpan<Char>, Int32, Int32, StringComparison)`.
- [x] Polyfill `string StringHelper.Create<TState> (int, TState, System.Buffers.SpanAction<char,TState>)`

