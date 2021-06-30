# FolkerKinzel.Strings

## Roadmap

### 2.0.0
- [x] Add support for .NET 5.0.
    
- [x] End .NET Framework 4.0 support.

- [x] Rename the GetStableHashCode extension methods to GetPersistentHashCode.

- [x] Rename the StringBuilderExtensions class to StringBuilderExtension.

- [x] Rename the ReadOnlySpanExtensions class to ReadOnlySpanExtension.

- [x] Rename the StringExtensions class to StringExtension.

- [x] Remove redundant code.

- [x] Let GetPersistentHashCode throw an ArgumentException instead of an ArgumentOutOfRangeException 
when an undefined enum value is passed as argument.

- [x] Add a Trim extension method for StringBuilder.

### 2.0.1
- [ ] Cleanup: Remove obsolete symbols.

### 2.1.0
- [ ] Add IndexOf- and Contains-Polyfills. 