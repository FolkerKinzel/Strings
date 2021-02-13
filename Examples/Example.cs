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

            // Different HashTypes may produce different hashcodes on the same Char sequence
            // an must therefore not be mixed:
            Console.WriteLine("Same String - different HashTypes:");
            Console.WriteLine(
                $"{s1.GetStableHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{s1.GetStableHashCode(HashType.OrdinalIgnoreCase),10:X08}");
            Console.WriteLine(
                $"{s1.GetStableHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");
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
Same String - different HashTypes:
  A31FA6EC
  1BBFB34C
  C672C38C
.
*/
