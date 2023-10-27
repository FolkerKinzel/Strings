using System.Text;
using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class InsertBench
{
    private const string CONTENT = "123456789abcdefghijklmnopqrstuvwxyz";
    private const int INDEX = 1;
    private StringBuilder builder = new StringBuilder(CONTENT);
    private const string TO_INSERT = "abcdefghijklmnopqrstuvwxyz";

    [IterationSetup]
    public void SetupData()
    {
        builder = new StringBuilder(CONTENT);
    }


    [Benchmark]
    public StringBuilder Test1() => Insert1(TO_INSERT.AsSpan());

    [Benchmark]
    public StringBuilder Test2() => Insert2(TO_INSERT.AsSpan());

    private StringBuilder Insert1(ReadOnlySpan<char> value)
    {
        //_ = builder.EnsureCapacity(builder.Length + value.Length);

        for (int i = value.Length - 1; i >= 0; i--)
        {
            _ = builder.Insert(INDEX, value[i]);
        }

        return builder;
    }

    private StringBuilder Insert2(ReadOnlySpan<char> value)
    {
        return builder.Insert(INDEX, value.ToString());
    }
}
