using System;
using FolkerKinzel.Strings;

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



        }
    }
}
