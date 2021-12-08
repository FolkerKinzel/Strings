using System;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification = "<Ausstehend>")]
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ReplaceLineEndingsBench>();
            Console.Write("Total Time:");
            Console.WriteLine(summary.TotalTime);
        }
    }
}
