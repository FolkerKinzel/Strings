using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class AccessBench
{
    private const string STR = "ABC";
    private const int LOOPS = 100000;

    [Benchmark]
    public bool SpanAccessBench()
    {
        ReadOnlySpan<char> span = STR.AsSpan();

        char c = 'X';
        for (int i = 0; i < LOOPS; i++)
        {
            c = span[1];
        }

        return c == span[1];

    }

    [Benchmark]
    public bool StringAccessBench()
    {
        ReadOnlySpan<char> span = STR.AsSpan();

        char c = 'X';
        for (int i = 0; i < LOOPS; i++)
        {
            c = STR[1];
        }

        return c == span[1];
    }

    [Benchmark]
    public bool TryGetBench()
    {
        bool result = false;
        char c = 'x';
        for (int i = 0; i < LOOPS; i++)
        {
            result = TryGetSth(out c);
        }
        return result && c == 'a';
    }

    [Benchmark]
    public bool GetBench()
    {
        bool result = false;
        char c = 'x';
        for (int i = 0; i < LOOPS; i++)
        {
            (char C, bool B) = GetSth();
            c = C;
            result = B;
        }
        return result && c == 'a';
    }


    private static bool TryGetSth(out char c) { c = 'a'; return true; }

    private static (char C, bool B) GetSth() { return ('a', true); }

}
