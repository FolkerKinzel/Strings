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
public static bool Contains(this StringBuilder, char);
public static int IndexOf(this StringBuilder, char);
public static int IndexOf(this StringBuilder, char, int);
public static int IndexOf(this StringBuilder, char, int, int);
```
.
- New polyfill for .NET Framework 4.5 and .NET Standard 2.0:
```csharp
public static StringBuilder Append(this StringBuilder, StringBuilder?, int, int);
```

.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)

.
