using BenchmarkDotNet.Attributes;
using System;

namespace Experiments;

[MemoryDiagnoser]
[BaselineColumn]
public class InRangeBench
{
    private readonly string _str = new('a', 300);

    [Benchmark(Baseline = true)]
    public int IndexInRange() => _str.AsSpan().IndexOfAnyInRange('b', 'x');


    [Benchmark]
    public int IndexInRangeOwn() => OwnIndexOfAnyInRange(_str, 'b', 'x');
    

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

            if(c >= lowInclusive && c <= highInclusive)
            {
                return i;
            }
        }

        return -1;
    }
}
