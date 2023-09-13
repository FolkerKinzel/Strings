- New static class `UrlEncoding`
- New enum `Base64ParserOptions`

.
- New extension methods:
```csharp
StringBuilder Replace(this StringBuilder, string, string?, int);
StringBuilder Replace(this StringBuilder, char, char, int);
StringBuilder AppendUrlEncoded(this StringBuilder, ReadOnlySpan<char>);
```
.
- New polyfill for the StringBuilder class (.NET Framework 4.5, .NET Standard 2.0):
```csharp
StringBuilder AppendUrlEncoded(this StringBuilder, string?);
```

.

> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.