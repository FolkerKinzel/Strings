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


    public Base64Bench()
    {
        this._arr = new byte[100000];
        Random.Shared.NextBytes(_arr);

        this._coll = new ReadOnlyCollection<byte>(_arr);
    }


    [Benchmark]
    public StringBuilder ExtensionMethodBench() => new StringBuilder().AppendBase64Encoded(_coll);


    [Benchmark]
    public StringBuilder FrameworkBench() => new(Convert.ToBase64String(_coll.ToArray()));


    [Benchmark]
    public StringBuilder ExtensionMethodBenchArray() => new StringBuilder().AppendBase64Encoded(_arr);


    [Benchmark]
    public StringBuilder FrameworkBenchArray() => new(Convert.ToBase64String(_arr));
}
