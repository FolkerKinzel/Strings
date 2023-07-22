[![GitHub](https://img.shields.io/github/license/FolkerKinzel/Strings)](https://github.com/FolkerKinzel/Strings/blob/master/LICENSE)

[Project Reference and Release Notes](https://github.com/FolkerKinzel/Strings/releases/tag/v5.3.0)
- Extension methods that help to write easier and cleaner code. Many of them are "Syntactic Sugar" that calls existing Framework methods and will (hopefully) be inlined. Some other fill gaps of the Framework.
- Extension methods which act as Polyfills for .NET 5.0, .NET Standard 2.1, .NET Standard 2.0, and .NET Framework 4.5 in order to make it easier to support such older Framework versions in Multi Targeting Projects. [(See the complete list.)](https://github.com/FolkerKinzel/Strings/blob/master/src/FolkerKinzel.Strings/md/Polyfills.md)
- Extension methods which return identical `Int32` hashcodes for identical `Char` sequences each time the program runs. These hashcodes are a slim alternative to larger hash algorithms, which is suitable for hashing short strings that are not used in a security-critical context.
- Useful helpers to work with character sets and encodings.

```csharp
// Publish this namespace to have useful extension methods,
// which enrich the existing methods of your runtime:
using FolkerKinzel.Strings;

// Publish this namespace for .NET Framework or .NET Standard
// build targets to have polyfills for .NET 6.0 methods.
// (It's not recommended to publish this namespace for 
// .NET Core 3.1 build targets because some of the polyfills might produce
// conflicts with extension methods from System.MemoryExtensions.)
#if !NETCOREAPP3_1
using FolkerKinzel.Strings.Polyfills;
#endif
```
.

- [Version History](https://github.com/FolkerKinzel/Strings/releases)



