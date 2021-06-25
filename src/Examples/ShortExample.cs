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
                $"{s1.GetPersistentHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{new StringBuilder().Append(s1).GetPersistentHashCode(HashType.Ordinal),10:X08}");

            Console.WriteLine("OrdinalIgnoreCase:");
            Console.WriteLine(
                $"{"HELLO FOLKER!".GetPersistentHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{"Hello Folker!".AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase),10:X08}");

            Console.WriteLine("AlphaNumericIgnoreCase:");
            Console.WriteLine(
                $"{"HELLO FOLKER!".AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");
            Console.WriteLine(
                $"{new StringBuilder().Append("&: !heL##Lof OLker *").GetPersistentHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");

            // Different HashTypes may produce different hashcodes on the same Char sequence
            // an must therefore not be mixed:
            Console.WriteLine("Same String - different HashTypes:");
            Console.WriteLine(
                $"{s1.GetPersistentHashCode(HashType.Ordinal),10:X08}");
            Console.WriteLine(
                $"{s1.GetPersistentHashCode(HashType.OrdinalIgnoreCase),10:X08}");
            Console.WriteLine(
                $"{s1.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase),10:X08}");
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
Same String - different HashTypes:
  A31FA6EC
  1BBFB34C
  C672C38C
*/