- New extension methods:
```csharp
byte[] GetBytes(this Encoding, ReadOnlySpan<char>);

StringBuilder AppendBase64Encoded(this StringBuilder,
                                  IEnumerable<byte>,
                                  Base64FormattingOptions);

StringBuilder AppendBase64Encoded(this StringBuilder,
                                  byte[],
                                  Base64FormattingOptions);

StringBuilder AppendBase64Encoded(this StringBuilder,
                                  ReadOnlySpan<byte>,
                                  Base64FormattingOptions);
```
.
- New polyfill for the Encoding Class (.NET Framework 4.5, .NET Standard 2.0)
```csharp
string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes);
```

.
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.