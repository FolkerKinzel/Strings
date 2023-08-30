using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class Base64Bench
{
    private readonly ReadOnlyCollection<byte> _coll;
    private readonly byte[] _arr;
    private readonly string _base64;


    public Base64Bench()
    {
        this._arr = new byte[100000];
        Random.Shared.NextBytes(_arr);

        this._coll = new ReadOnlyCollection<byte>(_arr);
        this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
    }

    [Benchmark]
    public byte[] ToBytesBench() => Base64Decoder.GetBytes(_base64);

    [Benchmark]
    public byte[] FrameworkDecoder() => Convert.FromBase64String(_base64.AsSpan().ToString());

    //[Benchmark]
    //public StringBuilder ExtensionMethodBench() => new StringBuilder().AppendBase64Encoded(_coll);


    //[Benchmark]
    //public StringBuilder FrameworkBench() => new(Convert.ToBase64String(_coll.ToArray()));


    //[Benchmark]
    //public StringBuilder ExtensionMethodBenchArray() => new StringBuilder().AppendBase64(_arr.AsSpan());


    //[Benchmark]
    //public StringBuilder FrameworkBenchArray() => new(Convert.ToBase64String(_arr));
}
