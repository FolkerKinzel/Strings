using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class IndexOfAnyExceptBench
{
    private readonly string _s = new('a', 200);
    const string NEEDLE = "a";

    [Benchmark]
    public int SingleValue() => _s.AsSpan().IndexOfAnyExcept('a');

    [Benchmark]
    public int Span() => _s.AsSpan().IndexOfAnyExcept(NEEDLE);
}
