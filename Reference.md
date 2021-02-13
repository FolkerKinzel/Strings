# Strings
.NET library, containing extension methods for System.String, System.Text.StringBuilder and ReadOnlySpan&lt;char&gt;.

##### Content:
* Extension methods, that produce identical (and therefore persistable) Int32 hashcodes for identical Char sequences everytime they are called - even on String, StringBuilder or ReadOnlySpan&lt;Char&gt;. The hashcodes can be specified to hash the sequence ordinal, ordinal case insensitive or alphanumeric case insensitive. The hashcodes produced by this library are not equivalent to the hashcodes produced by .NET-Framework 4.0, because they use roundshifting to keep more information. Don't use these hashcodes for security critical purposes (such as hashing passwords)!


* [Download Reference (English)](https://github.com/FolkerKinzel/Strings/blob/master/FolkerKinzel.Strings.Reference.en/Help/FolkerKinzel.Strings.Reference.en.chm)

* [Projektdokumentation (Deutsch) herunterladen](https://github.com/FolkerKinzel/Strings/blob/master/FolkerKinzel.Strings.Doku.de/Help/FolkerKinzel.Strings.Doku.de.chm)

> IMPORTANT: On some systems, the content of the CHM file is blocked. Before opening the file, right click on it, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.

#### Example:
```csharp
using System;
using System.Text;
using FolkerKinzel.Strings;

namespace Examples
{
    public static class ShortExample
    {
        public static void CreateConstantStringHashes()
        {
            Console.WriteLine("Ordinal:");
            const string s1 = "Hello Folker!";
            Console.WriteLine(
                $"{s1.GetStableHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{new StringBuilder().Append(s1).GetStableHashCode(HashType.Ordinal),10:X08}");

            Console.WriteLine("OrdinalIgnoreCase:");
            Console.WriteLine(
                $"{"HELLO FOLKER!".GetStableHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{"Hello Folker!".AsSpan().GetStableHashCode(HashType.OrdinalIgnoreCase),10:X08}");

            Console.WriteLine("AlphaNumericIgnoreCase:");
            Console.WriteLine(
                $"{"HELLO FOLKER!".AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");
            Console.WriteLine(
                $"{new StringBuilder().Append("&: !heL##Lof OLker *").GetStableHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");
        }
    }
}
/*
Output:

Ordinal:
  A31FA6EC
  A31FA6EC
OrdinalIgnoreCase:
  1BBFB34C
  1BBFB34C
AlphaNumericIgnoreCase:
  C672C38C
  C672C38C
*/
```