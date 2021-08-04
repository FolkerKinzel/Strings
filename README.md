# FolkerKinzel.Strings
[![NuGet](https://img.shields.io/nuget/v/FolkerKinzel.Strings)](https://www.nuget.org/packages/FolkerKinzel.Strings/)
[![GitHub](https://img.shields.io/github/license/FolkerKinzel/Strings)](https://github.com/FolkerKinzel/Strings/blob/master/LICENSE)

.NET library, containing extension methods for String, 
StringBuilder, ReadOnlySpan&lt;Char&gt; and ReadOnlyMemory&lt;Char&gt;.

## Content:
* Extension methods, which act as Polyfills for .NET Framework 4.5,
.NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support
such older Framework versions in Multi Targeting Projects. [(See the complete list.)](https://github.com/FolkerKinzel/Strings/blob/master/docs/PackageReleaseNotes/3.0.0-beta/Polyfills.md)
* Extension methods, which simulate the several overloads of the String.Trim() 
method for the `StringBuilder` class. [(See the list of overloads.)](https://github.com/FolkerKinzel/Strings/blob/master/docs/PackageReleaseNotes/3.0.0-beta/StringBuilderTrim.md)
* Extension methods, which return identical `Int32` hashcodes for 
identical `Char` sequences each time the program runs. These hashcodes
are a slim alternative to larger hash algorithms
that is suitable for hashing very short strings 
that are not used in a security-critical context. [(Read more.)](https://github.com/FolkerKinzel/Strings/blob/master/docs/PackageReleaseNotes/2.0.0/PersistableHashCodeExample.md)
* Other useful helpers for the work with charsets and encodings.

## Project Reference:
A detailed project reference is available in English and German:

* [Project Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.0.0-beta.2/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.0.0-beta.2/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file
>  right click on the file icon, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.
