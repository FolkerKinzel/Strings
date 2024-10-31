using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using System;
using System.Runtime.Serialization;

namespace Experiments;

[MemoryDiagnoser]
[BaselineColumn]
public class InRangeBench
{
    private const int LENGTH = 300;
    private readonly string _str = new string('a', LENGTH) + new string('z', LENGTH);

    [Benchmark(Baseline = true)]
    public int IndexInRange() => _str.AsSpan().IndexOfAnyInRange('b', 'x');


    [Benchmark]
    public int IndexInRangeOwn() => OwnIndexOfAnyInRange(_str, 'b', 'x');


    [Benchmark()]
    public int IndexExceptInRange() => _str.AsSpan().IndexOfAnyExceptInRange('a', 'z');


    [Benchmark]
    public int IndexExceptInRangeOwn() => OwnIndexOfAnyExceptInRange(_str, 'a', 'z');


    private static int OwnIndexOfAnyExceptInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
    {
        if (span.Length == 0) { return -1; }

        if (lowInclusive > highInclusive)
        {
            return -1;
        }

        if (lowInclusive == highInclusive)
        {
            return span.IndexOfAnyExcept(lowInclusive);
        }

        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];

            if ((c < lowInclusive) || (c > highInclusive))
            {
                return i;
            }
        }

        return -1;
    }

    private static int OwnIndexOfAnyInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
    {
        if (span.Length == 0) { return -1; }

        if (lowInclusive > highInclusive)
        {
            return 0;
        }

        if (lowInclusive == highInclusive)
        {
            return span.IndexOf(lowInclusive);
        }

        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];

            if((c >= lowInclusive) && (c <= highInclusive))
            {
                return i;
            }
        }

        return -1;
    }
}
