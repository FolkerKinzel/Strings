
[![GitHub](https://img.shields.io/github/license/FolkerKinzel/Strings)](https://github.com/FolkerKinzel/Strings/blob/master/LICENSE)

* Extension methods, which help to write easier and cleaner code. Most of them are "Syntactic Sugar" that calls existing Framework methods and will (hopefully) be inlined. Some other fill gaps of the Framework.
* Extension methods, which act as Polyfills for .NET Framework 4.5, .NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support such older Framework versions in Multi Targeting Projects.
* Extension methods, which return identical `Int32` hashcodes for identical `Char` sequences each time the program runs. These hashcodes are a slim alternative to larger hash algorithms that is suitable for hashing short strings, which are not used in a security-critical context.
* Useful helpers for the work with charsets and encodings.

```csharp
// Publish this namespace to have useful extension methods,
// which enrich the existing methods of your runtime:
using FolkerKinzel.Strings;

// Publish this namespace for .NET Framework or .NET Standard
// build targets to have polyfills for .NET 5.0 methods.
// (It is not generally recommended to publish this namespace for 
// .NET Core build targets because some of the polyfills might produce
// conflicts with extension methods from System.MemoryExtensions.)
using FolkerKinzel.Strings.Polyfills;
```
.

A detailed project reference is available in English and German:

* [Project Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.2.0-beta.1/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.2.0-beta.1/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file
>  right click on the file icon, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.
.
- [Version History](https://github.com/FolkerKinzel/Strings/releases)



