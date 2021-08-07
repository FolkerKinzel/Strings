# FolkerKinzel.Strings 3.1.0
## Package Release Notes

- Additional overloads for TextEncodingConverter.GetEncoding:
```csharp
public static Encoding GetEncoding(string?, EncoderFallback, DecoderFallback);
public static Encoding GetEncoding(int)
public static Encoding GetEncoding(int, EncoderFallback, DecoderFallback);
```
.
- New extension methods for the `StringBuilder` Class
```csharp
public static bool Contains(this StringBuilder builder, char value);
public static int IndexOf(this StringBuilder builder, char value);
public static int IndexOf(this StringBuilder builder, char value, int startIndex);
public static int IndexOf(this StringBuilder builder, char value, int startIndex, int length);
```

.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
