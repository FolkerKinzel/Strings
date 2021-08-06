# FolkerKinzel.Strings
.NET library, containing extension methods for String, StringBuilder, ReadOnlySpan&lt;Char&gt; and ReadOnlyMemory&lt;Char&gt;.

## Content:
* Extension methods for String, StringBuilder, ReadOnlySpan&lt;Char&gt; and ReadOnlyMemory&lt;Char&gt;, which act as Polyfills for .NET Framework 4.5, .NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support such older Framework versions in Multi Targeting Projects.
* Extension methods, which simulate several useful methods of the `String` class for the `StringBuilder` class.
* Extension methods, which return identical `Int32` hashcodes for identical `Char` sequences each time the program runs. These hashcodes are a slim alternative to larger hash algorithms that is suitable for hashing short strings, which are not used in a security-critical context.
* Other useful helpers for the work with charsets and encodings.

## Project Reference:
A detailed project reference is available in English and German:

* [Project Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.0.0/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/3.0.0/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file
>  right click on the file icon, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.


