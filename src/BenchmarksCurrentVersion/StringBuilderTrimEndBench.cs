using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

public class StringBuilderTrimEndBench
{
    const string S0 = "a";
    const string S1 = "a ";
    const string S2 = "a  ";
    const string S10 = "a          ";

    [Benchmark]
    public StringBuilder SbEmptyLibrary() => new StringBuilder().TrimEnd(' ');

    [Benchmark(Baseline = true)]
    public StringBuilder Sb0Library() => new StringBuilder(S0).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb1Library() => new StringBuilder(S1).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb2Library() => new StringBuilder(S2).TrimEnd(' ');

    [Benchmark]
    public StringBuilder Sb10Library() => new StringBuilder(S2).TrimEnd(' ');

    //[Benchmark]
    //public StringBuilder SbEmptyChunks() => TrimEndIntl(new StringBuilder(), ' ');

    //[Benchmark]
    //public StringBuilder Sb0Chunks() => TrimEndIntl(new StringBuilder(S0), ' ');

    //[Benchmark]
    //public StringBuilder Sb1Chunks() => TrimEndIntl(new StringBuilder(S1), ' ');

    //[Benchmark]
    //public StringBuilder Sb2Chunks() => TrimEndIntl(new StringBuilder(S2), ' ');

    //[Benchmark]
    //public StringBuilder Sb10Chunks() => TrimEndIntl(new StringBuilder(S2), ' ');



    //private static StringBuilder TrimEndIntl(StringBuilder builder, char trimChar)
    //{
    //    int pos = builder.Length - 1;

    //    while (ChunkProvider.TryGetChunk(builder, pos, out int chunkStart, out ReadOnlySpan<char> span))
    //    {
    //        int idx = span.LastIndexOfAnyExcept(trimChar);

    //        if (idx != -1)
    //        {
    //            builder.Length = chunkStart + idx + 1;
    //            return builder;
    //        }

    //        pos = chunkStart - 1;
    //    }

    //    return builder.Clear();
    //}

}
