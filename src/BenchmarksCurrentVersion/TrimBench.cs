using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class TrimBench
{
    private const string TRIM_CHARS = " \"\'";
    private readonly SearchValuesPolyfill<char> _trimChars = SearchValuesPolyfill.Create(TRIM_CHARS);

    [NotNull]
    private string? SFull { get; set; }

    [Params("", " ", "   \"\"\'\' \"")]
    [NotNull]
    public string? S { get; set; }

    [GlobalSetup]
    public void GlobalSetup() => SFull = S + "a" + S;


    [Benchmark]
    public int TrimEndBcl() => S.AsSpan().TrimEnd(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimEndSearchValues() => S.AsSpan().TrimEnd(_trimChars).Length;

    [Benchmark]
    public int TrimStartBcl() => S.AsSpan().TrimStart(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimStartSearchValues() => S.AsSpan().TrimStart(_trimChars).Length;


    [Benchmark]
    public int TrimBcl() => SFull.AsSpan().Trim(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimSearchValues() => SFull.AsSpan().Trim(_trimChars).Length;
}
