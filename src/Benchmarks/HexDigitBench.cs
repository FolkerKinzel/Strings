using System;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class HexDigitBench
{
    private const string TEST = "01234AaBbFfG";

    [Benchmark]
    public bool IsAsciiHexDigitTest()
    {
        ReadOnlySpan<char> span = TEST.AsSpan();
        bool result = false;
        for (int i = 0; i < span.Length; i++)
        {
            result = span[i].IsAsciiHexDigit();
        }

        return result;
    }


    [Benchmark]
    public bool IsHexDigitTest()
    {
        ReadOnlySpan<char> span = TEST.AsSpan();
        bool result = false;
        for (int i = 0; i < span.Length; i++)
        {
            result = span[i].IsHexDigit();
        }

        return result;
    }
}
