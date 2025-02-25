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
public class LastIndexOfBench
{
    private readonly StringBuilder _50 = new StringBuilder("a").Append(new string('a', 49));
    private readonly StringBuilder _10 = new StringBuilder("a").Append(new string('a', 9));

    [Benchmark]
    public int IndexOf50() => _50.LastIndexOf('x');

    [Benchmark]
    public int IndexOf10() => _10.LastIndexOf('x');
}
