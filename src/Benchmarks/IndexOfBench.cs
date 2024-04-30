using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class IndexOfBench
{
    private readonly StringBuilder _builder = new(new string('a', 200));

    [Benchmark]
    public int IndexOfLibrary() => _builder.IndexOf('z');

    [Benchmark]
    public int IndexOfChunks() => IndexOf(_builder, 'z');

    //[Benchmark]
    //public int IndexOfEnumerator() => IndexOfWithEnumerator(_builder, 'z');

    [Benchmark]
    public int IndexOfSpan() => IndexOfSpan(_builder, 'z');

    [Benchmark]
    public int IndexOfArray() => IndexOfPolyfill(_builder, 'z');



    private static int IndexOfPolyfill(StringBuilder sb, char c)
    {
        if (sb.Length == 0)
        {
            return -1;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(sb.Length);
        sb.CopyTo(0, shared.Value, sb.Length);
        return shared.Value.AsSpan(0, sb.Length).IndexOf(c);
    }


    //private static int IndexOfWithEnumerator(StringBuilder sb, char c)
    //{
    //    int pos = 0;
    //    StringBuilder.ChunkEnumerator enumerator = sb.GetChunks();

    //    while (enumerator.MoveNext()) 
    //    {
    //        ReadOnlySpan<char> span = enumerator.Current.Span;

    //        for (int i = 0; i < span.Length; i++)
    //        {
    //            if (span[i] == c)
    //            {
    //                return pos + i;
    //            }
    //        }

    //        pos += span.Length;
    //    }

    //    return -1;
    //}

    private static int IndexOf(StringBuilder sb, char c)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            ReadOnlySpan<char> span = chunk.Span;

            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == c)
                {
                    return pos + i;
                }
            }

            pos += span.Length;
        }

        return -1;
    }

    private static int IndexOfSpan(StringBuilder sb, char c)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            ReadOnlySpan<char> span = chunk.Span;
            int i = span.IndexOf(c);

            if(i != -1)
            {
                return pos + i;
            }

            pos += span.Length;
        }

        return -1;
    }
}
