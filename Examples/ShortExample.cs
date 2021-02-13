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