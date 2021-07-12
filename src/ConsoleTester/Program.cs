using System;
using FolkerKinzel.Strings;

#if !NETCOREAPP3_1
using FolkerKinzel.Strings.Polyfills;
#endif

namespace ConsoleTester
{
    class Program
    {
        static void Main()
        {
            string test = "Test";

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

            //MemoryExtensions.Trim(test.AsMemory());
        }
    }
}
