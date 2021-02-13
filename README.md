# Strings
[![NuGet](https://img.shields.io/nuget/v/FolkerKinzel.Strings)](https://www.nuget.org/packages/FolkerKinzel.Strings/)


.NET library, containing extension methods for System.String, System.Text.StringBuilder and ReadOnlySpan&lt;char&gt;.

##### Content:
* Extension methods, that produce identical Int32 hash codes for identical char sequences everytime they are called - 
even on String, StringBuilder or ReadOnlySpan&lt;char&gt;. 
The hash codes can be specified to hash the sequence ordinal, ordinal case insensitive or alphanumeric case insensitive.
The hash codes produced by this library are not equivalent to the hash codes produced by .NET-Framework 4.0, because they 
use roundshifting to keep more
information. Don't use these hash codes for security critical purposes like, e.g., passwords!

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

#### Example:
```csharp
using System;
using System.Text;
using FolkerKinzel.Strings;

namespace Examples
{
    public static class Example
    {
        public static void CreateConstantStringHashes()
        {
            const string s1 = "Hello Folker!";
            const string s2 = "HELLO FOLKER!";
            const string s3 = "&: !heL##Lof OLker *";

            const string ind = "  ";

            Console.WriteLine($"{nameof(s1)}: {s1}");
            Console.WriteLine($"{nameof(s2)}: {s2}");
            Console.WriteLine($"{nameof(s3)}: {s3}");
            Console.WriteLine();

            // The extension method GetStableHashCode() produces identical Int32 hash codes for identical
            // Char sequences everytime it is called - even on String, StringBuilder or ReadOnlySpan<char>:
            Console.WriteLine("Ordinal:");
            Console.WriteLine($"{ind}{nameof(s1)}: {s1.GetStableHashCode(HashType.Ordinal):X8}");
            Console.WriteLine($"{ind}{nameof(s2)}: {s2.GetStableHashCode(HashType.Ordinal):X8}");
            Console.WriteLine($"{ind}{nameof(s3)}: {s3.GetStableHashCode(HashType.Ordinal):X8}");

            Console.WriteLine("OrdinalIgnoreCase:");
            Console.WriteLine(
                $"{ind}{nameof(s1)}: {s1.AsSpan().GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");
            Console.WriteLine(
                $"{ind}{nameof(s2)}: {s2.GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");
            Console.WriteLine(
                $"{ind}{nameof(s3)}: {s3.GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");

            Console.WriteLine("AlphanumericIgnoreCase:");
            Console.WriteLine(
                $"{ind}{nameof(s1)}: {s1.AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
            Console.WriteLine(
                $"{ind}{nameof(s2)}: {new StringBuilder().Append(s2).GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
            Console.WriteLine(
                $"{ind}{nameof(s3)}: {s3.GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
        }
    }
}

/*
Console Output:

s1: Hello Folker!
s2: HELLO FOLKER!
s3: &: !heL##Lof OLker *

Ordinal:
  s1: A31FA6EC
  s2: 1BBFB34C
  s3: 364D7CD9
OrdinalIgnoreCase:
  s1: 1BBFB34C
  s2: 1BBFB34C
  s3: 12EF7A32
AlphanumericIgnoreCase:
  s1: C672C38C
  s2: C672C38C
  s3: C672C38C
*/
```
