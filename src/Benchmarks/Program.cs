using System;
using BenchmarkDotNet.Running;

namespace Benchmarks;

class Program
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification = "<Ausstehend>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0022:Blocktextkörper für Methode verwenden", Justification = "<Ausstehend>")]
    static void Main(string[] args) =>
        // new InsertBench().Test1();
        //var val = new IsAsciiLetterBench();
        //new IsUtf8Bench().IsUtf8Exception();
        //_ = BenchmarkRunner.Run<IsAsciiLetterBench>();
        //_ = BenchmarkRunner.Run<ToArrayVsToStringBench>();
        //_ = BenchmarkRunner.Run<HexDigitBench>();
        //_ = BenchmarkRunner.Run<InsertBench>();
        //_ = BenchmarkRunner.Run<Base64Bench>();
        //_ = BenchmarkRunner.Run<StackAllockBench>();
        _ = BenchmarkRunner.Run<SearchValuesBench>();
        //Base64Bench.Test2();


    //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<IsUtf8Bench>();
    //var summary = BenchmarkRunner.Run<ReplaceLineEndingsBench>();//Console.Write("Total Time:");//Console.WriteLine(summary.TotalTime);
}
