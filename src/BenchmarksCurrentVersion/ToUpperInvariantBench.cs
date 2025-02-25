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
public class ToUpperInvariantBench
{
    private readonly StringBuilder _builder = new StringBuilder("a");

    [Params(15, 50, 100)]
    public int N { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _builder.Length = 1;
        _builder.Append(new string('a', N));
    }

    [Benchmark]
    public StringBuilder ToUpperInvariantLibrary() => _builder.ToUpperInvariant();


}
