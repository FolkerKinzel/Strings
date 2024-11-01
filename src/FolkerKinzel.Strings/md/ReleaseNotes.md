- New methods of the `UrlEncoding` class:
```csharp
string UrlEncoding.Encode(ReadOnlySpan<byte>);
string UrlEncoding.Encode(ReadOnlySpan<char>);
string UrlEncoding.Encode(string);
```

&nbsp;
- Polyfill for .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
SpanLineEnumeratorPolyfill EnumerateLines(this ReadOnlySpan<char>);
```

&nbsp;
- Polyfills for .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
int CommonPrefixLength(this ReadOnlySpan<char>, ReadOnlySpan<char>);
int CommonPrefixLength(this ReadOnlySpan<char>, ReadOnlySpan<char>, IEqualityComparer<char>?);
int CommonPrefixLength(this Span<char>, ReadOnlySpan<char>);
int CommonPrefixLength(this Span<char>, ReadOnlySpan<char>, IEqualityComparer<char>?);
```

&nbsp;
- Polyfills for .NET 7.0, .NET 6.0, .NET 5.0, .NET Core 3.1, .NET Standard 2.1, .NET Standard 2.0, .NET Framework 4.6.1:
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

&nbsp;
- Polyfills for .NET Standard 2.0, .NET Framework 4.6.1:
```csharp
int CommonPrefixLength(this ReadOnlySpan<char>, string?);
int CommonPrefixLength(this ReadOnlySpan<char>, string?, IEqualityComparer<char>?);
int CommonPrefixLength(this Span<char>, string?);
int CommonPrefixLength(this Span<char>, string?, IEqualityComparer<char>?);
```

&nbsp;
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.