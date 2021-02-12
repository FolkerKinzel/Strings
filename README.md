# Strings
[![NuGet](https://img.shields.io/nuget/v/FolkerKinzel.Strings)](https://www.nuget.org/packages/FolkerKinzel.Strings/)


.NET library, containing extension methods for System.String and System.Text.StringBuilder.

##### Content:
* Extension methods, that produce constant integer hash codes for constant strings (or constant StringBuilder content). 
The hash codes can be specified to hash the string ordinal, ordinal case insensitive or alphanumeric case insensitiv.
The hash codes produced by this library are not equivalent to the hash codes produced by .NET-Framework 4.0 because they 
use roundshifting to keep more
information. Don't use constant hash codes for security critical purposes!

```
nuget Package Manager:
PM> Install-Package FolkerKinzel.Strings -Version 1.1.0

.NET CLI:
> dotnet add package FolkerKinzel.Strings --version 1.1.0

PackageReference (Visual Studio Project File):
<PackageReference Include="FolkerKinzel.Strings" Version="1.1.0" />

Paket CLI:
> paket add FolkerKinzel.Strings --version 1.1.0
```

* [Download Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/FolkerKinzel.Strings.Reference.en/Help/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch) herunterladen](https://github.com/FolkerKinzel/Strings/blob/master/FolkerKinzel.Strings.Doku.de/Help/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file
>  right click on it, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.

