# FolkerKinzel.Strings 4.4.0
## Package Release Notes

- New polyfills for the .NET Framework 4.5 and .NET Standard 2.0:
```csharp
    StringBuilder AppendJoin(this StringBuilder, char, params string?[]);
    StringBuilder AppendJoin(this StringBuilder, char, params object?[]);
    StringBuilder AppendJoin<T>(this StringBuilder, char, IEnumerable<T>);
    StringBuilder AppendJoin(this StringBuilder, string?, params string?[]);
    StringBuilder AppendJoin(this StringBuilder, string?, params object?[]);
    StringBuilder AppendJoin<T>(this StringBuilder, string?, IEnumerable<T>);

```

.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)


