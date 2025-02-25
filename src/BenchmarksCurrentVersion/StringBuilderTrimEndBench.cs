using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class StringBuilderTrimEndBench
{
    const string S0 = "a";
    const string S1 = "a ";
    const string S2 = "a  ";
    const string S10 = "a          ";

    [Benchmark]
    public StringBuilder SbEmptyLibrary() => new StringBuilder().TrimEnd(' ');

    [Benchmark(Baseline = true)]
    public StringBuilder Sb0Library() => new StringBuilder(S0).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb1Library() => new StringBuilder(S1).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb2Library() => new StringBuilder(S2).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb10Library() => new StringBuilder(S10).TrimEnd(' ');

}
