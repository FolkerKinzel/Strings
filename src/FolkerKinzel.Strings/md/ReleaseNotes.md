- New Extension Methods for `System.IO.Stream` and `System.IO.FileInfo`:
```csharp
bool IsUtf8(this Stream, int, bool);
bool IsUtf8Valid(this Stream, int, bool);
bool IsUtf8(this FileInfo, int);
bool IsUtf8Valid(this FileInfo, int);
```
- New helper class to detect text decoding errors without having to catch Exceptions:
```csharp
public sealed class DecoderValidationFallback : DecoderFallback
```

.
> Project reference: On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.