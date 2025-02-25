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
public class ContainsNewLineBench
{
    private readonly string _content = new('a', 200);

    [Benchmark]
    public bool ContainsNewLineLibrary() => _content.AsSpan().ContainsNewLine();
}
