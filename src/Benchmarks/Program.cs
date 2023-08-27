using System;
using BenchmarkDotNet.Running;

namespace Benchmarks;

class Program
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification = "<Ausstehend>")]
    static void Main(string[] args) =>
        //var val = new IsAsciiLetterBench();
        //new IsUtf8Bench().IsUtf8Exception();
        //_ = BenchmarkRunner.Run<IsAsciiLetterBench>();
        //_ = BenchmarkRunner.Run<ToArrayVsToStringBench>();
    _ = BenchmarkRunner.Run<Base64Bench>();

    //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<IsUtf8Bench>();
    //var summary = BenchmarkRunner.Run<ReplaceLineEndingsBench>();//Console.Write("Total Time:");//Console.WriteLine(summary.TotalTime);
}
