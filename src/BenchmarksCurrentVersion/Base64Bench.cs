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
public class Base64Bench
{
    private readonly byte[] _arr = new byte[50000];
    private readonly string _base64;

    public Base64Bench()
    {
        new Random().NextBytes(_arr);
        this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
    }

    [Benchmark]
    public byte[] GetBytesBenchBcl() => Base64.GetBytes(_base64);

    [Benchmark]
    public byte[] GetBytesBenchLibrary() => Base64.GetBytes(_base64, Base64ParserOptions.None);

    [Benchmark]
    public StringBuilder AppendLibrary() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.None);

    [Benchmark]
    public StringBuilder AppendLibraryLineBreaks() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.InsertLineBreaks);
}
