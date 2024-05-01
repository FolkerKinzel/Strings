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
    private readonly StringBuilder _builder = new StringBuilder(new string('a', 100)).Append(new string('a', 100));

    [Benchmark]
    public int IndexOfLibrary() => _builder.IndexOf('z');

    //[Benchmark]
    //public int IndexOfChunks() => IndexOf(_builder, 'z');

    //[Benchmark]
    //public int IndexOfEnumerator() => IndexOfWithEnumerator(_builder, 'z');

    [Benchmark]
    public int IndexOfSpan() => IndexOfSpan(_builder, 'z');

    [Benchmark]
    public int IndexOfArray() => IndexOfPolyfill(_builder, 'z');

    [Benchmark]
    public int IndexOfSpanBounds() => IndexOfSpanBounds(_builder, 'z', 0, _builder.Length);

    [Benchmark]
    public int IndexOfArrayBounds() => IndexOfPolyfillBounds(_builder, 'z', 0, _builder.Length);



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

    private static int IndexOfPolyfillBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        if (count == 0)
        {
            return -1;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        sb.CopyTo(startIndex, shared.Value, count);
        return shared.Value.AsSpan(0, count).IndexOf(c);
    }

    //private static int IndexOf(StringBuilder sb, char c)
    //{
    //    int pos = 0;

    //    foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
    //    {
    //        ReadOnlySpan<char> span = chunk.Span;

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

    private static int IndexOfSpanBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            if(startIndex >= chunk.Length + pos)
            {
                pos += chunk.Length;
                continue;
            }

            int spanStart = startIndex - pos;
            int evaluatedLength = chunk.Length - spanStart;
            ReadOnlySpan<char> span = chunk.Span;
            int idx;

            if (evaluatedLength >= count)
            {
                span = span.Slice(spanStart, count);

                idx = span.IndexOf(c);

                return idx == -1 ? -1 : pos + idx;
            }

            span = span.Slice(spanStart);

            idx = span.IndexOf(c);

            if (idx != -1)
            {
                return pos + idx;
            }
           
            pos += chunk.Length;
            count -= evaluatedLength;
            startIndex = pos;
        }

        return -1;
    }
}
