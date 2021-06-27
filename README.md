# FolkerKinzel.Strings
[![NuGet](https://img.shields.io/nuget/v/FolkerKinzel.Strings)](https://www.nuget.org/packages/FolkerKinzel.Strings/)
[![GitHub](https://img.shields.io/github/license/FolkerKinzel/Strings)](https://github.com/FolkerKinzel/Strings/blob/master/LICENSE)

.NET library, containing extension methods for String, 
StringBuilder and ReadOnlySpan&lt;Char&gt;.

## Content:
* Extension methods, which return persistable `Int32` hashcodes for 
`Char` sequences. - That means, the same
hashcode is returned for an identical `Char` sequence 
 everytime the program runs - even on String, StringBuilder or 
 ReadOnlySpan&lt;Char&gt;. The hashcodes can be specified to 
 hash the sequence ordinal, ordinal case insensitive or 
 alphanumeric case insensitive. The hashcodes produced by this 
 library are not equivalent to the hashcodes produced by 
 the .NET-Framework 4.0 `System.String` class (because they use roundshifting to keep 
 more information) and they are not intended to be used for security 
 critical purposes (such as hashing passwords). [(See example.)]()
* Extension methods, which simulate the several overloads of the String.Trim() 
method for the `StringBuilder` class. [(See the list overloads.)]()
* Extension methods, which act as Polyfills for .NET Framework 4.5,
.NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support
such older Framework versions in Multi Targeting Projects. [(See the complete list.)]()

## Project Reference:
A detailed project reference is available in English and German:

* [Project Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/1.2.0/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch)](https://github.com/FolkerKinzel/Strings/blob/master/ProjectReference/1.2.0/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file
>  right click on the file icon, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.
