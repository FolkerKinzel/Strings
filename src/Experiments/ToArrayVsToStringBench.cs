using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class ToArrayVsToStringBench
{
    private readonly string _s;
    public ToArrayVsToStringBench()
    {
        char[] chars = new char[10000];

        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)new Random().Next(32,128);
        }
        _s = new string(chars);
    }

    //[Benchmark]
    //public int ToArrayBench() => _s.AsSpan().ToArray().Length;

    //[Benchmark]
    //public int ToStringBench() => _s.AsSpan().ToString().Length;

    [Benchmark]
    public byte[] FromSpanBench() => Encoding.UTF8.GetBytes(_s.AsSpan());

    [Benchmark]
    public byte[] FromStringBench() => Encoding.UTF8.GetBytes(_s);

}
