using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[BaselineColumn]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class UrlEncodingBench
{
    private readonly byte[] _arr;
    private const string TO_ESCAPE = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜµ|~#*;,=\\\"\'123456789.:?§$!ß";

    public UrlEncodingBench() => _arr = Encoding.UTF8.GetBytes(TO_ESCAPE);

    [Benchmark]
    public string EncodeArray() => UrlEncoding.Encode(_arr);

    [Benchmark(Baseline = true)]
    public string EncodeString() => UrlEncoding.Encode(TO_ESCAPE);

    [Benchmark]
    public string EncodeSpan() => UrlEncoding.Encode(TO_ESCAPE.AsSpan());

    [Benchmark]
    public string EncodeArrayStringBuilder() => new StringBuilder().AppendUrlEncoded(_arr).ToString();

    [Benchmark]
    public string EncodeStringStringBuilder() => new StringBuilder().AppendUrlEncoded(TO_ESCAPE.AsSpan()).ToString();
}
