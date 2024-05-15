using System.Text;
using System;
using BenchmarkDotNet.Attributes;
using System.Buffers;
using FolkerKinzel.Strings;
using BenchmarkDotNet.Jobs;

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
