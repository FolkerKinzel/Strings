# FolkerKinzel.Strings 2.0.0
## Package Release Notes

- The .NET Framework 4.0 has been removed.
- .NET 5.0 support has been added.
- The `GetStableHashCode` extension methods have been renamed to `GetPersistentHashCode`
to make their intention more clear.
- Extension methods have been added, which simulate the several overloads of the String.Trim() 
method for the `StringBuilder` class. [(See the list of overloads.)](https://github.com/FolkerKinzel/Strings/blob/master/docs/PackageReleaseNotes/2.0.0/StringBuilderTrim.md)
- Extension methods, which act as Polyfills for .NET Framework 4.5,
.NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support
such older Framework versions in Multi Targeting Projects have been added.
[(See the complete list.)](https://github.com/FolkerKinzel/Strings/blob/master/docs/PackageReleaseNotes/2.0.0/Polyfills.md)
- The `StringBuilderExtensions` class has been renamed to `StringBuilderExtension`.
- The `ReadOnlySpanExtensions` class has been renamed to `ReadOnlySpanExtension`.
- The `StringExtensions` class has been renamed to `StringExtension`.
- The `GetPersistentHashCode(HashType)` extension methods throw an `ArgumentException` now instead of an `ArgumentOutOfRangeException` 
when an undefined enum value is passed as argument.
