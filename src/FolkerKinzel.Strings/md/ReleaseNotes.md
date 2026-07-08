- Static methods for the `PersistentStringHash` structure:
```csharp
int PersistentStringHash.From(string? s, HashType hashType); //.NET Standard 2.0 and .NET Framework only
int PersistentStringHash.From(ReadOnlySpan<char>, HashType);
int PersistentStringHash.From(StringBuilder, HashType);
int PersistentStringHash.From(StringBuilder, int, HashType);
int PersistentStringHash.From(StringBuilder, int, int, HashType);
```
- `StringExtension.GetPersistentHashCode(this string?, HashType)` is less restrictive now and accepts `null` as input.
- Dependency updates

&nbsp;
> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and **check the "Allow" checkbox** - if it is present - in the lower right corner of the General tab in the Properties dialog.