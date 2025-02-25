using System;
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
public class PersistentHashCodeBench
{
    private readonly string _s = new('a', 200);
    private readonly StringBuilder _builder;

    public PersistentHashCodeBench() => _builder = new StringBuilder(_s);

    [Benchmark]
    public int SpanHashLibrary() => _s.AsSpan().GetPersistentHashCode(HashType.Ordinal);

    [Benchmark]
    public int SpanHashStruct()
    {
        var hash = new PersistentStringHash(HashType.Ordinal);
        hash.Add(_s.AsSpan());
        return hash.ToHashCode();
    }

    [Benchmark]
    public int StringBuilderHashLibrary() => _builder.GetPersistentHashCode(HashType.Ordinal);

    [Benchmark]
    public int StringBuilderHashStruct()
    {
        var hash = new PersistentStringHash(HashType.Ordinal);
        hash.Add(_builder);
        return hash.ToHashCode();
    }
}
