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

            const string indent = "   ";

            Console.WriteLine($"{nameof(s1)}: {s1}");
            Console.WriteLine($"{nameof(s2)}: {s2}");
            Console.WriteLine($"{nameof(s3)}: {s3}");
            Console.WriteLine();

            // The extension method GetStableHashCode() produces identical Int32 hash codes for identical
            // Char sequences everytime it is called - even on String, StringBuilder or ReadOnlySpan<char>:
            Console.WriteLine("String-Hashcodes Ordinal:");
            Console.WriteLine($"{indent}{nameof(s1)}: {s1.GetStableHashCode(HashType.Ordinal):X8}");
            Console.WriteLine($"{indent}{nameof(s2)}: {s2.GetStableHashCode(HashType.Ordinal):X8}");
            Console.WriteLine($"{indent}{nameof(s3)}: {s3.GetStableHashCode(HashType.Ordinal):X8}");

            var sb = new StringBuilder();
            Console.WriteLine("StringBuilder-Hashcodes OrdinalIgnoreCase:");
            _ = sb.Append(s1);
            Console.WriteLine($"{indent}{nameof(s1)}: {sb.GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");
            _ = sb.Clear().Append(s2);
            Console.WriteLine($"{indent}{nameof(s2)}: {sb.GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");
            _ = sb.Clear().Append(s3);
            Console.WriteLine($"{indent}{nameof(s3)}: {sb.GetStableHashCode(HashType.OrdinalIgnoreCase):X8}");

            Console.WriteLine("ReadOnlySpan<char>-Hashcodes AlphanumericIgnoreCase:");
            Console.WriteLine($"{indent}{nameof(s1)}: {s1.AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
            Console.WriteLine($"{indent}{nameof(s2)}: {s2.AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
            Console.WriteLine($"{indent}{nameof(s3)}: {s3.AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase):X8}");
        }
    }
}

/*
Console Output:

s1: Hello Folker!
s2: HELLO FOLKER!
s3: &: !heL##Lof OLker *

String-Hashcodes Ordinal:
   s1: A31FA6EC
   s2: 1BBFB34C
   s3: 364D7CD9
StringBuilder-Hashcodes OrdinalIgnoreCase:
   s1: 1BBFB34C
   s2: 1BBFB34C
   s3: 12EF7A32
ReadOnlySpan<char>-Hashcodes AlphanumericIgnoreCase:
   s1: C672C38C
   s2: C672C38C
   s3: C672C38C
*/
