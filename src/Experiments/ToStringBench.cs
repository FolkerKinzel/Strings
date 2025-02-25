using BenchmarkDotNet.Attributes;

namespace Experiments;


public class ToStringBench
{
    private readonly char[] _short = ['a'];

    private readonly char[] _long = "sdfghjpoiure123456789kjhgfdswertzu09876543yxcvbnmkjhgfdiuztr99876543".ToCharArray();

    [Benchmark]
    public string CtorShort() => new(_short, 0, _short.Length);

    [Benchmark]
    public string CtorLong() => new(_long, 0, _long.Length);

    [Benchmark]
    public string ToStringShort() => _short.AsSpan(0, _short.Length).ToString();

    [Benchmark]
    public string ToStringLong() => _long.AsSpan(0, _long.Length).ToString();

}
