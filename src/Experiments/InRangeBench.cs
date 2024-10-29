using BenchmarkDotNet.Attributes;
using System;

namespace Experiments;

[MemoryDiagnoser]
public class InRangeBench
{

    [Benchmark]
    public int IndexInRange() => "abc".AsSpan().IndexOfAnyInRange('C', 'A');


    [Benchmark]
    public int IndexInRangeOwn() => OwnIndexOfAnyInRange("abcd", 'c', 'b');
    

    private int OwnIndexOfAnyInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
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

            if(c >= lowInclusive && c <= highInclusive)
            {
                return i;
            }
        }

        return -1;
    }
}
