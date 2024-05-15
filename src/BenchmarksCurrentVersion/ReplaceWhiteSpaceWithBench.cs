using System;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class ReplaceWhiteSpaceWithBench
{
    const string REPLACEMENT = "\r\n";

    readonly string _s;

    private StringBuilder Builder { get; set; }

    public ReplaceWhiteSpaceWithBench()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < 80; i++)
        {
            sb.Append("a\nb  ");
        }

        Builder = sb;
        _s = sb.ToString();
    }

    [Params(1, 2, 3)]
    public int N { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        Builder = new StringBuilder(N * _s.Length);

        for (int i = 0; i < N; i++)
        {
            Builder.Append(_s);
        }
    }

    [Benchmark]
    public string ReplaceWhiteSpaceStringLibrary() => _s.ReplaceWhiteSpaceWith(REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderLibrary() => Builder.ReplaceWhiteSpaceWith(REPLACEMENT, false);
}
