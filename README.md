# FolkerKinzel.Strings
[![NuGet](https://img.shields.io/nuget/v/FolkerKinzel.Strings)](https://www.nuget.org/packages/FolkerKinzel.Strings/)
[![GitHub](https://img.shields.io/github/license/FolkerKinzel/Strings)](https://github.com/FolkerKinzel/Strings/blob/master/LICENSE)
[![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/badges/StandWithUkraine.svg)](https://stand-with-ukraine.pp.ua)

[Project Reference](https://folkerkinzel.github.io/Strings/reference/)

.NET library that contains extension methods and helper classes for character-based data types.

Very high code coverage of the unit tests (100% line and branch) and the consistent avoidance of unsafe code blocks are main design 
principles of this library.

## Content:
- Extension methods that help to write easier and cleaner code. Many of them are "Syntactic Sugar" that calls existing Framework methods and will (hopefully) be inlined. Some other fill gaps of the Framework.
- Extension methods that act as polyfills in order to make it easier to support older framework versions in Multi Targeting Projects. [(See the complete list.)](https://github.com/FolkerKinzel/Strings/blob/master/src/FolkerKinzel.Strings/md/Polyfills.md)
- Extension methods that return identical `Int32` hashcodes for identical `Char` sequences each time the program runs. These hashcodes are a slim alternative to larger hash algorithms, which is suitable for hashing short strings that are not used in a security-critical context.
- Useful helpers to work with character sets and encodings.

## Usage:
- Simply install the [nuget package](https://www.nuget.org/packages/FolkerKinzel.Strings), publish the `FolkerKinzel.Strings` namespace
 and enjoy a lot more functionality for character-based .NET types.

&nbsp;

[Version History](https://github.com/FolkerKinzel/Strings/releases)

