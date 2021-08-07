using System;
using System.Text;
using FolkerKinzel.Strings;
using System.Linq;
using Baz;

#if !NETCOREAPP3_1
using FolkerKinzel.Strings.Polyfills;
#endif

namespace LibraryTesters
{
    class Program
    {
        static void Main()
        {
            string test = "Test";

            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder(test);

            _ = sb1.Append(sb2, -17, sb2.Length);

            _ = test.Trim(stackalloc char[] { ',', ';' });
            _ = test.TrimStart(stackalloc char[] { ',', ';' });
            _ = test.TrimEnd(stackalloc char[] { ',', ';' });

            _ = test.Contains('e');

            _ = test.AsSpan().Contains('e');


            _ = test.Contains('e', StringComparison.OrdinalIgnoreCase);


            _ = test.StartsWith('T');

            _ = test.EndsWith('T');

            _ = test.IndexOf('e', StringComparison.Ordinal);


            _ = test.Split('e');

            _ = test.Split('e', 2);

//#if !NETCOREAPP3_1
            _ = test.AsMemory().Trim();

            _ = test.AsMemory().TrimStart();

            _ = test.AsMemory().TrimEnd();
            //#endif

            var sb = new StringBuilder();

            _ = sb.Append("Test".AsSpan());

            //MemoryExtensions.Trim(test.AsMemory());

            _ = TextEncodingConverter.GetEncoding("iso-8859-1");

            _ = "c".IsAscii();

            _ = "test".IsAscii();

            _ = "test".AsSpan().IsAscii();

            _ = sb.ContainsNonAscii();

            _ = sb.ContainsNonAscii(0);

            _ = sb.ContainsNonAscii(0,0);

            _ = sb.ToUpperInvariant();
            _ = sb.ToUpperInvariant(0);
            _ = sb.ToUpperInvariant(0, 0);

            _ = sb.ToLowerInvariant();
            _ = sb.ToLowerInvariant(0);
            _ = sb.ToLowerInvariant(0, 0);

            _ = test.AsSpan().ContainsAny(ReadOnlySpan<char>.Empty);

             _ = test.AsSpan().GetTrimmedLength();

            _ = test.AsSpan().GetTrimmedStart();

            test.Foo();
        }
    }
}
