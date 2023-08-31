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
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.