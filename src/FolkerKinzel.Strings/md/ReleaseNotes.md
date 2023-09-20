- New extension methods:
```csharp
StringBuilder AppendUrlEncoded(this StringBuilder, IEnumerable<byte>?);
StringBuilder AppendUrlEncoded(this StringBuilder, byte[]?);
StringBuilder AppendUrlEncoded(this StringBuilder, ReadOnlySpan<byte>);
```
.
- New method in the `UrlEncoding` class:
```csharp
bool TryDecodeToBytes(ReadOnlySpan<char>, out byte[]?);
```
.
- Obsolete extension method:
```csharp
bool IsHexDigit(this char);
```
.
- The `StringBuilderExtension.AppendBase64` methods are less restrictive now and accept `null` as input.

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.